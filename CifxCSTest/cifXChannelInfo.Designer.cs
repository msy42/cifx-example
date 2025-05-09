namespace cifXTest
{
    partial class cifXChannelInfo
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbInfoSelect = new System.Windows.Forms.ComboBox();
            this.lstList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtError = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbInfoSelect
            // 
            this.cmbInfoSelect.FormattingEnabled = true;
            this.cmbInfoSelect.Location = new System.Drawing.Point(12, 298);
            this.cmbInfoSelect.Name = "cmbInfoSelect";
            this.cmbInfoSelect.Size = new System.Drawing.Size(179, 21);
            this.cmbInfoSelect.TabIndex = 0;
            this.cmbInfoSelect.SelectedIndexChanged += new System.EventHandler(this.cmbInfoSelect_SelectedIndexChanged);
            // 
            // lstList
            // 
            this.lstList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstList.GridLines = true;
            this.lstList.Location = new System.Drawing.Point(12, 12);
            this.lstList.Name = "lstList";
            this.lstList.Size = new System.Drawing.Size(384, 278);
            this.lstList.TabIndex = 5;
            this.lstList.UseCompatibleStateImageBehavior = false;
            this.lstList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Property";
            this.columnHeader1.Width = 212;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 168;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(321, 296);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtError
            // 
            this.txtError.Enabled = false;
            this.txtError.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError.Location = new System.Drawing.Point(12, 358);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(179, 43);
            this.txtError.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Last Error:";
            // 
            // cifXChannelInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 413);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lstList);
            this.Controls.Add(this.cmbInfoSelect);
            this.Name = "cifXChannelInfo";
            this.Text = "cifXChannelInfo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.cifXChannelInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbInfoSelect;
        private System.Windows.Forms.ListView lstList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Label label1;
    }
}