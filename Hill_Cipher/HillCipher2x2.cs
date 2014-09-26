using System;
using System.Collections.Generic;
using System.Text;

namespace Hill_Cipher
{
    class HillCipher2x2
    {
        public static Boolean useRowMsgVector = false;

        public static string encryptText(string _plainText, Matrix key)
        {
            string plainText = _plainText.ToUpper();
            string cipherText = "";
            for (int i = 0; i < plainText.Length / 2; i++) 
            {
                // the key is 2x2 so we work on blocks of 2 characters
                // turn each letter into a number modulo 26 (integer, 0 - 25)
                // message vector = an either column or row matrix of letters in form of a number
                // row vector will produce different cipher texts than column vector
                // and cipher texts produced in row vector mode can be decrypted only in row vector mode
                // same for ones produced in column vector mode
                if (!useRowMsgVector)
                {
                    Matrix msgVector = new Matrix(2, 1);
                    msgVector[0, 0] = (int)plainText[i * 2] - 65;
                    msgVector[1, 0] = (int)plainText[i * 2 + 1] - 65;
                    // multiply the message vector by the key
                    Matrix cipherCodes = Matrix.Multiply(key, msgVector);
                    // turn numbers back to letters
                    cipherText += ((char)(cipherCodes[0, 0] + 65)).ToString() + ((char)(cipherCodes[1, 0] + 65)).ToString();
                }
                else
                {
                    Matrix msgVector = new Matrix(1, 2);
                    msgVector[0, 0] = (int)plainText[i * 2] - 65;
                    msgVector[0, 1] = (int)plainText[i * 2 + 1] - 65;
                    // multiply the message vector by the key
                    Matrix cipherCodes = Matrix.Multiply(msgVector, key);
                    // turn numbers back to letters
                    cipherText += ((char)(cipherCodes[0, 0] + 65)).ToString() + ((char)(cipherCodes[0, 1] + 65)).ToString();
                }
            }
            return cipherText;
        }

        public static string decryptText(string _cipherText, Matrix _key)
        {
            // The only difference between encrypting and decrypting is the key
            // Inverse the key, give it to the encrypt function and we got a decrypt function
            string cipherText = _cipherText.ToUpper();
            // Inverse the key
            Matrix key = Matrix.Inverse2x2Matrix(_key); // MessageBox.Show(key.String2Show());
            // Decrypt with the encrypt function and the inversed key
            string plainText = encryptText(cipherText, key);
            return plainText;
        }
    }
}
