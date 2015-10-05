using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MatchPattnerSQL
{
    public partial class Form1 : Form
    {

        public delegate void UpdateBar();
        public delegate void UpdateLog(string log);
        public UpdateBar delegateUpdateBar;
        public UpdateLog delegateUpdateLog;
        private Thread myThread;

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
           
            //Product deserializedProduct = JsonConvert.DeserializeObject<Product>(json);
            MyThreadClass myThr = new MyThreadClass(this);
            List<FileInfo> lstFiles = null;
            try
            {
                if (myThread != null && myThread.IsAlive)
                    return;

                //btnGo.Enabled = false;
                txtLog.Text = "";

                lstFiles = getFiles();

                if (lstFiles == null || lstFiles.Count() == 0)
                    return;
                                                
                delegateUpdateBar = new UpdateBar(methodUpdateBar);
                delegateUpdateLog = new UpdateLog(methodUpdatetxtLog);

                pBar1.Minimum = 0;
                pBar1.Maximum = lstFiles.Count();
                pBar1.Value = 1;
                pBar1.Step = 1;

                myThread = new Thread(() => myThr.myThread(lstFiles));
                myThread.Start();
 
            }
            catch 
            {
                throw;
            }
            finally
            {
                //btnGo.Enabled = true;
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

        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo diretorio = new DirectoryInfo(txtFolder.Text + @"\");
            FileInfo[] Arquivos = diretorio.GetFiles(textBox1.Text);
            txtLog.Text = "";
            foreach (FileInfo fileinfo in Arquivos)
            {
                txtLog.Text += fileinfo.Name + Environment.NewLine;
            }
        }



        private void methodUpdateBar()
        {
            try
            { 
                pBar1.PerformStep();
            }
            catch
            {
                throw;
            }
        }

        private void methodUpdatetxtLog(string log)
        {
            try
            {
                txtLog.Text = DateTime.Now.ToString() + @" - " + log + Environment.NewLine + txtLog.Text; 
            }
            catch
            {
                throw;
            }
        }
        
    }

    public class MyThreadClass
    {
        Form1 myForm1 = null;

        public MyThreadClass(Form1 Form1)
        {
            this.myForm1 = Form1;
        }

        public void myThread(List<FileInfo> outlstFiles)
        {
            List<FileInfo> lstFiles = outlstFiles;

            try
            {

                foreach (FileInfo fileinfo in lstFiles)
                {
                    //textBox2.Text += DateTime.Now.ToString() + @" - " + fileinfo.Name + Environment.NewLine;
                    // pBar1.PerformStep();
                    myForm1.Invoke(myForm1.delegateUpdateLog, new Object[] {fileinfo.Name});
                    myForm1.Invoke(myForm1.delegateUpdateBar);

                    System.Threading.Thread.Sleep(100);
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(@"RulesSQL.xml");
                XmlNodeList xnList = xmlDoc.GetElementsByTagName("RulesSQL");

                List<RulesSQL> lstRules = new List<RulesSQL>();
                foreach (XmlNode xn in xnList)
                {
                    lstRules.Add(new RulesSQL() { ID = xn["ID"].InnerText, Description = xn["Description"].InnerText, Pattern = xn["Pattern"].InnerText });
                }
            }
            catch
            {
                throw;
            }
        }

    }

}
