using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicEngine;
using Mathematics;
using Exceptions;
using static Exceptions.EngineException;

namespace GraphicEngine.Tests
{
    [TestClass]
    public class VectorTests
    {
        public static void VectorAssert(Vector expected, Vector actual)
        {
            bool flag = true;

            if (expected.Size != actual.Size)
                flag = false;

            for (int i = 0; i < expected.Size; ++i)
                Assert.AreEqual(expected[i], actual[i], 1e-3);

            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void Vector_Size_3_Constructor_Only_0()
        {
            Vector actual = new(3);
            Vector expected = new(new float[] { 0, 0, 0 });

            VectorAssert(expected, actual);
        }

        [TestMethod]
        public void Vector_Size_3_Constructor_Matrix()
        {
            Matrix matrix = new(new float[,] { { 1 },
                                               { 2 },
                                               { 4 } });

            Vector actual = new(matrix);
            Vector expected = new(new float[] { 1, 2, 4 });

            VectorAssert(expected, actual);
        }

        [TestMethod]
        public void Vector_Size_3_Get_Size()
        {
            Vector vector = new(new float[] { 1, 6, 9, 4 });

            Assert.AreEqual(4, vector.Size);
        }

        [TestMethod]
        public void Vector_Size_3_Get_This()
        {
            Vector vector = new(new float[] { 1, 6, 9, 4 });

            Assert.AreEqual(4, vector[3]);
        }

        [TestMethod]
        public void Vectors_Size_4_Scalar_Product()
        {
            Vector vector1 = new(new float[] { 1, 6, 9, 4 });
            Vector vector2 = new(new float[] { 8, 5, 0, 1 });

            float actual = vector1 % vector2;

            Assert.AreEqual(42f, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionException))]
        public void Vectors_Wrong_Size_Scalar_Product()
        {
            Vector vector1 = new(new float[] { 1, 6, 9, 4 });
            Vector vector2 = new(new float[] { 8, 5, 0 });

            float actual = vector1 % vector2;

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void Vectors_SIze_3_Vector_Product()
        {
            Vector vector1 = new(new float[] { 1, 6, 9 });
            Vector vector2 = new(new float[] { 8, 5, 0 });

            Vector expected = new(new float[] { -45, 72, -43 });

            Vector actual = vector1 ^ vector2;

            VectorAssert(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionException))]
        public void Vector_Product_Non_3D()
        {
            Vector vector1 = new(new float[] { 1, 6, 9, 4 });
            Vector vector2 = new(new float[] { 8, 5, 0, 1 });

            Vector actual = vector1 ^ vector2;

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void Vectors_Size_4_Sum()
        {
            Vector vector1 = new(new float[] { 1, 6, 9, 4 });
            Vector vector2 = new(new float[] { 8, 5, 0, 1 });

            Vector expected = new(new float[] { 9, 11, 9, 5 });
            Vector actual = vector1 + vector2;

            VectorAssert(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionException))]
        public void Vectors_Different_Size_Sum()
        {
            Vector vector1 = new(new float[] { 1, 6, 9, 4 });
            Vector vector2 = new(new float[] { 8, 5, 0 });

            Vector actual = vector1 + vector2;

            VectorAssert(null, actual);
        }

        [TestMethod]
        public void Vectors_Size_4_Substruction()
        {
            Vector vector1 = new(new float[] { 1, 6, 9, 4 });
            Vector vector2 = new(new float[] { 8, 5, 0, 1 });

            Vector expected = new(new float[] { -7, 1, 9, 3 });
            Vector actual = vector1 - vector2;

            VectorAssert(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionException))]
        public void Vectors_Different_Size_Substruction()
        {
            Vector vector1 = new(new float[] { 1, 6, 9, 4 });
            Vector vector2 = new(new float[] { 8, 5, 0 });

            Vector actual = vector1 - vector2;

            VectorAssert(null, actual);
        }

        [TestMethod]
        public void Vectors_Size_4_Positive_Scalar_Multiplication()
        {
            Vector vector1 = new(new float[] { 1, 6, 9, 4 });

            Vector expected = new(new float[] { 3, 18, 27, 12 });
            Vector actual = vector1 * 3;

            VectorAssert(expected, actual);
        }

        [TestMethod]
        public void Vectors_Size_4_Negative_Scalar_Multiplication()
        {
            Vector vector1 = new(new float[] { 1, 6, 9, 4 });

            Vector expected = new(new float[] { -3, -18, -27, -12 });
            Vector actual = vector1 * -3;

            VectorAssert(expected, actual);
        }

        [TestMethod]
        public void Vectors_Size_4_Positive_Scalar_Substruction()
        {
            Vector vector1 = new(new float[] { 3, 18, 27, 12 });

            Vector expected = new(new float[] { 1, 6, 9, 4 });
            Vector actual = vector1 / 3;

            VectorAssert(expected, actual);
        }

        [TestMethod]
        public void Matrix_Size_3x3_Vector_Size_3x1_Multiplication()
        {
            Matrix matrix = new(new float[,] { { 1, 4, 7 },
                                               { 2, 5, 8 },
                                               { 3, 6, 9 }, });

            Vector vector = new(new float[] { 1, 2, 3 });

            Vector expected = new(new float[] { 30, 36, 42 });
            Vector actual = matrix * vector;

            VectorAssert(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionException))]
        public void Matrix_Vector_Wrong_Size_Multiplication()
        {
            Matrix matrix = new(new float[,] { { 1, 4, 7 },
                                               { 2, 5, 8 },
                                               { 3, 6, 9 }, });

            Vector vector = new(new float[] { 1, 2 });
            Vector actual = matrix * vector;

            VectorAssert(null, actual);
        }

        [TestMethod]
        public void Vector_Length()
        {
            Vector vector = new(new float[] { 1, 2, 3, 4, 5, 3 });

            float actual = vector.Length();

            Assert.AreEqual(8, actual);
        }
    }
}
