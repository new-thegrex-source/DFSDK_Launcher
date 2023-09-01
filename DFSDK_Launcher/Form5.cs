using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace DFSDK_Launcher
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            LoadResolutions();
            LoadSettings();
        }

        private readonly string keyPath = @"SOFTWARE\Arkane\Dishonored";
        private readonly string resXKey = "ResX";
        private readonly string resYKey = "ResY";
        private readonly string fullscreenKey = "Fullscreen";
        private readonly string vsyncKey = "Vsync";

        private bool hasChanges = false;

        private void LoadResolutions()
        {
            // Load default resolution from registry
            RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath);
            int resX = (int)key.GetValue(resXKey);
            int resY = (int)key.GetValue(resYKey);
            string defaultResolution = $"{resX}x{resY}";
            comboBox1.Items.Add(defaultResolution);

            // Load available resolutions
            Screen screen = Screen.PrimaryScreen;
            foreach (var resolution in screen.Bounds.Size.Height >= 1080 ? new[] { "1920x1080", "1280x720" } : new[] { "1280x720" })
            {
                comboBox1.Items.Add(resolution);
            }

            // Add custom resolution option
            comboBox1.Items.Add("Custom Resolution");
            comboBox1.SelectedItem = defaultResolution;
        }

        private void LoadSettings()
        {
            // Load fullscreen setting from registry
            RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath);
            // Load fullscreen setting from registry
            if (key != null)
            {
                object value = key.GetValue(fullscreenKey);
                if (value != null && int.TryParse(value.ToString(), out int fullscreen))
                {
                    checkBox1.Checked = fullscreen == 1;
                }
            }

            // Load vsync setting from registry
            if (key != null)
            {
                object value = key.GetValue(vsyncKey);
                if (value != null && int.TryParse(value.ToString(), out int vsync))
                {
                    checkBox2.Checked = vsync == 1;
                }
            }

            // Load AllowD3D10 setting from file
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "./My Games/Dishonored/DishonoredGame/Config/DishonoredEngine.ini");
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (line.StartsWith("AllowD3D10="))
                    {
                        string[] parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            string value = parts[1].Trim();
                            checkBox3.Checked = value.Equals("True", StringComparison.OrdinalIgnoreCase);
                        }
                        break;
                    }
                }
            }

            // Load LocalMap setting from file
            string DisConfigFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "./My Games/Dishonored/DishonoredGame/Config/DishonoredEngine.ini");
            string localMapValue = "";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(DisConfigFile);
                foreach (string line in lines)
                {
                    if (line.StartsWith("LocalMap="))
                    {
                        string[] parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            localMapValue = parts[1].Trim();
                            break;
                        }
                    }
                }
            }

            // Add LocalMap and DishonoredGameFull_P to ComboBox13
            string[] mapParts = localMapValue.Split('.');
            if (mapParts.Length >= 2 && mapParts[0] != "DishonoredGameFull_P")
            {
                comboBox13.Items.Add(mapParts[0]);
            }
            comboBox13.Items.Add("DishonoredGameFull_P");

            // Add other maps from the Maps folder to ComboBox13
            string mapsPath = "./DishonoredGame/CookedPCConsole/Maps";
            if (Directory.Exists(mapsPath))
            {
                string[] mapFiles = Directory.GetFiles(mapsPath, "*.upk");
                foreach (string mapFile in mapFiles)
                {
                    string mapName = Path.GetFileNameWithoutExtension(mapFile);
                    if (mapName != mapParts[0] && mapName != "DishonoredGameFull_P")
                    {
                        comboBox13.Items.Add(mapName);
                        comboBox2.Items.Add(mapName);

                    }
                }
            }

        }

        private void SaveSettings()
        {
            // Save fullscreen setting to registry
            RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath);
            key.SetValue(fullscreenKey, checkBox1.Checked ? 1 : 0);

            // Save vsync setting to registry
            key.SetValue(vsyncKey, checkBox2.Checked ? 1 : 0);

            // Save custom resolution to registry
            if (comboBox1.SelectedItem.ToString() == "Custom Resolution")
            {
                int resX, resY;
                if (!int.TryParse(textBox1.Text, out resX) || !int.TryParse(textBox2.Text, out resY))
                {
                    MessageBox.Show("Invalid custom resolution values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                key.SetValue(resXKey, resX);
                key.SetValue(resYKey, resY);
            }

            // Save AllowD3D10 setting to file
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Games", "Dishonored", "DishonoredGame", "Config", "DishonoredEngine.ini");
            if (File.Exists(filePath))
            {
                bool allowD3D10 = checkBox3.Checked;
                string[] fileLines = File.ReadAllLines(filePath);
                for (int i = 0; i < fileLines.Length; i++)
                {
                    if (fileLines[i].StartsWith("AllowD3D10="))
                    {
                        fileLines[i] = "AllowD3D10=" + allowD3D10.ToString();
                        break;
                    }
                }
                File.WriteAllLines(filePath, fileLines);
            }
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith("LocalMap="))
                    {
                        string[] parts = lines[i].Split('=');
                        if (parts.Length == 2)
                        {
                            string oldValue = parts[1].Trim();
                            string newValue = comboBox13.SelectedItem.ToString() + ".umap";
                            lines[i] = parts[0] + "=" + newValue;
                            File.WriteAllLines(filePath, lines);
                            break;
                        }
                    }
                }
            }

            hasChanges = false;
            MessageBox.Show("Settings saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Custom Resolution")
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }

            hasChanges = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (hasChanges)
            {
                DialogResult result = MessageBox.Show("Save changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SaveSettings();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No changes to save", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsoleEnabler();
        }

        private void ConsoleEnabler()
        {
            string Doc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(Doc + "/My Games/Dishonored"))
            {
                MessageBox.Show("Game not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Dishonored\DishonoredGame\Config\DishonoredInput.ini";
                // Проверяем, существует ли файл
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Error: can not found DishonoredInput.ini file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Снимаем атрибут только для чтения, если он установлен
                FileAttributes attributes = File.GetAttributes(filePath);
                if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    File.SetAttributes(filePath, attributes & ~FileAttributes.ReadOnly);
                }

                // Ищем нужную строку и добавляем новую строку после неё
                string searchLine = "m_PCBindings=(Name=\"Zero\",Command=\"GBA_Shortcut_9\")";
                string newLine = "m_PCBindings=(Name=\"F1\",Command=\"set Console ConsoleKey F1 | set PlayerController CheatClass class'DishonoredCheatManager' | EnableCheats\")";
                string[] lines = File.ReadAllLines(filePath);

                // Проверяем, есть ли уже нужная строка в файле
                bool alreadyActivated = false;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(newLine))
                    {
                        alreadyActivated = true;
                        break;
                    }
                }

                if (alreadyActivated)
                {
                    MessageBox.Show("Console is already enabled!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ищем нужную строку и добавляем новую строку после неё
                bool found = false;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(searchLine))
                    {
                        lines[i] += Environment.NewLine + newLine;
                        found = true;
                        break;
                    }
                }

                // Если строка не найдена, выводим ошибку и выходим из программы
                if (!found)
                {
                    MessageBox.Show("Corrupted DishonoredInput.ini", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Записываем изменения в файл
                File.WriteAllLines(filePath, lines);

                // Устанавливаем атрибут только для чтения
                File.SetAttributes(filePath, File.GetAttributes(filePath) | FileAttributes.ReadOnly);

                MessageBox.Show("Console is activated now!", "Success!", MessageBoxButtons.OK);

            }

        }

    }
}
