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

namespace DFSDK_Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string cdir = Directory.GetCurrentDirectory();

        private void button1_Click(object sender, EventArgs e)
        {
            string editorPath = cdir + "./DishonoredEditor/Binaries/win64/UDK.exe";
            string arguments = "Editor";
            try
            {
                System.Diagnostics.Process.Start(editorPath, arguments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string DisGamePath = cdir + "./DishonoredGame/CookedPCConsole";
            string DisConfigPath = cdir + "./DishonoredGame/CookedPCConsole";

            bool gameExists = Directory.Exists(DisGamePath);
            bool configExists = Directory.Exists(DisConfigPath);

            if (!gameExists & !configExists)
            {
                MessageBox.Show("Make sure your DFSDK installed in root of Dishonored folder. Otherwise, you can manually prepare maps from DFSDK to game. See Readme.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Form2 frm2 = new Form2();

            frm2.Show(); // Launch Form2,the new form.
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string scriptsPath = cdir + "./DishonoredEditor/UDKGame/Script";
            string makePath = cdir + "./DishonoredEditor/Binaries/win64/UDK.exe";
            string arguments = "make";
            try
            {
                Directory.Delete(scriptsPath, true);
                System.Diagnostics.Process.Start(makePath, arguments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string consoleEnablerPath = cdir + "./DFSDK_Tools/DFSDK_ConsoleEnabler.exe";
            try
            {
                System.Diagnostics.Process.Start(consoleEnablerPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string dlc05Path = cdir + "./DishonoredGame/DLC/PCConsole/DLC05/DishonoredUI.ini";
            string dlc06Path = cdir + "./DishonoredGame/DLC/PCConsole/DLC06/DishonoredUI.ini";
            string dlc07Path = cdir + "./DishonoredGame/DLC/PCConsole/DLC07/DishonoredUI.ini";

            bool dlc05Exists = File.Exists(dlc05Path);
            bool dlc06Exists = File.Exists(dlc06Path);
            bool dlc07Exists = File.Exists(dlc07Path);

            if (!dlc05Exists && !dlc06Exists && !dlc07Exists)
            {
                MessageBox.Show("No DLC folders found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form3 form3 = new Form3();

            if (dlc05Exists)
            {
                string dlc05Command = GetDLCCommand(dlc05Path);
                form3.textBox1.Text = dlc05Command;
            }
            else
            {
                form3.textBox1.Enabled = false;
                form3.textBox1.BackColor = System.Drawing.SystemColors.Control;
            }

            if (dlc06Exists)
            {
                string dlc06Command = GetDLCCommand(dlc06Path);
                form3.textBox2.Text = dlc06Command;
            }
            else
            {
                form3.textBox2.Enabled = false;
                form3.textBox2.BackColor = System.Drawing.SystemColors.Control;
            }

            if (dlc07Exists)
            {
                string dlc07Command = GetDLCCommand(dlc07Path);
                form3.textBox3.Text = dlc07Command;
            }
            else
            {
                form3.textBox3.Enabled = false;
                form3.textBox3.BackColor = System.Drawing.SystemColors.Control;
            }

            form3.ShowDialog();
        }

        private string GetDLCCommand(string path)
        {
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                if (line.Contains("m_Command"))
                {
                    int startIndex = line.IndexOf('"') + 1;
                    int endIndex = line.LastIndexOf('"');
                    return line.Substring(startIndex, endIndex - startIndex);
                }
            }

            return "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /* old method string updateToolPath = cdir + "./DFSDK_Tools/DFSDK_UpdateTool.bat";
            try
            {
                System.Diagnostics.Process.Start(updateToolPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string gamePath = cdir + "./Binaries/win32/Dishonored.exe";
            try
            {
                System.Diagnostics.Process.Start(gamePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }
    }
}
