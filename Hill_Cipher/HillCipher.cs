using System;
using System.Collections.Generic;
using System.Text;

namespace Hill_Cipher
{
    class HillCipher
    {
        public static Boolean useRowMsgVector = true;

        private static string removeNonAlphaChars(string _text)
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

        private static string preparePlainText(string _text, int keySize)
        {
            string text = removeNonAlphaChars(_text);
            while (text.Length % keySize != 0)
                text += "A";
            return text;
        }

        public static string encryptText(string _plainText, Matrix key)
        {
            if (!key.isSquare)
                return "";
            int keySize = key.Height;
            string plainText = preparePlainText(_plainText, keySize);
            StringBuilder cipherText = new StringBuilder();
            for (int i = 0; i < plainText.Length / keySize; i++) 
            {
                // the key is 2x2 so we work on blocks of 2 characters
                // turn each letter into a number modulo 26 (integer, 0 - 25)
                // message vector = an either column or row matrix of letters in form of a number
                // row vector will produce different cipher texts than column vector
                // and cipher texts produced in row vector mode can be decrypted only in row vector mode
                // same for ones produced in column vector mode
                if (!useRowMsgVector)
                {
                    Matrix msgVector = new Matrix(keySize, 1);
                    for (int j = 0; j < keySize; j++)
                        msgVector[j, 0] = (int)plainText[i * keySize + j] - 65;
                    // multiply the message vector by the key
                    Matrix cipherCodes = key * msgVector;
                    // turn numbers back to letters
                    for (int j = 0; j < keySize; j++)
                        cipherText.Append(((char)(cipherCodes[j, 0] + 65)).ToString());
                }
                else
                {
                    Matrix msgVector = new Matrix(1, keySize);
                    for (int j = 0; j < keySize; j++)
                        msgVector[0, j] = (int)plainText[i * keySize + j] - 65;
                    // multiply the message vector by the key
                    Matrix cipherCodes = msgVector * key;
                    // turn numbers back to letters
                    for (int j = 0; j < keySize; j++)
                        cipherText.Append(((char)(cipherCodes[0, j] + 65)).ToString());
                }
            }
            return cipherText.ToString();
        }

        public static string decryptText(string _cipherText, Matrix _key)
        {
            if (!_key.isSquare)
                return "";
            // The only difference between encrypting and decrypting is the key
            // Inverse the key, give it to the encrypt function and we got a decrypt function
            string cipherText = _cipherText.ToUpper();
            // Inverse the key
            Matrix key = Matrix.Inverse(_key); // MessageBox.Show(key.String2Show());
            // Decrypt with the encrypt function and the inversed key
            string plainText = encryptText(cipherText, key);
            return plainText;
        }

        public static string plainTextFullSample()
        {
            // all possible pairs of chars
            StringBuilder plainText = new StringBuilder();
            for (int i = (int)'A'; i < (int)'Z'; i++)
                for (int j = (int)'A'; j < (int)'Z'; j++)
                    plainText.Append(((char)i).ToString() + ((char)j).ToString());
            return plainText.ToString();
        }
    }
}
