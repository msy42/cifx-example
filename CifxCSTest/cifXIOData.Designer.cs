namespace cifXTest
{
    partial class cifXIOData
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
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbOutArea = new System.Windows.Forms.ComboBox();
            this.txtOutLen = new System.Windows.Forms.TextBox();
            this.chkVerifyOutputs = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutOffset = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtLastOutError = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkAutoInc = new System.Windows.Forms.CheckBox();
            this.chkCyclic = new System.Windows.Forms.CheckBox();
            this.txtOutputData = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTimerIntervall = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbInArea = new System.Windows.Forms.ComboBox();
            this.txtLastInError = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInputData = new System.Windows.Forms.TextBox();
            this.txtInLen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInOffset = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TimerIn = new System.Windows.Forms.Timer(this.components);
            this.TimerOut = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbOutArea);
            this.groupBox2.Controls.Add(this.txtOutLen);
            this.groupBox2.Controls.Add(this.chkVerifyOutputs);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtOutOffset);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.txtLastOutError);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.chkAutoInc);
            this.groupBox2.Controls.Add(this.chkCyclic);
            this.groupBox2.Controls.Add(this.txtOutputData);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(315, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 395);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Process Data Output Image";
            // 
            // cmbOutArea
            // 
            this.cmbOutArea.FormattingEnabled = true;
            this.cmbOutArea.Location = new System.Drawing.Point(91, 33);
            this.cmbOutArea.Name = "cmbOutArea";
            this.cmbOutArea.Size = new System.Drawing.Size(72, 22);
            this.cmbOutArea.TabIndex = 34;
            // 
            // txtOutLen
            // 
            this.txtOutLen.Enabled = false;
            this.txtOutLen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutLen.Location = new System.Drawing.Point(91, 87);
            this.txtOutLen.Name = "txtOutLen";
            this.txtOutLen.Size = new System.Drawing.Size(72, 20);
            this.txtOutLen.TabIndex = 33;
            // 
            // chkVerifyOutputs
            // 
            this.chkVerifyOutputs.AutoSize = true;
            this.chkVerifyOutputs.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVerifyOutputs.Location = new System.Drawing.Point(81, 278);
            this.chkVerifyOutputs.Name = "chkVerifyOutputs";
            this.chkVerifyOutputs.Size = new System.Drawing.Size(96, 18);
            this.chkVerifyOutputs.TabIndex = 35;
            this.chkVerifyOutputs.Text = "Verify Outputs";
            this.chkVerifyOutputs.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 32;
            this.label1.Text = "Length:";
            // 
            // txtOutOffset
            // 
            this.txtOutOffset.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutOffset.Location = new System.Drawing.Point(91, 60);
            this.txtOutOffset.Name = "txtOutOffset";
            this.txtOutOffset.Size = new System.Drawing.Size(72, 20);
            this.txtOutOffset.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 14);
            this.label4.TabIndex = 30;
            this.label4.Text = "Offset:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 14);
            this.label6.TabIndex = 29;
            this.label6.Text = "Area Number:";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(78, 278);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(96, 18);
            this.checkBox3.TabIndex = 28;
            this.checkBox3.Text = "Verify Outputs";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(208, 278);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(68, 23);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtLastOutError
            // 
            this.txtLastOutError.Enabled = false;
            this.txtLastOutError.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastOutError.Location = new System.Drawing.Point(12, 343);
            this.txtLastOutError.Multiline = true;
            this.txtLastOutError.Name = "txtLastOutError";
            this.txtLastOutError.Size = new System.Drawing.Size(163, 46);
            this.txtLastOutError.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 326);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 14);
            this.label11.TabIndex = 23;
            this.label11.Text = "Last Error:";
            // 
            // chkAutoInc
            // 
            this.chkAutoInc.AutoSize = true;
            this.chkAutoInc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoInc.Location = new System.Drawing.Point(12, 298);
            this.chkAutoInc.Name = "chkAutoInc";
            this.chkAutoInc.Size = new System.Drawing.Size(125, 18);
            this.chkAutoInc.TabIndex = 22;
            this.chkAutoInc.Text = "Auto-Increment Data";
            this.chkAutoInc.UseVisualStyleBackColor = true;
            this.chkAutoInc.CheckedChanged += new System.EventHandler(this.chkAutoInc_CheckedChanged);
            // 
            // chkCyclic
            // 
            this.chkCyclic.AutoSize = true;
            this.chkCyclic.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCyclic.Location = new System.Drawing.Point(12, 278);
            this.chkCyclic.Name = "chkCyclic";
            this.chkCyclic.Size = new System.Drawing.Size(55, 18);
            this.chkCyclic.TabIndex = 21;
            this.chkCyclic.Text = "Cyclic";
            this.chkCyclic.UseVisualStyleBackColor = true;
            this.chkCyclic.CheckedChanged += new System.EventHandler(this.chkCyclic_CheckedChanged);
            // 
            // txtOutputData
            // 
            this.txtOutputData.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputData.Location = new System.Drawing.Point(12, 113);
            this.txtOutputData.Multiline = true;
            this.txtOutputData.Name = "txtOutputData";
            this.txtOutputData.Size = new System.Drawing.Size(264, 144);
            this.txtOutputData.TabIndex = 20;
            this.txtOutputData.TextChanged += new System.EventHandler(this.txtOutputData_TextChanged);
            this.txtOutputData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOutputData_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbTimerIntervall);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbInArea);
            this.groupBox1.Controls.Add(this.txtLastInError);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtInputData);
            this.groupBox1.Controls.Add(this.txtInLen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtInOffset);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 395);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process Data Input Image";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(166, 297);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 14);
            this.label9.TabIndex = 30;
            this.label9.Text = "[ms]";
            // 
            // cmbTimerIntervall
            // 
            this.cmbTimerIntervall.FormattingEnabled = true;
            this.cmbTimerIntervall.Location = new System.Drawing.Point(88, 294);
            this.cmbTimerIntervall.Name = "cmbTimerIntervall";
            this.cmbTimerIntervall.Size = new System.Drawing.Size(72, 22);
            this.cmbTimerIntervall.TabIndex = 29;
            this.cmbTimerIntervall.SelectedIndexChanged += new System.EventHandler(this.cmbTimerIntervall_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 14);
            this.label8.TabIndex = 28;
            this.label8.Text = "Update Rate:";
            // 
            // cmbInArea
            // 
            this.cmbInArea.FormattingEnabled = true;
            this.cmbInArea.Location = new System.Drawing.Point(88, 33);
            this.cmbInArea.Name = "cmbInArea";
            this.cmbInArea.Size = new System.Drawing.Size(72, 22);
            this.cmbInArea.TabIndex = 27;
            // 
            // txtLastInError
            // 
            this.txtLastInError.Enabled = false;
            this.txtLastInError.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastInError.Location = new System.Drawing.Point(12, 343);
            this.txtLastInError.Multiline = true;
            this.txtLastInError.Name = "txtLastInError";
            this.txtLastInError.Size = new System.Drawing.Size(163, 46);
            this.txtLastInError.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 23;
            this.label2.Text = "Last Error:";
            // 
            // txtInputData
            // 
            this.txtInputData.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputData.Location = new System.Drawing.Point(12, 113);
            this.txtInputData.Multiline = true;
            this.txtInputData.Name = "txtInputData";
            this.txtInputData.Size = new System.Drawing.Size(264, 144);
            this.txtInputData.TabIndex = 20;
            // 
            // txtInLen
            // 
            this.txtInLen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInLen.Location = new System.Drawing.Point(88, 87);
            this.txtInLen.Name = "txtInLen";
            this.txtInLen.Size = new System.Drawing.Size(72, 20);
            this.txtInLen.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Length:";
            // 
            // txtInOffset
            // 
            this.txtInOffset.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInOffset.Location = new System.Drawing.Point(88, 60);
            this.txtInOffset.Name = "txtInOffset";
            this.txtInOffset.Size = new System.Drawing.Size(72, 20);
            this.txtInOffset.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Offset:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "Area Number:";
            // 
            // TimerIn
            // 
            this.TimerIn.Tick += new System.EventHandler(this.TimerIn_Tick);
            // 
            // TimerOut
            // 
            this.TimerOut.Tick += new System.EventHandler(this.TimerOut_Tick);
            // 
            // cifXIOData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 414);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "cifXIOData";
            this.Text = "cifXIOData";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.cifXIOData_FormClosing);
            this.Load += new System.EventHandler(this.cifXIOData_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtLastOutError;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkAutoInc;
        private System.Windows.Forms.CheckBox chkCyclic;
        private System.Windows.Forms.TextBox txtOutputData;
        private System.Windows.Forms.ComboBox cmbOutArea;
        private System.Windows.Forms.TextBox txtOutLen;
        private System.Windows.Forms.CheckBox chkVerifyOutputs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOutOffset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTimerIntervall;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbInArea;
        private System.Windows.Forms.TextBox txtLastInError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInputData;
        private System.Windows.Forms.TextBox txtInLen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInOffset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer TimerIn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer TimerOut;
    }
}