namespace cifXTest
{
    partial class cifXAppReady
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtActState = new System.Windows.Forms.TextBox();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.cmbNewState = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtError = new System.Windows.Forms.TextBox();
            this.btnGetAppState = new System.Windows.Forms.Button();
            this.btnSetAppState = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application Ready Test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Actual Application State";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "New Application State:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Timeout [ms]:";
            // 
            // txtActState
            // 
            this.txtActState.Enabled = false;
            this.txtActState.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActState.Location = new System.Drawing.Point(220, 95);
            this.txtActState.Name = "txtActState";
            this.txtActState.Size = new System.Drawing.Size(146, 21);
            this.txtActState.TabIndex = 4;
            // 
            // txtTimeout
            // 
            this.txtTimeout.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeout.Location = new System.Drawing.Point(220, 166);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(146, 21);
            this.txtTimeout.TabIndex = 6;
            // 
            // cmbNewState
            // 
            this.cmbNewState.FormattingEnabled = true;
            this.cmbNewState.Location = new System.Drawing.Point(220, 138);
            this.cmbNewState.Name = "cmbNewState";
            this.cmbNewState.Size = new System.Drawing.Size(146, 21);
            this.cmbNewState.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(72, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Last Error";
            // 
            // txtError
            // 
            this.txtError.Enabled = false;
            this.txtError.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError.Location = new System.Drawing.Point(75, 254);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(204, 49);
            this.txtError.TabIndex = 9;
            // 
            // btnGetAppState
            // 
            this.btnGetAppState.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetAppState.Location = new System.Drawing.Point(394, 94);
            this.btnGetAppState.Name = "btnGetAppState";
            this.btnGetAppState.Size = new System.Drawing.Size(131, 23);
            this.btnGetAppState.TabIndex = 10;
            this.btnGetAppState.Text = "Get Application State";
            this.btnGetAppState.UseVisualStyleBackColor = true;
            this.btnGetAppState.Click += new System.EventHandler(this.btnGetAppState_Click);
            // 
            // btnSetAppState
            // 
            this.btnSetAppState.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetAppState.Location = new System.Drawing.Point(394, 165);
            this.btnSetAppState.Name = "btnSetAppState";
            this.btnSetAppState.Size = new System.Drawing.Size(131, 23);
            this.btnSetAppState.TabIndex = 11;
            this.btnSetAppState.Text = "Set Application State";
            this.btnSetAppState.UseVisualStyleBackColor = true;
            this.btnSetAppState.Click += new System.EventHandler(this.btnSetAppState_Click);
            // 
            // cifXAppReady
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 379);
            this.Controls.Add(this.btnSetAppState);
            this.Controls.Add(this.btnGetAppState);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbNewState);
            this.Controls.Add(this.txtTimeout);
            this.Controls.Add(this.txtActState);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "cifXAppReady";
            this.Text = "cifXAppReady";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtActState;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.ComboBox cmbNewState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Button btnGetAppState;
        private System.Windows.Forms.Button btnSetAppState;
    }
}