using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Hill_Cipher.Test
{
    [TestFixture]
    class HillCipherTest
    {
        // reference encrypter for column message vector http://practicalcryptography.com/ciphers/hill-cipher/
        [TestCase("implementation", "aglwsuvzmfktpd")]
        [TestCase("TestFixtures", "yzptidzinpky")]
        [TestCase("WEHAVENOTYETDISCUSSEDTWOCOMPLICATIONSTHATEXISTINPICKINGTHEENCRYPTINGMATRIX", "eiovcfqfgvndexqmquwwlaiguyrhuvegktpdptovyzsfptdlchiedlrjapvzdnprktsryklmhj")]
        [TestCase("zxcvbnmasdfghjklqwertyuiop", "piphpqyktrctpobhuchtgvmwvn")]
        [TestCase("aa", "aa")]
        public void encryptText_Key2x2ColumnVectorVariousInputs_ChecksThem(string plainText, string expected)
        {
            Matrix key = new Matrix(2, 2);
            key[0, 0] = 2;
            key[0, 1] = 3;
            key[1, 0] = 3;
            key[1, 1] = 5;
            Hill_Cipher.HillCipher.useRowMsgVector = false;
            string re = Hill_Cipher.HillCipher.encryptText(plainText, key);
            Assert.AreEqual(expected.ToUpper(), re.ToUpper());
        }

        // reference decrypter for column message vector http://practicalcryptography.com/ciphers/hill-cipher/
        [TestCase("implementation", "aglwsuvzmfktpd")]
        [TestCase("TestFixtures", "yzptidzinpky")]
        [TestCase("WEHAVENOTYETDISCUSSEDTWOCOMPLICATIONSTHATEXISTINPICKINGTHEENCRYPTINGMATRIX", "eiovcfqfgvndexqmquwwlaiguyrhuvegktpdptovyzsfptdlchiedlrjapvzdnprktsryklmhj")]
        [TestCase("zxcvbnmasdfghjklqwertyuiop", "piphpqyktrctpobhuchtgvmwvn")]
        [TestCase("aa", "aa")]
        public void decryptText_Key2x2ColumnVectorVariousInputs_ChecksThem(string expected, string cipherText)
        {
            Matrix key = new Matrix(2, 2);
            key[0, 0] = 2;
            key[0, 1] = 3;
            key[1, 0] = 3;
            key[1, 1] = 5;
            Hill_Cipher.HillCipher.useRowMsgVector = false;
            string re = Hill_Cipher.HillCipher.decryptText(cipherText, key);
            Assert.AreEqual(expected.ToUpper(), re.ToUpper());
        }

        [TestCase("hillcipher", "HCRZSSXNSP")] // sample in book, page 48 - 49
        public void encryptText_Key2x2RowVectorVariousInputs_ChecksThem(string plainText, string expected)
        {
            Matrix key = new Matrix(2, 2);
            key[0, 0] = 3;
            key[0, 1] = 2;
            key[1, 0] = 8;
            key[1, 1] = 5;
            Hill_Cipher.HillCipher.useRowMsgVector = true;
            string re = Hill_Cipher.HillCipher.encryptText(plainText, key);
            Assert.AreEqual(expected.ToUpper(), re.ToUpper());
        }

        [TestCase("hillcipher", "HCRZSSXNSP")] // sample in book, page 48 - 49
        public void decryptText_Key2x2RowVectorVariousInputs_ChecksThem(string expected, string cipherText)
        {
            Matrix key = new Matrix(2, 2);
            key[0, 0] = 3;
            key[0, 1] = 2;
            key[1, 0] = 8;
            key[1, 1] = 5;
            Hill_Cipher.HillCipher.useRowMsgVector = true;
            string re = Hill_Cipher.HillCipher.decryptText(cipherText, key);
            Assert.AreEqual(expected.ToUpper(), re.ToUpper());
        }

        [TestCase("paymoremoney", "RRLMWBKASPDH", 17, 17, 5, 21, 18, 21, 2, 2, 19)] // sample in book, page 48 - 49
        public void encryptText_Key3x3RowVectorVariousInputs_ChecksThem(string plainText, string expected, int m1_00, int m1_01, int m1_02, int m1_10, int m1_11, int m1_12, int m1_20, int m1_21, int m1_22)
        {
            Matrix key = new Matrix(3, 3);
            key[0, 0] = m1_00;
            key[0, 1] = m1_01;
            key[0, 2] = m1_02;
            key[1, 0] = m1_10;
            key[1, 1] = m1_11;
            key[1, 2] = m1_12;
            key[2, 0] = m1_20;
            key[2, 1] = m1_21;
            key[2, 2] = m1_22;
            Hill_Cipher.HillCipher.useRowMsgVector = true;
            string re = Hill_Cipher.HillCipher.encryptText(plainText, key);
            Assert.AreEqual(expected.ToUpper(), re.ToUpper());
        }

        [TestCase("RRLMWBKASPDH", "paymoremoney", 17, 17, 5, 21, 18, 21, 2, 2, 19)] // sample in book, page 48 - 49
        public void decryptText_Key3x3RowVectorVariousInputs_ChecksThem(string cipherText, string expected, int m1_00, int m1_01, int m1_02, int m1_10, int m1_11, int m1_12, int m1_20, int m1_21, int m1_22)
        {
            Matrix key = new Matrix(3, 3);
            key[0, 0] = m1_00;
            key[0, 1] = m1_01;
            key[0, 2] = m1_02;
            key[1, 0] = m1_10;
            key[1, 1] = m1_11;
            key[1, 2] = m1_12;
            key[2, 0] = m1_20;
            key[2, 1] = m1_21;
            key[2, 2] = m1_22;
            Hill_Cipher.HillCipher.useRowMsgVector = true;
            string re = Hill_Cipher.HillCipher.decryptText(cipherText, key);
            Assert.AreEqual(expected.ToUpper(), re.ToUpper());
        }

        [TestCase("ACT", "POH", 6, 24, 1, 13, 16, 10, 20, 17, 15)] // small sample in wikipedia
        [TestCase("CAT", "FIN", 6, 24, 1, 13, 16, 10, 20, 17, 15)]
        [TestCase("paymoremoney", "LNSHDLEWMTRW", 17, 17, 5, 21, 18, 21, 2, 2, 19)] // sample in our report
        public void encryptText_Key3x3ColumnVectorVariousInputs_ChecksThem(string plainText, string expected, int m1_00, int m1_01, int m1_02, int m1_10, int m1_11, int m1_12, int m1_20, int m1_21, int m1_22)
        {
            Matrix key = new Matrix(3, 3);
            key[0, 0] = m1_00;
            key[0, 1] = m1_01;
            key[0, 2] = m1_02;
            key[1, 0] = m1_10;
            key[1, 1] = m1_11;
            key[1, 2] = m1_12;
            key[2, 0] = m1_20;
            key[2, 1] = m1_21;
            key[2, 2] = m1_22;
            Hill_Cipher.HillCipher.useRowMsgVector = false;
            string re = Hill_Cipher.HillCipher.encryptText(plainText, key);
            Assert.AreEqual(expected.ToUpper(), re.ToUpper());
        }

        [TestCase("POH", "ACT", 6, 24, 1, 13, 16, 10, 20, 17, 15)] // small sample in wikipedia
        [TestCase("FIN", "CAT", 6, 24, 1, 13, 16, 10, 20, 17, 15)]
        [TestCase("LNSHDLEWMTRW", "paymoremoney", 17, 17, 5, 21, 18, 21, 2, 2, 19)] // sample in our report
        public void decryptText_Key3x3ColumnVectorVariousInputs_ChecksThem(string cipherText, string expected, int m1_00, int m1_01, int m1_02, int m1_10, int m1_11, int m1_12, int m1_20, int m1_21, int m1_22)
        {
            Matrix key = new Matrix(3, 3);
            key[0, 0] = m1_00;
            key[0, 1] = m1_01;
            key[0, 2] = m1_02;
            key[1, 0] = m1_10;
            key[1, 1] = m1_11;
            key[1, 2] = m1_12;
            key[2, 0] = m1_20;
            key[2, 1] = m1_21;
            key[2, 2] = m1_22;
            Hill_Cipher.HillCipher.useRowMsgVector = false;
            string re = Hill_Cipher.HillCipher.decryptText(cipherText, key);
            Assert.AreEqual(expected.ToUpper(), re.ToUpper());
        }
    }
}
