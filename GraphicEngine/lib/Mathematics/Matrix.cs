using Mathematics;
using Exceptions;

namespace Mathematics
{
    public class Matrix
    {
        private readonly int lines, columns;
        protected float[,] data;

        public Matrix(int n, int m)
        {
            lines = n;
            columns = m;

            data = new float[lines, columns];
        }

        public Matrix(float[,] matrix)
        {
            lines = matrix.GetLength(0);
            columns = matrix.GetLength(1);

            data = new float[lines, columns];

            for (int i = 0; i < lines; ++i)
                for (int j = 0; j < columns; ++j)
                    data[i, j] = matrix[i, j];
        }

        public Matrix(Vector vector)
        {
            lines = vector.Size;
            columns = 1;

            data = new float[lines, columns];

            for (int i = 0; i < lines; ++i)
                data[i, 0] = vector[i];
        }

        public static Matrix Identity(int n)
        {
            Matrix result = new(n, n);

            for (int i = 0; i < n; ++i)
                result[i, i] = 1;

            return result;
        }

        public (int, int) Size => (lines, columns);

        public int Lines { get { return data.GetLength(0); } }

        public int Columns { get { return data.GetLength(1); } }

        public float this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }

        public Vector this[int i]
        {
            get
            {
                Vector vector = new(Columns);

                for (int j = 0; j < Columns; j++)
                    vector[j] = data[i, j];

                return vector;
            }
        }

        public void Print()
        {
            for (int i = 0; i < lines; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    Console.Write(data[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static Matrix Sum(Matrix matrix_1, Matrix matrix_2)
        {
            if (matrix_1.lines != matrix_2.lines || matrix_1.columns != matrix_2.columns)
                throw new EngineException.DimensionException();

            Matrix result = new(matrix_1.lines, matrix_1.columns);

            for (int i = 0; i < matrix_1.lines; ++i)
                for (int j = 0; j < matrix_1.columns; ++j)
                    result[i, j] = matrix_1[i, j] + matrix_2[i, j];

            return result;
        }

        public static Matrix operator +(Matrix matrix_1, Matrix matrix_2)
            => Matrix.Sum(matrix_1, matrix_2);

        public static Matrix operator -(Matrix matrix_1, Matrix matrix_2)
            => matrix_1 + (-1) * matrix_2;

        public static Matrix ScalarMultiplication(Matrix matrix, float num)
        {
            for (int i = 0; i < matrix.lines; ++i)
                for (int j = 0; j < matrix.columns; ++j)
                    matrix[i, j] *= num;

            return matrix;
        }

        public static Matrix operator *(Matrix matrix, float num)
            => Matrix.ScalarMultiplication(matrix, num);

        public static Matrix operator *(float num, Matrix matrix)
            => matrix * num;

        public static Matrix operator /(Matrix matrix, float num)
            => matrix * (1 / num);

        public static Matrix MatrixMultiplication(Matrix matrix_1, Matrix matrix_2)
        {
            if (matrix_1.columns != matrix_2.lines)
                throw new EngineException.DimensionException();

            Matrix result = new(matrix_1.lines, matrix_2.columns);

            for (int i = 0; i < matrix_1.lines; ++i)
                for (int j = 0; j < matrix_2.columns; ++j)
                    for (int h = 0; h < matrix_1.columns; ++h)
                        result[i, j] += matrix_1[i, h] * matrix_2[h, j];

            return result;
        }

        public static Matrix operator *(Matrix matrix_1, Matrix matrix_2)
            => Matrix.MatrixMultiplication(matrix_1, matrix_2);

        public static Matrix operator /(Matrix matrix_1, Matrix matrix_2)
            => matrix_1 * matrix_2.GetInverse();

        public static Matrix VectorMatrixMultiplication(Vector vector, Matrix matrix)
        {
            if (matrix.Lines != 1)
                throw new EngineException.DimensionException();

            Matrix result = new(vector.Size, matrix.Columns);

            for (int i = 0; i < vector.Size; ++i)
                for (int j = 0; j < matrix.Columns; ++j)
                    result[i, j] = vector[i] * matrix[0, j];

            return result;
        }

        public static Matrix operator *(Vector vector, Matrix matrix)
            => Matrix.VectorMatrixMultiplication(vector, matrix);

        public Matrix GetMinor(int line, int column)
        {
            if (line >= Lines || column >= Columns)
                throw new EngineException.OutOfSizeException();

            Matrix result = new(lines - 1, columns - 1);

            for (int i = 0; i < lines; ++i)
                for (int j = 0; j < columns; ++j)
                    if (i < line && j < column)
                        result[i, j] = data[i, j];
                    else if (i < line && j > column)
                        result[i, j - 1] = data[i, j];
                    else if (i > line && j < column)
                        result[i - 1, j] = data[i, j];
                    else if (i > line && j > column)
                        result[i - 1, j - 1] = data[i, j];

            return result;
        }

        public Matrix GetTranspose()
        {
            Matrix result = new(columns, lines);

            for (int i = 0; i < columns; ++i)
                for (int j = 0; j < lines; ++j)
                    result[i, j] = data[j, i];

            return result;
        }

        public float Determinant()
        {
            if (lines != columns)
                throw new EngineException.DimensionException();

            if (lines == 1)
                return data[0, 0];
            else
            {
                float result = 0;

                for (int i = 0; i < lines; ++i)
                    result += (float)Math.Pow(-1, i) * data[0, i] * GetMinor(0, i).Determinant();

                return result;
            }
        }

        public Matrix GetInverse()
        {
            if (Determinant() == 0)
                throw new Exception("Inverse matrix does not exist, determinant is zero");

            Matrix cofactor_matrix = new(lines, columns);

            for (int i = 0; i < lines; ++i)
                for (int j = 0; j < columns; ++j)
                    cofactor_matrix[i, j] = (float)Math.Pow(-1, i + j) * GetMinor(i, j).Determinant();

            return cofactor_matrix.GetTranspose() / Determinant();
        }

        public static Matrix Gram(params Vector[] args)
        {
            int dimension = args[0].Size;

            for (int i = 1; i < args.Length; ++i)
                if (args[i].Size != dimension)
                    throw new EngineException.DimensionException();

            Matrix result = new(args.Length, args.Length);

            for (int i = 0; i < args.Length; ++i)
                for (int j = 0; j < args.Length; ++j)
                    result[i, j] = Vector.ScalarProduct(args[i], args[j]);

            return result;
        }

        public static Matrix GeneralRotation(int dimension, int axis_1, int axis_2, float angle)
        {
            angle = angle * (float)Math.PI / 180;

            Matrix result = Identity(dimension);

            if (axis_1 >= dimension || axis_2 >= dimension)
                throw new EngineException.DimensionException();

            result[axis_1, axis_2] = -(float)Math.Sin(angle) * ((axis_1 + axis_2) % 2 == 0 ? -1 : 1);
            result[axis_2, axis_1] = (float)Math.Sin(angle) * ((axis_1 + axis_2) % 2 == 0 ? -1 : 1);
            result[axis_1, axis_1] = (float)Math.Cos(angle);
            result[axis_2, axis_2] = (float)Math.Cos(angle);

            return result;
        }

        public static Matrix RotationX(float angle) => GeneralRotation(3, 1, 2, angle);

        public static Matrix RotationY(float angle) => GeneralRotation(3, 0, 2, angle);

        public static Matrix RotationZ(float angle) => GeneralRotation(3, 0, 1, angle);

        public static Matrix Rotation3D(float x, float y, float z)
            => RotationX(x) * RotationY(y) * RotationZ(z);
    }
}
