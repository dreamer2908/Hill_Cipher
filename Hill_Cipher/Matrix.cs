using System;
using System.Collections.Generic;
using System.Text;

namespace Hill_Cipher
{
    public class Matrix
    {
        private readonly int[,] _matrix;

        public Matrix(int dim1, int dim2)
        {
            _matrix = new int[dim1, dim2];
        }
        // Height (dim1) = number of rows, width (dim2) = number of columns
        public int Height { get { return _matrix.GetLength(0); } }
        public int Width { get { return _matrix.GetLength(1); } }
        public int dim1 { get { return _matrix.GetLength(0); } }
        public int dim2 { get { return _matrix.GetLength(1); } }

        public int this[int x, int y]
        {
            get { return _matrix[x, y]; }
            set { _matrix[x, y] = value; }
        }

        // A key is usable if its determinant is not zero, and not divisible by both 2 and 13
        // its size should be 2x2, too
        public Boolean isUsable()
        {
            if (this.Width == 2 && this.Height == 2)
            {
                int det = this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];
                return (det != 0 && det % 2 != 0 && det % 13 != 0);
            }
            return false;
        }

        private static Random _r = new Random(); // random number generator had better be static

        public static Matrix generateNewKey()
        {
            // get new random numbers until got a usable key
            // usually got one after one or two attempts
            Matrix newKey = new Matrix(2, 2);
            // int count = 0;
            while (!newKey.isUsable())
            {
                // count += 1;
                newKey[0, 0] = _r.Next(0, 25);
                newKey[0, 1] = _r.Next(0, 25);
                newKey[1, 0] = _r.Next(0, 25);
                newKey[1, 1] = _r.Next(0, 25);
            }
            // System.Windows.Forms.MessageBox.Show("Took " + count.ToString() + " attempts to get a usable key");
            return newKey;
        }

        // modular multiplicative inverse
        public static int modInverse(int _a, int m)
        {
            int a = _a % m;
            for (int x = 0; x < m; x++)
            {
                if (modular((a * x), m) == 1) // according to the definition
                {
                    return x;
                }
            }
            return -1; // couldn't find its modular multiplicative inverse
        }

        // multiply matrix m1 by matrix m2 and return as a new matrix
        // and modular by 26
        // Shouldn't modify this matrix because it will be reused again and again
        public static Matrix Multiply(Matrix m1, Matrix m2)
        {
            if (m1.Width != m2.Height) // wrong size
                return null; 

            Matrix re = new Matrix(m1.Height, m2.Width);
            for (int i = 0; i < re.Height; i++)
            {
                for (int j = 0; j < re.Width; j++)
                {
                    re[i, j] = 0;
                    for (int k = 0; k < m1.Width; k++)
                    {
                        re[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            //System.Windows.Forms.MessageBox.Show(re.String2Show());
            re.ModularBy(26);
            //System.Windows.Forms.MessageBox.Show(re.String2Show());
            return re;
        }

        // Inverse matrix m (size 2x2) and return as a new matrix
        // Shouldn't modify this matrix because it will be reused again and again
        public static Matrix Inverse2x2Matrix(Matrix m)
        {
            // see Cryptography and Network Security Principles and Practice, 5th Edition, page 46

            if (!(m.Height == 2 && m.Width == 2)) // wrong size
                return null;
            if (!m.isUsable()) // so not inversible
                return null;

            int det = m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];
            int miDet = (int)modInverse(det, 26);
            // System.Windows.Forms.MessageBox.Show("det = " + det.ToString() + " miDet = " + miDet.ToString()); 
            Matrix re = new Matrix(2, 2);
            re[0, 0] = (m[1, 1] * miDet);
            re[0, 1] = (-m[0, 1] * miDet);
            re[1, 0] = (-m[1, 0] * miDet);
            re[1, 1] = (m[0, 0] * miDet);
            re.ModularBy(26);

            return re;
        }

        // The way C# modular number, while not wrong, is unsuitable for our purpose
        // Modular must be always non-negative
        public static int modular(int a, int m)
        {
            int re = a % m;
            if (re * m < 0)
                re = m + re;
            return re;
        }

        // modular this matrix by m
        public void ModularBy(int m)
        {
            for (int i = 0; i < this.Height; i++)
                for (int j = 0; j < this.Width; j++)
                    this[i, j] = modular(this[i, j], m);
        }

        // create a string from this matrix
        public string String2Show()
        {
            String re = "";
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    re += Format(this[i, j]) + " ";
                }
                re += "\n";
            }
            return re;
        }

        private string Format(int n)
        {
            return String.Format("{0:0.###############}", n);
        }
    }
}
