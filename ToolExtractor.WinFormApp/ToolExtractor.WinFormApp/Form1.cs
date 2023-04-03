using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using ToolExtractor.Lib.MCAGOV;
using ToolExtractor.Lib.Utils;
using ToolExtractor.Lib.HtmlExtractorJob1;
using ToolExtractor.Lib.HmtlExtractorJob2;

namespace ToolExtractor.WinFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.loadingGif.Visible = false;
            this.tabPage1.Text = "Scrappers 1";

            //hide tab2
            TabControl parent = (TabControl)tabPage2.Parent;
            parent.TabPages.Remove(tabPage2);


            this.tabPage3.Text = "mca.gov scraper";

            this.progressBar1.Dock = DockStyle.Bottom;
            
            this.progressBarTab3.Dock = DockStyle.Bottom;

            this.inputSourceDirectory.Enabled = false;
            this.inputTargetDirectory.Enabled = false;
            initTestData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btnfolderSelect_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.inputSourceDirectory.Text = this.folderBrowserDialog1.SelectedPath;

            } else
            {
                MessageBox.Show("Please select the directory where the files will be extracted.");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                this.inputTargetDirectory.Text = this.folderBrowserDialog2.SelectedPath;
            }
            else
            {
                MessageBox.Show("Please select the directory where the files will be downloaded.");

            }
        }

        enum ToolTypes
        {
            MasterData,
            Directors_details,
            Charges_Borrowing_Details,
            Documents
        };

        private async void button1_Click(object sender, EventArgs e)
        {
            //test
           
            //validate
            var sourceDirectory = this.inputSourceDirectory.Text;
            var targetDirectory = this.inputTargetDirectory.Text;
            
            Enum.TryParse(this.comboToolTypes.SelectedIndex.ToString(), out ToolTypes toolType);
            
            if ((int)toolType == -1)
            {
                MessageBox.Show("Select a tool type.");
                return;
            }

            if (!Directory.Exists(sourceDirectory))
            {
                MessageBox.Show("Select a valid directory.");
                return;
            }

            if (!Directory.Exists(targetDirectory))
            {
                MessageBox.Show("Select valid directory.");
                return;
            }
            

            //this.loadingGif.Visible = true;
            this.btnfolderSelect.Enabled = false;
            this.btnExtract.Enabled = false;

            var files = Directory.GetFiles(sourceDirectory, "*.html").ToList();
            
            progressBar1.Minimum = 0;
            progressBar1.Maximum = files.Count;

            var progress = new Progress<int>(v =>
            {
                progressBar1.Value = v; // This lambda is executed in context of UI thread, so it can safely update form controls
            });
           
            this.statusLabel.Text = "Status: Working";
            var totalRecords = 0;

            var state = await Task.Run(async () =>
            {
                try
                {
              
                    var filePathTarget = Path.Combine(targetDirectory, Enum.GetName(toolType) + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx");

                    switch (toolType)
                    {
                        case ToolTypes.MasterData:
                            var records1 = CustomExtractor.ExtractMasterData(files, progress);
                            totalRecords = records1.Count;
                            ExtractorUtilService.ConvertListToExcel(records1, filePathTarget);
                            break;
                        case ToolTypes.Documents:
                            var docs = CustomExtractor.ExtractDocuments(files, progress);
                            totalRecords = docs.Count;

                            ExtractorUtilService.ConvertListToExcel( docs, filePathTarget);
                            break;
                        case ToolTypes.Charges_Borrowing_Details:
                            var charges = CustomExtractor.ExtractCharges(files, progress);
                            totalRecords = charges.Count;

                            ExtractorUtilService.ConvertListToExcel(charges, filePathTarget);
                            break;
                        case ToolTypes.Directors_details:
                            var directors = CustomExtractor.ExtractDirectors(files, progress);
                            totalRecords = directors.Count;
                            ExtractorUtilService.ConvertListToExcel( directors, filePathTarget);
                            break;
                    }


                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return false;
            });

            this.statusLabel.Text = "Status: Complete";
            progressBar1.Value = 0;
            MessageBox.Show($"Complete, total records scrape {totalRecords}");

            if (state)
            {
                Process.Start("explorer.exe", targetDirectory);
            }

            //this.loadingGif.Visible = false;
            this.btnfolderSelect.Enabled = true;
            this.btnExtract.Enabled = true;
            this.statusLabel.Text = "Status: None";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void statusLabel_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectFolder3_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog3.ShowDialog() == DialogResult.OK)
            {
                this.inputSource3.Text = this.folderBrowserDialog3.SelectedPath;

            }
            else
            {
                MessageBox.Show("Please select the directory where the files will be extracted.");
            }
        }

        private void buttonSelectFolder4_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog4.ShowDialog() == DialogResult.OK)
            {
                this.inputTarget4.Text = this.folderBrowserDialog4.SelectedPath;

            }
            else
            {
                MessageBox.Show("Please select the directory where the files will be extracted.");
            }
        }
        private void initTestData()
        {
            this.inputSource3.Text = "C:\\Users\\pc001\\source\\repos\\ToolExtractor\\ToolExtractor.WinFormApp\\ToolExtractor.WinFormApp\\Resources\\gstin1";
            this.inputTarget4.Text = "C:\\Users\\pc001\\source\\repos\\ToolExtractor\\ToolExtractor.WinFormApp\\ToolExtractor.WinFormApp\\Resources\\GsTinDownload";
        }

        private async void buttonExtractTab2_click(object sender, EventArgs e)
        {
            //var sourceDirectory = this.inputSource3.Text;
            //var targetDirectory = this.inputTarget4.Text;


            //if (!Directory.Exists(sourceDirectory))
            //{
            //    MessageBox.Show("Select a valid directory.");
            //    return;
            //}

            //if (!Directory.Exists(targetDirectory))
            //{
            //    MessageBox.Show("Select valid directory.");
            //    return;
            //}


            ////this.loadingGif.Visible = true;
            //this.btnSelectFolder3.Enabled = false;
            //this.buttonSelectFolder4.Enabled = false;
            //this.buttonSelectFolder4.Enabled = false;

            //var files = Directory.GetFiles(sourceDirectory, "*.html").ToList();

            //progressBar1.Minimum = 0;
            //progressBar1.Maximum = files.Count;

            //var progress = new Progress<int>(v =>
            //{
            //    progressBar1.Value = v; // This lambda is executed in context of UI thread, so it can safely update form controls
            //});

            this.statusLabel.Text = "Status: Working";

             await Task.Run(async () => { 
                 try
                 {
                    await TestAngleExtractors.TestExtractGstin(); 

                 }  catch(Exception  ex)
                 {
                     MessageBox.Show(ex.Message);
                 }  
             
             });
            this.statusLabel.Text = "Status: Complete";

            //var totalRecords = 0;

            //var state = await Task.Run(async () =>
            //{
            //    try
            //    {

            //        var filePathTarget = Path.Combine(targetDirectory, Enum.GetName(toolType) + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx");

            //        switch (toolType)
            //        {
            //            case ToolTypes.MasterData:
            //                var records1 = CustomExtractor.ExtractMasterData(files, progress);
            //                totalRecords = records1.Count;
            //                CustomExtractorUtils.ConvertListToExcel(records1, filePathTarget);
            //                break;
            //            case ToolTypes.Documents:
            //                var docs = CustomExtractor.ExtractDocuments(files, progress);
            //                totalRecords = docs.Count;

            //                CustomExtractorUtils.ConvertListToExcel(docs, filePathTarget);
            //                break;
            //            case ToolTypes.Charges_Borrowing_Details:
            //                var charges = CustomExtractor.ExtractCharges(files, progress);
            //                totalRecords = charges.Count;

            //                CustomExtractorUtils.ConvertListToExcel(charges, filePathTarget);
            //                break;
            //            case ToolTypes.Directors_details:
            //                var directors = CustomExtractor.ExtractDirectors(files, progress);
            //                totalRecords = directors.Count;
            //                CustomExtractorUtils.ConvertListToExcel(directors, filePathTarget);
            //                break;
            //        }


            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    return false;
            //});

            //this.statusLabel.Text = "Status: Complete";
            //progressBar1.Value = 0;
            //MessageBox.Show($"Complete, total records scrape {totalRecords}");

            //if (state)
            //{
            //    Process.Start("explorer.exe", targetDirectory);
            //}

            ////this.loadingGif.Visible = false;
            //this.btnfolderSelect.Enabled = true;
            //this.btnExtract.Enabled = true;
            //this.statusLabel.Text = "Status: None";
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void comboToolTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void label7_Click(object sender, EventArgs e)
        {

        }

        #region tab3
        //Extractor Tab 3
        private async void buttonExtractTab3_Click_1(object sender, EventArgs e)
        {
            var downloadDirectory = downloadDirTab3.Text;
            var cinList = this.cinTextBox.Text.Split("\n").Select(t => t.Trim()).Where(t => t.Length > 0).ToList();

            buttonExtractTab3.Enabled = false;

            var errMss = ValidateTab3(downloadDirectory, cinList);

            if (errMss != null)
            {
                MessageBox.Show(errMss);
                buttonExtractTab3.Enabled = true;

                return;
            }

            progressBarTab3.Minimum = 0;
            progressBarTab3.Maximum = cinList.Count();

            var progress = new Progress<int>(v =>
            {
                progressBarTab3.Value = v; // This lambda is executed in context of UI thread, so it can safely update form controls
            });


            statusTab3.Text = "Working..";

            var totalRecords = await Task.Run(async () =>
            {
                try
                {
                    var dataList = cinList.ConvertAll(cin =>
                    {
                        return new RequestCinMeta(cin);
                    });


                    var tableData = await McaGovRequest.RequestByCinList(dataList, progress);

                    var sheet = new SheetObjectMeta(
                        name: "mvc_gov",
                        rows: tableData
                    );

                    var sheetList = new List<SheetObjectMeta>() { sheet };

                    var filePathTarget = Path.Combine(downloadDirectory, "mcagov_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx");
                    ExtractorUtilService.ConvertDictToExcel(sheets: sheetList, filePath: filePathTarget);
                    return tableData.Count;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return 0;
            });

            buttonExtractTab3.Enabled = true;
            statusTab3.Text = "Status: Completed";

            progressBarTab3.Value = 0;
            MessageBox.Show($"Complete, total records scrape {totalRecords}");

            Process.Start("explorer.exe", downloadDirectory);

            if (totalRecords > 0)
            {
                Process.Start("explorer.exe", downloadDirectory);
            }

        }
        string ValidateTab3(string targetDirectory, List<string> cinList)
        {
            if (string.IsNullOrEmpty(targetDirectory) || !Directory.Exists(targetDirectory))
            {
                return "No Valid Directory";
            }

            if (cinList.Count == 0)
            {
                return "Cin is required";
            }
            return null;
        }

        private void buttonSelectFolderTab3_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserTab3.ShowDialog() == DialogResult.OK)
            {
                this.downloadDirTab3.Text = this.folderBrowserTab3.SelectedPath;

            }
            else
            {
                MessageBox.Show("Please select the directory where the files will be extracted.");
            }
        }

        #endregion

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}