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
            this.toolStripButton_timer = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_AddAccount = new System.Windows.Forms.ToolStripButton();
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_active = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_email = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_balance = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_lastLogin = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStripLabel_title = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_Font = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_FontDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_FontUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_timer,
            this.toolStripLabel_title,
            this.toolStripButton_Font,
            this.toolStripSeparator2,
            this.toolStripButton_FontUp,
            this.toolStripSeparator3,
            this.toolStripButton_FontDown,
            this.toolStripSeparator1,
            this.toolStripButton_AddAccount});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(612, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
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
            // toolStripButton_AddAccount
            // 
            this.toolStripButton_AddAccount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_AddAccount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_AddAccount.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddAccount.Image")));
            this.toolStripButton_AddAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddAccount.Name = "toolStripButton_AddAccount";
            this.toolStripButton_AddAccount.Size = new System.Drawing.Size(81, 22);
            this.toolStripButton_AddAccount.Text = "Add Account";
            this.toolStripButton_AddAccount.Click += new System.EventHandler(this.toolStripButton_AddAccount_Click);
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_active);
            this.listView.AllColumns.Add(this.column_email);
            this.listView.AllColumns.Add(this.column_balance);
            this.listView.AllColumns.Add(this.column_lastLogin);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_active,
            this.column_email,
            this.column_balance,
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
            this.listView.Size = new System.Drawing.Size(612, 332);
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
            // toolStripLabel_title
            // 
            this.toolStripLabel_title.Name = "toolStripLabel_title";
            this.toolStripLabel_title.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel_title.Text = "TITLE";
            // 
            // toolStripButton_Font
            // 
            this.toolStripButton_Font.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_Font.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Font.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Font.Image")));
            this.toolStripButton_Font.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Font.Name = "toolStripButton_Font";
            this.toolStripButton_Font.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Font.Text = "FONT";
            this.toolStripButton_Font.Click += new System.EventHandler(this.toolStripButton_Font_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_FontDown
            // 
            this.toolStripButton_FontDown.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_FontDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_FontDown.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton_FontDown.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_FontDown.Image")));
            this.toolStripButton_FontDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_FontDown.Name = "toolStripButton_FontDown";
            this.toolStripButton_FontDown.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_FontDown.Text = "-";
            this.toolStripButton_FontDown.ToolTipText = "Decrease Font Size";
            this.toolStripButton_FontDown.Click += new System.EventHandler(this.toolStripButton_FontDown_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_FontUp
            // 
            this.toolStripButton_FontUp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_FontUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_FontUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton_FontUp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_FontUp.Image")));
            this.toolStripButton_FontUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_FontUp.Name = "toolStripButton_FontUp";
            this.toolStripButton_FontUp.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_FontUp.Text = "+";
            this.toolStripButton_FontUp.ToolTipText = "Increase Font Size";
            this.toolStripButton_FontUp.Click += new System.EventHandler(this.toolStripButton_FontUp_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // EarnGGManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip);
            this.Name = "EarnGGManagerControl";
            this.Size = new System.Drawing.Size(612, 357);
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
        private System.Windows.Forms.ToolStripButton toolStripButton_AddAccount;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_title;
        private System.Windows.Forms.ToolStripButton toolStripButton_Font;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_FontDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_FontUp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.FontDialog fontDialog;
    }
}
