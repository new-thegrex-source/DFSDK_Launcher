using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace DFSDK_Launcher
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            // Получение версии из файла dfsdkver.txt
            string localVersion = File.ReadAllText("DishonoredEditor/dfsdkver.txt");

            // Получение версии с удаленного сервера
            WebClient client = new WebClient();
            string remoteVersion = client.DownloadString("http://grexofficial.ru/dfsdkver.txt");

            // Сравнение версий и загрузка обновления, если нужно
            if (localVersion == remoteVersion)
            {
                MessageBox.Show("DFSDK Up-to date!");
            }
            else
            {
                // Удаление старого архива, если он есть
                if (File.Exists("update.zip"))
                {
                    File.Delete("update.zip");
                }

                // Загрузка архива с сервера
                client.DownloadProgressChanged += Client_DownloadProgressChanged;
                client.DownloadFileCompleted += Client_DownloadFileCompleted;
                client.DownloadFileAsync(new Uri("http://grexofficial.ru/update.zip"), "update.zip");
            }
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Обновление значения прогресс бара
            progressBar1.Value = e.ProgressPercentage;
            label2.Text = "Downloading";
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

            
            using (var archive = ZipFile.OpenRead("update.zip"))
            {
                int count = archive.Entries.Count;
                int i = 0;
                // Проходим по всем файлам в архиве
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith("/"))
                    {
                        // Если это папка, пропускаем
                        continue;
                    }

                    // Получаем путь к файлу в директории "DishonoredEditor"
                    string filePath = Path.Combine("./", entry.FullName);

                    // Обновляем прогресс бар
                    i++;
                    int progressPercentage = (int)((float)i / count * 100);
                    progressBar1.Value = progressPercentage;
                    label2.Text = "Extracting";
                    // Удаляем файл, если он уже существует
                   /* if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }*/

                    // Распаковываем файл из архива
                    entry.ExtractToFile(filePath);
                }
            }

            if (Directory.Exists ("./DishonoredEditor/Development")) {
                Directory.Delete("./DishonoredEditor/Development");
            }
            if (Directory.Exists("./DishonoredEditor/UDKGame/Script"))
            {
                Directory.Delete("./DishonoredEditor/UDKGame/Script");
            }

            // Распаковка архива
            ZipFile.ExtractToDirectory("update.zip", "./");

            // Обновление текста и закрытие диалога прогресса
            progressBar1.Value = 0;
            label1.Text = "Current Version: " + File.ReadAllText("DishonoredEditor/dfsdkver.txt");
            label2.Text = "Update complete!";
            MessageBox.Show("Update complete!");
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }


}
