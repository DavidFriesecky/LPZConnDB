namespace LPZConnDB
{
    partial class FormMain
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelConnBtns = new System.Windows.Forms.Panel();
            this.panelAdminBtns = new System.Windows.Forms.Panel();
            this.btnPasswd = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogIO = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvIniFiles = new System.Windows.Forms.DataGridView();
            this.IniName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControllContent = new System.Windows.Forms.DataGridViewButtonColumn();
            this.iniNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceIniFiles = new System.Windows.Forms.BindingSource(this.components);
            this.panelAdminBtns.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIniFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceIniFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // panelConnBtns
            // 
            resources.ApplyResources(this.panelConnBtns, "panelConnBtns");
            this.panelConnBtns.Name = "panelConnBtns";
            // 
            // panelAdminBtns
            // 
            this.panelAdminBtns.Controls.Add(this.btnPasswd);
            this.panelAdminBtns.Controls.Add(this.btnAdd);
            this.panelAdminBtns.Controls.Add(this.btnDelete);
            this.panelAdminBtns.Controls.Add(this.btnEdit);
            resources.ApplyResources(this.panelAdminBtns, "panelAdminBtns");
            this.panelAdminBtns.Name = "panelAdminBtns";
            // 
            // btnPasswd
            // 
            resources.ApplyResources(this.btnPasswd, "btnPasswd");
            this.btnPasswd.Name = "btnPasswd";
            this.btnPasswd.UseVisualStyleBackColor = true;
            this.btnPasswd.Click += new System.EventHandler(this.btnPasswd_Click);
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSetting});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // menuSetting
            // 
            this.menuSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLogIO,
            this.menuEnd});
            this.menuSetting.Name = "menuSetting";
            resources.ApplyResources(this.menuSetting, "menuSetting");
            // 
            // menuLogIO
            // 
            this.menuLogIO.Name = "menuLogIO";
            resources.ApplyResources(this.menuLogIO, "menuLogIO");
            this.menuLogIO.Click += new System.EventHandler(this.menuLogIO_Click);
            // 
            // menuEnd
            // 
            this.menuEnd.Name = "menuEnd";
            resources.ApplyResources(this.menuEnd, "menuEnd");
            this.menuEnd.Click += new System.EventHandler(this.menuEnd_Click);
            // 
            // dgvIniFiles
            // 
            this.dgvIniFiles.AllowUserToResizeColumns = false;
            this.dgvIniFiles.AllowUserToResizeRows = false;
            this.dgvIniFiles.AutoGenerateColumns = false;
            this.dgvIniFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIniFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIniFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IniName,
            this.ControllContent,
            this.iniNameDataGridViewTextBoxColumn1,
            this.contentDataGridViewTextBoxColumn1});
            this.dgvIniFiles.DataSource = this.sourceIniFiles;
            resources.ApplyResources(this.dgvIniFiles, "dgvIniFiles");
            this.dgvIniFiles.MultiSelect = false;
            this.dgvIniFiles.Name = "dgvIniFiles";
            this.dgvIniFiles.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIniFiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIniFiles_CellContentClick);
            this.dgvIniFiles.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvIniFiles_UserDeletingRow);
            // 
            // IniName
            // 
            this.IniName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IniName.DataPropertyName = "IniName";
            this.IniName.FillWeight = 159.3909F;
            resources.ApplyResources(this.IniName, "IniName");
            this.IniName.Name = "IniName";
            this.IniName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ControllContent
            // 
            this.ControllContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ControllContent.FillWeight = 40F;
            resources.ApplyResources(this.ControllContent, "ControllContent");
            this.ControllContent.Name = "ControllContent";
            this.ControllContent.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ControllContent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // iniNameDataGridViewTextBoxColumn1
            // 
            this.iniNameDataGridViewTextBoxColumn1.DataPropertyName = "IniName";
            resources.ApplyResources(this.iniNameDataGridViewTextBoxColumn1, "iniNameDataGridViewTextBoxColumn1");
            this.iniNameDataGridViewTextBoxColumn1.Name = "iniNameDataGridViewTextBoxColumn1";
            // 
            // contentDataGridViewTextBoxColumn1
            // 
            this.contentDataGridViewTextBoxColumn1.DataPropertyName = "Content";
            resources.ApplyResources(this.contentDataGridViewTextBoxColumn1, "contentDataGridViewTextBoxColumn1");
            this.contentDataGridViewTextBoxColumn1.Name = "contentDataGridViewTextBoxColumn1";
            // 
            // sourceIniFiles
            // 
            this.sourceIniFiles.DataSource = typeof(LPZConnDB.src_data.ConnIniFile);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.panelAdminBtns);
            this.Controls.Add(this.panelConnBtns);
            this.Controls.Add(this.dgvIniFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.panelAdminBtns.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIniFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceIniFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelConnBtns;
        private System.Windows.Forms.Panel panelAdminBtns;
        private System.Windows.Forms.Button btnPasswd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuSetting;
        private System.Windows.Forms.ToolStripMenuItem menuLogIO;
        private System.Windows.Forms.ToolStripMenuItem menuEnd;
        private System.Windows.Forms.BindingSource sourceIniFiles;
        private System.Windows.Forms.DataGridView dgvIniFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn IniName;
        private System.Windows.Forms.DataGridViewButtonColumn ControllContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn iniNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentDataGridViewTextBoxColumn1;
    }
}

