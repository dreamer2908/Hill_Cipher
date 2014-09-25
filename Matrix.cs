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

        public int Height { get { return _matrix.GetLength(0); } }
        public int Width { get { return _matrix.GetLength(1); } }

        public int this[int x, int y]
        {
            get { return _matrix[x, y]; }
            set { _matrix[x, y] = value; }
        }

        public Boolean isUsable()
        {
            int det = this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];
            return (det != 0 && det % 2 != 0 && det % 13 != 0);
        }

        public static int modInverse(int _a, int m)
        {
            // modular multiplicative inverse
            int a = _a % m;
            for (int x = 0; x < m; x++)
            {
                if ((a * x) % m == 1) // according to the defination
                {
                    return x;
                }
            }
            return -1; // couldn't find its modular multiplicative inverse
        }

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
            re.Modular(26);
            //System.Windows.Forms.MessageBox.Show(re.String2Show());
            return re;
        }

        public static Matrix Inverse2x2Matrix(Matrix m)
        {
            // see Cryptography and Network Security Principles and Practice, 5th Edition, page 46

            if (!(m.Height == 2 && m.Width == 2)) // wrong size
                return null; 

            Matrix re = new Matrix(2, 2);

            int det = m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];
            int miDet = (int)modInverse(det, 26);
            // System.Windows.Forms.MessageBox.Show("det = " + det.ToString() + " miDet = " + miDet.ToString()); 

            re[0, 0] = (m[1, 1] * miDet);
            re[0, 1] = (-m[0, 1] * miDet);
            re[1, 0] = (-m[1, 0] * miDet);
            re[1, 1] = (m[0, 0] * miDet);
            re.Modular(26);

            return re;
        }

        // The way C# modular number, though not wrong, is unsuitable for our purpose
        // Modular must be always non-negative
        public void Modular(int m)
        {
            for (int i = 0; i < this.Height; i++)
                for (int j = 0; j < this.Width; j++)
                {
                    this[i, j] %= m;
                    if (this[i, j] < 0)
                        this[i, j] = m + this[i, j];
                }
        }

        public static Matrix MultipleBy(Matrix m, int n)
        {            
            Matrix re = new Matrix(m.Height, m.Width);

            for (int i = 0; i < re.Height; i++)
            {
                for (int j = 0; j < re.Width; j++)
                {
                    re[i, j] = n * m[i, j];
                }
            }
            return re;
        }

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
