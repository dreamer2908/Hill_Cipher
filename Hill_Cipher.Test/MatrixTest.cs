using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Hill_Cipher.Test
{
    [TestFixture]
    public class MatrixTest
    {
        [TestCase(-174, 1, 0)]
        [TestCase(678, 1, 0)]
        [TestCase(2, 26, 2)]
        [TestCase(17, 26, 17)]
        [TestCase(70, 26, 18)]
        [TestCase(0, 26, 0)]
        [TestCase(-2, 26, 24)]
        [TestCase(-17, 26, 9)]
        [TestCase(-70, 26, 8)]
        [TestCase(-1, -26, -1)]
        [TestCase(70, -26, -8)]
        [TestCase(-70, -26, -18)]
        public void modular_VariousInputs_ChecksThem(int a, int m, int expected)
        {
            int re = Hill_Cipher.Matrix.modular(a, m);
            Assert.AreEqual(expected, re);
        }

        [Test]
        public void modular_ZeroM_ThrowsFluent()
        {
            var ex = Assert.Catch<Exception>(() => Hill_Cipher.Matrix.modular(12, 0));
            Assert.That(ex.Message, Is.StringContaining("divide by zero"));
        }

        [TestCase(23, 17)]
        [TestCase(9, 3)]
        [TestCase(1, 1)]
        [TestCase(-1, 25)]
        [TestCase(-19, 15)]
        [TestCase(-19251, 7)]
        [TestCase(19251, 19)]
        [TestCase(0, -1)] // mod inverse not found
        [TestCase(2, -1)]
        [TestCase(13, -1)]
        public void modInverse_VariousAMod26_ChecksThem(int a, int expected)
        {
            int re = Hill_Cipher.Matrix.modInverse(a, 26);
            Assert.AreEqual(expected, re);
        }

        [TestCase(1, 1, 0, 0, false)] // det = 0
        [TestCase(1, -1, 1, 1, false)] // det = 2
        [TestCase(7, 4, -1, 5, false)] // det = 39
        [TestCase(2, 3, 3, 5, true)] // det = 1
        [TestCase(10, 3, 25, 5, true)] // det = -25
        [TestCase(7, 7, 1, 2, true)] // det = 21
        public void isUsable_VariousInputs_ChecksThem(int k1, int k2, int k3, int k4, Boolean expected)
        {
            Matrix m = new Matrix(2, 2);
            m[0, 0] = k1;
            m[0, 1] = k2;
            m[1, 0] = k3;
            m[1, 1] = k4;
            Assert.AreEqual(expected, m.isUsable());
        }

        [Test]
        public void generateNewKey_None_ReturnsAUsableKey()
        {
            Matrix newKey = Matrix.generateNewKey();
            Assert.AreEqual(true, newKey.isUsable());
        }

        [TestCase(7, 7, 1, 0, 7, 7, 1, 0, 26)]
        [TestCase(70, -2, -17, -70, 18, 24, 9, 8, 26)]
        public void ModularBy_VariousInputs_ChecksThem(int k1, int k2, int k3, int k4, int l1, int l2, int l3, int l4, int mod)
        {
            Matrix m1 = new Matrix(2, 2);
            m1[0, 0] = k1;
            m1[0, 1] = k2;
            m1[1, 0] = k3;
            m1[1, 1] = k4;
            m1.ModularBy(mod);
            Matrix m2 = new Matrix(2, 2);
            m2[0, 0] = l1;
            m2[0, 1] = l2;
            m2[1, 0] = l3;
            m2[1, 1] = l4;
            Assert.AreEqual(m2.String2Show(), m1.String2Show());
        }

        [Test]
        public void Multiply_WrongSize_ReturnsNull()
        {
            Matrix m1 = new Matrix(2, 1);
            Matrix m2 = new Matrix(3, 4);
            Matrix re = Matrix.Multiply(m1, m2);
            Assert.AreEqual(null, re);
        }

        [TestCase(3, 3, 2, 5, 7, 4, 7, 8)]
        [TestCase(25, 22, 1, 23, 7, 17, 3, 8)]
        [TestCase(25, 22, 1, 23, 2, 25, 2, 5)]
        public void Multiply_VariousInputs2x2x2x1_ChecksThem(int m1_00, int m1_01, int m1_10, int m1_11, int m2_00, int m2_10, int m3_00, int m3_10)
        {
            Matrix m1 = new Matrix(2, 2);
            m1[0, 0] = m1_00;
            m1[0, 1] = m1_01;
            m1[1, 0] = m1_10;
            m1[1, 1] = m1_11;
            Matrix m2 = new Matrix(2, 1);
            m2[0, 0] = m2_00;
            m2[1, 0] = m2_10;
            Matrix m3 = new Matrix(2, 1);
            m3[0, 0] = m3_00;
            m3[1, 0] = m3_10;
            Matrix re = Matrix.Multiply(m1, m2);
            Assert.AreEqual(m3.String2Show(), re.String2Show());
        }

        [TestCase(3, 3, 2, 5, 7, 4, 1, 1)]
        [TestCase(3, 3, 2, 5, 11, 15, 13, 8)]
        [TestCase(25, 22, 1, 23, 7, 17, 23, 13)]
        [TestCase(25, 22, 1, 23, 2, 25, 17, 7)]
        public void Multiply_VariousInputs1x2x2x2_ChecksThem(int m1_00, int m1_01, int m2_00, int m2_01, int m2_10, int m2_11, int m3_00, int m3_01)
        {
            Matrix m1 = new Matrix(1, 2);
            m1[0, 0] = m1_00;
            m1[0, 1] = m1_01;
            Matrix m2 = new Matrix(2, 2);
            m2[0, 0] = m2_00;
            m2[0, 1] = m2_01;
            m2[1, 0] = m2_10;
            m2[1, 1] = m2_11;
            Matrix m3 = new Matrix(1, 2);
            m3[0, 0] = m3_00;
            m3[0, 1] = m3_01;
            Matrix re = Matrix.Multiply(m1, m2);
            Assert.AreEqual(m3.String2Show(), re.String2Show());
        }

        public void Multiply_VariousInputs_ChecksThem(int m1_00, int m1_01, int m1_10, int m1_11, int m2_00, int m2_01, int m2_10, int m2_11, int m3_00, int m3_01, int m3_10, int m3_11)
        {
        }

        [TestCase(5, 2, -7, -3)]
        [TestCase(5, 8, 17, 3)]
        [TestCase(5, 3, 5, 3)]
        public void Inverse2x2Matrix_VariousInputs_ChecksThem(int k1, int k2, int k3, int k4)
        {
            Matrix m1 = new Matrix(2, 2);
            m1[0, 0] = k1;
            m1[0, 1] = k2;
            m1[1, 0] = k3;
            m1[1, 1] = k4;
            Matrix unitM = new Matrix(2, 2);
            unitM[0, 0] = 1;
            unitM[0, 1] = 0;
            unitM[1, 0] = 0;
            unitM[1, 1] = 1;
            Matrix zeroM = new Matrix(2, 2);
            zeroM.zeroFill();
            Matrix m2 = Matrix.Inverse2x2Matrix(m1);
            Matrix product = Matrix.Multiply(m1, m2);
            if (m1.isUsable()) // inversible
            {
                Assert.AreEqual(product.String2Show(), unitM.String2Show());
            }
            else // return zero matrix if it's not inversible
            {
                Assert.AreEqual(product.String2Show(), zeroM.String2Show()); 
            }
        }

        [Test]
        public void Inverse2x2Matrix_WrongSize_ReturnsNull()
        {
            Matrix m = new Matrix(2, 1);
            var re = Matrix.Inverse2x2Matrix(m);
            Assert.AreEqual(null, re);
        }
    }
}
