﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Hill_Cipher.Test
{
    [TestFixture]
    public class MatrixTest
    {

        #region Tests for modular
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
            Assert.AreEqual(m2.ToString(), m1.ToString());
        }
        #endregion

        #region Tests for modInverse
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
        #endregion

        #region Tests for isUsable
        [TestCase(1, 1, 0, 0, false)] // det = 0
        [TestCase(1, -1, 1, 1, false)] // det = 2
        [TestCase(7, 4, -1, 5, false)] // det = 39
        [TestCase(2, 3, 3, 5, true)] // det = 1
        [TestCase(10, 3, 25, 5, true)] // det = -25
        [TestCase(7, 7, 1, 2, true)] // det = 21
        public void isUsable2x2_VariousInputs_ChecksThem(int k1, int k2, int k3, int k4, Boolean expected)
        {
            Matrix m = new Matrix(2, 2);
            m[0, 0] = k1;
            m[0, 1] = k2;
            m[1, 0] = k3;
            m[1, 1] = k4;
            Assert.AreEqual(expected, m.isUsable2x2);
        }

        [TestCase(17, 17, 5, 21, 18, 21, 2, 2, 19, true)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, 0, false)]
        public void isUsable_3x3Inputs_ChecksThem(int m1_00, int m1_01, int m1_02, int m1_10, int m1_11, int m1_12, int m1_20, int m1_21, int m1_22, Boolean expected)
        {
            Matrix m1 = new Matrix(3, 3);
            m1[0, 0] = m1_00;
            m1[0, 1] = m1_01;
            m1[0, 2] = m1_02;
            m1[1, 0] = m1_10;
            m1[1, 1] = m1_11;
            m1[1, 2] = m1_12;
            m1[2, 0] = m1_20;
            m1[2, 1] = m1_21;
            m1[2, 2] = m1_22;
            Assert.AreEqual(expected, m1.isUsable);
        }
        #endregion

        #region Tests for generateNewKey
        [Test]
        public void generateNewKey_None_ReturnsAUsableKey()
        {
            Matrix newKey = Matrix.generateNewKey(2);
            Assert.AreEqual(true, newKey.isUsable2x2);
        }
        #endregion
        
        #region Tests for Multiply
        [Test]
        public void Multiply_WrongSize_ThrowsFluent()
        {
            Matrix m1 = new Matrix(2, 1);
            Matrix m2 = new Matrix(3, 4);
            var ex = Assert.Catch<Exception>(() => Hill_Cipher.Matrix.Multiply(m1, m2));
            Assert.That(ex.Message, Is.StringContaining("First matrix's width must be equal with second matrix's height"));
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
            Matrix re = m1 * m2;
            Assert.AreEqual(m3.ToString(), re.ToString());
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
            Matrix re = m1 * m2;
            Assert.AreEqual(m3.ToString(), re.ToString());
        }
        #endregion

        #region Tests for Inverse

        [TestCase(5, 2, -7, -3)]
        [TestCase(5, 8, 17, 3)]
        [TestCase(5, 3, 5, 3)]
        public void Inverse_2x2Inputs_ChecksThem(int k1, int k2, int k3, int k4)
        {
            Matrix m1 = new Matrix(2, 2);
            m1[0, 0] = k1;
            m1[0, 1] = k2;
            m1[1, 0] = k3;
            m1[1, 1] = k4;
            Matrix unitM = Matrix.unit(2);
            Matrix zeroM = Matrix.zero(2);
            Matrix re = Matrix.Inverse(m1);
            Matrix product = Matrix.Multiply(m1, re);
            if (m1.isUsable) // invertible
            {
                Assert.AreEqual(product.ToString(), unitM.ToString());
            }
            else // return zero matrix if it's not invertible
            {
                Assert.AreEqual(re.ToString(), zeroM.ToString()); 
            }
        }

        [TestCase(-2, 3, -1, 5, -1, 4, 4, -8, 2)]
        [TestCase(10, 0, -3, -2, -4, 1, 3, 0, 2)]
        [TestCase(2, -3, -2, -6, 3, 3, -2, -3, -2)]
        [TestCase(-4, 5, 2, -3, 4, 2, -1, 2, 5)]
        [TestCase(1, -3, -6, -1, 5, 5, -1, 6, 5)]
        [TestCase(17, 17, 5, 21, 18, 21, 2, 2, 19)]
        public void Inverse_3x3Inputs_ChecksThem(int m1_00, int m1_01, int m1_02, int m1_10, int m1_11, int m1_12, int m1_20, int m1_21, int m1_22)
        {
            Matrix m1 = new Matrix(3, 3);
            m1[0, 0] = m1_00;
            m1[0, 1] = m1_01;
            m1[0, 2] = m1_02;
            m1[1, 0] = m1_10;
            m1[1, 1] = m1_11;
            m1[1, 2] = m1_12;
            m1[2, 0] = m1_20;
            m1[2, 1] = m1_21;
            m1[2, 2] = m1_22;
            Matrix re = Matrix.Inverse(m1);
            // System.Windows.Forms.MessageBox.Show(re.ToString());
            Matrix unitM = Matrix.unit(3);
            Matrix zeroM = Matrix.zero(3);
            Matrix product = m1 * re;
            if (m1.isUsable) // invertible
            {
                Assert.AreEqual(product.ToString(), unitM.ToString());
            }
            else // return zero matrix if it's not invertible
            {
                Assert.AreEqual(re.ToString(), zeroM.ToString());
            }
        }

        [TestCase(17, 17, 5, 1, 21, 18, 21, 0, 2, 2, 19, 3, 4, 6, -1, 5)]
        [TestCase(3, -5, -15, 1, 0, 2, -9, 10, 2, 3, -19, 23, -4, 0, -3, 5)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        public void Inverse_4x4Inputs_ChecksThem(int m1_00, int m1_01, int m1_02, int m1_03, int m1_10, int m1_11, int m1_12, int m1_13, int m1_20, int m1_21, int m1_22, int m1_23, int m1_30, int m1_31, int m1_32, int m1_33)
        {
            Matrix m1 = new Matrix(4, 4);
            m1[0, 0] = m1_00;
            m1[0, 1] = m1_01;
            m1[0, 2] = m1_02;
            m1[0, 3] = m1_03;
            m1[1, 0] = m1_10;
            m1[1, 1] = m1_11;
            m1[1, 2] = m1_12;
            m1[1, 3] = m1_13;
            m1[2, 0] = m1_20;
            m1[2, 1] = m1_21;
            m1[2, 2] = m1_22;
            m1[2, 3] = m1_23;
            m1[3, 0] = m1_30;
            m1[3, 1] = m1_31;
            m1[3, 2] = m1_32;
            m1[3, 3] = m1_33;
            Matrix re = Matrix.Inverse(m1);
            // System.Windows.Forms.MessageBox.Show(re.ToString());
            Matrix unitM = Matrix.unit(4);
            Matrix zeroM = Matrix.zero(4);
            Matrix product = m1 * re;
            if (m1.isUsable) // invertible
            {
                Assert.AreEqual(product.ToString(), unitM.ToString());
            }
            else // return zero matrix if it's not invertible
            {
                Assert.AreEqual(re.ToString(), zeroM.ToString());
            }
        }

        [Test]
        public void Inverse_WrongSize_ThrowsFluent()
        {
            Matrix m = new Matrix(3, 2);
            var ex = Assert.Catch<Exception>(() => Hill_Cipher.Matrix.Inverse(m));
            Assert.That(ex.Message, Is.StringContaining("Matrix must be square"));
        }
        #endregion

        # region Tests for determinant
        [TestCase(1, 1, 1, 1)]
        [TestCase(5, 2, -7, -3)]
        [TestCase(5, 8, 17, 3)]
        [TestCase(5, 3, 5, 3)]
        public void determinant_2x2Inputs_ChecksThem(int m2_00, int m2_01, int m2_10, int m2_11)
        {
            Matrix m2 = new Matrix(2, 2);
            m2[0, 0] = m2_00;
            m2[0, 1] = m2_01;
            m2[1, 0] = m2_10;
            m2[1, 1] = m2_11;
            int expected = m2[0, 0] * m2[1, 1] - m2[0, 1] * m2[1, 0];
            Assert.AreEqual(expected, m2.determinant);
        }

        [TestCase(-2, 2, -3, -1, 1, 3, 2, 0, -1, 18)]
        [TestCase(1, 2, 3, 2, 3, 1, 3, 1, 2, -18)]
        [TestCase(-2, 3, -1, 5, -1, 4, 4, -8, 2, -6)]
        [TestCase(10, 0, -3, -2, -4, 1, 3, 0, 2, -116)]
        [TestCase(2, -3, -2, -6, 3, 3, -2, -3, -2, 12)]
        [TestCase(-4, 5, 2, -3, 4, 2, -1, 2, 5, -3)]
        [TestCase(1, -3, -6, -1, 5, 5, -1, 6, 5, 1)]
        public void determinant_3x3Inputs_ChecksThem(int m1_00, int m1_01, int m1_02, int m1_10, int m1_11, int m1_12, int m1_20, int m1_21, int m1_22, int expected)
        {
            Matrix m1 = new Matrix(3, 3);
            m1[0, 0] = m1_00;
            m1[0, 1] = m1_01;
            m1[0, 2] = m1_02;
            m1[1, 0] = m1_10;
            m1[1, 1] = m1_11;
            m1[1, 2] = m1_12;
            m1[2, 0] = m1_20;
            m1[2, 1] = m1_21;
            m1[2, 2] = m1_22;
            Assert.AreEqual(expected, m1.determinant);
        }

        [TestCase(9, 3, 5, 1, -6, -9, 7, 2, -1, -8, 1, 3, 9, 3, 5, 0, -615)]
        [TestCase(0, -3, 25, 8, -1, -2, 9, -2, 11, -4, 1, 0, -5, 3, -5, 1, 0)]
        [TestCase(20, -3, 0, 18, -1, -12, 0, 2, 4, 4, -1, 12, -25, 13, 0, 21, 11107)]
        public void determinant_4x4Inputs_ChecksThem(int m1_00, int m1_01, int m1_02, int m1_03, int m1_10, int m1_11, int m1_12, int m1_13, int m1_20, int m1_21, int m1_22, int m1_23, int m1_30, int m1_31, int m1_32, int m1_33, int expected)
        {
            Matrix m1 = new Matrix(4, 4);
            m1[0, 0] = m1_00;
            m1[0, 1] = m1_01;
            m1[0, 2] = m1_02;
            m1[0, 3] = m1_03;
            m1[1, 0] = m1_10;
            m1[1, 1] = m1_11;
            m1[1, 2] = m1_12;
            m1[1, 3] = m1_13;
            m1[2, 0] = m1_20;
            m1[2, 1] = m1_21;
            m1[2, 2] = m1_22;
            m1[2, 3] = m1_23;
            m1[3, 0] = m1_30;
            m1[3, 1] = m1_31;
            m1[3, 2] = m1_32;
            m1[3, 3] = m1_33;
            Assert.AreEqual(expected, m1.determinant);
        }
    #endregion

    }
}
