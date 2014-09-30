using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Hill_Cipher.Research
{
    class Program
    {
        static void Main(string[] args)
        {
            verifyKeyConditionVsDecryptability();
            benchmarkCipher();
        }

        static void verifyKeyConditionVsDecryptability()
        {
            string plainText = "abcdefghijklmnopqrstuvwxyz".ToUpper();
            // plainText = Hill_Cipher.HillCipher2x2.plainTextFullSample(); // actually not too big
            Matrix key = new Matrix(2, 2);
            int total = 0;
            int conditionMet_decryptable = 0;
            int conditionMet_notDecryptable = 0;
            int conditionNotMet_decryptable = 0;
            int conditionNotMet_notDecryptable = 0;

            benchmark bm = new benchmark();
            bm.startBenchmark();

            for (int k1 = 0; k1 < 26; k1++)
                for (int k2 = 0; k2 < 26; k2++)
                    for (int k3 = 0; k3 < 26; k3++)
                        for (int k4 = 0; k4 < 26; k4++)
                        {
                            key[0, 0] = k1;
                            key[0, 1] = k2;
                            key[1, 0] = k3;
                            key[1, 1] = k4;
                            Boolean conditionMet = key.isUsable2x2();
                            string cipherText = Hill_Cipher.HillCipher2x2.encryptText(plainText, key);
                            string _plainText = Hill_Cipher.HillCipher2x2.decryptText(cipherText, key);
                            Boolean decryptable = (plainText == _plainText);
                            if (conditionMet)
                                if (decryptable)
                                    conditionMet_decryptable += 1;
                                else
                                    conditionMet_notDecryptable += 1;
                            else
                                if (decryptable)
                                    conditionNotMet_decryptable += 1;
                                else
                                    conditionNotMet_notDecryptable += 1;
                            total += 1;
                        }
            Console.WriteLine();
            Console.WriteLine("Condition met, decryptable: " + conditionMet_decryptable.ToString());
            Console.WriteLine("Condition met, not decryptable: " + conditionMet_notDecryptable.ToString());
            Console.WriteLine("Condition didn't meet, decryptable: " + conditionNotMet_decryptable.ToString());
            Console.WriteLine("Condition didn't meet, not decryptable: " + conditionNotMet_notDecryptable.ToString());
            Console.WriteLine("Total: " + total.ToString() + " ");
            Console.WriteLine("Verification took " + bm.getBenchmarkResult() + ".\n");
            
        }

        static void benchmarkCipher()
        {
            string plainText = "abcdefghijklmnopqrstuvwxyz".ToUpper();
            //plainText = Hill_Cipher.HillCipher2x2.plainTextFullSample(); // if you want a bigger sample
            Matrix key = Hill_Cipher.Matrix.generateNewKey(2);
            string cipherText = Hill_Cipher.HillCipher2x2.encryptText(plainText, key);
            int loops = 1000000;

            benchmark bm = new benchmark();
            bm.startBenchmark();

            for (int i = 0; i < loops; i++)
            {
                key = Hill_Cipher.Matrix.generateNewKey(2);
            }
            Console.WriteLine("Generating a new key " + loops.ToString() + " times took " + bm.getBenchmarkResult() + ".");

            bm.startBenchmark();
            for (int i = 0; i < loops; i++)
            {
                string _cipherText = Hill_Cipher.HillCipher2x2.encryptText(plainText, key);
            }
            Console.WriteLine("Encrypting the sample (" + plainText.Length + " chars) " + loops.ToString() + " times took " + bm.getBenchmarkResult() + ".");

            bm.startBenchmark();
            for (int i = 0; i < loops; i++)
            {
                string _plainText = Hill_Cipher.HillCipher2x2.decryptText(cipherText, key);
            }
            Console.WriteLine("Decrypting the sample (" + cipherText.Length + " chars) " + loops.ToString() + " times took " + bm.getBenchmarkResult() + ".");
        }
    }
}
