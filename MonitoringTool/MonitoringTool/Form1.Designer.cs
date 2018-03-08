namespace MonitoringTool
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TsMiLoadCustomDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.TsMiCreateTestDepartments = new System.Windows.Forms.ToolStripMenuItem();
            this.TsMiSetInterval = new System.Windows.Forms.ToolStripMenuItem();
            this.TsTbTimerInterval = new System.Windows.Forms.ToolStripTextBox();
            this.bRefresh_DepartmentCheck = new System.Windows.Forms.Button();
            this.tv_DepartmentCheck = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lLog = new System.Windows.Forms.Label();
            this.tv_LockedOutAccount = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bRefresh_LockedOutAccount = new System.Windows.Forms.Button();
            this.bRefresh_LockedOutEmails = new System.Windows.Forms.Button();
            this.tv_LockedOutEmails = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.bTimer = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lv_LockedOutOldList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.bRefresh_LockedOutOldList = new System.Windows.Forms.Button();
            this.bRefresh_ExpiredPasswords = new System.Windows.Forms.Button();
            this.tv_ExpiredPasswords = new System.Windows.Forms.TreeView();
            this.label5 = new System.Windows.Forms.Label();
            this.bRefresh_CheckEmailsToSend = new System.Windows.Forms.Button();
            this.tb_numberOfEmails = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mS_unblockUser = new System.Windows.Forms.MenuStrip();
            this.TS_unblockUser = new System.Windows.Forms.ToolStripMenuItem();
            this.TS_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.mS_unblockEmail = new System.Windows.Forms.MenuStrip();
            this.unblockEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mS_setPassword = new System.Windows.Forms.MenuStrip();
            this.nastavitHesloProToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pb_DepartmentCheck = new System.Windows.Forms.PictureBox();
            this.pb_LockedOutAccount = new System.Windows.Forms.PictureBox();
            this.pb_LockedOutEmails = new System.Windows.Forms.PictureBox();
            this.pb_ExpiredPasswords = new System.Windows.Forms.PictureBox();
            this.pb_LockedOutOldList = new System.Windows.Forms.PictureBox();
            this.pb_CheckEmailsToSend = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.mS_unblockUser.SuspendLayout();
            this.mS_unblockEmail.SuspendLayout();
            this.mS_setPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_DepartmentCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_LockedOutAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_LockedOutEmails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ExpiredPasswords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_LockedOutOldList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CheckEmailsToSend)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(703, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsMiLoadCustomDepartment,
            this.TsMiSetInterval});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.settingToolStripMenuItem.Text = "Nastavení";
            // 
            // TsMiLoadCustomDepartment
            // 
            this.TsMiLoadCustomDepartment.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsMiCreateTestDepartments});
            this.TsMiLoadCustomDepartment.Name = "TsMiLoadCustomDepartment";
            this.TsMiLoadCustomDepartment.Size = new System.Drawing.Size(176, 22);
            this.TsMiLoadCustomDepartment.Text = "Pobočky";
            // 
            // TsMiCreateTestDepartments
            // 
            this.TsMiCreateTestDepartments.Name = "TsMiCreateTestDepartments";
            this.TsMiCreateTestDepartments.Size = new System.Drawing.Size(236, 22);
            this.TsMiCreateTestDepartments.Text = "Vytvoření testovacích poboček";
            this.TsMiCreateTestDepartments.Click += new System.EventHandler(this.ts_CreateTestDepartments_Click);
            // 
            // TsMiSetInterval
            // 
            this.TsMiSetInterval.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsTbTimerInterval});
            this.TsMiSetInterval.Name = "TsMiSetInterval";
            this.TsMiSetInterval.Size = new System.Drawing.Size(176, 22);
            this.TsMiSetInterval.Text = "opakování (vteřiny)";
            // 
            // TsTbTimerInterval
            // 
            this.TsTbTimerInterval.Name = "TsTbTimerInterval";
            this.TsTbTimerInterval.Size = new System.Drawing.Size(100, 23);
            this.TsTbTimerInterval.Text = "100";
            // 
            // bRefresh_DepartmentCheck
            // 
            this.bRefresh_DepartmentCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bRefresh_DepartmentCheck.BackColor = System.Drawing.SystemColors.Control;
            this.bRefresh_DepartmentCheck.Location = new System.Drawing.Point(597, 28);
            this.bRefresh_DepartmentCheck.Name = "bRefresh_DepartmentCheck";
            this.bRefresh_DepartmentCheck.Size = new System.Drawing.Size(95, 23);
            this.bRefresh_DepartmentCheck.TabIndex = 1;
            this.bRefresh_DepartmentCheck.Text = "Obnovit";
            this.bRefresh_DepartmentCheck.UseVisualStyleBackColor = false;
            this.bRefresh_DepartmentCheck.Click += new System.EventHandler(this.b_RefDepartmentCheck_Click);
            // 
            // tv_DepartmentCheck
            // 
            this.tv_DepartmentCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_DepartmentCheck.ImageIndex = 0;
            this.tv_DepartmentCheck.ImageList = this.imageList1;
            this.tv_DepartmentCheck.Location = new System.Drawing.Point(484, 54);
            this.tv_DepartmentCheck.Name = "tv_DepartmentCheck";
            this.tv_DepartmentCheck.SelectedImageIndex = 0;
            this.tv_DepartmentCheck.Size = new System.Drawing.Size(208, 419);
            this.tv_DepartmentCheck.TabIndex = 2;
            this.tv_DepartmentCheck.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tv_DepartmentCheck_MouseMove);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "dot_multi.png");
            this.imageList1.Images.SetKeyName(1, "dot_red.png");
            this.imageList1.Images.SetKeyName(2, "dot_green.png");
            this.imageList1.Images.SetKeyName(3, "dot_single.png");
            // 
            // lLog
            // 
            this.lLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lLog.AutoSize = true;
            this.lLog.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lLog.Location = new System.Drawing.Point(12, 495);
            this.lLog.Name = "lLog";
            this.lLog.Size = new System.Drawing.Size(16, 13);
            this.lLog.TabIndex = 3;
            this.lLog.Text = "...";
            // 
            // tv_LockedOutAccount
            // 
            this.tv_LockedOutAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_LockedOutAccount.ImageIndex = 1;
            this.tv_LockedOutAccount.ImageList = this.imageList1;
            this.tv_LockedOutAccount.Location = new System.Drawing.Point(270, 53);
            this.tv_LockedOutAccount.Name = "tv_LockedOutAccount";
            this.tv_LockedOutAccount.SelectedImageIndex = 0;
            this.tv_LockedOutAccount.Size = new System.Drawing.Size(208, 71);
            this.tv_LockedOutAccount.TabIndex = 4;
            this.tv_LockedOutAccount.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_LockedOutAccount_NodeMouseClick);
            this.tv_LockedOutAccount.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tv_LockedOutAccount_MouseMove);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Dostupnost Poboček:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Uzamklé Účty:";
            // 
            // bRefresh_LockedOutAccount
            // 
            this.bRefresh_LockedOutAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bRefresh_LockedOutAccount.BackColor = System.Drawing.SystemColors.Control;
            this.bRefresh_LockedOutAccount.Location = new System.Drawing.Point(349, 28);
            this.bRefresh_LockedOutAccount.Name = "bRefresh_LockedOutAccount";
            this.bRefresh_LockedOutAccount.Size = new System.Drawing.Size(129, 23);
            this.bRefresh_LockedOutAccount.TabIndex = 1;
            this.bRefresh_LockedOutAccount.Text = "Obnovit";
            this.bRefresh_LockedOutAccount.UseVisualStyleBackColor = false;
            this.bRefresh_LockedOutAccount.Click += new System.EventHandler(this.b_RefLockedOutAccount_Click);
            // 
            // bRefresh_LockedOutEmails
            // 
            this.bRefresh_LockedOutEmails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bRefresh_LockedOutEmails.BackColor = System.Drawing.SystemColors.Control;
            this.bRefresh_LockedOutEmails.Location = new System.Drawing.Point(357, 131);
            this.bRefresh_LockedOutEmails.Name = "bRefresh_LockedOutEmails";
            this.bRefresh_LockedOutEmails.Size = new System.Drawing.Size(121, 23);
            this.bRefresh_LockedOutEmails.TabIndex = 1;
            this.bRefresh_LockedOutEmails.Text = "Obnovit";
            this.bRefresh_LockedOutEmails.UseVisualStyleBackColor = false;
            this.bRefresh_LockedOutEmails.Click += new System.EventHandler(this.b_RefLockedOutEmails_Click);
            // 
            // tv_LockedOutEmails
            // 
            this.tv_LockedOutEmails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_LockedOutEmails.ImageIndex = 1;
            this.tv_LockedOutEmails.ImageList = this.imageList1;
            this.tv_LockedOutEmails.Location = new System.Drawing.Point(270, 160);
            this.tv_LockedOutEmails.Name = "tv_LockedOutEmails";
            this.tv_LockedOutEmails.SelectedImageIndex = 3;
            this.tv_LockedOutEmails.Size = new System.Drawing.Size(208, 71);
            this.tv_LockedOutEmails.TabIndex = 4;
            this.tv_LockedOutEmails.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.mS_unblockEmail_NodeMouseClick);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Uzamklé Emaily:";
            // 
            // bTimer
            // 
            this.bTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bTimer.BackColor = System.Drawing.SystemColors.Control;
            this.bTimer.Location = new System.Drawing.Point(571, 485);
            this.bTimer.Name = "bTimer";
            this.bTimer.Size = new System.Drawing.Size(121, 23);
            this.bTimer.TabIndex = 1;
            this.bTimer.Text = "Start";
            this.bTimer.UseVisualStyleBackColor = false;
            this.bTimer.Click += new System.EventHandler(this.b_Timer_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 100000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lv_LockedOutOldList
            // 
            this.lv_LockedOutOldList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lv_LockedOutOldList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_LockedOutOldList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv_LockedOutOldList.FullRowSelect = true;
            this.lv_LockedOutOldList.Location = new System.Drawing.Point(17, 108);
            this.lv_LockedOutOldList.Name = "lv_LockedOutOldList";
            this.lv_LockedOutOldList.Size = new System.Drawing.Size(247, 364);
            this.lv_LockedOutOldList.TabIndex = 7;
            this.lv_LockedOutOldList.UseCompatibleStateImageBehavior = false;
            this.lv_LockedOutOldList.View = System.Windows.Forms.View.Details;
            this.lv_LockedOutOldList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_LockedOutOldList_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 24;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Čas";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Účet";
            this.columnHeader3.Width = 67;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "PC";
            this.columnHeader4.Width = 81;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Naposledy Uzamklé Účty:";
            // 
            // bRefresh_LockedOutOldList
            // 
            this.bRefresh_LockedOutOldList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bRefresh_LockedOutOldList.BackColor = System.Drawing.SystemColors.Control;
            this.bRefresh_LockedOutOldList.Location = new System.Drawing.Point(164, 82);
            this.bRefresh_LockedOutOldList.Name = "bRefresh_LockedOutOldList";
            this.bRefresh_LockedOutOldList.Size = new System.Drawing.Size(102, 23);
            this.bRefresh_LockedOutOldList.TabIndex = 1;
            this.bRefresh_LockedOutOldList.Text = "Obnovit";
            this.bRefresh_LockedOutOldList.UseVisualStyleBackColor = false;
            this.bRefresh_LockedOutOldList.Click += new System.EventHandler(this.b_RefLockedOutOldList_Click);
            // 
            // bRefresh_ExpiredPasswords
            // 
            this.bRefresh_ExpiredPasswords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bRefresh_ExpiredPasswords.BackColor = System.Drawing.SystemColors.Control;
            this.bRefresh_ExpiredPasswords.Location = new System.Drawing.Point(357, 237);
            this.bRefresh_ExpiredPasswords.Name = "bRefresh_ExpiredPasswords";
            this.bRefresh_ExpiredPasswords.Size = new System.Drawing.Size(121, 23);
            this.bRefresh_ExpiredPasswords.TabIndex = 1;
            this.bRefresh_ExpiredPasswords.Text = "Obnovit";
            this.bRefresh_ExpiredPasswords.UseVisualStyleBackColor = false;
            this.bRefresh_ExpiredPasswords.Click += new System.EventHandler(this.b_RefExpiredPasswords_Click);
            // 
            // tv_ExpiredPasswords
            // 
            this.tv_ExpiredPasswords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_ExpiredPasswords.ImageIndex = 0;
            this.tv_ExpiredPasswords.ImageList = this.imageList1;
            this.tv_ExpiredPasswords.Location = new System.Drawing.Point(270, 263);
            this.tv_ExpiredPasswords.Name = "tv_ExpiredPasswords";
            this.tv_ExpiredPasswords.SelectedImageIndex = 0;
            this.tv_ExpiredPasswords.Size = new System.Drawing.Size(208, 210);
            this.tv_ExpiredPasswords.TabIndex = 4;
            this.tv_ExpiredPasswords.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_ExpiredPasswords_NodeMouseClick);
            this.tv_ExpiredPasswords.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tv_ExpiredPasswords_MouseMove);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Expirované účty:";
            // 
            // bRefresh_CheckEmailsToSend
            // 
            this.bRefresh_CheckEmailsToSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bRefresh_CheckEmailsToSend.BackColor = System.Drawing.SystemColors.Control;
            this.bRefresh_CheckEmailsToSend.Location = new System.Drawing.Point(164, 52);
            this.bRefresh_CheckEmailsToSend.Name = "bRefresh_CheckEmailsToSend";
            this.bRefresh_CheckEmailsToSend.Size = new System.Drawing.Size(100, 23);
            this.bRefresh_CheckEmailsToSend.TabIndex = 8;
            this.bRefresh_CheckEmailsToSend.Text = "Obnovit";
            this.bRefresh_CheckEmailsToSend.UseVisualStyleBackColor = false;
            this.bRefresh_CheckEmailsToSend.Click += new System.EventHandler(this.b_RefCheckEmailsToSend_Click);
            // 
            // tb_numberOfEmails
            // 
            this.tb_numberOfEmails.BackColor = System.Drawing.SystemColors.Window;
            this.tb_numberOfEmails.Location = new System.Drawing.Point(17, 53);
            this.tb_numberOfEmails.Name = "tb_numberOfEmails";
            this.tb_numberOfEmails.Size = new System.Drawing.Size(141, 20);
            this.tb_numberOfEmails.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Počet Emalů ve frontě na odeslání:";
            // 
            // mS_unblockUser
            // 
            this.mS_unblockUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mS_unblockUser.Dock = System.Windows.Forms.DockStyle.None;
            this.mS_unblockUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_unblockUser,
            this.TS_exit});
            this.mS_unblockUser.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.mS_unblockUser.Location = new System.Drawing.Point(390, 69);
            this.mS_unblockUser.Name = "mS_unblockUser";
            this.mS_unblockUser.Padding = new System.Windows.Forms.Padding(0);
            this.mS_unblockUser.Size = new System.Drawing.Size(88, 38);
            this.mS_unblockUser.TabIndex = 10;
            this.mS_unblockUser.Text = "mS_unblockUser";
            this.mS_unblockUser.Visible = false;
            // 
            // TS_unblockUser
            // 
            this.TS_unblockUser.Name = "TS_unblockUser";
            this.TS_unblockUser.Size = new System.Drawing.Size(88, 19);
            this.TS_unblockUser.Text = "Unblock user";
            this.TS_unblockUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TS_unblockUser.Click += new System.EventHandler(this.ts_unblockUser_Click);
            // 
            // TS_exit
            // 
            this.TS_exit.Name = "TS_exit";
            this.TS_exit.Size = new System.Drawing.Size(37, 19);
            this.TS_exit.Text = "Exit";
            this.TS_exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TS_exit.Click += new System.EventHandler(this.ts_exit_Click);
            // 
            // mS_unblockEmail
            // 
            this.mS_unblockEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mS_unblockEmail.Dock = System.Windows.Forms.DockStyle.None;
            this.mS_unblockEmail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unblockEmailToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mS_unblockEmail.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.mS_unblockEmail.Location = new System.Drawing.Point(383, 177);
            this.mS_unblockEmail.Name = "mS_unblockEmail";
            this.mS_unblockEmail.Padding = new System.Windows.Forms.Padding(0);
            this.mS_unblockEmail.Size = new System.Drawing.Size(95, 38);
            this.mS_unblockEmail.TabIndex = 11;
            this.mS_unblockEmail.Text = "mS_unblockEmail";
            this.mS_unblockEmail.Visible = false;
            // 
            // unblockEmailToolStripMenuItem
            // 
            this.unblockEmailToolStripMenuItem.Name = "unblockEmailToolStripMenuItem";
            this.unblockEmailToolStripMenuItem.Size = new System.Drawing.Size(95, 19);
            this.unblockEmailToolStripMenuItem.Text = "Unblock Email";
            this.unblockEmailToolStripMenuItem.Click += new System.EventHandler(this.ts_unblockEmail_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ts_exit_Click);
            // 
            // mS_setPassword
            // 
            this.mS_setPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mS_setPassword.Dock = System.Windows.Forms.DockStyle.None;
            this.mS_setPassword.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nastavitHesloProToolStripMenuItem,
            this.toolStripTextBox2,
            this.exitToolStripMenuItem1});
            this.mS_setPassword.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.mS_setPassword.Location = new System.Drawing.Point(361, 392);
            this.mS_setPassword.Name = "mS_setPassword";
            this.mS_setPassword.Padding = new System.Windows.Forms.Padding(0);
            this.mS_setPassword.Size = new System.Drawing.Size(117, 61);
            this.mS_setPassword.TabIndex = 12;
            this.mS_setPassword.Text = "mS_setPassword";
            this.mS_setPassword.Visible = false;
            // 
            // nastavitHesloProToolStripMenuItem
            // 
            this.nastavitHesloProToolStripMenuItem.Name = "nastavitHesloProToolStripMenuItem";
            this.nastavitHesloProToolStripMenuItem.Size = new System.Drawing.Size(117, 19);
            this.nastavitHesloProToolStripMenuItem.Text = "Nastavit heslo pro ";
            this.nastavitHesloProToolStripMenuItem.Click += new System.EventHandler(this.ts_setPassword_Click);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(37, 19);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ts_exit_Click);
            // 
            // pb_DepartmentCheck
            // 
            this.pb_DepartmentCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_DepartmentCheck.BackColor = System.Drawing.Color.Transparent;
            this.pb_DepartmentCheck.Image = global::MonitoringTool.Properties.Resources.icon_R;
            this.pb_DepartmentCheck.Location = new System.Drawing.Point(671, 31);
            this.pb_DepartmentCheck.Name = "pb_DepartmentCheck";
            this.pb_DepartmentCheck.Size = new System.Drawing.Size(15, 15);
            this.pb_DepartmentCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_DepartmentCheck.TabIndex = 13;
            this.pb_DepartmentCheck.TabStop = false;
            // 
            // pb_LockedOutAccount
            // 
            this.pb_LockedOutAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_LockedOutAccount.Image = ((System.Drawing.Image)(resources.GetObject("pb_LockedOutAccount.Image")));
            this.pb_LockedOutAccount.Location = new System.Drawing.Point(458, 31);
            this.pb_LockedOutAccount.Name = "pb_LockedOutAccount";
            this.pb_LockedOutAccount.Size = new System.Drawing.Size(15, 15);
            this.pb_LockedOutAccount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_LockedOutAccount.TabIndex = 13;
            this.pb_LockedOutAccount.TabStop = false;
            // 
            // pb_LockedOutEmails
            // 
            this.pb_LockedOutEmails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_LockedOutEmails.Image = ((System.Drawing.Image)(resources.GetObject("pb_LockedOutEmails.Image")));
            this.pb_LockedOutEmails.Location = new System.Drawing.Point(458, 134);
            this.pb_LockedOutEmails.Name = "pb_LockedOutEmails";
            this.pb_LockedOutEmails.Size = new System.Drawing.Size(15, 15);
            this.pb_LockedOutEmails.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_LockedOutEmails.TabIndex = 13;
            this.pb_LockedOutEmails.TabStop = false;
            // 
            // pb_ExpiredPasswords
            // 
            this.pb_ExpiredPasswords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_ExpiredPasswords.Image = ((System.Drawing.Image)(resources.GetObject("pb_ExpiredPasswords.Image")));
            this.pb_ExpiredPasswords.Location = new System.Drawing.Point(458, 241);
            this.pb_ExpiredPasswords.Name = "pb_ExpiredPasswords";
            this.pb_ExpiredPasswords.Size = new System.Drawing.Size(15, 15);
            this.pb_ExpiredPasswords.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_ExpiredPasswords.TabIndex = 13;
            this.pb_ExpiredPasswords.TabStop = false;
            // 
            // pb_LockedOutOldList
            // 
            this.pb_LockedOutOldList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_LockedOutOldList.Image = global::MonitoringTool.Properties.Resources.icon_R;
            this.pb_LockedOutOldList.Location = new System.Drawing.Point(246, 86);
            this.pb_LockedOutOldList.Name = "pb_LockedOutOldList";
            this.pb_LockedOutOldList.Size = new System.Drawing.Size(15, 15);
            this.pb_LockedOutOldList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_LockedOutOldList.TabIndex = 13;
            this.pb_LockedOutOldList.TabStop = false;
            // 
            // pb_CheckEmailsToSend
            // 
            this.pb_CheckEmailsToSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_CheckEmailsToSend.Image = global::MonitoringTool.Properties.Resources.icon_R;
            this.pb_CheckEmailsToSend.Location = new System.Drawing.Point(246, 55);
            this.pb_CheckEmailsToSend.Name = "pb_CheckEmailsToSend";
            this.pb_CheckEmailsToSend.Size = new System.Drawing.Size(15, 15);
            this.pb_CheckEmailsToSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_CheckEmailsToSend.TabIndex = 13;
            this.pb_CheckEmailsToSend.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 517);
            this.Controls.Add(this.pb_CheckEmailsToSend);
            this.Controls.Add(this.pb_LockedOutOldList);
            this.Controls.Add(this.pb_ExpiredPasswords);
            this.Controls.Add(this.pb_LockedOutEmails);
            this.Controls.Add(this.pb_LockedOutAccount);
            this.Controls.Add(this.pb_DepartmentCheck);
            this.Controls.Add(this.mS_setPassword);
            this.Controls.Add(this.mS_unblockUser);
            this.Controls.Add(this.mS_unblockEmail);
            this.Controls.Add(this.tb_numberOfEmails);
            this.Controls.Add(this.bRefresh_CheckEmailsToSend);
            this.Controls.Add(this.lv_LockedOutOldList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tv_ExpiredPasswords);
            this.Controls.Add(this.tv_LockedOutEmails);
            this.Controls.Add(this.tv_LockedOutAccount);
            this.Controls.Add(this.lLog);
            this.Controls.Add(this.tv_DepartmentCheck);
            this.Controls.Add(this.bRefresh_ExpiredPasswords);
            this.Controls.Add(this.bTimer);
            this.Controls.Add(this.bRefresh_LockedOutEmails);
            this.Controls.Add(this.bRefresh_LockedOutOldList);
            this.Controls.Add(this.bRefresh_LockedOutAccount);
            this.Controls.Add(this.bRefresh_DepartmentCheck);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Monitoring Tool";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mS_unblockUser.ResumeLayout(false);
            this.mS_unblockUser.PerformLayout();
            this.mS_unblockEmail.ResumeLayout(false);
            this.mS_unblockEmail.PerformLayout();
            this.mS_setPassword.ResumeLayout(false);
            this.mS_setPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_DepartmentCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_LockedOutAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_LockedOutEmails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ExpiredPasswords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_LockedOutOldList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CheckEmailsToSend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TsMiSetInterval;
        private System.Windows.Forms.ToolStripTextBox TsTbTimerInterval;
        private System.Windows.Forms.Button bRefresh_DepartmentCheck;
        private System.Windows.Forms.TreeView tv_DepartmentCheck;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lLog;
        private System.Windows.Forms.TreeView tv_LockedOutAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bRefresh_LockedOutAccount;
        private System.Windows.Forms.Button bRefresh_LockedOutEmails;
        private System.Windows.Forms.TreeView tv_LockedOutEmails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListView lv_LockedOutOldList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bRefresh_LockedOutOldList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button bRefresh_ExpiredPasswords;
        private System.Windows.Forms.TreeView tv_ExpiredPasswords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bRefresh_CheckEmailsToSend;
        private System.Windows.Forms.TextBox tb_numberOfEmails;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem TS_unblockUser;
        private System.Windows.Forms.MenuStrip mS_unblockUser;
        private System.Windows.Forms.ToolStripMenuItem TS_exit;
        private System.Windows.Forms.MenuStrip mS_unblockEmail;
        private System.Windows.Forms.ToolStripMenuItem unblockEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mS_setPassword;
        private System.Windows.Forms.ToolStripMenuItem nastavitHesloProToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.PictureBox pb_LockedOutAccount;
        private System.Windows.Forms.PictureBox pb_LockedOutEmails;
        private System.Windows.Forms.PictureBox pb_ExpiredPasswords;
        private System.Windows.Forms.PictureBox pb_LockedOutOldList;
        private System.Windows.Forms.PictureBox pb_DepartmentCheck;
        private System.Windows.Forms.PictureBox pb_CheckEmailsToSend;
        private System.Windows.Forms.ToolStripMenuItem TsMiLoadCustomDepartment;
        private System.Windows.Forms.ToolStripMenuItem TsMiCreateTestDepartments;
    }
}

