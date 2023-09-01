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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public string InputText1//назовите как нравится
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string InputText2//назовите как нравится
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public string InputText3//назовите как нравится
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dlc05Path = @"DishonoredGame/DLC/PCConsole/DLC05/DishonoredUI.ini";
            string dlc06Path = @"DishonoredGame/DLC/PCConsole/DLC06/DishonoredUI.ini";
            string dlc07Path = @"DishonoredGame/DLC/PCConsole/DLC07/DishonoredUI.ini";

            if (textBox1.Enabled)
            {
                SaveDLCCommand(dlc05Path, textBox1.Text);
            }

            if (textBox2.Enabled)
            {
                SaveDLCCommand(dlc06Path, textBox2.Text);
            }

            if (textBox3.Enabled)
            {
                SaveDLCCommand(dlc07Path, textBox3.Text);
            }

            this.Close();
        }

        private void SaveDLCCommand(string path, string command)
        {
            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("m_Command"))
                {
                    int startIndex = lines[i].IndexOf('"') + 1;
                    int endIndex = lines[i].LastIndexOf('"');
                    lines[i] = lines[i].Substring(0, startIndex) + command + lines[i].Substring(endIndex);
                    break;
                }
            }

            File.WriteAllLines(path, lines);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
