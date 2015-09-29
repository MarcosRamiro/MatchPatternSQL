using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchPattnerSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void selFolder_Click(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            folder.Description = "Selecione a pasta...";
            folder.RootFolder = Environment.SpecialFolder.MyComputer;
            folder.ShowNewFolderButton = true;

            if (folder.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = folder.SelectedPath;
            }

        }

        private void txtFolder_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                btnGo.Enabled = false;
                pBar1.Minimum = 1;
                pBar1.Maximum = 100;
                pBar1.Value = 1;
                pBar1.Step = 1;

                for (int x = 1; x <= 100; x++)
                    pBar1.PerformStep();
                                
            }
            catch { }
            finally 
            {
                btnGo.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo diretorio = new DirectoryInfo(txtFolder.Text+@"\");
            FileInfo[] Arquivos = diretorio.GetFiles(textBox1.Text);
            textBox2.Text = "";
            foreach (FileInfo fileinfo in Arquivos)
            {
                textBox2.Text += fileinfo.Name + Environment.NewLine;
            }
        }
    }
}
