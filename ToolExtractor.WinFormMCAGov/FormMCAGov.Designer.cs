namespace ToolExtractor.WinFormMCAGov
{
    partial class FormMCAGov
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDownloadFolder = new System.Windows.Forms.TextBox();
            this.btnSelectFolderTab1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCinTab1 = new System.Windows.Forms.TextBox();
            this.progressBarTab1 = new System.Windows.Forms.ProgressBar();
            this.labelStatusTab1 = new System.Windows.Forms.Label();
            this.buttonExtractTab1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.comboBoxRequestType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cookie1 = new System.Windows.Forms.TextBox();
            this.cookie2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder Directory";
            // 
            // textBoxDownloadFolder
            // 
            this.textBoxDownloadFolder.Location = new System.Drawing.Point(131, 158);
            this.textBoxDownloadFolder.Name = "textBoxDownloadFolder";
            this.textBoxDownloadFolder.Size = new System.Drawing.Size(400, 23);
            this.textBoxDownloadFolder.TabIndex = 1;
            this.textBoxDownloadFolder.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnSelectFolderTab1
            // 
            this.btnSelectFolderTab1.Location = new System.Drawing.Point(549, 158);
            this.btnSelectFolderTab1.Name = "btnSelectFolderTab1";
            this.btnSelectFolderTab1.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFolderTab1.TabIndex = 2;
            this.btnSelectFolderTab1.Text = "select";
            this.btnSelectFolderTab1.UseVisualStyleBackColor = true;
            this.btnSelectFolderTab1.Click += new System.EventHandler(this.btnSelectFolderTab1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cin Values";
            // 
            // textBoxCinTab1
            // 
            this.textBoxCinTab1.Location = new System.Drawing.Point(128, 276);
            this.textBoxCinTab1.Multiline = true;
            this.textBoxCinTab1.Name = "textBoxCinTab1";
            this.textBoxCinTab1.Size = new System.Drawing.Size(400, 167);
            this.textBoxCinTab1.TabIndex = 4;
            // 
            // progressBarTab1
            // 
            this.progressBarTab1.Location = new System.Drawing.Point(125, 546);
            this.progressBarTab1.Name = "progressBarTab1";
            this.progressBarTab1.Size = new System.Drawing.Size(403, 23);
            this.progressBarTab1.TabIndex = 6;
            this.progressBarTab1.Click += new System.EventHandler(this.progressBarTab1_Click);
            // 
            // labelStatusTab1
            // 
            this.labelStatusTab1.AutoSize = true;
            this.labelStatusTab1.Location = new System.Drawing.Point(125, 516);
            this.labelStatusTab1.Name = "labelStatusTab1";
            this.labelStatusTab1.Size = new System.Drawing.Size(74, 15);
            this.labelStatusTab1.TabIndex = 7;
            this.labelStatusTab1.Text = "Status: None";
            // 
            // buttonExtractTab1
            // 
            this.buttonExtractTab1.Location = new System.Drawing.Point(126, 452);
            this.buttonExtractTab1.Name = "buttonExtractTab1";
            this.buttonExtractTab1.Size = new System.Drawing.Size(75, 23);
            this.buttonExtractTab1.TabIndex = 8;
            this.buttonExtractTab1.Text = "Extract";
            this.buttonExtractTab1.UseVisualStyleBackColor = true;
            this.buttonExtractTab1.Click += new System.EventHandler(this.buttonExtractTab1_Click);
            // 
            // comboBoxRequestType
            // 
            this.comboBoxRequestType.FormattingEnabled = true;
            this.comboBoxRequestType.Items.AddRange(new object[] {
            "CIN",
            "CIN & COMPANY_NAME"});
            this.comboBoxRequestType.Location = new System.Drawing.Point(131, 210);
            this.comboBoxRequestType.Name = "comboBoxRequestType";
            this.comboBoxRequestType.Size = new System.Drawing.Size(157, 23);
            this.comboBoxRequestType.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Request Type";
            // 
            // cookie1
            // 
            this.cookie1.Location = new System.Drawing.Point(131, 47);
            this.cookie1.Name = "cookie1";
            this.cookie1.Size = new System.Drawing.Size(397, 23);
            this.cookie1.TabIndex = 14;
            // 
            // cookie2
            // 
            this.cookie2.Location = new System.Drawing.Point(132, 96);
            this.cookie2.Name = "cookie2";
            this.cookie2.Size = new System.Drawing.Size(396, 23);
            this.cookie2.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "COOKIE: cookiesession1";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "COOKIE:JSESSION ";
            // 
            // FormMCAGov
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 611);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cookie2);
            this.Controls.Add(this.cookie1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxRequestType);
            this.Controls.Add(this.buttonExtractTab1);
            this.Controls.Add(this.labelStatusTab1);
            this.Controls.Add(this.progressBarTab1);
            this.Controls.Add(this.textBoxCinTab1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectFolderTab1);
            this.Controls.Add(this.textBoxDownloadFolder);
            this.Controls.Add(this.label1);
            this.Name = "FormMCAGov";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMCAGov_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBoxDownloadFolder;
        private Button btnSelectFolderTab1;
        private Label label2;
        private TextBox textBoxCinTab1;
        private ProgressBar progressBarTab1;
        private Label labelStatusTab1;
        private Button buttonExtractTab1;
        private FolderBrowserDialog folderBrowserDialog1;
        private ComboBox comboBoxRequestType;
        private Label label3;
        private TextBox cookie1;
        private TextBox cookie2;
        private Label label4;
        private Label label5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}