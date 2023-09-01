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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mapsPath = @"DishonoredEditor/UDKGame/Content/Maps/ForCook";
            string mapsExtension = ".udk";
            string cookedMapsPath = "";
            string cookedMapsExtension = ".upk";
            string message = "";
            string title = "";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            if (MainGameRadioButton.Checked)
            {
                cookedMapsPath = @"DishonoredGame/CookedPCConsole/Maps";
            }
            else if (DLC1RadioButton.Checked)
            {
                cookedMapsPath = @"DishonoredGame/DLC/PCConsole/DLC05/Maps";
            }
            else if (DLC2RadioButton.Checked)
            {
                cookedMapsPath = @"DishonoredGame/DLC/PCConsole/DLC06/Maps";
            }
            else if (DLC3RadioButton.Checked)
            {
                cookedMapsPath = @"DishonoredGame/DLC/PCConsole/DLC07/Maps";
            }

            if (!Directory.Exists(mapsPath))
            {
                message = "No files found";
                title = "Error";
                buttons = MessageBoxButtons.OK;
                icon = MessageBoxIcon.Error;
                MessageBox.Show(message, title, buttons, icon);
                return;
            }

            if (!Directory.Exists(cookedMapsPath))
            {
                message = "The selected DLC is not installed";
                title = "Error";
                buttons = MessageBoxButtons.OK;
                icon = MessageBoxIcon.Error;
                MessageBox.Show(message, title, buttons, icon);
                return;
            }

            string[] maps = Directory.GetFiles(mapsPath, "*" + mapsExtension);
            if (maps.Length == 0)
            {
                message = "No files found";
                title = "Error";
                buttons = MessageBoxButtons.OK;
                icon = MessageBoxIcon.Error;
                MessageBox.Show(message, title, buttons, icon);
                return;
            }

            foreach (string map in maps)
            {
                string mapName = Path.GetFileNameWithoutExtension(map);
                string cookedMapPath = Path.Combine(cookedMapsPath, mapName + cookedMapsExtension);
                File.Copy(map, cookedMapPath, true);
            }

            message = "Maps successfully copied!";
            title = "Success";
            buttons = MessageBoxButtons.OK;
            icon = MessageBoxIcon.Information;
            MessageBox.Show(message, title, buttons, icon);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
