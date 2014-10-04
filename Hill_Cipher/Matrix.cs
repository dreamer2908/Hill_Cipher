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

        public void zeroFill()
        {
            for (int x = 0; x < dim1; x++)
                for (int y = 0; y < dim2; y++)
                    this[x, y] = 0;
        }

        static public Matrix unit(int size)
        {
            Matrix re = new Matrix(size, size);
            for (int x = 0; x < size; x++)
                re[x, x] = 1;
            return re;
        }

        static public Matrix zero(int size)
        {
            Matrix re = new Matrix(size, size);
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    re[x, y] = 0;
            return re;
        }

        static public Matrix zero(int dim1, int dim2)
        {
            Matrix re = new Matrix(dim1, dim2);
            for (int x = 0; x < dim1; x++)
                for (int y = 0; y < dim2; y++)
                    re[x, y] = 0;
            return re;
        }

        static public Matrix zeroLike(Matrix m)
        {
            int dim1 = m.dim1, dim2 = m.dim2;
            Matrix re = new Matrix(dim1, dim2);
            for (int x = 0; x < dim1; x++)
                for (int y = 0; y < dim2; y++)
                    re[x, y] = 0;
            return re;
        }

        // A key is usable if its determinant is not zero, and not divisible by both 2 and 13
        public Boolean isUsable()
        {
            int det = this.determinant();
            return ((det != 0 && det % 2 != 0 && det % 13 != 0) && (this.Width == this.Height));
        }
        // its size should be 2x2, too
        public Boolean isUsable2x2()
        {
            if (this.Width == 2 && this.Height == 2)
            {
                return this.isUsable();
            }
            return false;
        }

        public Boolean isSquare()
        {
            return (this.Height == this.Width);
        }

        public Boolean isColumn()
        {
            return (this.dim2 == 1);
        }

        public Boolean isRow()
        {
            return (this.dim1 == 1);
        }

        public Boolean isZero()
        {
            for (int i = 0; i < this.Height; i++)
                for (int j = 0; j < this.Width; j++)
                    if (this[i, j] != 0)
                        return false;
            return true;
        }

        // calculate the determinant of this matrix. Supports any size
        public int determinant()
        {
            if ((this.Height != this.Width))
            {
                Exception e = new Exception("Matrix must be square!");
                throw e;
            }

            // see https://en.wikipedia.org/wiki/Determinant
            // and http://ctec.tvu.edu.vn/ttkhai/TCC/63_Dinh_thuc.htm
            // and http://mathworld.wolfram.com/Determinant.html
            // Using recursive implemention
            int det = 0;
            int n = this.Height;

            if (n == 1)
            {
                return this[0, 0];
            }

            for (int j = 0; j < n; j++)
            {
                // copy everything but row i column j to create minorMatrix
                Matrix minorMatrix = new Matrix(n - 1, n - 1);
                for (int x = 0; x < n - 1; x++)
                {
                    int r = (x < 1) ? x : x + 1;
                    for (int y = 0; y < n - 1; y++)
                    {
                        int c = (y < j) ? y : y + 1;
                        minorMatrix[x, y] = this[r, c];
                    }
                }
                int minorDet = minorMatrix.determinant();
                int cofactor = (int)Math.Pow(-1, 1 + j) * minorDet;
                det = det + cofactor * this[1, j];
            }

            return det;
        }

        // check if this matrix can be inversed
        public Boolean inversible()
        {
            return (this.determinant() != 0);
        }

        private static Random _r = new Random(); // random number generator had better be static

        public static Matrix generateNewKey(int size)
        {
            // get new random numbers until got a usable key
            // usually got one after one or two attempts
            Matrix newKey = new Matrix(size, size);
            // int count = 0;
            while (!newKey.isUsable())
            {
                // count += 1;
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                        newKey[i, j] = _r.Next(0, 25);
            }
            // System.Windows.Forms.MessageBox.Show("Took " + count.ToString() + " attempts to get a usable key");
            return newKey;
        }

        public static Boolean operator ==(Matrix m1, Matrix m2)
        {
            return (m1.ToString() == m2.ToString());
        }

        public static Boolean operator !=(Matrix m1, Matrix m2)
        {
            return (m1.ToString() != m2.ToString());
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            return Add(m1, m2);
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            return m1 + (m2 * -1);
        }

        public static Matrix operator -(Matrix m1)
        {
            return (m1 * -1);
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            return Multiply(m1, m2);
        }

        public static Matrix operator *(Matrix m1, int scalar)
        {
            return Multiply(m1, scalar);
        }

        public static Matrix operator *(int scalar, Matrix m1)
        {
            return Multiply(m1, scalar);
        }

        public static Matrix operator /(Matrix m1, Matrix m2)
        {
            return Divide(m1, m2);
        }

        public static Matrix operator /(Matrix m1, int scalar)
        {
            return Divide(m1, scalar);
        }

        public static Matrix operator /(int scalar, Matrix m1)
        {
            return Divide(m1, scalar);
        }

        // Get the inverse matrix of m
        public static Matrix operator ~(Matrix m)
        {
            return Matrix.Inverse(m);
        }

        // Return the sum of m1 and m2. They must be in the same size
        public static Matrix Add(Matrix m1, Matrix m2)
        {
            if (m1.Width != m2.Width || m1.Height != m2.Height)
            {
                Exception e = new Exception("Two matrixes must be the same in size!");
                throw e;
            }

            Matrix re = new Matrix(m1.Height, m2.Width);
            for (int i = 0; i < re.Height; i++)
            {
                for (int j = 0; j < re.Width; j++)
                {
                    re[i, j] = m1[i, j] + m2[i, j];
                }
            }
            re.ModularBy(26);
            return re;
        }

        // Return the product of matrix m1 and m2.
        public static Matrix Multiply(Matrix m1, Matrix m2)
        {
            if (m1.Width != m2.Height) // wrong size
            {
                Exception e = new Exception("First matrix's width must be equal with second matrix's height!");
                throw e;
            }

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
            re.ModularBy(26);
            return re;
        }

        // Scalar multiply matrix m1 by scalar
        public static Matrix Multiply(Matrix m1, int scalar)
        {
            Matrix re = new Matrix(m1.Height, m1.Width);
            for (int i = 0; i < re.Height; i++)
                for (int j = 0; j < re.Width; j++)
                    re[i, j] = m1[i, j] * scalar;
            re.ModularBy(26);
            return re;
        }

        // Scalar multiply matrix m1 by 1/scalar
        public static Matrix Divide(Matrix m1, int scalar)
        {
            return Multiply(m1, 1 / scalar);
        }

        // Calculate product of matrix m1 and the inverse matrix of m2.
        public static Matrix Divide(Matrix m1, Matrix m2)
        {
            if (m1.Width != m2.Height || !m2.isSquare()) // wrong size
            {
                Exception e = new Exception("First matrix's width must be equal with second matrix's height AND the second matrix must be square!");
                throw e;
            }

            return m1 * Matrix.Inverse(m2);
        }

        // Inverse matrix m (size 2x2) and return as a new matrix
        // Shouldn't modify this matrix because it will be reused again and again
        // see Cryptography and Network Security Principles and Practice, 5th Edition, page 46
        public static Matrix Inverse(Matrix m)
        {
            int size = m.Height;
            if (m.Height != m.Width)
            {
                Exception e = new Exception("Matrix must be square!");
                throw e;
            }
            if (!m.isUsable()) // so not inversible 
            {
                // still return for the sake of simplicity
                // Zero matrix * any matrix = zero matrix
                return Matrix.zero(size);
            }

            int det = m.determinant();
            int miDet = (int)modInverse(det, 26);

            Matrix re = new Matrix(size, size);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    // copy everything but row *j* column *i* to create minorMatrix 
                    // It's NOT the same as in determinant()
                    Matrix minorMatrix = new Matrix(size - 1, size - 1);
                    for (int x = 0; x < size - 1; x++)
                    {
                        int r = (x < j) ? x : x + 1;
                        for (int y = 0; y < size - 1; y++)
                        {
                            int c = (y < i) ? y : y + 1;
                            minorMatrix[x, y] = m[r, c];
                        }
                    }
                    int minorDet = minorMatrix.determinant();
                    re[i, j] = miDet * (int)Math.Pow(-1, i + j) * minorDet;
                }
            re.ModularBy(26);
            return re;
        }

        // reflect A over its main diagonal (which runs from top-left to bottom-right) to obtain A transpose
        public static Matrix Transpose(Matrix m)
        {
            Matrix re = new Matrix(m.Width, m.Height);
            for (int i = 0; i < re.Height; i++)
                for (int j = 0; j < re.Width; j++)
                    re[i, j] = m[j, i];
            return re;
        }

        // Return a separated copy of matrix m
        public static Matrix Duplicate(Matrix m)
        {
            Matrix re = new Matrix(m.Height, m.Width);
            for (int i = 0; i < re.Height; i++)
                for (int j = 0; j < re.Width; j++)
                    re[i, j] = m[i, j];
            return re;
        }

        public override bool Equals(object obj)
        {
            return (this.GetHashCode() == obj.GetHashCode());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        // create a string from this matrix
        public override string ToString()
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
    }
}
