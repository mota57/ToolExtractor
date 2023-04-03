namespace ToolExtractor.WinFormApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.comboToolTypes = new System.Windows.Forms.ComboBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.inputTargetDirectory = new System.Windows.Forms.TextBox();
            this.inputSourceDirectory = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnfolderSelect = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusTab2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.inputTarget4 = new System.Windows.Forms.TextBox();
            this.buttonSelectFolder4 = new System.Windows.Forms.Button();
            this.btnSelectFolder3 = new System.Windows.Forms.Button();
            this.inputSource3 = new System.Windows.Forms.TextBox();
            this.buttonExtractTab2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.statusTab3 = new System.Windows.Forms.Label();
            this.buttonSelectFolderTab3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.downloadDirTab3 = new System.Windows.Forms.TextBox();
            this.progressBarTab3 = new System.Windows.Forms.ProgressBar();
            this.buttonExtractTab3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cinTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog3 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog4 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserTab3 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.comboToolTypes);
            this.tabPage1.Controls.Add(this.statusLabel);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.inputTargetDirectory);
            this.tabPage1.Controls.Add(this.inputSourceDirectory);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.btnExtract);
            this.tabPage1.Controls.Add(this.btnfolderSelect);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(605, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tool Type";
            // 
            // comboToolTypes
            // 
            this.comboToolTypes.FormattingEnabled = true;
            this.comboToolTypes.Items.AddRange(new object[] {
            "MasterData",
            "Directors details",
            "Charges/Borrowing Details",
            "Documents"});
            this.comboToolTypes.Location = new System.Drawing.Point(75, 46);
            this.comboToolTypes.Name = "comboToolTypes";
            this.comboToolTypes.Size = new System.Drawing.Size(192, 23);
            this.comboToolTypes.TabIndex = 11;
            this.comboToolTypes.SelectedIndexChanged += new System.EventHandler(this.comboToolTypes_SelectedIndexChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(75, 314);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(74, 15);
            this.statusLabel.TabIndex = 10;
            this.statusLabel.Text = "Status: None";
            this.statusLabel.Click += new System.EventHandler(this.statusLabel_Click);
            // 
            // button2
            // 
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.Location = new System.Drawing.Point(430, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Select Folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Folder Download";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Folder Source";
            // 
            // inputTargetDirectory
            // 
            this.inputTargetDirectory.Location = new System.Drawing.Point(75, 169);
            this.inputTargetDirectory.Name = "inputTargetDirectory";
            this.inputTargetDirectory.Size = new System.Drawing.Size(349, 23);
            this.inputTargetDirectory.TabIndex = 6;
            // 
            // inputSourceDirectory
            // 
            this.inputSourceDirectory.Location = new System.Drawing.Point(75, 105);
            this.inputSourceDirectory.Name = "inputSourceDirectory";
            this.inputSourceDirectory.Size = new System.Drawing.Size(349, 23);
            this.inputSourceDirectory.TabIndex = 2;
            this.inputSourceDirectory.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(75, 272);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(430, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(75, 222);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(178, 23);
            this.btnExtract.TabIndex = 4;
            this.btnExtract.Text = "Extract";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnfolderSelect
            // 
            this.btnfolderSelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnfolderSelect.Location = new System.Drawing.Point(430, 104);
            this.btnfolderSelect.Name = "btnfolderSelect";
            this.btnfolderSelect.Size = new System.Drawing.Size(75, 23);
            this.btnfolderSelect.TabIndex = 3;
            this.btnfolderSelect.Text = "Select Folder";
            this.btnfolderSelect.UseVisualStyleBackColor = true;
            this.btnfolderSelect.Click += new System.EventHandler(this.btnfolderSelect_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(91, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(613, 459);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.statusTab2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.inputTarget4);
            this.tabPage2.Controls.Add(this.buttonSelectFolder4);
            this.tabPage2.Controls.Add(this.btnSelectFolder3);
            this.tabPage2.Controls.Add(this.inputSource3);
            this.tabPage2.Controls.Add(this.buttonExtractTab2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(605, 431);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // statusTab2
            // 
            this.statusTab2.AutoSize = true;
            this.statusTab2.Location = new System.Drawing.Point(54, 243);
            this.statusTab2.Name = "statusTab2";
            this.statusTab2.Size = new System.Drawing.Size(74, 15);
            this.statusTab2.TabIndex = 9;
            this.statusTab2.Text = "Status: None";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Option";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Folder Download";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Folder Source";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(54, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(318, 23);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // inputTarget4
            // 
            this.inputTarget4.Enabled = false;
            this.inputTarget4.Location = new System.Drawing.Point(54, 150);
            this.inputTarget4.Name = "inputTarget4";
            this.inputTarget4.Size = new System.Drawing.Size(318, 23);
            this.inputTarget4.TabIndex = 4;
            // 
            // buttonSelectFolder4
            // 
            this.buttonSelectFolder4.Location = new System.Drawing.Point(399, 149);
            this.buttonSelectFolder4.Name = "buttonSelectFolder4";
            this.buttonSelectFolder4.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFolder4.TabIndex = 3;
            this.buttonSelectFolder4.Text = "Select";
            this.buttonSelectFolder4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonSelectFolder4.UseVisualStyleBackColor = true;
            this.buttonSelectFolder4.Click += new System.EventHandler(this.buttonSelectFolder4_Click);
            // 
            // btnSelectFolder3
            // 
            this.btnSelectFolder3.Location = new System.Drawing.Point(399, 95);
            this.btnSelectFolder3.Name = "btnSelectFolder3";
            this.btnSelectFolder3.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFolder3.TabIndex = 2;
            this.btnSelectFolder3.Text = "Select";
            this.btnSelectFolder3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSelectFolder3.UseVisualStyleBackColor = true;
            this.btnSelectFolder3.Click += new System.EventHandler(this.btnSelectFolder3_Click);
            // 
            // inputSource3
            // 
            this.inputSource3.Enabled = false;
            this.inputSource3.Location = new System.Drawing.Point(54, 95);
            this.inputSource3.Name = "inputSource3";
            this.inputSource3.Size = new System.Drawing.Size(318, 23);
            this.inputSource3.TabIndex = 1;
            // 
            // buttonExtractTab2
            // 
            this.buttonExtractTab2.Location = new System.Drawing.Point(54, 196);
            this.buttonExtractTab2.Name = "buttonExtractTab2";
            this.buttonExtractTab2.Size = new System.Drawing.Size(148, 23);
            this.buttonExtractTab2.TabIndex = 0;
            this.buttonExtractTab2.Text = "Extract Data";
            this.buttonExtractTab2.UseVisualStyleBackColor = true;
            this.buttonExtractTab2.Click += new System.EventHandler(this.buttonExtractTab2_click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.statusTab3);
            this.tabPage3.Controls.Add(this.buttonSelectFolderTab3);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.downloadDirTab3);
            this.tabPage3.Controls.Add(this.progressBarTab3);
            this.tabPage3.Controls.Add(this.buttonExtractTab3);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.cinTextBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(605, 431);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // statusTab3
            // 
            this.statusTab3.AutoSize = true;
            this.statusTab3.Location = new System.Drawing.Point(104, 363);
            this.statusTab3.Name = "statusTab3";
            this.statusTab3.Size = new System.Drawing.Size(74, 15);
            this.statusTab3.TabIndex = 7;
            this.statusTab3.Text = "Status: None";
            this.statusTab3.Click += new System.EventHandler(this.label9_Click);
            // 
            // buttonSelectFolderTab3
            // 
            this.buttonSelectFolderTab3.Location = new System.Drawing.Point(520, 24);
            this.buttonSelectFolderTab3.Name = "buttonSelectFolderTab3";
            this.buttonSelectFolderTab3.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFolderTab3.TabIndex = 6;
            this.buttonSelectFolderTab3.Text = "Select";
            this.buttonSelectFolderTab3.UseVisualStyleBackColor = true;
            this.buttonSelectFolderTab3.Click += new System.EventHandler(this.buttonSelectFolderTab3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(102, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Download Directory";
            // 
            // downloadDirTab3
            // 
            this.downloadDirTab3.Enabled = false;
            this.downloadDirTab3.Location = new System.Drawing.Point(102, 24);
            this.downloadDirTab3.Name = "downloadDirTab3";
            this.downloadDirTab3.Size = new System.Drawing.Size(412, 23);
            this.downloadDirTab3.TabIndex = 4;
            // 
            // progressBarTab3
            // 
            this.progressBarTab3.Location = new System.Drawing.Point(103, 378);
            this.progressBarTab3.Name = "progressBarTab3";
            this.progressBarTab3.Size = new System.Drawing.Size(411, 23);
            this.progressBarTab3.TabIndex = 3;
            // 
            // buttonExtractTab3
            // 
            this.buttonExtractTab3.Location = new System.Drawing.Point(102, 322);
            this.buttonExtractTab3.Name = "buttonExtractTab3";
            this.buttonExtractTab3.Size = new System.Drawing.Size(75, 23);
            this.buttonExtractTab3.TabIndex = 2;
            this.buttonExtractTab3.Text = "Extract Data";
            this.buttonExtractTab3.UseVisualStyleBackColor = true;
            this.buttonExtractTab3.Click += new System.EventHandler(this.buttonExtractTab3_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(102, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Cin Values";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // cinTextBox
            // 
            this.cinTextBox.Location = new System.Drawing.Point(102, 80);
            this.cinTextBox.Multiline = true;
            this.cinTextBox.Name = "cinTextBox";
            this.cinTextBox.Size = new System.Drawing.Size(412, 236);
            this.cinTextBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 579);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Scrapper Tool Freelance";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private FolderBrowserDialog folderBrowserDialog1;
        private FolderBrowserDialog folderBrowserDialog2;
        private TabPage tabPage1;
        private Label label3;
        private ComboBox comboToolTypes;
        private Label statusLabel;
        private Button button2;
        private Label label2;
        private Label label1;
        private TextBox inputTargetDirectory;
        private TextBox inputSourceDirectory;
        private ProgressBar progressBar1;
        private Button btnExtract;
        private Button btnfolderSelect;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private TextBox inputTarget4;
        private Button buttonSelectFolder4;
        private Button btnSelectFolder3;
        private TextBox inputSource3;
        private Button buttonExtractTab2;
        private FolderBrowserDialog folderBrowserDialog3;
        private FolderBrowserDialog folderBrowserDialog4;
        private Label label6;
        private Label label5;
        private Label label4;
        private ComboBox comboBox1;
        private Label statusTab2;
        private TabPage tabPage3;
        private Button buttonExtractTab3;
        private Label label7;
        private TextBox cinTextBox;
        private ProgressBar progressBarTab3;
        private Button buttonSelectFolderTab3;
        private Label label8;
        private TextBox downloadDirTab3;
        private FolderBrowserDialog folderBrowserTab3;
        private Label statusTab3;
    }
}