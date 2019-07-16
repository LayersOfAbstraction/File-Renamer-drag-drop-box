namespace UI
{
    partial class frmSettings
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mmuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mmuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.gvSettings = new System.Windows.Forms.DataGridView();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this._dclColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dclColumnData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(408, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmuNew,
            this.mnuOpen,
            this.mmuSaveAs,
            this.mnuQuit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mmuNew
            // 
            this.mmuNew.Name = "mmuNew";
            this.mmuNew.Size = new System.Drawing.Size(146, 22);
            this.mmuNew.Text = "&New";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(146, 22);
            this.mnuOpen.Text = "&Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mmuSaveAs
            // 
            this.mmuSaveAs.Name = "mmuSaveAs";
            this.mmuSaveAs.Size = new System.Drawing.Size(146, 22);
            this.mmuSaveAs.Text = "&Save As...";
            this.mmuSaveAs.Click += new System.EventHandler(this.mmuSaveAs_Click);
            // 
            // mnuQuit
            // 
            this.mnuQuit.Name = "mnuQuit";
            this.mnuQuit.Size = new System.Drawing.Size(146, 22);
            this.mnuQuit.Text = "&Quit Program";
            this.mnuQuit.Click += new System.EventHandler(this.mnuQuit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(322, 218);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gvSettings
            // 
            this.gvSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._dclColumnDescription,
            this._dclColumnData});
            this.gvSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gvSettings.Location = new System.Drawing.Point(0, 246);
            this.gvSettings.Name = "gvSettings";
            this.gvSettings.Size = new System.Drawing.Size(408, 293);
            this.gvSettings.TabIndex = 3;
            this.gvSettings.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSettings_CellEndEdit);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Bradley Hand ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(9, 24);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(79, 19);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "lblMessage";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(13, 220);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(303, 20);
            this.txtFilePath.TabIndex = 5;
            // 
            // _dclColumnDescription
            // 
            this._dclColumnDescription.DataPropertyName = "Description";
            this._dclColumnDescription.HeaderText = "Description";
            this._dclColumnDescription.Name = "_dclColumnDescription";
            this._dclColumnDescription.Width = 185;
            // 
            // _dclColumnData
            // 
            this._dclColumnData.DataPropertyName = "Data";
            this._dclColumnData.HeaderText = "Data";
            this._dclColumnData.Name = "_dclColumnData";
            this._dclColumnData.Width = 180;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(408, 539);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.gvSettings);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mmuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mmuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnuQuit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView gvSettings;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dclColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dclColumnData;
    }
}