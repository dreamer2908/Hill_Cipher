﻿using System;
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
            rbtnMessageRowVector.Checked = true;
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

        public static string removeNonAlphaChars(string _text)
        {
            string text = _text.ToUpper();
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

        public static string preparePlainText(string _text)
        {
            string text = removeNonAlphaChars(_text);

            return text;
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
            Matrix newKey = Matrix.generateNewKey(2); // generate a random and usable key
            numKey00.Value = newKey[0, 0];
            numKey01.Value = newKey[0, 1];
            numKey10.Value = newKey[1, 0];
            numKey11.Value = newKey[1, 1];
        }

        private Matrix getCurrentKey()
        {
            //Matrix key = new Matrix(3, 3);
            //key[0, 0] = 17;
            //key[0, 1] = 17;
            //key[0, 2] = 5;
            //key[1, 0] = 21;
            //key[1, 1] = 18;
            //key[1, 2] = 21;
            //key[2, 0] = 2;
            //key[2, 1] = 2;
            //key[2, 2] = 19;
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
            // get the encryption key
            Matrix key = getCurrentKey();
            int keySize = key.Height;
            if (!key.isUsable)
            {
                MessageBox.Show("This key is NOT usable in " + keySize.ToString() + "x" + keySize.ToString() + " Hill cipher! If you encrypt your message \nwith this key and send it, it canNOT be decrypted even if the receiver has the key! \nPlease click \"New key\" to get a good key!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // remove non alpha chars
            string plainText = removeNonAlphaChars(txtPlainText.Text.ToUpper());

            // some sanity checks
            if (plainText.Length < 1)
            {
                MessageBox.Show("Please enter a message to encrypt! Only A - Z count!", "Encrypt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlainText.Text = "AMESSAGE";
                return;
            }
            if (plainText.Length % keySize != 0)
            {
                MessageBox.Show("Message length is not divisible by " + keySize.ToString() + ". Gonna insert more character(s)!", "Encrypt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                plainText += "A";
            }

            // encrypt it
            string cipherText = HillCipher.encryptText(plainText, key);
            txtCipherText.Text = cipherText;
        }

        private void decryptText()
        {
            // get the encryption key
            Matrix key = getCurrentKey();
            int keySize = key.Height;
            if (!key.isUsable)
            {
                MessageBox.Show("This key is NOT usable in " + keySize.ToString() + "x" + keySize.ToString() + " Hill cipher! Your message canNOT be decrypted sucessfully with this key. Are you sure you input the correct key?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // remove non alpha chars
            string cipherText = removeNonAlphaChars(txtCipherText.Text.ToUpper());

            // some sanity checks
            if (cipherText.Length < 1)
            {
                MessageBox.Show("Please enter a message to decrypt! Only A - Z count!", "Decrypt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCipherText.Text = "AMESSAGE";
                return;
            }
            if (cipherText.Length % keySize != 0)
            {
                MessageBox.Show("Message length is not divisible by " + keySize.ToString() + ". Wrong algorithm?", "Decrypt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // decrypt it
            string plainText = HillCipher.decryptText(cipherText, key);
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
            Matrix key = getCurrentKey();
            int keySize = key.Height;
            if (key.isUsable)
            {
                MessageBox.Show("This key is suitable for " + keySize.ToString() + "x" + keySize.ToString() + " Hill cipher. All good!", "Check key", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("This key is NOT usable in " + keySize.ToString() + "x" + keySize.ToString() + " Hill cipher! If you encrypt your message \nwith this key and send it, it canNOT be decrypted even if the receiver has the key! \nPlease click \"New key\" to get a good key!", "Check key", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            decryptText();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            encryptText();
        }

        private void btnNewKey_Click(object sender, EventArgs e)
        {
            getNewKey();
        }

        private void rbtnMessageRowVector_CheckedChanged(object sender, EventArgs e)
        {
            HillCipher.useRowMsgVector = rbtnMessageRowVector.Checked;
        }

        private void rbtnMessageColumnVector_CheckedChanged(object sender, EventArgs e)
        {
            HillCipher.useRowMsgVector = !rbtnMessageColumnVector.Checked;
        }
    }
}
