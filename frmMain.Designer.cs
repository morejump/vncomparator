namespace VnSentencesConparator
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.importTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.taskReadTxt = new System.ComponentModel.BackgroundWorker();
            this.taskSeparatingWord = new System.ComponentModel.BackgroundWorker();
            this.taskImportDB = new System.ComponentModel.BackgroundWorker();
            this.label8 = new System.Windows.Forms.Label();
            this.ttVecInfo = new System.Windows.Forms.ToolTip(this.components);
            this.taskCalculateSimilarity = new System.ComponentModel.BackgroundWorker();
            this.tabControl = new VnSentencesConparator.HiddenTabControl();
            this.importDbTab = new System.Windows.Forms.TabPage();
            this.txtImportDBInfo = new MetroFramework.Controls.MetroLabel();
            this.txtSeparationInfo = new MetroFramework.Controls.MetroLabel();
            this.txtReadInfo = new MetroFramework.Controls.MetroLabel();
            this.txtFileName = new MetroFramework.Controls.MetroLabel();
            this.btnImportDB = new MetroFramework.Controls.MetroButton();
            this.btnPreprocess = new MetroFramework.Controls.MetroButton();
            this.btnChooseFile = new MetroFramework.Controls.MetroButton();
            this.txtInOut = new System.Windows.Forms.RichTextBox();
            this.compareTab = new System.Windows.Forms.TabPage();
            this.lbTxt2Info = new MetroFramework.Controls.MetroLabel();
            this.lbVec2Info = new MetroFramework.Controls.MetroLabel();
            this.lbSimilarity = new MetroFramework.Controls.MetroLabel();
            this.lbVec1Info = new MetroFramework.Controls.MetroLabel();
            this.lbTxt1Info = new MetroFramework.Controls.MetroLabel();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.btnCalculate = new MetroFramework.Controls.MetroButton();
            this.txtSentence2 = new System.Windows.Forms.RichTextBox();
            this.txtSentence1 = new System.Windows.Forms.RichTextBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDBInfo = new MetroFramework.Controls.MetroButton();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtMaxTime = new System.Windows.Forms.TextBox();
            this.menu.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.importDbTab.SuspendLayout();
            this.compareTab.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importTextToolStripMenuItem,
            this.compareToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(23, 73);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(1149, 25);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // importTextToolStripMenuItem
            // 
            this.importTextToolStripMenuItem.Name = "importTextToolStripMenuItem";
            this.importTextToolStripMenuItem.Size = new System.Drawing.Size(125, 21);
            this.importTextToolStripMenuItem.Text = "Dictionary provider";
            this.importTextToolStripMenuItem.Click += new System.EventHandler(this.importTextToolStripMenuItem_Click);
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(125, 21);
            this.compareToolStripMenuItem.Text = "Distance Calculator";
            this.compareToolStripMenuItem.Click += new System.EventHandler(this.compareToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.aboutToolStripMenuItem.Text = "Config";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(74, 30);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(243, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Vietnamese Sentences Comparator v 1.0";
            // 
            // taskReadTxt
            // 
            this.taskReadTxt.WorkerReportsProgress = true;
            this.taskReadTxt.WorkerSupportsCancellation = true;
            this.taskReadTxt.DoWork += new System.ComponentModel.DoWorkEventHandler(this.taskReadTxt_DoWork);
            this.taskReadTxt.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.taskReadTxt_ProgressChanged);
            this.taskReadTxt.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.taskReadTxt_RunWorkerCompleted);
            // 
            // taskSeparatingWord
            // 
            this.taskSeparatingWord.WorkerReportsProgress = true;
            this.taskSeparatingWord.WorkerSupportsCancellation = true;
            this.taskSeparatingWord.DoWork += new System.ComponentModel.DoWorkEventHandler(this.taskSeparatingWord_DoWork);
            this.taskSeparatingWord.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.taskSeparatingWord_RunWorkerCompleted);
            // 
            // taskImportDB
            // 
            this.taskImportDB.WorkerReportsProgress = true;
            this.taskImportDB.WorkerSupportsCancellation = true;
            this.taskImportDB.DoWork += new System.ComponentModel.DoWorkEventHandler(this.taskImportDB_DoWork);
            this.taskImportDB.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.taskImportDB_ProgressChanged);
            this.taskImportDB.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.taskImportDB_RunWorkerCompleted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(1040, 563);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Copyright © 2015 EPU VN";
            // 
            // taskCalculateSimilarity
            // 
            this.taskCalculateSimilarity.WorkerReportsProgress = true;
            this.taskCalculateSimilarity.WorkerSupportsCancellation = true;
            this.taskCalculateSimilarity.DoWork += new System.ComponentModel.DoWorkEventHandler(this.taskCalculateSimilarity_DoWork);
            this.taskCalculateSimilarity.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.taskCalculateSimilarity_ProgressChanged);
            this.taskCalculateSimilarity.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.taskCalculateSimilarity_RunWorkerCompleted);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.importDbTab);
            this.tabControl.Controls.Add(this.compareTab);
            this.tabControl.Controls.Add(this.tabAbout);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(23, 98);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1149, 461);
            this.tabControl.TabIndex = 2;
            // 
            // importDbTab
            // 
            this.importDbTab.Controls.Add(this.txtImportDBInfo);
            this.importDbTab.Controls.Add(this.txtSeparationInfo);
            this.importDbTab.Controls.Add(this.txtReadInfo);
            this.importDbTab.Controls.Add(this.txtFileName);
            this.importDbTab.Controls.Add(this.btnImportDB);
            this.importDbTab.Controls.Add(this.btnPreprocess);
            this.importDbTab.Controls.Add(this.btnChooseFile);
            this.importDbTab.Controls.Add(this.txtInOut);
            this.importDbTab.Location = new System.Drawing.Point(4, 26);
            this.importDbTab.Name = "importDbTab";
            this.importDbTab.Padding = new System.Windows.Forms.Padding(3);
            this.importDbTab.Size = new System.Drawing.Size(1141, 431);
            this.importDbTab.TabIndex = 0;
            this.importDbTab.Text = "import db";
            this.importDbTab.UseVisualStyleBackColor = true;
            // 
            // txtImportDBInfo
            // 
            this.txtImportDBInfo.AutoSize = true;
            this.txtImportDBInfo.Location = new System.Drawing.Point(771, 216);
            this.txtImportDBInfo.Name = "txtImportDBInfo";
            this.txtImportDBInfo.Size = new System.Drawing.Size(97, 19);
            this.txtImportDBInfo.TabIndex = 7;
            this.txtImportDBInfo.Text = "Import DB info";
            // 
            // txtSeparationInfo
            // 
            this.txtSeparationInfo.AutoSize = true;
            this.txtSeparationInfo.Location = new System.Drawing.Point(771, 89);
            this.txtSeparationInfo.Name = "txtSeparationInfo";
            this.txtSeparationInfo.Size = new System.Drawing.Size(87, 19);
            this.txtSeparationInfo.TabIndex = 6;
            this.txtSeparationInfo.Text = "Separate info";
            // 
            // txtReadInfo
            // 
            this.txtReadInfo.AutoSize = true;
            this.txtReadInfo.Location = new System.Drawing.Point(771, 57);
            this.txtReadInfo.Name = "txtReadInfo";
            this.txtReadInfo.Size = new System.Drawing.Size(65, 19);
            this.txtReadInfo.TabIndex = 5;
            this.txtReadInfo.Text = "Read info";
            // 
            // txtFileName
            // 
            this.txtFileName.AutoSize = true;
            this.txtFileName.ForeColor = System.Drawing.Color.Blue;
            this.txtFileName.Location = new System.Drawing.Point(1, 7);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(66, 19);
            this.txtFileName.TabIndex = 4;
            this.txtFileName.Text = "File name";
            this.txtFileName.UseCustomForeColor = true;
            // 
            // btnImportDB
            // 
            this.btnImportDB.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnImportDB.Highlight = true;
            this.btnImportDB.Location = new System.Drawing.Point(1031, 31);
            this.btnImportDB.Name = "btnImportDB";
            this.btnImportDB.Size = new System.Drawing.Size(107, 23);
            this.btnImportDB.TabIndex = 3;
            this.btnImportDB.Text = "Import to DB";
            this.btnImportDB.UseSelectable = true;
            this.btnImportDB.Click += new System.EventHandler(this.btnImportDB_Click);
            // 
            // btnPreprocess
            // 
            this.btnPreprocess.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnPreprocess.Highlight = true;
            this.btnPreprocess.Location = new System.Drawing.Point(888, 31);
            this.btnPreprocess.Name = "btnPreprocess";
            this.btnPreprocess.Size = new System.Drawing.Size(136, 23);
            this.btnPreprocess.TabIndex = 2;
            this.btnPreprocess.Text = "Word Separation && Tag";
            this.btnPreprocess.UseSelectable = true;
            this.btnPreprocess.Click += new System.EventHandler(this.btnPreprocess_Click);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnChooseFile.Highlight = true;
            this.btnChooseFile.Location = new System.Drawing.Point(774, 31);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(107, 23);
            this.btnChooseFile.TabIndex = 1;
            this.btnChooseFile.Text = "Browse...";
            this.btnChooseFile.UseSelectable = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // txtInOut
            // 
            this.txtInOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInOut.Location = new System.Drawing.Point(3, 31);
            this.txtInOut.Name = "txtInOut";
            this.txtInOut.ReadOnly = true;
            this.txtInOut.Size = new System.Drawing.Size(764, 397);
            this.txtInOut.TabIndex = 0;
            this.txtInOut.Text = "";
            this.txtInOut.TextChanged += new System.EventHandler(this.txtInOut_TextChanged);
            // 
            // compareTab
            // 
            this.compareTab.Controls.Add(this.lbTxt2Info);
            this.compareTab.Controls.Add(this.lbVec2Info);
            this.compareTab.Controls.Add(this.lbSimilarity);
            this.compareTab.Controls.Add(this.lbVec1Info);
            this.compareTab.Controls.Add(this.lbTxt1Info);
            this.compareTab.Controls.Add(this.btnClear);
            this.compareTab.Controls.Add(this.btnCalculate);
            this.compareTab.Controls.Add(this.txtSentence2);
            this.compareTab.Controls.Add(this.txtSentence1);
            this.compareTab.Location = new System.Drawing.Point(4, 26);
            this.compareTab.Name = "compareTab";
            this.compareTab.Padding = new System.Windows.Forms.Padding(3);
            this.compareTab.Size = new System.Drawing.Size(1141, 431);
            this.compareTab.TabIndex = 1;
            this.compareTab.Text = "compare";
            this.compareTab.UseVisualStyleBackColor = true;
            // 
            // lbTxt2Info
            // 
            this.lbTxt2Info.AutoSize = true;
            this.lbTxt2Info.Location = new System.Drawing.Point(571, 167);
            this.lbTxt2Info.Name = "lbTxt2Info";
            this.lbTxt2Info.Size = new System.Drawing.Size(101, 19);
            this.lbTxt2Info.TabIndex = 4;
            this.lbTxt2Info.Text = "lbSentence2Info";
            // 
            // lbVec2Info
            // 
            this.lbVec2Info.AutoSize = true;
            this.lbVec2Info.Location = new System.Drawing.Point(571, 292);
            this.lbVec2Info.MaximumSize = new System.Drawing.Size(555, 290);
            this.lbVec2Info.Name = "lbVec2Info";
            this.lbVec2Info.Size = new System.Drawing.Size(69, 19);
            this.lbVec2Info.TabIndex = 4;
            this.lbVec2Info.Text = "lbVec2Info";
            this.lbVec2Info.MouseHover += new System.EventHandler(this.lbVec1Info_MouseHover);
            // 
            // lbSimilarity
            // 
            this.lbSimilarity.AutoSize = true;
            this.lbSimilarity.Location = new System.Drawing.Point(7, 406);
            this.lbSimilarity.Name = "lbSimilarity";
            this.lbSimilarity.Size = new System.Drawing.Size(73, 19);
            this.lbSimilarity.Style = MetroFramework.MetroColorStyle.Red;
            this.lbSimilarity.TabIndex = 4;
            this.lbSimilarity.Text = "lbSimilarity";
            this.lbSimilarity.UseStyleColors = true;
            // 
            // lbVec1Info
            // 
            this.lbVec1Info.AutoSize = true;
            this.lbVec1Info.Location = new System.Drawing.Point(7, 292);
            this.lbVec1Info.MaximumSize = new System.Drawing.Size(555, 290);
            this.lbVec1Info.Name = "lbVec1Info";
            this.lbVec1Info.Size = new System.Drawing.Size(67, 19);
            this.lbVec1Info.TabIndex = 4;
            this.lbVec1Info.Text = "lbVec1Info";
            this.lbVec1Info.MouseHover += new System.EventHandler(this.lbVec1Info_MouseHover);
            // 
            // lbTxt1Info
            // 
            this.lbTxt1Info.AutoSize = true;
            this.lbTxt1Info.Location = new System.Drawing.Point(7, 167);
            this.lbTxt1Info.Name = "lbTxt1Info";
            this.lbTxt1Info.Size = new System.Drawing.Size(99, 19);
            this.lbTxt1Info.TabIndex = 4;
            this.lbTxt1Info.Text = "lbSentence1Info";
            // 
            // btnClear
            // 
            this.btnClear.Highlight = true;
            this.btnClear.Location = new System.Drawing.Point(571, 132);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Highlight = true;
            this.btnCalculate.Location = new System.Drawing.Point(6, 132);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(100, 23);
            this.btnCalculate.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnCalculate.TabIndex = 3;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseSelectable = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtSentence2
            // 
            this.txtSentence2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSentence2.Location = new System.Drawing.Point(571, 31);
            this.txtSentence2.Name = "txtSentence2";
            this.txtSentence2.Size = new System.Drawing.Size(559, 94);
            this.txtSentence2.TabIndex = 2;
            this.txtSentence2.Text = "";
            this.txtSentence2.Enter += new System.EventHandler(this.txtSentence1_Enter);
            this.txtSentence2.Leave += new System.EventHandler(this.txtSentence1_Leave);
            // 
            // txtSentence1
            // 
            this.txtSentence1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSentence1.ForeColor = System.Drawing.Color.Black;
            this.txtSentence1.Location = new System.Drawing.Point(6, 31);
            this.txtSentence1.Name = "txtSentence1";
            this.txtSentence1.Size = new System.Drawing.Size(559, 94);
            this.txtSentence1.TabIndex = 1;
            this.txtSentence1.Text = "";
            this.txtSentence1.Enter += new System.EventHandler(this.txtSentence1_Enter);
            this.txtSentence1.Leave += new System.EventHandler(this.txtSentence1_Leave);
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.groupBox3);
            this.tabAbout.Controls.Add(this.groupBox1);
            this.tabAbout.Location = new System.Drawing.Point(4, 26);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Size = new System.Drawing.Size(1141, 431);
            this.tabAbout.TabIndex = 2;
            this.tabAbout.Text = "about";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupBox3.Location = new System.Drawing.Point(406, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(329, 223);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "About:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(19, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 45);
            this.label2.TabIndex = 3;
            this.label2.Text = "VSC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(82, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "law and inernational treaties.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(28, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "This computer program is protected by copyright";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(25, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(285, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vietnamese Sentences Comparator v 1.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(81, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Email: ducpm_d7cnpm@epu.edu.vn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(88, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Email: duongvd.2106@gmail.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(57, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Copyright © 2015 EPU VN.   All right reserved";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDBInfo);
            this.groupBox1.Controls.Add(this.txtDB);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.txtMaxTime);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(439, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 134);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config:";
            // 
            // btnDBInfo
            // 
            this.btnDBInfo.Highlight = true;
            this.btnDBInfo.Location = new System.Drawing.Point(67, 91);
            this.btnDBInfo.Name = "btnDBInfo";
            this.btnDBInfo.Size = new System.Drawing.Size(126, 25);
            this.btnDBInfo.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnDBInfo.TabIndex = 5;
            this.btnDBInfo.Text = "Database Info";
            this.btnDBInfo.UseSelectable = true;
            // 
            // txtDB
            // 
            this.txtDB.Location = new System.Drawing.Point(98, 21);
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(142, 25);
            this.txtDB.TabIndex = 3;
            this.txtDB.Text = "dbVSC";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.metroLabel3.Location = new System.Drawing.Point(23, 57);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(175, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Max Separate time (minute):";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.ForeColor = System.Drawing.Color.Red;
            this.metroLabel2.Location = new System.Drawing.Point(23, 24);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(69, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "DB Name:";
            // 
            // txtMaxTime
            // 
            this.txtMaxTime.Location = new System.Drawing.Point(202, 54);
            this.txtMaxTime.Name = "txtMaxTime";
            this.txtMaxTime.Size = new System.Drawing.Size(38, 25);
            this.txtMaxTime.TabIndex = 3;
            this.txtMaxTime.Text = "30";
            this.txtMaxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 583);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1195, 583);
            this.MinimumSize = new System.Drawing.Size(1195, 583);
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(23, 73, 23, 24);
            this.Text = "VSC ";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.importDbTab.ResumeLayout(false);
            this.importDbTab.PerformLayout();
            this.compareTab.ResumeLayout(false);
            this.compareTab.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem importTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private HiddenTabControl tabControl;
        private System.Windows.Forms.TabPage importDbTab;
        private System.Windows.Forms.TabPage compareTab;
        private System.Windows.Forms.RichTextBox txtInOut;
        private MetroFramework.Controls.MetroButton btnPreprocess;
        private MetroFramework.Controls.MetroButton btnChooseFile;
        private MetroFramework.Controls.MetroButton btnImportDB;
        private MetroFramework.Controls.MetroLabel txtFileName;
        private System.ComponentModel.BackgroundWorker taskReadTxt;
        private MetroFramework.Controls.MetroLabel txtReadInfo;
        private System.ComponentModel.BackgroundWorker taskSeparatingWord;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroLabel txtSeparationInfo;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabPage tabAbout;
        private System.ComponentModel.BackgroundWorker taskImportDB;
        private MetroFramework.Controls.MetroLabel txtImportDBInfo;
        private System.Windows.Forms.TextBox txtDB;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.TextBox txtMaxTime;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private MetroFramework.Controls.MetroButton btnDBInfo;
        private System.Windows.Forms.RichTextBox txtSentence2;
        private System.Windows.Forms.RichTextBox txtSentence1;
        private MetroFramework.Controls.MetroButton btnCalculate;
        private MetroFramework.Controls.MetroLabel lbTxt2Info;
        private MetroFramework.Controls.MetroLabel lbTxt1Info;
        private MetroFramework.Controls.MetroLabel lbVec2Info;
        private MetroFramework.Controls.MetroLabel lbVec1Info;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroLabel lbSimilarity;
        private System.Windows.Forms.ToolTip ttVecInfo;
        private System.ComponentModel.BackgroundWorker taskCalculateSimilarity;
    }
}