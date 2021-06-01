
namespace TicketManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAssigned = new System.Windows.Forms.Label();
            this.lblInProgress = new System.Windows.Forms.Label();
            this.lblCompleted = new System.Windows.Forms.Label();
            this.lblNeedToStart = new System.Windows.Forms.Label();
            this.lblAnalysis = new System.Windows.Forms.Label();
            this.lblWaiting = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ticketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.rbComments = new System.Windows.Forms.RadioButton();
            this.btnSearchKeyWord = new System.Windows.Forms.Button();
            this.rbTicketNo = new System.Windows.Forms.RadioButton();
            this.btnDateFilter = new System.Windows.Forms.Button();
            this.dtpCompltdTo = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpCompltdFrom = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTimeStamp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnShowObjects = new System.Windows.Forms.Button();
            this.btnMail = new System.Windows.Forms.Button();
            this.btnDirectory = new System.Windows.Forms.Button();
            this.rtbComments = new System.Windows.Forms.RichTextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmbEditStatus = new System.Windows.Forms.ComboBox();
            this.txtTicketNo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.lblAssigned);
            this.groupBox1.Controls.Add(this.lblInProgress);
            this.groupBox1.Controls.Add(this.lblCompleted);
            this.groupBox1.Controls.Add(this.lblNeedToStart);
            this.groupBox1.Controls.Add(this.lblAnalysis);
            this.groupBox1.Controls.Add(this.lblWaiting);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1659, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summary";
            // 
            // lblAssigned
            // 
            this.lblAssigned.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAssigned.AutoSize = true;
            this.lblAssigned.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssigned.Location = new System.Drawing.Point(634, 15);
            this.lblAssigned.Name = "lblAssigned";
            this.lblAssigned.Size = new System.Drawing.Size(23, 28);
            this.lblAssigned.TabIndex = 5;
            this.lblAssigned.Text = "0";
            // 
            // lblInProgress
            // 
            this.lblInProgress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblInProgress.AutoSize = true;
            this.lblInProgress.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInProgress.Location = new System.Drawing.Point(880, 15);
            this.lblInProgress.Name = "lblInProgress";
            this.lblInProgress.Size = new System.Drawing.Size(23, 28);
            this.lblInProgress.TabIndex = 6;
            this.lblInProgress.Text = "0";
            // 
            // lblCompleted
            // 
            this.lblCompleted.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCompleted.AutoSize = true;
            this.lblCompleted.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleted.Location = new System.Drawing.Point(408, 15);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(23, 28);
            this.lblCompleted.TabIndex = 4;
            this.lblCompleted.Text = "0";
            // 
            // lblNeedToStart
            // 
            this.lblNeedToStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNeedToStart.AutoSize = true;
            this.lblNeedToStart.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNeedToStart.Location = new System.Drawing.Point(1150, 15);
            this.lblNeedToStart.Name = "lblNeedToStart";
            this.lblNeedToStart.Size = new System.Drawing.Size(23, 28);
            this.lblNeedToStart.TabIndex = 7;
            this.lblNeedToStart.Text = "0";
            // 
            // lblAnalysis
            // 
            this.lblAnalysis.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAnalysis.AutoSize = true;
            this.lblAnalysis.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnalysis.Location = new System.Drawing.Point(1347, 15);
            this.lblAnalysis.Name = "lblAnalysis";
            this.lblAnalysis.Size = new System.Drawing.Size(23, 28);
            this.lblAnalysis.TabIndex = 8;
            this.lblAnalysis.Text = "0";
            // 
            // lblWaiting
            // 
            this.lblWaiting.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWaiting.AutoSize = true;
            this.lblWaiting.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaiting.Location = new System.Drawing.Point(1535, 15);
            this.lblWaiting.Name = "lblWaiting";
            this.lblWaiting.Size = new System.Drawing.Size(23, 28);
            this.lblWaiting.TabIndex = 9;
            this.lblWaiting.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(1446, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 25);
            this.label7.TabIndex = 9;
            this.label7.Text = "Waiting:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(1254, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Analysis:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(763, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "In Progress:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(290, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Completed:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(1011, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Need to Start:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(532, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Assigned:";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(156, 15);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(23, 28);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(83, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ticketsToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.settingsToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1690, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ticketsToolStripMenuItem
            // 
            this.ticketsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.ticketsToolStripMenuItem.Name = "ticketsToolStripMenuItem";
            this.ticketsToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.ticketsToolStripMenuItem.Text = "Tickets";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toExcelToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // toExcelToolStripMenuItem
            // 
            this.toExcelToolStripMenuItem.Name = "toExcelToolStripMenuItem";
            this.toExcelToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.toExcelToolStripMenuItem.Text = "to Excel";
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem1.Text = "Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.btnDateFilter);
            this.groupBox2.Controls.Add(this.dtpCompltdTo);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.dtpCompltdFrom);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmbStatusFilter);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 91);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox2.Size = new System.Drawing.Size(1659, 100);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filters";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtKeyWord);
            this.groupBox4.Controls.Add(this.rbComments);
            this.groupBox4.Controls.Add(this.btnSearchKeyWord);
            this.groupBox4.Controls.Add(this.rbTicketNo);
            this.groupBox4.ForeColor = System.Drawing.Color.Gray;
            this.groupBox4.Location = new System.Drawing.Point(1370, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(271, 80);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Keyword";
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyWord.Location = new System.Drawing.Point(6, 17);
            this.txtKeyWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(211, 30);
            this.txtKeyWord.TabIndex = 14;
            this.toolTip1.SetToolTip(this.txtKeyWord, "Enter ticket number or specific words.");
            // 
            // rbComments
            // 
            this.rbComments.AutoSize = true;
            this.rbComments.Location = new System.Drawing.Point(101, 50);
            this.rbComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbComments.Name = "rbComments";
            this.rbComments.Size = new System.Drawing.Size(95, 21);
            this.rbComments.TabIndex = 18;
            this.rbComments.TabStop = true;
            this.rbComments.Text = "Comments";
            this.rbComments.UseVisualStyleBackColor = true;
            // 
            // btnSearchKeyWord
            // 
            this.btnSearchKeyWord.BackColor = System.Drawing.Color.White;
            this.btnSearchKeyWord.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchKeyWord.Image")));
            this.btnSearchKeyWord.Location = new System.Drawing.Point(223, 17);
            this.btnSearchKeyWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearchKeyWord.Name = "btnSearchKeyWord";
            this.btnSearchKeyWord.Size = new System.Drawing.Size(43, 32);
            this.btnSearchKeyWord.TabIndex = 15;
            this.btnSearchKeyWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchKeyWord.UseVisualStyleBackColor = false;
            this.btnSearchKeyWord.Click += new System.EventHandler(this.btnSearchKeyWord_Click);
            // 
            // rbTicketNo
            // 
            this.rbTicketNo.AutoSize = true;
            this.rbTicketNo.Location = new System.Drawing.Point(9, 50);
            this.rbTicketNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbTicketNo.Name = "rbTicketNo";
            this.rbTicketNo.Size = new System.Drawing.Size(74, 21);
            this.rbTicketNo.TabIndex = 17;
            this.rbTicketNo.TabStop = true;
            this.rbTicketNo.Text = "Tickets";
            this.rbTicketNo.UseVisualStyleBackColor = true;
            // 
            // btnDateFilter
            // 
            this.btnDateFilter.BackColor = System.Drawing.Color.White;
            this.btnDateFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnDateFilter.Image")));
            this.btnDateFilter.Location = new System.Drawing.Point(763, 30);
            this.btnDateFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDateFilter.Name = "btnDateFilter";
            this.btnDateFilter.Size = new System.Drawing.Size(41, 31);
            this.btnDateFilter.TabIndex = 11;
            this.btnDateFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDateFilter.UseVisualStyleBackColor = false;
            this.btnDateFilter.Click += new System.EventHandler(this.btnDateFilter_Click);
            // 
            // dtpCompltdTo
            // 
            this.dtpCompltdTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpCompltdTo.CalendarFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCompltdTo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCompltdTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCompltdTo.Location = new System.Drawing.Point(612, 30);
            this.dtpCompltdTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpCompltdTo.Name = "dtpCompltdTo";
            this.dtpCompltdTo.Size = new System.Drawing.Size(139, 31);
            this.dtpCompltdTo.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(576, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 25);
            this.label10.TabIndex = 10;
            this.label10.Text = "to";
            // 
            // dtpCompltdFrom
            // 
            this.dtpCompltdFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpCompltdFrom.CalendarFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCompltdFrom.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCompltdFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCompltdFrom.Location = new System.Drawing.Point(429, 30);
            this.dtpCompltdFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpCompltdFrom.Name = "dtpCompltdFrom";
            this.dtpCompltdFrom.Size = new System.Drawing.Size(139, 31);
            this.dtpCompltdFrom.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(267, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 25);
            this.label9.TabIndex = 10;
            this.label9.Text = "Completed from:";
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbStatusFilter.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(86, 30);
            this.cmbStatusFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(159, 33);
            this.cmbStatusFilter.TabIndex = 11;
            this.cmbStatusFilter.SelectedValueChanged += new System.EventHandler(this.cmbStatusFilter_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(3, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "Status:";
            // 
            // dgvTickets
            // 
            this.dgvTickets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTickets.Location = new System.Drawing.Point(12, 197);
            this.dgvTickets.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.RowHeadersWidth = 51;
            this.dgvTickets.RowTemplate.Height = 24;
            this.dgvTickets.Size = new System.Drawing.Size(1659, 139);
            this.dgvTickets.TabIndex = 11;
            this.dgvTickets.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTickets_CellDoubleClick);
            this.dgvTickets.SelectionChanged += new System.EventHandler(this.dgvTickets_SelectionChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.btnTimeStamp);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnShowObjects);
            this.groupBox3.Controls.Add(this.btnMail);
            this.groupBox3.Controls.Add(this.btnDirectory);
            this.groupBox3.Controls.Add(this.rtbComments);
            this.groupBox3.Controls.Add(this.txtDescription);
            this.groupBox3.Controls.Add(this.cmbEditStatus);
            this.groupBox3.Controls.Add(this.txtTicketNo);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(12, 342);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(1659, 361);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "View/Edit";
            // 
            // btnTimeStamp
            // 
            this.btnTimeStamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTimeStamp.BackColor = System.Drawing.Color.GhostWhite;
            this.btnTimeStamp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTimeStamp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTimeStamp.Image = ((System.Drawing.Image)(resources.GetObject("btnTimeStamp.Image")));
            this.btnTimeStamp.Location = new System.Drawing.Point(63, 183);
            this.btnTimeStamp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimeStamp.Name = "btnTimeStamp";
            this.btnTimeStamp.Size = new System.Drawing.Size(53, 44);
            this.btnTimeStamp.TabIndex = 27;
            this.btnTimeStamp.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(1580, 279);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 60);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.GhostWhite;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(1580, 210);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 62);
            this.btnSave.TabIndex = 25;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnShowObjects
            // 
            this.btnShowObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowObjects.BackColor = System.Drawing.Color.White;
            this.btnShowObjects.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShowObjects.Image = ((System.Drawing.Image)(resources.GetObject("btnShowObjects.Image")));
            this.btnShowObjects.Location = new System.Drawing.Point(1580, 142);
            this.btnShowObjects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowObjects.Name = "btnShowObjects";
            this.btnShowObjects.Size = new System.Drawing.Size(61, 63);
            this.btnShowObjects.TabIndex = 24;
            this.toolTip1.SetToolTip(this.btnShowObjects, "Shows the objects related to this ticket.");
            this.btnShowObjects.UseVisualStyleBackColor = false;
            this.btnShowObjects.Click += new System.EventHandler(this.btnShowObjects_Click);
            // 
            // btnMail
            // 
            this.btnMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMail.BackColor = System.Drawing.Color.White;
            this.btnMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMail.Image = ((System.Drawing.Image)(resources.GetObject("btnMail.Image")));
            this.btnMail.Location = new System.Drawing.Point(1580, 71);
            this.btnMail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(61, 63);
            this.btnMail.TabIndex = 23;
            this.btnMail.UseVisualStyleBackColor = false;
            // 
            // btnDirectory
            // 
            this.btnDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirectory.BackColor = System.Drawing.Color.White;
            this.btnDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDirectory.Image = ((System.Drawing.Image)(resources.GetObject("btnDirectory.Image")));
            this.btnDirectory.Location = new System.Drawing.Point(1580, 11);
            this.btnDirectory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDirectory.Name = "btnDirectory";
            this.btnDirectory.Size = new System.Drawing.Size(61, 55);
            this.btnDirectory.TabIndex = 22;
            this.toolTip1.SetToolTip(this.btnDirectory, "Opens the folder related to this project.");
            this.btnDirectory.UseVisualStyleBackColor = false;
            this.btnDirectory.Click += new System.EventHandler(this.btnDirectory_Click);
            // 
            // rtbComments
            // 
            this.rtbComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbComments.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbComments.Location = new System.Drawing.Point(128, 103);
            this.rtbComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbComments.Name = "rtbComments";
            this.rtbComments.Size = new System.Drawing.Size(1416, 210);
            this.rtbComments.TabIndex = 21;
            this.rtbComments.Text = "";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(128, 63);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(1416, 31);
            this.txtDescription.TabIndex = 20;
            // 
            // cmbEditStatus
            // 
            this.cmbEditStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbEditStatus.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEditStatus.FormattingEnabled = true;
            this.cmbEditStatus.Location = new System.Drawing.Point(471, 21);
            this.cmbEditStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEditStatus.Name = "cmbEditStatus";
            this.cmbEditStatus.Size = new System.Drawing.Size(263, 33);
            this.cmbEditStatus.TabIndex = 19;
            // 
            // txtTicketNo
            // 
            this.txtTicketNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTicketNo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTicketNo.Location = new System.Drawing.Point(128, 21);
            this.txtTicketNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTicketNo.Name = "txtTicketNo";
            this.txtTicketNo.Size = new System.Drawing.Size(240, 31);
            this.txtTicketNo.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Gray;
            this.label17.Location = new System.Drawing.Point(5, 103);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 25);
            this.label17.TabIndex = 9;
            this.label17.Text = "Comments:";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Gray;
            this.label16.Location = new System.Drawing.Point(5, 63);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 25);
            this.label16.TabIndex = 8;
            this.label16.Text = "Description:";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Gray;
            this.label15.Location = new System.Drawing.Point(948, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 25);
            this.label15.TabIndex = 7;
            this.label15.Text = "Object count:";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Gray;
            this.label14.Location = new System.Drawing.Point(759, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 25);
            this.label14.TabIndex = 6;
            this.label14.Text = "Duration:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Gray;
            this.label13.Location = new System.Drawing.Point(396, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 25);
            this.label13.TabIndex = 5;
            this.label13.Text = "Status:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(5, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 25);
            this.label12.TabIndex = 4;
            this.label12.Text = "Ticket No:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStripStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 721);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1690, 26);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStripStatus
            // 
            this.lblStripStatus.Name = "lblStripStatus";
            this.lblStripStatus.Size = new System.Drawing.Size(15, 20);
            this.lblStripStatus.Text = "..";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1690, 747);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvTickets);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1533, 782);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TicketManager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAnalysis;
        private System.Windows.Forms.Label lblWaiting;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.Label lblAssigned;
        private System.Windows.Forms.Label lblInProgress;
        private System.Windows.Forms.Label lblNeedToStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpCompltdTo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpCompltdFrom;
        private System.Windows.Forms.Button btnDateFilter;
        private System.Windows.Forms.Button btnSearchKeyWord;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.RadioButton rbComments;
        private System.Windows.Forms.RadioButton rbTicketNo;
        private System.Windows.Forms.DataGridView dgvTickets;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTicketNo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbEditStatus;
        private System.Windows.Forms.RichTextBox rtbComments;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ToolStripMenuItem ticketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toExcelToolStripMenuItem;
        private System.Windows.Forms.Button btnDirectory;
        private System.Windows.Forms.Button btnMail;
        private System.Windows.Forms.Button btnShowObjects;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTimeStamp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStripStatus;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

