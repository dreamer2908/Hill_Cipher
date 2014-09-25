﻿using System;
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

        // modular multiplicative inverse
        public static int modInverse(int _a, int m)
        {
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

        public static Matrix Multiplication(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix(m1.Height, m2.Width);

            for (int i = 0; i < result.Height; i++)
            {
                for (int j = 0; j < result.Width; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < m1.Width; k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j];
                    }
                    // resultMatrix[i, j] = resultMatrix[i, j] % 26;
                }
            }
            return result;
        }

        public static Matrix Inverse2x2Matrix(Matrix m)
        {
            // see Cryptography and Network Security Principles and Practice, 5th Edition, page 46

            if (!(m.Height == 2 && m.Width == 2))
                return null; // return nothing if wrong size

            Matrix result = new Matrix(2, 2);

            int det = m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];
            int miDet = (int)modInverse(det, 26);

            result[0, 0] = (m[1, 1] * miDet) % 26;
            result[0, 1] = (-m[0, 1] * miDet) % 26;
            result[1, 0] = (-m[1, 0] * miDet) % 26;
            result[1, 1] = (m[0, 0] * miDet) % 26;

            return result;
        }

        public static Matrix MultipleBy(Matrix m, int n)
        {            
            Matrix result = new Matrix(m.Height, m.Width);

            for (int i = 0; i < result.Height; i++)
            {
                for (int j = 0; j < result.Width; j++)
                {
                    result[i, j] = n * m[i, j];
                }
            }
            return result;
        }

        public string String2Show()
        {
            // string tmp = Format(this[0, 0]) + " " + Format(this[0, 1]) + " " + Format(this[0, 2]) + "\n" + Format(this[1, 0]) + " " + Format(this[1, 1]) + " " + Format(this[1, 2]) + "\n" + Format(this[2, 0]) + " " + Format(this[2, 1]) + " " + Format(this[2, 2]);
            string tmp = Format(this[0, 0]) + " " + Format(this[0, 1]) + " \n" + Format(this[1, 0]) + " " + Format(this[1, 1]);

            return tmp;
        }

        public string String2Show2()
        {
            // string tmp = Format(this[0, 0]) + " " + Format(this[0, 1]) + " " + Format(this[0, 2]) + "\n" + Format(this[1, 0]) + " " + Format(this[1, 1]) + " " + Format(this[1, 2]) + "\n" + Format(this[2, 0]) + " " + Format(this[2, 1]) + " " + Format(this[2, 2]);
            string tmp = Format(this[0, 0]) + " " + Format(this[0, 1]);

            return tmp;
        }

        private string Format(int n)
        {
            return String.Format("{0:0.###############}", n);
        }
    }
}
