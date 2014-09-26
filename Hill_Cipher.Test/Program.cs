using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Hill_Cipher
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void modInverse_23_imod_26_Returns17()
        {
            int re = Hill_Cipher.Matrix.modInverse(23, 26);
            Assert.AreEqual(17, re);
        }
    }
}

namespace Hill_Cipher.Test
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
