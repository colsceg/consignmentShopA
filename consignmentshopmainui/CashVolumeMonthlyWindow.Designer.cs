namespace ConsignmentShopMainUI
{
    partial class CashVolumeMonthlyWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.VolumeDataGridView = new System.Windows.Forms.DataGridView();
            this.DiagButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.PrintBtn = new System.Windows.Forms.Button();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesSumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provisionSumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cashVolumeMonthlyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.VolumeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashVolumeMonthlyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // VolumeDataGridView
            // 
            this.VolumeDataGridView.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.VolumeDataGridView.AllowUserToAddRows = false;
            this.VolumeDataGridView.AllowUserToDeleteRows = false;
            this.VolumeDataGridView.AllowUserToResizeColumns = false;
            this.VolumeDataGridView.AllowUserToResizeRows = false;
            this.VolumeDataGridView.AutoGenerateColumns = false;
            this.VolumeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VolumeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yearDataGridViewTextBoxColumn,
            this.monthnameDataGridViewTextBoxColumn,
            this.salesSumDataGridViewTextBoxColumn,
            this.provisionSumDataGridViewTextBoxColumn});
            this.VolumeDataGridView.DataSource = this.cashVolumeMonthlyBindingSource;
            this.VolumeDataGridView.Location = new System.Drawing.Point(27, 12);
            this.VolumeDataGridView.Name = "VolumeDataGridView";
            this.VolumeDataGridView.RowHeadersVisible = false;
            this.VolumeDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VolumeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VolumeDataGridView.Size = new System.Drawing.Size(315, 413);
            this.VolumeDataGridView.TabIndex = 1;
            // 
            // DiagButton
            // 
            this.DiagButton.Location = new System.Drawing.Point(26, 431);
            this.DiagButton.Name = "DiagButton";
            this.DiagButton.Size = new System.Drawing.Size(75, 23);
            this.DiagButton.TabIndex = 2;
            this.DiagButton.Text = "Diagramm";
            this.DiagButton.UseVisualStyleBackColor = true;
            this.DiagButton.Click += new System.EventHandler(this.DiagButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(269, 431);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "Schliessen";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // PrintBtn
            // 
            this.PrintBtn.Location = new System.Drawing.Point(107, 431);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(75, 23);
            this.PrintBtn.TabIndex = 4;
            this.PrintBtn.Text = "Drucken";
            this.PrintBtn.UseVisualStyleBackColor = true;
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // ExportBtn
            // 
            this.ExportBtn.Location = new System.Drawing.Point(188, 431);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(75, 23);
            this.ExportBtn.TabIndex = 5;
            this.ExportBtn.Text = "Exportieren";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.yearDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.yearDataGridViewTextBoxColumn.HeaderText = "Jahr";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            this.yearDataGridViewTextBoxColumn.Width = 60;
            // 
            // monthnameDataGridViewTextBoxColumn
            // 
            this.monthnameDataGridViewTextBoxColumn.DataPropertyName = "Monthname";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.monthnameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.monthnameDataGridViewTextBoxColumn.HeaderText = "Monat";
            this.monthnameDataGridViewTextBoxColumn.Name = "monthnameDataGridViewTextBoxColumn";
            this.monthnameDataGridViewTextBoxColumn.Width = 60;
            // 
            // salesSumDataGridViewTextBoxColumn
            // 
            this.salesSumDataGridViewTextBoxColumn.DataPropertyName = "SalesSum";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "C2";
            dataGridViewCellStyle11.NullValue = null;
            this.salesSumDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.salesSumDataGridViewTextBoxColumn.HeaderText = "Umsatz";
            this.salesSumDataGridViewTextBoxColumn.Name = "salesSumDataGridViewTextBoxColumn";
            this.salesSumDataGridViewTextBoxColumn.ReadOnly = true;
            this.salesSumDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.salesSumDataGridViewTextBoxColumn.Width = 80;
            // 
            // provisionSumDataGridViewTextBoxColumn
            // 
            this.provisionSumDataGridViewTextBoxColumn.DataPropertyName = "CostSum";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "C2";
            dataGridViewCellStyle12.NullValue = null;
            this.provisionSumDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.provisionSumDataGridViewTextBoxColumn.HeaderText = "Auszahlung";
            this.provisionSumDataGridViewTextBoxColumn.Name = "provisionSumDataGridViewTextBoxColumn";
            this.provisionSumDataGridViewTextBoxColumn.ReadOnly = true;
            this.provisionSumDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.provisionSumDataGridViewTextBoxColumn.Width = 80;
            // 
            // cashVolumeMonthlyBindingSource
            // 
            this.cashVolumeMonthlyBindingSource.DataSource = typeof(ConsignmentShopLibrary.CashVolumeMonthly);
            // 
            // CashVolumeMonthlyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 458);
            this.Controls.Add(this.ExportBtn);
            this.Controls.Add(this.PrintBtn);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.DiagButton);
            this.Controls.Add(this.VolumeDataGridView);
            this.Name = "CashVolumeMonthlyWindow";
            this.Text = "Monatsumsätze";
            this.Shown += new System.EventHandler(this.CashVolumeMonthlyWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.VolumeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashVolumeMonthlyBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView VolumeDataGridView;
        private System.Windows.Forms.BindingSource cashVolumeMonthlyBindingSource;
        private System.Windows.Forms.Button DiagButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button PrintBtn;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesSumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn provisionSumDataGridViewTextBoxColumn;
    }
}