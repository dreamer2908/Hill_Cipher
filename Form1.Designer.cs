namespace Hill_Cipher
{
    partial class Form1
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
            this.txtPlainText = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCipherText = new System.Windows.Forms.TextBox();
            this.numKey00 = new System.Windows.Forms.NumericUpDown();
            this.numKey01 = new System.Windows.Forms.NumericUpDown();
            this.numKey10 = new System.Windows.Forms.NumericUpDown();
            this.numKey11 = new System.Windows.Forms.NumericUpDown();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.rbtnKeySelect = new System.Windows.Forms.RadioButton();
            this.rbtnKeySelect2 = new System.Windows.Forms.RadioButton();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnGenKey = new System.Windows.Forms.Button();
            this.btnCheckKey = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKey00)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKey01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKey10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKey11)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPlainText
            // 
            this.txtPlainText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPlainText.Location = new System.Drawing.Point(3, 16);
            this.txtPlainText.Multiline = true;
            this.txtPlainText.Name = "txtPlainText";
            this.txtPlainText.Size = new System.Drawing.Size(430, 89);
            this.txtPlainText.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(442, 306);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.txtPlainText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 108);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plain text";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCheckKey);
            this.groupBox3.Controls.Add(this.btnGenKey);
            this.groupBox3.Controls.Add(this.btnDecrypt);
            this.groupBox3.Controls.Add(this.btnEncrypt);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 231);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(169, 72);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Command";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbtnKeySelect2);
            this.groupBox4.Controls.Add(this.rbtnKeySelect);
            this.groupBox4.Controls.Add(this.txtKey);
            this.groupBox4.Controls.Add(this.numKey11);
            this.groupBox4.Controls.Add(this.numKey10);
            this.groupBox4.Controls.Add(this.numKey01);
            this.groupBox4.Controls.Add(this.numKey00);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(178, 231);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(261, 72);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Key";
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.txtCipherText);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 108);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cipher text";
            // 
            // txtCipherText
            // 
            this.txtCipherText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCipherText.Location = new System.Drawing.Point(3, 16);
            this.txtCipherText.Multiline = true;
            this.txtCipherText.Name = "txtCipherText";
            this.txtCipherText.Size = new System.Drawing.Size(430, 89);
            this.txtCipherText.TabIndex = 1;
            // 
            // numKey00
            // 
            this.numKey00.Location = new System.Drawing.Point(6, 19);
            this.numKey00.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numKey00.Name = "numKey00";
            this.numKey00.Size = new System.Drawing.Size(40, 20);
            this.numKey00.TabIndex = 2;
            this.numKey00.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // numKey01
            // 
            this.numKey01.Location = new System.Drawing.Point(52, 19);
            this.numKey01.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numKey01.Name = "numKey01";
            this.numKey01.Size = new System.Drawing.Size(40, 20);
            this.numKey01.TabIndex = 3;
            this.numKey01.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // numKey10
            // 
            this.numKey10.Location = new System.Drawing.Point(6, 45);
            this.numKey10.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numKey10.Name = "numKey10";
            this.numKey10.Size = new System.Drawing.Size(40, 20);
            this.numKey10.TabIndex = 4;
            this.numKey10.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numKey11
            // 
            this.numKey11.Location = new System.Drawing.Point(52, 45);
            this.numKey11.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numKey11.Name = "numKey11";
            this.numKey11.Size = new System.Drawing.Size(40, 20);
            this.numKey11.TabIndex = 5;
            this.numKey11.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(156, 30);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(100, 20);
            this.txtKey.TabIndex = 6;
            this.txtKey.Text = "EHBC";
            this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rbtnKeySelect
            // 
            this.rbtnKeySelect.AutoSize = true;
            this.rbtnKeySelect.Checked = true;
            this.rbtnKeySelect.Location = new System.Drawing.Point(98, 33);
            this.rbtnKeySelect.Name = "rbtnKeySelect";
            this.rbtnKeySelect.Size = new System.Drawing.Size(34, 17);
            this.rbtnKeySelect.TabIndex = 7;
            this.rbtnKeySelect.TabStop = true;
            this.rbtnKeySelect.Text = "or";
            this.rbtnKeySelect.UseVisualStyleBackColor = true;
            // 
            // rbtnKeySelect2
            // 
            this.rbtnKeySelect2.AutoSize = true;
            this.rbtnKeySelect2.Location = new System.Drawing.Point(136, 35);
            this.rbtnKeySelect2.Name = "rbtnKeySelect2";
            this.rbtnKeySelect2.Size = new System.Drawing.Size(14, 13);
            this.rbtnKeySelect2.TabIndex = 8;
            this.rbtnKeySelect2.UseVisualStyleBackColor = true;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(6, 16);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 0;
            this.btnEncrypt.Text = "&Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(6, 42);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 1;
            this.btnDecrypt.Text = "&Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            // 
            // btnGenKey
            // 
            this.btnGenKey.Location = new System.Drawing.Point(87, 16);
            this.btnGenKey.Name = "btnGenKey";
            this.btnGenKey.Size = new System.Drawing.Size(75, 23);
            this.btnGenKey.TabIndex = 2;
            this.btnGenKey.Text = "&New key";
            this.btnGenKey.UseVisualStyleBackColor = true;
            // 
            // btnCheckKey
            // 
            this.btnCheckKey.Location = new System.Drawing.Point(87, 42);
            this.btnCheckKey.Name = "btnCheckKey";
            this.btnCheckKey.Size = new System.Drawing.Size(75, 23);
            this.btnCheckKey.TabIndex = 3;
            this.btnCheckKey.Text = "&Check key";
            this.btnCheckKey.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 306);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(450, 340);
            this.Name = "Form1";
            this.Text = "Hill Cipher";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKey00)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKey01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKey10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKey11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPlainText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCipherText;
        private System.Windows.Forms.NumericUpDown numKey00;
        private System.Windows.Forms.NumericUpDown numKey11;
        private System.Windows.Forms.NumericUpDown numKey10;
        private System.Windows.Forms.NumericUpDown numKey01;
        private System.Windows.Forms.RadioButton rbtnKeySelect;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.RadioButton rbtnKeySelect2;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnGenKey;
        private System.Windows.Forms.Button btnCheckKey;
    }
}

