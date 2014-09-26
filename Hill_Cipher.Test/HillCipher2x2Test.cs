using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Hill_Cipher.Test
{
    [TestFixture]
    class HillCipher2x2Test
    {
        // reference encrypter for column message vector http://practicalcryptography.com/ciphers/hill-cipher/
        [TestCase("implementation", "aglwsuvzmfktpd")]
        [TestCase("TestFixtures", "yzptidzinpky")]
        [TestCase("WEHAVENOTYETDISCUSSEDTWOCOMPLICATIONSTHATEXISTINPICKINGTHEENCRYPTINGMATRIX", "eiovcfqfgvndexqmquwwlaiguyrhuvegktpdptovyzsfptdlchiedlrjapvzdnprktsryklmhj")]
        [TestCase("zxcvbnmasdfghjklqwertyuiop", "piphpqyktrctpobhuchtgvmwvn")]
        [TestCase("aa", "aa")]
        public void encryptText_ColumnVectorVariousInputs_ChecksThem(string plainText, string expected)
        {
            Matrix key = new Matrix(2, 2);
            key[0, 0] = 2;
            key[0, 1] = 3;
            key[1, 0] = 3;
            key[1, 1] = 5;
            Hill_Cipher.HillCipher2x2.useRowMsgVector = false;
            string re = Hill_Cipher.HillCipher2x2.encryptText(plainText, key);
            Assert.AreEqual(expected.ToUpper(), re.ToUpper());
        }

        // reference decrypter for column message vector http://practicalcryptography.com/ciphers/hill-cipher/
        [TestCase("implementation", "aglwsuvzmfktpd")]
        [TestCase("TestFixtures", "yzptidzinpky")]
        [TestCase("WEHAVENOTYETDISCUSSEDTWOCOMPLICATIONSTHATEXISTINPICKINGTHEENCRYPTINGMATRIX", "eiovcfqfgvndexqmquwwlaiguyrhuvegktpdptovyzsfptdlchiedlrjapvzdnprktsryklmhj")]
        [TestCase("zxcvbnmasdfghjklqwertyuiop", "piphpqyktrctpobhuchtgvmwvn")]
        [TestCase("aa", "aa")]
        public void decryptText_ColumnVectorVariousInputs_ChecksThem(string expected, string cipherText)
        {
            Matrix key = new Matrix(2, 2);
            key[0, 0] = 2;
            key[0, 1] = 3;
            key[1, 0] = 3;
            key[1, 1] = 5;
            Hill_Cipher.HillCipher2x2.useRowMsgVector = false;
            string re = Hill_Cipher.HillCipher2x2.decryptText(cipherText, key);
            Assert.AreEqual(expected.ToUpper(), re.ToUpper());
        }

        [TestCase("hillcipher", "HCRZSSXNSP")] // sample in book, page 48 - 49
        public void encryptText_RowVectorVariousInputs_ChecksThem(string plainText, string expected)
        {
            Matrix key = new Matrix(2, 2);
            key[0, 0] = 3;
            key[0, 1] = 2;
            key[1, 0] = 8;
            key[1, 1] = 5;
            Hill_Cipher.HillCipher2x2.useRowMsgVector = true;
            string re = Hill_Cipher.HillCipher2x2.encryptText(plainText, key);
            Assert.AreEqual(expected.ToUpper(), re.ToUpper());
        }

        [TestCase("hillcipher", "HCRZSSXNSP")] // sample in book, page 48 - 49
        public void decryptText_RowVectorVariousInputs_ChecksThem(string expected, string cipherText)
        {
            Matrix key = new Matrix(2, 2);
            key[0, 0] = 3;
            key[0, 1] = 2;
            key[1, 0] = 8;
            key[1, 1] = 5;
            Hill_Cipher.HillCipher2x2.useRowMsgVector = true;
            string re = Hill_Cipher.HillCipher2x2.decryptText(cipherText, key);
            Assert.AreEqual(expected.ToUpper(), re.ToUpper());
        }
    }
}
