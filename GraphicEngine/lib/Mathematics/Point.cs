using System.Drawing;
using Mathematics;
using Exceptions;

namespace Mathematics
{
    public class Point
    {
        private readonly int size;
        private readonly float[,] data;

        public Point(int n)
        {
            size = n;
            data = new float[size, 1];
        }

        public Point(float[] values)
        {
            size = values.Length;
            data = new float[size, 1];

            for (int i = 0; i < size; ++i)
                data[i, 0] = values[i];
        }

        public Point(Vector vector)
        {
            size = vector.Size;
            data = new float[size, 1];

            for (int i = 0; i < size; ++i)
                data[i, 0] = vector[i];
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

        public static Point PointVectorSum(Point point, Vector vector)
        {
            if (point.Size != vector.Size)
                throw new EngineException.DimensionException();

            Point result = new(point.Size);

            for (int i = 0; i < point.Size; ++i)
                result[i] = point[i] + vector[i];

            return result;
        }

        public static Point operator +(Point point, Vector vector)
            => Point.PointVectorSum(point, vector);

        public static Point operator +(Vector vector, Point point)
            => point + vector;

        public static Point operator -(Point point, Vector vector)
            => point + vector * (-1);

        public void Print()
        {
            for (int i = 0; i < Size; ++i)
                Console.WriteLine(data[i, 0]);
        }
    }
}
