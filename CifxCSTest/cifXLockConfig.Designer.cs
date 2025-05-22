namespace cifXTest
{
    partial class cifXLockConfig
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
            this.btnSetLockState = new System.Windows.Forms.Button();
            this.btnGetLockState = new System.Windows.Forms.Button();
            this.txtError = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbNewState = new System.Windows.Forms.ComboBox();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.txtActState = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSetLockState
            // 
            this.btnSetLockState.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetLockState.Location = new System.Drawing.Point(366, 136);
            this.btnSetLockState.Name = "btnSetLockState";
            this.btnSetLockState.Size = new System.Drawing.Size(131, 23);
            this.btnSetLockState.TabIndex = 22;
            this.btnSetLockState.Text = "Set Lock State";
            this.btnSetLockState.UseVisualStyleBackColor = true;
            this.btnSetLockState.Click += new System.EventHandler(this.btnSetLockState_Click);
            // 
            // btnGetLockState
            // 
            this.btnGetLockState.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetLockState.Location = new System.Drawing.Point(366, 65);
            this.btnGetLockState.Name = "btnGetLockState";
            this.btnGetLockState.Size = new System.Drawing.Size(131, 23);
            this.btnGetLockState.TabIndex = 21;
            this.btnGetLockState.Text = "Get Lock State";
            this.btnGetLockState.UseVisualStyleBackColor = true;
            this.btnGetLockState.Click += new System.EventHandler(this.btnGetLockState_Click);
            // 
            // txtError
            // 
            this.txtError.Enabled = false;
            this.txtError.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError.Location = new System.Drawing.Point(47, 225);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(204, 49);
            this.txtError.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Last Error";
            // 
            // cmbNewState
            // 
            this.cmbNewState.FormattingEnabled = true;
            this.cmbNewState.Location = new System.Drawing.Point(192, 109);
            this.cmbNewState.Name = "cmbNewState";
            this.cmbNewState.Size = new System.Drawing.Size(146, 21);
            this.cmbNewState.TabIndex = 18;
            // 
            // txtTimeout
            // 
            this.txtTimeout.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeout.Location = new System.Drawing.Point(192, 137);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(146, 21);
            this.txtTimeout.TabIndex = 17;
            // 
            // txtActState
            // 
            this.txtActState.Enabled = false;
            this.txtActState.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActState.Location = new System.Drawing.Point(192, 66);
            this.txtActState.Name = "txtActState";
            this.txtActState.Size = new System.Drawing.Size(146, 21);
            this.txtActState.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Timeout [ms]:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "New Lock State:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Actual Lock State";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Lock Configuration Test";
            // 
            // cifXLockConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 346);
            this.Controls.Add(this.btnSetLockState);
            this.Controls.Add(this.btnGetLockState);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbNewState);
            this.Controls.Add(this.txtTimeout);
            this.Controls.Add(this.txtActState);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "cifXLockConfig";
            this.Text = "cifXLockConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetLockState;
        private System.Windows.Forms.Button btnGetLockState;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbNewState;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.TextBox txtActState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}