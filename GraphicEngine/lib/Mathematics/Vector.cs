using Mathematics;
using GraphicEngine;
using Exceptions;

namespace Mathematics
{
    public class Vector
    {
        private readonly int size;
        private readonly float[,] data;

        public Vector(int n)
        {
            size = n;   
            data = new float[size, 1];
        }

        public Vector(float[] values)
        {
            size = values.Length;
            data = new float[size, 1];

            for (int i = 0; i < size; ++i)
                data[i, 0] = values[i];
        }

        public Vector(Matrix matrix)
        {
            if (matrix.Columns > 1) 
                throw new EngineException.DimensionException();

            size = matrix.Lines;
            data = new float[size, 1];

            for ( int i = 0; i < size; i++)
                data[i, 0] = matrix[i, 0];
        }

        public int Size
        {
            get { return size; }
        }

        public float this[int i]
        {
            get { return data[i, 0]; }
            set { data[i, 0] = value; }
        }

        public static float ScalarProduct(Vector vector_1, Vector vector_2)
        {
            if (vector_1.Size != vector_2.Size)
                throw new EngineException.DimensionException();

            float result = 0;

            for (int i = 0; i < vector_1.Size; ++i)
                result += vector_1[i] * vector_2[i];

            return result;
        }

        public static float operator %(Vector vector_1, Vector vector_2)
           => ScalarProduct(vector_1, vector_2);

        public static Vector VectorProduct(Vector vector_1, Vector vector_2)
        {
            if (vector_1.Size != 3 && vector_2.Size != 3)
                throw new EngineException.DimensionException();

            float x = vector_1[1] * vector_2[2] - vector_1[2] * vector_2[1];
            float y = vector_1[2] * vector_2[0] - vector_1[0] * vector_2[2];
            float z = vector_1[0] * vector_2[1] - vector_1[1] * vector_2[0];

            return new Vector(new float[] { x, y, z });
        }

        public static Vector operator ^(Vector vector_1, Vector vector_2)
            => VectorProduct(vector_1, vector_2);

        public static Vector Sum(Vector vector_1, Vector vector_2)
        {
            if (vector_1.Size != vector_2.Size)
                throw new EngineException.DimensionException();

            Vector result = new(vector_1.Size);

            for (int i = 0; i < result.Size; ++i)
                result[i] = vector_1[i] + vector_2[i];

            return result;
        }

        public static Vector operator +(Vector vector_1, Vector vector_2)
            => Vector.Sum(vector_1, vector_2);

        public static Vector operator -(Vector vector_1, Vector vector_2)
            => vector_1 + vector_2 * (-1);

        public static Vector ScalarMultiplication(Vector vector, float num)
        {
            Vector result = new(vector.Size);

            for (int i = 0; i < result.Size; ++i)
                result[i] = vector[i] * num;

            return result;
        }

        public static Vector operator *(Vector vector, float num)
            => Vector.ScalarMultiplication(vector, num);

        public static Vector operator *(float num, Vector vector)
            => vector * num;

        public static Vector operator /(Vector vector, float num)
            => vector * (1 / num);

        public static Vector MatrixVectorMultiplication(Matrix matrix, Vector vector)
        {
            if (vector.Size != matrix.Columns) 
                throw new EngineException.DimensionException();

            Vector result = new(matrix.Lines);

            for (int i = 0; i < matrix.Lines; ++i)
                for (int j = 0; j < vector.Size; ++j)
                    result[i] += matrix[i, j] * vector[j];

            return result;
        }

        public static Vector operator *(Matrix matrix, Vector vector)
            => Vector.MatrixVectorMultiplication(matrix, vector);

        public float Length()
            => (float)Math.Sqrt(Vector.ScalarProduct(this, this));

        public void Print()
        {
            for (int i = 0; i < Size; ++i)
                Console.WriteLine(data[i, 0]);
        }
    }
}
