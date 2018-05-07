namespace TwEX_API.Controls
{
    partial class EarnGGManagerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EarnGGManagerControl));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton_menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_font = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontIncrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontDecrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_AddAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_update = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_timer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_title = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_toggleHeight = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_total = new System.Windows.Forms.ToolStripLabel();
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_active = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_email = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_balance = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_lastLogin = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_lastIP = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_menu,
            this.toolStripSeparator1,
            this.toolStripButton_timer,
            this.toolStripSeparator2,
            this.toolStripLabel_title,
            this.toolStripButton_toggleHeight,
            this.toolStripSeparator3,
            this.toolStripLabel_total});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(608, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripDropDownButton_menu
            // 
            this.toolStripDropDownButton_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_font,
            this.toolStripMenuItem_fontIncrease,
            this.toolStripMenuItem_fontDecrease,
            this.toolStripSeparator5,
            this.toolStripMenuItem_AddAccount,
            this.toolStripSeparator4,
            this.toolStripMenuItem_update});
            this.toolStripDropDownButton_menu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_menu.Image")));
            this.toolStripDropDownButton_menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_menu.Name = "toolStripDropDownButton_menu";
            this.toolStripDropDownButton_menu.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton_menu.Text = "OPTIONS";
            this.toolStripDropDownButton_menu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_menu_DropDownItemClicked);
            // 
            // toolStripMenuItem_font
            // 
            this.toolStripMenuItem_font.Name = "toolStripMenuItem_font";
            this.toolStripMenuItem_font.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_font.Tag = "Font";
            this.toolStripMenuItem_font.Text = "Font";
            // 
            // toolStripMenuItem_fontIncrease
            // 
            this.toolStripMenuItem_fontIncrease.Name = "toolStripMenuItem_fontIncrease";
            this.toolStripMenuItem_fontIncrease.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_fontIncrease.Tag = "FontIncrease";
            this.toolStripMenuItem_fontIncrease.Text = "Increase Font";
            // 
            // toolStripMenuItem_fontDecrease
            // 
            this.toolStripMenuItem_fontDecrease.Name = "toolStripMenuItem_fontDecrease";
            this.toolStripMenuItem_fontDecrease.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_fontDecrease.Tag = "FontDecrease";
            this.toolStripMenuItem_fontDecrease.Text = "Decrease Font";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripMenuItem_AddAccount
            // 
            this.toolStripMenuItem_AddAccount.Name = "toolStripMenuItem_AddAccount";
            this.toolStripMenuItem_AddAccount.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_AddAccount.Tag = "AddAccount";
            this.toolStripMenuItem_AddAccount.Text = "Add Account";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripMenuItem_update
            // 
            this.toolStripMenuItem_update.Name = "toolStripMenuItem_update";
            this.toolStripMenuItem_update.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_update.Tag = "Update";
            this.toolStripMenuItem_update.Text = "Update";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_timer
            // 
            this.toolStripButton_timer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_timer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_timer.Image")));
            this.toolStripButton_timer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_timer.Name = "toolStripButton_timer";
            this.toolStripButton_timer.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_timer.Tag = "EARNGG";
            this.toolStripButton_timer.Text = "TIMER";
            this.toolStripButton_timer.Click += new System.EventHandler(this.toolStripButton_timer_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_title
            // 
            this.toolStripLabel_title.Name = "toolStripLabel_title";
            this.toolStripLabel_title.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel_title.Text = "TITLE";
            // 
            // toolStripButton_toggleHeight
            // 
            this.toolStripButton_toggleHeight.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_toggleHeight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_toggleHeight.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_toggleHeight.Image")));
            this.toolStripButton_toggleHeight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_toggleHeight.Name = "toolStripButton_toggleHeight";
            this.toolStripButton_toggleHeight.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_toggleHeight.Text = "Toggle Height";
            this.toolStripButton_toggleHeight.Click += new System.EventHandler(this.toolStripButton_toggleHeight_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_total
            // 
            this.toolStripLabel_total.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_total.Name = "toolStripLabel_total";
            this.toolStripLabel_total.Size = new System.Drawing.Size(19, 22);
            this.toolStripLabel_total.Text = "$0";
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_active);
            this.listView.AllColumns.Add(this.column_email);
            this.listView.AllColumns.Add(this.column_balance);
            this.listView.AllColumns.Add(this.column_lastIP);
            this.listView.AllColumns.Add(this.column_lastLogin);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_active,
            this.column_email,
            this.column_balance,
            this.column_lastIP,
            this.column_lastLogin});
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HasCollapsibleGroups = false;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 25);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(608, 328);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 5;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            // 
            // column_active
            // 
            this.column_active.AspectName = "";
            this.column_active.MinimumWidth = 24;
            this.column_active.Text = "";
            this.column_active.Width = 24;
            // 
            // column_email
            // 
            this.column_email.AspectName = "email";
            this.column_email.Text = "Email";
            // 
            // column_balance
            // 
            this.column_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_lastLogin
            // 
            this.column_lastLogin.AspectName = "lastLogin";
            this.column_lastLogin.FillsFreeSpace = true;
            this.column_lastLogin.Text = "Last Login";
            // 
            // column_lastIP
            // 
            this.column_lastIP.AspectName = "lastIP";
            // 
            // EarnGGManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip);
            this.Name = "EarnGGManagerControl";
            this.Size = new System.Drawing.Size(608, 353);
            this.Load += new System.EventHandler(this.EarnGGManagerControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton_timer;
        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_active;
        private BrightIdeasSoftware.OLVColumn column_email;
        private BrightIdeasSoftware.OLVColumn column_balance;
        private BrightIdeasSoftware.OLVColumn column_lastLogin;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_title;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_font;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontIncrease;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontDecrease;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddAccount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_update;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_total;
        private System.Windows.Forms.ToolStripButton toolStripButton_toggleHeight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private BrightIdeasSoftware.OLVColumn column_lastIP;
    }
}
