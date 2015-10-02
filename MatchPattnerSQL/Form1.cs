using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

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
            List<FileInfo> lstFiles = null;
            //Product deserializedProduct = JsonConvert.DeserializeObject<Product>(json);

            try
            {
                btnGo.Enabled = false;
                textBox2.Text = "";
                lstFiles = getFiles();

                if (lstFiles == null || lstFiles.Count()==0)
                    return;

                pBar1.Minimum = 0;
                pBar1.Maximum =  lstFiles.Count();
                pBar1.Value = 1;
                pBar1.Step = 1;
                
                //for (int x = 1; x <= 100; x++)

                foreach (FileInfo fileinfo in lstFiles)
                {
                    textBox2.Text += DateTime.Now.ToString() + @" - " + fileinfo.Name + Environment.NewLine;
                    pBar1.PerformStep();
                    //System.Threading.Thread.Sleep(1000);
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(@"RulesSQL.xml"); 
                XmlNodeList xnList = xmlDoc.GetElementsByTagName("RulesSQL");

                List<RulesSQL> lstRules = new List<RulesSQL>();
                foreach (XmlNode xn in xnList)
                {
                    lstRules.Add(new RulesSQL() { ID = xn["ID"].InnerText, Description = xn["Description"].InnerText, Pattern = xn["Pattern"].InnerText });
                }

               // foreach(RulesSQL r in instance)
                 //  textBox2.Text += "olaa";

            }
            catch 
            {

            }
            finally
            {
                btnGo.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo diretorio = new DirectoryInfo(txtFolder.Text + @"\");
            FileInfo[] Arquivos = diretorio.GetFiles(textBox1.Text);
            textBox2.Text = "";
            foreach (FileInfo fileinfo in Arquivos)
            {
                textBox2.Text += fileinfo.Name + Environment.NewLine;
            }
        }

        private List<FileInfo> getFiles()
        {
            List<FileInfo> lstFiles = null;
            try
            {
                DirectoryInfo path = new DirectoryInfo(txtFolder.Text);
                FileInfo[] Files = path.GetFiles(textBox1.Text);
                //               textBox2.Text = "";
                if (Files != null && Files.Count() > 0)
                    lstFiles = Files.ToList();
            }
            catch
            {
                throw;
            }
            return lstFiles;
        }

        
    }
}
