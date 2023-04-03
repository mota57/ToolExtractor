using DocumentFormat.OpenXml.Drawing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolExtractor.Lib.MCAGOV;
using ToolExtractor.Lib.Utils;

namespace ToolExtractor.WinFormMCAGov
{

    public partial class FormMCAGov : Form
    {

    
        public FormMCAGov()
        {
            InitializeComponent();
            this.textBoxDownloadFolder.Enabled = false;
            //var jsonData = File.ReadAllText(System.IO.Path.Combine(Environment.CurrentDirectory, "ProfileData1", "profile_data.json"));
            //userProfileData = JsonConvert.DeserializeObject<UserProfileData>(jsonData) ?? new UserProfileData();
            //this.textBoxChromeProfile.Text = userProfileData.chromeProfileDir ?? "";
            this.comboBoxRequestType.SelectedIndex = 0;
            //this.comboBoxMaxYear.SelectedIndex = 17;
            this.cookie1.Text = "cookiesession1=";
            this.cookie2.Text = "JSESSIONID=";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBarTab1_Click(object sender, EventArgs e)
        {

        }


        private async void btnSelectFolderTab1_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBoxDownloadFolder.Text = this.folderBrowserDialog1.SelectedPath;

            }
            else
            {
                MessageBox.Show("Please select the directory where the files will be extracted.");
            }
        }

        string ValidateTab1(string targetDirectory, List<string> cinList)
        {

            //if (string.IsNullOrEmpty(this.textBoxChromeProfile.Text) || !Directory.Exists(this.textBoxChromeProfile.Text))
            //{
            //    return "No Valid Chrome Directory";
            //}

            if (string.IsNullOrEmpty(cookie1.Text) || string.IsNullOrEmpty(cookie2.Text))
            {
                return "MUST COMPLETE ALL COOKIES FROM CHROME.";
            }

            if (cookie1.Text.Split("=")[1] == "")
            {
                return $"Invalid values for cookies. cookiesession1";
            }
            if (cookie1.Text.Split("=")[1] == "")
            {
                return $"Invalid values for cookies. JSESSIONID";
            }
          
            if (string.IsNullOrEmpty(targetDirectory) || !Directory.Exists(targetDirectory))
            {
                return "No Valid Download Directory";
            }

            if (cinList.Count == 0)
            {
                return "Cin is required";
            }

            if (this.comboBoxRequestType.SelectedItem  == null)
            {
                return "Must select CIN OR [CIN & COMPANY]";
            }
            return null;
        }



        private async void buttonExtractTab1_Click(object sender, EventArgs e)
        {
            var downloadDirectory = this.textBoxDownloadFolder.Text;
            //var chromeProfile = this.textBoxChromeProfile.Text;
            var dataTextList = this.textBoxCinTab1.Text.Split("\n").Select(t => t.Trim()).Where(t => t.Length > 0).ToList();

            this.buttonExtractTab1.Enabled = false;

            var errMss = ValidateTab1(downloadDirectory, dataTextList);

            if (errMss != null)
            {
                MessageBox.Show(errMss);
                this.buttonExtractTab1.Enabled = true;

                return;
            }

            progressBarTab1.Minimum = 0;
            progressBarTab1.Maximum = dataTextList.Count();

            var progress = new Progress<int>(v =>
            {
                progressBarTab1.Value = v; // This lambda is executed in context of UI thread, so it can safely update form controls
            });


            this.labelStatusTab1.Text = "Working..";


            var method = this.comboBoxRequestType.SelectedItem.ToString();
            var cookies = new List<string> { cookie1.Text, cookie2.Text };

            var totalRecords = await Task.Run(async () =>
            {
                try
                {
                    if (method == "CIN")
                    {
                        var dataList = dataTextList.ConvertAll(cin =>   new RequestByCIN(cin) ).ToList();

                        return await McaGovRequest.RequestByCinMethod(dataList, downloadDirectory, cookies, progress);
                    }
                    
                    if (method == "CIN & COMPANY_NAME")
                    {
                        var dataList = new List<RequestPublicDocument>();
                        for (int lineNumber = 0; lineNumber < dataTextList.Count; lineNumber++) 
                        {
                            string? txt = dataTextList[lineNumber];
                            var cin = txt.Substring(0, txt.IndexOf('\t')).Trim();
                            var company = txt.Substring(txt.IndexOf('\t')).Trim();
                            if (company ==  null)
                            {
                                throw new Exception($"Company is not fill, are you sure you introduce CIN AND COMPANY NAME? (for line number {lineNumber+1}");
                            }
                            dataList.Add(new RequestPublicDocument(company, cin));
                       }

                        return await McaGovRequest.RequestByCINAndCompany(dataList, downloadDirectory, cookies, progress);
                    }

                    return 0;

                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return 0;
            });

            buttonExtractTab1.Enabled = true;
            this.labelStatusTab1.Text = "Status: Completed";

            progressBarTab1.Value = 0;
            MessageBox.Show($"Complete, total records scrape {totalRecords}");

            Process.Start("explorer.exe", downloadDirectory);

            if (totalRecords > 0)
            {
                Process.Start("explorer.exe", downloadDirectory);
            }
        }

        private void FormMCAGov_Load(object sender, EventArgs e)
        {

        }

        //private void buttonSaveProfile_Click(object sender, EventArgs e)
        //{
        //    if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        this.textBoxChromeProfile.Text = this.folderBrowserDialog1.SelectedPath;

        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select the directory where the files will be extracted.");
        //    }
        //}

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void labelChromeProfile_Click(object sender, EventArgs e)
        {

        }
   
    }
}
