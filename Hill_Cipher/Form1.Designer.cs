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
            this.components = new System.ComponentModel.Container();
            this.txtPlainText = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCipherText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCheckKey = new System.Windows.Forms.Button();
            this.btnNewKey = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbtnKeySelect2 = new System.Windows.Forms.RadioButton();
            this.rbtnKeySelect = new System.Windows.Forms.RadioButton();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.numKey11 = new System.Windows.Forms.NumericUpDown();
            this.numKey10 = new System.Windows.Forms.NumericUpDown();
            this.numKey01 = new System.Windows.Forms.NumericUpDown();
            this.numKey00 = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnMessageRowVector = new System.Windows.Forms.RadioButton();
            this.rbtnMessageColumnVector = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKey11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKey10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKey01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKey00)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPlainText
            // 
            this.txtPlainText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPlainText.Location = new System.Drawing.Point(3, 16);
            this.txtPlainText.Multiline = true;
            this.txtPlainText.Name = "txtPlainText";
            this.txtPlainText.Size = new System.Drawing.Size(470, 94);
            this.txtPlainText.TabIndex = 0;
            this.txtPlainText.Text = "WEHAVENOTYETDISCUSSEDTWOCOMPLICATIONSTHATEXISTINPICKINGTHEENCRYPTINGMATRIX";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(482, 366);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.txtCipherText);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 113);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cipher text";
            // 
            // txtCipherText
            // 
            this.txtCipherText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCipherText.Location = new System.Drawing.Point(3, 16);
            this.txtCipherText.Multiline = true;
            this.txtCipherText.Name = "txtCipherText";
            this.txtCipherText.Size = new System.Drawing.Size(470, 94);
            this.txtCipherText.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.txtPlainText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plain text";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCheckKey);
            this.groupBox3.Controls.Add(this.btnNewKey);
            this.groupBox3.Controls.Add(this.btnDecrypt);
            this.groupBox3.Controls.Add(this.btnEncrypt);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 241);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(202, 79);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Command";
            // 
            // btnCheckKey
            // 
            this.btnCheckKey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCheckKey.Location = new System.Drawing.Point(104, 46);
            this.btnCheckKey.Name = "btnCheckKey";
            this.btnCheckKey.Size = new System.Drawing.Size(75, 23);
            this.btnCheckKey.TabIndex = 5;
            this.btnCheckKey.Text = "&Check key";
            this.toolTip1.SetToolTip(this.btnCheckKey, "Verify if this key is usable in 2x2 Hill cipher");
            this.btnCheckKey.UseVisualStyleBackColor = true;
            this.btnCheckKey.Click += new System.EventHandler(this.btnCheckKey_Click);
            // 
            // btnNewKey
            // 
            this.btnNewKey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewKey.Location = new System.Drawing.Point(104, 20);
            this.btnNewKey.Name = "btnNewKey";
            this.btnNewKey.Size = new System.Drawing.Size(75, 23);
            this.btnNewKey.TabIndex = 4;
            this.btnNewKey.Text = "&New key";
            this.toolTip1.SetToolTip(this.btnNewKey, "Generate a random and usable key");
            this.btnNewKey.UseVisualStyleBackColor = true;
            this.btnNewKey.Click += new System.EventHandler(this.btnNewKey_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDecrypt.Location = new System.Drawing.Point(23, 46);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 3;
            this.btnDecrypt.Text = "&Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEncrypt.Location = new System.Drawing.Point(23, 20);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 2;
            this.btnEncrypt.Text = "&Encrypt";
            this.toolTip1.SetToolTip(this.btnEncrypt, "Right click to switch between column and row message vector mode");
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
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
            this.groupBox4.Location = new System.Drawing.Point(211, 241);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(268, 79);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Key";
            // 
            // rbtnKeySelect2
            // 
            this.rbtnKeySelect2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnKeySelect2.AutoSize = true;
            this.rbtnKeySelect2.Location = new System.Drawing.Point(153, 36);
            this.rbtnKeySelect2.Name = "rbtnKeySelect2";
            this.rbtnKeySelect2.Size = new System.Drawing.Size(14, 13);
            this.rbtnKeySelect2.TabIndex = 11;
            this.rbtnKeySelect2.UseVisualStyleBackColor = true;
            // 
            // rbtnKeySelect
            // 
            this.rbtnKeySelect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnKeySelect.AutoSize = true;
            this.rbtnKeySelect.Checked = true;
            this.rbtnKeySelect.Location = new System.Drawing.Point(115, 34);
            this.rbtnKeySelect.Name = "rbtnKeySelect";
            this.rbtnKeySelect.Size = new System.Drawing.Size(34, 17);
            this.rbtnKeySelect.TabIndex = 10;
            this.rbtnKeySelect.TabStop = true;
            this.rbtnKeySelect.Text = "or";
            this.rbtnKeySelect.UseVisualStyleBackColor = true;
            this.rbtnKeySelect.CheckedChanged += new System.EventHandler(this.rbtnKeySelect_CheckedChanged);
            // 
            // txtKey
            // 
            this.txtKey.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtKey.Location = new System.Drawing.Point(173, 31);
            this.txtKey.Name = "txtKey";
            this.txtKey.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(75, 20);
            this.txtKey.TabIndex = 12;
            this.txtKey.Text = "EHBC";
            this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKey.Leave += new System.EventHandler(this.txtKey_Leave);
            // 
            // numKey11
            // 
            this.numKey11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numKey11.Location = new System.Drawing.Point(69, 46);
            this.numKey11.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numKey11.Name = "numKey11";
            this.numKey11.Size = new System.Drawing.Size(40, 20);
            this.numKey11.TabIndex = 9;
            this.numKey11.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numKey11.ValueChanged += new System.EventHandler(this.numKey11_ValueChanged);
            // 
            // numKey10
            // 
            this.numKey10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numKey10.Location = new System.Drawing.Point(23, 46);
            this.numKey10.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numKey10.Name = "numKey10";
            this.numKey10.Size = new System.Drawing.Size(40, 20);
            this.numKey10.TabIndex = 8;
            this.numKey10.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numKey10.ValueChanged += new System.EventHandler(this.numKey10_ValueChanged);
            // 
            // numKey01
            // 
            this.numKey01.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numKey01.Location = new System.Drawing.Point(69, 20);
            this.numKey01.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numKey01.Name = "numKey01";
            this.numKey01.Size = new System.Drawing.Size(40, 20);
            this.numKey01.TabIndex = 7;
            this.numKey01.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numKey01.ValueChanged += new System.EventHandler(this.numKey01_ValueChanged);
            // 
            // numKey00
            // 
            this.numKey00.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numKey00.Location = new System.Drawing.Point(23, 20);
            this.numKey00.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numKey00.Name = "numKey00";
            this.numKey00.Size = new System.Drawing.Size(40, 20);
            this.numKey00.TabIndex = 6;
            this.numKey00.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numKey00.ValueChanged += new System.EventHandler(this.numKey00_ValueChanged);
            // 
            // groupBox5
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox5, 2);
            this.groupBox5.Controls.Add(this.rbtnMessageColumnVector);
            this.groupBox5.Controls.Add(this.rbtnMessageRowVector);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 326);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(476, 37);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Express the plaintext and ciphertext as";
            // 
            // rbtnMessageRowVector
            // 
            this.rbtnMessageRowVector.AutoSize = true;
            this.rbtnMessageRowVector.Checked = true;
            this.rbtnMessageRowVector.Location = new System.Drawing.Point(214, 14);
            this.rbtnMessageRowVector.Name = "rbtnMessageRowVector";
            this.rbtnMessageRowVector.Size = new System.Drawing.Size(80, 17);
            this.rbtnMessageRowVector.TabIndex = 13;
            this.rbtnMessageRowVector.TabStop = true;
            this.rbtnMessageRowVector.Text = "row vectors";
            this.toolTip1.SetToolTip(this.rbtnMessageRowVector, "Express the plaintext and ciphertext as row vectors like in \r\nCryptography and Ne" +
                    "twork Security: Principles and Practice, \r\n5th edition, William Stallings.");
            this.rbtnMessageRowVector.UseVisualStyleBackColor = true;
            this.rbtnMessageRowVector.CheckedChanged += new System.EventHandler(this.rbtnMessageRowVector_CheckedChanged);
            // 
            // rbtnMessageColumnVector
            // 
            this.rbtnMessageColumnVector.AutoSize = true;
            this.rbtnMessageColumnVector.Location = new System.Drawing.Point(300, 14);
            this.rbtnMessageColumnVector.Name = "rbtnMessageColumnVector";
            this.rbtnMessageColumnVector.Size = new System.Drawing.Size(97, 17);
            this.rbtnMessageColumnVector.TabIndex = 14;
            this.rbtnMessageColumnVector.Text = "column vectors";
            this.toolTip1.SetToolTip(this.rbtnMessageColumnVector, "Express the plaintext and ciphertext as column vectors like in \r\nElementary Numbe" +
                    "r Theory and its applications, \r\nAddison Wesley Longman.");
            this.rbtnMessageColumnVector.UseVisualStyleBackColor = true;
            this.rbtnMessageColumnVector.CheckedChanged += new System.EventHandler(this.rbtnMessageColumnVector_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 366);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(490, 400);
            this.Name = "Form1";
            this.Text = "Hill Cipher";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKey11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKey10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKey01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKey00)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
        private System.Windows.Forms.Button btnNewKey;
        private System.Windows.Forms.Button btnCheckKey;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbtnMessageColumnVector;
        private System.Windows.Forms.RadioButton rbtnMessageRowVector;
        private System.Windows.Forms.Label label1;
    }
}

