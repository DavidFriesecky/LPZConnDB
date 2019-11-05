namespace LPZConnDB
{
    partial class FormDataItem
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
            this.gbProperties = new System.Windows.Forms.GroupBox();
            this.dgvProperties = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbModules = new System.Windows.Forms.GroupBox();
            this.dgvModules = new System.Windows.Forms.DataGridView();
            this.ModuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbModProperties = new System.Windows.Forms.GroupBox();
            this.dgvModuleProperties = new System.Windows.Forms.DataGridView();
            this.sourceModuleProperties = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ModuleProperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceModules = new System.Windows.Forms.BindingSource(this.components);
            this.moduleNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceProperties = new System.Windows.Forms.BindingSource(this.components);
            this.gbProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).BeginInit();
            this.gbModules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModules)).BeginInit();
            this.gbModProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModuleProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceModuleProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceModules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // gbProperties
            // 
            this.gbProperties.Controls.Add(this.dgvProperties);
            this.gbProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbProperties.Location = new System.Drawing.Point(12, 12);
            this.gbProperties.Name = "gbProperties";
            this.gbProperties.Size = new System.Drawing.Size(500, 200);
            this.gbProperties.TabIndex = 2;
            this.gbProperties.TabStop = false;
            this.gbProperties.Text = "Parametry";
            // 
            // dgvProperties
            // 
            this.dgvProperties.AllowUserToOrderColumns = true;
            this.dgvProperties.AllowUserToResizeColumns = false;
            this.dgvProperties.AllowUserToResizeRows = false;
            this.dgvProperties.AutoGenerateColumns = false;
            this.dgvProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Value,
            this.keyDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.dgvProperties.DataSource = this.sourceProperties;
            this.dgvProperties.Location = new System.Drawing.Point(6, 19);
            this.dgvProperties.MultiSelect = false;
            this.dgvProperties.Name = "dgvProperties";
            this.dgvProperties.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProperties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvProperties.Size = new System.Drawing.Size(488, 175);
            this.dgvProperties.TabIndex = 6;
            this.dgvProperties.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProperties_CellEndEdit);
            this.dgvProperties.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProperties_CellEnter);
            this.dgvProperties.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProperties_CellLeave);
            this.dgvProperties.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvProperties_CellValidating);
            this.dgvProperties.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvProperties_UserDeletingRow);
            // 
            // Key
            // 
            this.Key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Key.DataPropertyName = "Key";
            this.Key.HeaderText = "Název";
            this.Key.Name = "Key";
            this.Key.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.DataPropertyName = "Value";
            this.Value.HeaderText = "Hodnota";
            this.Value.Name = "Value";
            this.Value.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // gbModules
            // 
            this.gbModules.Controls.Add(this.dgvModules);
            this.gbModules.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbModules.Location = new System.Drawing.Point(12, 218);
            this.gbModules.Name = "gbModules";
            this.gbModules.Size = new System.Drawing.Size(500, 200);
            this.gbModules.TabIndex = 4;
            this.gbModules.TabStop = false;
            this.gbModules.Text = "Moduly";
            // 
            // dgvModules
            // 
            this.dgvModules.AllowUserToResizeColumns = false;
            this.dgvModules.AllowUserToResizeRows = false;
            this.dgvModules.AutoGenerateColumns = false;
            this.dgvModules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvModules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModuleName,
            this.moduleNameDataGridViewTextBoxColumn});
            this.dgvModules.DataSource = this.sourceModules;
            this.dgvModules.Location = new System.Drawing.Point(6, 19);
            this.dgvModules.MultiSelect = false;
            this.dgvModules.Name = "dgvModules";
            this.dgvModules.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvModules.Size = new System.Drawing.Size(488, 175);
            this.dgvModules.TabIndex = 7;
            this.dgvModules.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModules_CellClick);
            this.dgvModules.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModules_CellEndEdit);
            this.dgvModules.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvModules_CellValidating);
            // 
            // ModuleName
            // 
            this.ModuleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ModuleName.DataPropertyName = "ModuleName";
            this.ModuleName.HeaderText = "Název";
            this.ModuleName.Name = "ModuleName";
            this.ModuleName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // gbModProperties
            // 
            this.gbModProperties.Controls.Add(this.dgvModuleProperties);
            this.gbModProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbModProperties.Location = new System.Drawing.Point(12, 424);
            this.gbModProperties.Name = "gbModProperties";
            this.gbModProperties.Size = new System.Drawing.Size(500, 200);
            this.gbModProperties.TabIndex = 5;
            this.gbModProperties.TabStop = false;
            this.gbModProperties.Text = "Parametry modulu";
            // 
            // dgvModuleProperties
            // 
            this.dgvModuleProperties.AllowUserToResizeColumns = false;
            this.dgvModuleProperties.AllowUserToResizeRows = false;
            this.dgvModuleProperties.AutoGenerateColumns = false;
            this.dgvModuleProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvModuleProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModuleProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModuleProperty});
            this.dgvModuleProperties.DataSource = this.sourceModuleProperties;
            this.dgvModuleProperties.Enabled = false;
            this.dgvModuleProperties.Location = new System.Drawing.Point(6, 19);
            this.dgvModuleProperties.MultiSelect = false;
            this.dgvModuleProperties.Name = "dgvModuleProperties";
            this.dgvModuleProperties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvModuleProperties.Size = new System.Drawing.Size(488, 175);
            this.dgvModuleProperties.TabIndex = 7;
            this.dgvModuleProperties.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModuleProperties_CellEndEdit);
            this.dgvModuleProperties.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvModuleProperties_CellValidating);
            // 
            // sourceModuleProperties
            // 
            this.sourceModuleProperties.DataMember = "Properties";
            this.sourceModuleProperties.DataSource = this.sourceModules;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(314, 630);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Uložit";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(416, 630);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Zrušit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ModuleProperty
            // 
            this.ModuleProperty.DataPropertyName = "ModuleProperty";
            this.ModuleProperty.HeaderText = "Parametr";
            this.ModuleProperty.Name = "ModuleProperty";
            // 
            // sourceModules
            // 
            this.sourceModules.DataSource = typeof(LPZConnDB.src_data.ConnModule);
            // 
            // moduleNameDataGridViewTextBoxColumn
            // 
            this.moduleNameDataGridViewTextBoxColumn.DataPropertyName = "ModuleName";
            this.moduleNameDataGridViewTextBoxColumn.HeaderText = "ModuleName";
            this.moduleNameDataGridViewTextBoxColumn.Name = "moduleNameDataGridViewTextBoxColumn";
            this.moduleNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // keyDataGridViewTextBoxColumn
            // 
            this.keyDataGridViewTextBoxColumn.DataPropertyName = "Key";
            this.keyDataGridViewTextBoxColumn.HeaderText = "Key";
            this.keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
            this.keyDataGridViewTextBoxColumn.Visible = false;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.Visible = false;
            // 
            // sourceProperties
            // 
            this.sourceProperties.DataSource = typeof(LPZConnDB.src_data.ConnProperty);
            // 
            // FormDataItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 677);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbModProperties);
            this.Controls.Add(this.gbModules);
            this.Controls.Add(this.gbProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormDataItem";
            this.Text = "FormDataItem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDataItem_FormClosing);
            this.gbProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).EndInit();
            this.gbModules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModules)).EndInit();
            this.gbModProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModuleProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceModuleProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceModules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceProperties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbProperties;
        private System.Windows.Forms.GroupBox gbModules;
        private System.Windows.Forms.GroupBox gbModProperties;
        private System.Windows.Forms.DataGridView dgvProperties;
        private System.Windows.Forms.DataGridView dgvModules;
        private System.Windows.Forms.DataGridView dgvModuleProperties;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.BindingSource sourceProperties;
        private System.Windows.Forms.BindingSource sourceModules;
        private System.Windows.Forms.BindingSource sourceModuleProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleProperty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduleNameDataGridViewTextBoxColumn;
    }
}