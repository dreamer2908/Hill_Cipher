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
            getNewKey();
            //numKey00.Value = 10;
            //numKey01.Value = 3;
            //numKey10.Value = 25;
            //numKey11.Value = 5;
        }

        private void updateKeyNum()
        {
            char key1 = (char)(numKey00.Value + 65);
            char key2 = (char)(numKey01.Value + 65);
            char key3 = (char)(numKey10.Value + 65);
            char key4 = (char)(numKey11.Value + 65);
            txtKey.Text = key1.ToString() + key2.ToString() + key3.ToString() + key4.ToString();
        }

        private static string removeNonAlphaChars(string text)
        {
            string re = "";
            for (int i = 0; i < text.Length; i++)
            {
                char disChar = text[i];
                if ((int)disChar <= (int)'Z' && ((int)disChar >= (int)'A'))
                {
                    re += disChar;
                }
            }
            return re;
        }

        private void updateKeyString()
        {
            // remove non alpha chars
            string key = removeNonAlphaChars(txtKey.Text.ToUpper());
            // append A if key is not long enough
            while (key.Length < 4)
                key += "A";
            // trim key to 4 chars
            key = key.Substring(0, 4);
            // write back values to txtKey and numKeyxy
            txtKey.Text = key;
            numKey00.Value = (int)key[0] - 65;
            numKey01.Value = (int)key[1] - 65;
            numKey10.Value = (int)key[2] - 65;
            numKey11.Value = (int)key[3] - 65;
        }

        private void getNewKey()
        {
            Matrix newKey = Matrix.generateNewKey(); // generate a random and usable key
            numKey00.Value = newKey[0, 0];
            numKey01.Value = newKey[0, 1];
            numKey10.Value = newKey[1, 0];
            numKey11.Value = newKey[1, 1];
        }

        private Matrix getCurrentKey()
        {
            Matrix key = new Matrix(2, 2);
            key[0, 0] = (int)numKey00.Value;
            key[0, 1] = (int)numKey01.Value;
            key[1, 0] = (int)numKey10.Value;
            key[1, 1] = (int)numKey11.Value;
            return key;
        }

        // Reference encrypter, decrypter: http://practicalcryptography.com/ciphers/hill-cipher/
        private void encryptText()
        {
            // remove non alpha chars
            string plainText = removeNonAlphaChars(txtPlainText.Text.ToUpper());

            // some sanity checks
            if (plainText.Length < 1)
            {
                MessageBox.Show("Please enter a message to encrypt! Only A - Z count!", "Encrypt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlainText.Text = "AMESSAGE";
                return;
            }
            if (plainText.Length % 2 != 0)
            {
                MessageBox.Show("Message length is not divisible by 2. Gonna insert one more character!", "Encrypt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // get encryption key
            Matrix key = getCurrentKey();
            // MessageBox.Show(key.String2Show());

            // encrypt it
            string cipherText = encryptText(plainText, key);
            txtCipherText.Text = cipherText;
        }

        private static string encryptText(string plainText, Matrix key)
        {
            string cipherText = "";
            for (int i = 0; i < plainText.Length / 2; i++)
            {
                Matrix msgVector = new Matrix(2, 1);
                msgVector[0, 0] = (int)plainText[i * 2] - 65;
                msgVector[1, 0] = (int)plainText[i * 2 + 1] - 65;

                Matrix cipherCodes = Matrix.Multiply(key, msgVector);
                cipherText += ((char)(cipherCodes[0, 0] + 65)).ToString() + ((char)(cipherCodes[1, 0] + 65)).ToString();
            }
            return cipherText;
        }

        private void decryptText()
        {
            // remove non alpha chars
            string cipherText = removeNonAlphaChars(txtCipherText.Text.ToUpper());

            // some sanity checks
            if (cipherText.Length < 1)
            {
                MessageBox.Show("Please enter a message to decrypt! Only A - Z count!", "Decrypt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCipherText.Text = "AMESSAGE";
                return;
            }
            if (cipherText.Length % 2 != 0)
            {
                MessageBox.Show("Message length is not divisible by 2. Wrong algorithm?", "Decrypt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // get the encryption key
            Matrix key = getCurrentKey();

            // decrypt it
            string plainText = decryptText(cipherText, key);
            txtPlainText.Text = plainText;
        }

        private static string decryptText(string cipherText, Matrix _key)
        {
            string plainText = "";
            // we're decrypting, so inverse the key
            Matrix key = Matrix.Inverse2x2Matrix(_key);
            // MessageBox.Show(key.String2Show());
            for (int i = 0; i < cipherText.Length / 2; i++)
            {
                Matrix msgVector = new Matrix(2, 1);
                msgVector[0, 0] = (int)cipherText[i * 2] - 65;
                msgVector[1, 0] = (int)cipherText[i * 2 + 1] - 65;

                Matrix cipherCodes = Matrix.Multiply(key, msgVector);
                plainText += ((char)(cipherCodes[0, 0] + 65)).ToString() + ((char)(cipherCodes[1, 0] + 65)).ToString();
            }
            return plainText;
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
            Matrix key = getCurrentKey();
            if (key.isUsable())
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

        private void btnNewKey_Click(object sender, EventArgs e)
        {
            getNewKey();
        }
    }
}
