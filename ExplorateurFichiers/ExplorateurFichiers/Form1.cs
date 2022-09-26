using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExplorateurFichiers
{
    public partial class FileBrowser : Form
    {
        List<string> listFiles = new List<string>();
        public FileBrowser()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            //Nous nettoyons la liste
            listFiles.Clear();

            //Nous nettoyons la listView
            listView.Items.Clear();

            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Selectionnez votre fichier." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    textBoxPath.Text = fbd.SelectedPath;
                    foreach(string item in Directory.GetFiles(fbd.SelectedPath))
                    {
                        imageList.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(item));
                        FileInfo fi = new FileInfo(item);
                        listFiles.Add(fi.FullName);
                        listView.Items.Add(fi.Name, imageList.Images.Count - 1);
                    }
                }
            }
        }
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.FocusedItem != null)
            {
                Process.Start(listFiles[listView.FocusedItem.Index]);
            }
        }
    }
}
