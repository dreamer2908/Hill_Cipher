using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hill_Cipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void updateKeyNum()
        {
            char key1 = (char)(numKey00.Value + 65);
            char key2 = (char)(numKey01.Value + 65);
            char key3 = (char)(numKey10.Value + 65);
            char key4 = (char)(numKey11.Value + 65);
            txtKey.Text = key1.ToString() + key2.ToString() + key3.ToString() + key4.ToString();
        }

        private void updateKeyString()
        {
            // remove non alpha chars
            string _key = txtKey.Text.ToUpper();
            string key = "";
            for (int i = 0; i < _key.Length; i++)
            {
                char disChar = _key[i];
                if ((int)disChar <= (int)'Z' && ((int)disChar >= (int)'A'))
                {
                    key += disChar;
                }
            }
            // append A if key is not long enough
            while (key.Length < 4)
            {
                key += "A";
            }
            // trim key to 4
            key = key.Substring(0, 4);
            // write back values to txtKey and numKeyxy
            txtKey.Text = key;
            numKey00.Value = (int)key[0] - 65;
            numKey01.Value = (int)key[1] - 65;
            numKey10.Value = (int)key[2] - 65;
            numKey11.Value = (int)key[3] - 65;
        }

        private void generateNewKey()
        {
            // TODO: find a convinient way to generate a good an usable key
        }

        // Reference encrypter, decrypter: http://practicalcryptography.com/ciphers/hill-cipher/
        private void encryptText()
        {
            // remove non alpha chars
            string _plainText = txtPlainText.Text.ToUpper();
            string plainText = "";
            for (int i = 0; i < _plainText.Length; i++)
            {
                char disChar = _plainText[i];
                if ((int)disChar <= (int)'Z' && ((int)disChar >= (int)'A'))
                {
                    plainText += disChar;
                }
            }

            // some sanity checks
            if (plainText.Length < 1)
            {
                MessageBox.Show("Please enter a message to encrypt! Only A - Z count!", "Encrypt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlainText.Text = "AMESSAGE";
                return;
            }
            if (plainText.Length % 2 != 0)
            {
                MessageBox.Show("Text length is not divisible by 2. Gonna add a character to it!", "Encrypt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // encrypt it
            string cipherText = "";
            Matrix key = new Matrix(2, 2);
            key[0, 0] = (int)numKey00.Value;
            key[0, 1] = (int)numKey01.Value;
            key[1, 0] = (int)numKey10.Value;
            key[1, 1] = (int)numKey11.Value;
            // MessageBox.Show(key.String2Show());
            for (int i = 0; i < plainText.Length / 2; i++)
            {
                Matrix msgVector = new Matrix(2, 1);
                msgVector[0, 0] = (int)plainText[i * 2] - 65;
                msgVector[1, 0] = (int)plainText[i * 2 + 1] - 65;

                Matrix cipherCodes = Matrix.Multiply(key, msgVector);
                cipherText += ((char)(cipherCodes[0, 0] + 65)).ToString() + ((char)(cipherCodes[1, 0] + 65)).ToString();
            }
            txtCipherText.Text = cipherText;
        }

        private void decryptText()
        {
            // remove non alpha chars
            string _cipherText = txtCipherText.Text.ToUpper();
            string cipherText = "";
            for (int i = 0; i < _cipherText.Length; i++)
            {
                char disChar = _cipherText[i];
                if ((int)disChar <= (int)'Z' && ((int)disChar >= (int)'A'))
                {
                    cipherText += disChar;
                }
            }

            // some sanity checks
            if (cipherText.Length < 1)
            {
                MessageBox.Show("Please enter a message to decrypt! Only A - Z count!", "Encrypt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlainText.Text = "AMESSAGE";
                return;
            }
            if (cipherText.Length % 2 != 0)
            {
                MessageBox.Show("Text length is not divisible by 2. Wrong algorithm?", "Encrypt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // decrypt it
            string plainText = "";
            Matrix key = new Matrix(2, 2);
            key[0, 0] = (int)numKey00.Value;
            key[0, 1] = (int)numKey01.Value;
            key[1, 0] = (int)numKey10.Value;
            key[1, 1] = (int)numKey11.Value;
            // we're decrypting, so inverse the key
            key = Matrix.Inverse2x2Matrix(key);
            // MessageBox.Show(key.String2Show());
            for (int i = 0; i < cipherText.Length / 2; i++)
            {
                Matrix msgVector = new Matrix(2, 1);
                msgVector[0, 0] = (int)cipherText[i * 2] - 65;
                msgVector[1, 0] = (int)cipherText[i * 2 + 1] - 65;

                Matrix cipherCodes = Matrix.Multiply(key, msgVector);
                plainText += ((char)(cipherCodes[0, 0] + 65)).ToString() + ((char)(cipherCodes[1, 0] + 65)).ToString();
            }
            txtPlainText.Text = plainText;
        }

        private void numKey00_ValueChanged(object sender, EventArgs e)
        {
            updateKeyNum();
        }

        private void numKey01_ValueChanged(object sender, EventArgs e)
        {
            updateKeyNum();
        }

        private void numKey10_ValueChanged(object sender, EventArgs e)
        {
            updateKeyNum();
        }

        private void numKey11_ValueChanged(object sender, EventArgs e)
        {
            updateKeyNum();
        }

        private void rbtnKeySelect_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnKeySelect.Checked)
            {
                txtKey.ReadOnly = true;
                numKey00.ReadOnly = false;
                numKey01.ReadOnly = false;
                numKey10.ReadOnly = false;
                numKey11.ReadOnly = false;
            }
            else
            {
                txtKey.ReadOnly = false;
                numKey00.ReadOnly = true;
                numKey01.ReadOnly = true;
                numKey10.ReadOnly = true;
                numKey11.ReadOnly = true;
            }
        }

        private void txtKey_Leave(object sender, EventArgs e)
        {
            updateKeyString();
        }

        private void btnCheckKey_Click(object sender, EventArgs e)
        {
            int det = (int)(numKey00.Value * numKey11.Value - numKey01.Value * numKey10.Value);
            if (det != 0 && det % 2 != 0 && det % 13 != 0)
            {
                MessageBox.Show("This key is usable!", "Check key", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("This key is NOT usable! Please use \"New key\" function to generate a good key!","Check key", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            encryptText();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            decryptText();
        }

        private void btnGenKey_Click(object sender, EventArgs e)
        {
            generateNewKey();
        }
    }
}
