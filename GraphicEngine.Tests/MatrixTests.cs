using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicEngine;
using Mathematics;
using Exceptions;
using static Exceptions.EngineException;

namespace GraphicEngine.Tests
{
    [TestClass]
    public class MatrixTests
    {
        public static void MatrixAssert(Matrix expected, Matrix actual)
        {
            bool flag = true;

            if (expected.Lines != actual.Lines) 
                flag = false; 
            if (expected.Columns != actual.Columns)
                flag = false;

            for (int i = 0; i < expected.Lines; ++i)
                for (int j = 0; j < expected.Columns; ++j)
                    Assert.AreEqual(expected[i, j], actual[i, j], 1e-3);

            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void Matrix_Size_4_Constructor_Only_0() 
        {
            Matrix actual = new(4, 4);

            Matrix expected = new(new float[,] { { 0, 0, 0, 0 },
                                                 { 0, 0, 0, 0 },
                                                 { 0, 0, 0, 0 },
                                                 { 0, 0, 0, 0 } } );

            MatrixAssert(expected, actual);
        }

        [TestMethod]
        public void Matrix_Size_3_Constructor_Vector()
        {
            Vector vector3 = new(new float[] { 9, 8, 2 } );

            Matrix actual = new(vector3);
            Matrix expected = new(new float[,] { { 9 },
                                                 { 8 },
                                                 { 2 } } );

            MatrixAssert(expected, actual);
        }

        [TestMethod]
        public void Matrix_Identity_Size_3()
        {
            Matrix actual = Matrix.Identity(3);
            Matrix expected = new(new float[,] { { 1, 0, 0 },
                                                 { 0, 1, 0 },
                                                 { 0, 0, 1 } } );

            MatrixAssert(expected, actual);
        }

        [TestMethod]
        public void Matrix_Size_3õ4_Get_Size()
        {
            Matrix matrix = new(new float[,] { { 1, 2, 3, 0 },
                                               { 4, 5, 6, 0 },
                                               { 7, 8, 9, 0 } } );

            Assert.AreEqual((3, 4), matrix.Size);
        }

        [TestMethod]
        public void Matrix_Size_3x4_Get_Lines()
        {
            Matrix matrix = new(new float[,] { { 1, 2, 3, 0 },
                                               { 4, 5, 6, 0 },
                                               { 7, 8, 9, 0 } } );

            Assert.AreEqual(3, matrix.Lines);
        }

        [TestMethod]
        public void Matrix_Size_3x4_Get_Columns()
        {
            Matrix matrix = new(new float[,] { { 1, 2, 3, 0 },
                                               { 4, 5, 6, 0 },
                                               { 7, 8, 9, 0 } } );

            Assert.AreEqual(4, matrix.Columns);
        }

        [TestMethod]
        public void Matrix_Size_3x4_Get_This()
        {
            Matrix matrix = new(new float[,] { { 1, 2, 3, 0 },
                                               { 4, 5, 6, 0 },
                                               { 7, 8, 9, 0 } } );

            Assert.AreEqual(3, matrix[0,2]);
        }

        [TestMethod]
        public void Matrix_Size_3_Sum()
        {
            Matrix matrix1 = new(new float[,] { { 2, 4, 1, 8 },
                                                { 6, 8, 1, 5 },
                                                { 3, 1, 7, 0 } } );

            Matrix matrix2 = new(new float[,] { { 1, 2, 4, 3 },
                                                { 0, 1, 3, 0 },
                                                { 1, 5, 9, 1 } } );

            Matrix expected = new(new float[,] { { 3, 6, 5, 11 },
                                                 { 6, 9, 4, 5 },
                                                 { 4, 6, 16, 1 } } );

            Matrix actual = matrix1 + matrix2;

            MatrixAssert(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionException))]
        public void Matrix_Different_Size_Sum()
        {
            Matrix matrix1 = new(new float[,] { { 2, 4, 1, 8 },
                                                { 6, 8, 1, 5 },
                                                { 3, 1, 7, 0 } } );

            Matrix matrix2 = new(new float[,] { { 1, 2, 4, 3 },
                                                { 0, 1, 3, 0 } } );

            Matrix actual = matrix1 + matrix2;

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void Matrix_Size_3_Substrction()
        {
            Matrix matrix1 = new(new float[,] { { 2, 4, 1, 8 },
                                                { 6, 8, 1, 5 },
                                                { 3, 1, 7, 0 } } );

            Matrix matrix2 = new(new float[,] { { 1, 2, 4, 3 },
                                                { 0, 1, 3, 0 },
                                                { 1, 5, 9, 1 } } );

            Matrix expected = new(new float[,] { { 1, 2, -3, 5 },
                                                 { 6, 7, -2, 5 },
                                                 { 2, -4, -2, -1 } } );

            Matrix actual = matrix1 - matrix2;

            MatrixAssert(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionException))]
        public void Matrix_Different_Size_Substrction()
        {
            Matrix matrix1 = new(new float[,] { { 2, 4, 1, 8 },
                                                { 6, 8, 1, 5 },
                                                { 3, 1, 7, 0 } } );

            Matrix matrix2 = new(new float[,] { { 1, 2, 4, 3 },
                                                { 0, 1, 3, 0 } } );

            Matrix actual = matrix1 - matrix2;

            MatrixAssert(null, actual);
        }

        [TestMethod]
        public void Matrix_Size_3x4_Positive_Scalar_Multiplication()
        {
            Matrix matrix1 = new(new float[,] { { 2, 4, 1, 8 },
                                                { 6, 8, 1, 5 },
                                                { 3, 1, 7, 0 } } );

            Matrix expected = new(new float[,] { { 5, 10, 2.5f, 20 },
                                                 { 15, 20, 2.5f, 12.5f },
                                                 { 7.5f, 2.5f, 17.5f, 0 } } );

            Matrix actual = matrix1 * 2.5f;

            MatrixAssert(expected, actual);
        }

        [TestMethod]
        public void Matrix_Size_3x4_Negative_Scalar_Multiplication()
        {
            Matrix matrix1 = new(new float[,] { { 2, 4, 1, 8 },
                                                { 6, 8, 1, 5 },
                                                { 3, 1, 7, 0 } } );

            Matrix expected = new(new float[,] { { -5, -10, -2.5f, -20 },
                                                 { -15, -20, -2.5f, -12.5f },
                                                 { -7.5f, -2.5f, -17.5f, 0 } } );

            Matrix actual = matrix1 * -2.5f;

            MatrixAssert(expected, actual);
        }

        [TestMethod]
        public void Matrix_Size_3x4_Positive_Scalar_Substruction()
        {
            Matrix matrix1 = new(new float[,] { { 2, 4, 2, 8 },
                                                { 6, 8, 2, 6 },
                                                { 2, 2, 8, 0 } } );

            Matrix expected = new(new float[,] { { 1, 2, 1, 4 },
                                                 { 3, 4, 1, 3 },
                                                 { 1, 1, 4, 0 } } );

            Matrix actual = matrix1 / 2;

            MatrixAssert(expected, actual);
        }

        [TestMethod]
        public void Matrix_Size_3x4_and_4x3_Multiplication()
        {
            Matrix matrix1 = new(new float[,] { { 2, 4, 1, 8 },
                                                { 6, 8, 1, 5 },
                                                { 3, 1, 7, 0 } } );

            Matrix matrix2 = new(new float[,] { { 1, 2, 4 },
                                                { 0, 1, 3 },
                                                { 1, 5, 9 },
                                                { 3, 0, 1 } } );

            Matrix expected = new(new float[,] { { 27, 13, 37 },
                                                 { 22, 25, 62 },
                                                 { 10, 42, 78 } } );

            Matrix actual = matrix1 * matrix2;

            MatrixAssert(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionException))]
        public void Matrix_Wrong_Size_Multiplication()
        {
            Matrix matrix1 = new(new float[,] { { 2, 4, 1, 8 },
                                                { 6, 8, 1, 5 },
                                                { 3, 1, 7, 0 } } );

            Matrix matrix2 = new(new float[,] { { 1, 2, 4 },
                                                { 0, 1, 3 },
                                                { 1, 5, 9 } } );

            Matrix actual = matrix1 * matrix2;

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void Matrix_Size_3_Division()
        {
            Matrix matrix1 = new(new float[,] { { 2, 4, 1 },
                                                { 0, 2, 1 },
                                                { 2, 1, 1 } } );

            Matrix matrix2 = new(new float[,] { { 2, 0, 1 },
                                                { 1, -1, 0 },
                                                { 0, 3, 1  } } );

            Matrix actual = matrix1 / matrix2;
            Matrix expected = new(new float[,] { { -3, 8, 4 },
                                                 { 1, -2, 0 },
                                                 { 0, 2, 1 } });

            MatrixAssert(expected, actual);
        }

        [TestMethod]
        public void Vector_Size_1x3_Matrix_Size_3x1_Multiplication()
        {
            Vector vector = new(new float[] { 1, 2, 3 });

            Matrix matrix = new(new float[,] { { 4, 5, 6 } });

            Matrix expected = new(new float[,] { { 4, 5, 6 },
                                                 { 8, 10, 12 },
                                                 { 12, 15, 18 } });

            Matrix actual = vector * matrix;

            MatrixAssert(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionException))]
        public void Vector_Matrix_Wrong_Size_Multiplication()
        {
            Vector vector = new(new float[] { 1, 2, 3 });

            Matrix matrix = new(new float[,] { { 4, 5, 6 },
                                               { 4, 4, 4 } });

            Matrix actual = vector * matrix;

            MatrixAssert(null, actual);
        }

        [TestMethod]
        public void Matrix_Size_3x4_Get_Minor_Without_Line_0_Column_1()
        {
            Matrix matrix1 = new(new float[,] { { 2, 4, 1, 8 },
                                                { 6, 8, 1, 5 },
                                                { 3, 1, 7, 0 } });

            Matrix expected = new(new float[,] { { 6, 1, 5 },
                                                 { 3, 7, 0 } });

            Matrix actual = matrix1.GetMinor(0, 1);

            MatrixAssert(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfSizeException))]
        public void Matrix_Size_3x4_Get_Minor_Wrong_Parameters()
        {
            Matrix matrix1 = new(new float[,] { { 2, 4, 1, 8 },
                                                { 6, 8, 1, 5 },
                                                { 3, 1, 7, 0 } });

            Matrix actual = matrix1.GetMinor(0, 5);

            MatrixAssert(null, actual);
        }

        [TestMethod]
        public void Matrix_Size_3x4_Transpose()
        {
            Matrix matrix1 = new(new float[,] { { 2, 4, 1, 8 },
                                                { 6, 8, 1, 5 },
                                                { 3, 1, 7, 0 } });

            Matrix expected = new(new float[,] { { 2, 6, 3 },
                                                 { 4, 8, 1 },
                                                 { 1, 1, 7 },
                                                 { 8, 5, 0 } });

            Matrix actual = matrix1.GetTranspose();

            MatrixAssert(expected, actual);
        }

        [TestMethod]
        public void Matrix_Size_4_Determinant()
        {
            Matrix matrix = new(new float[,] { { 2, 4, 1, 8 },
                                               { 6, 8, 1, 5 },
                                               { 3, 1, 7, 0 },
                                               { 4, 9, 1, 2 } } );

            float actual = matrix.Determinant();

            Assert.AreEqual(1059, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionException))]
        public void Matrix_Non_Square_Determinant()
        {
            Matrix matrix = new(new float[,] { { 1, 2, 3, 4 },
                                               { 5, 6, 7, 8 },
                                               { 9, 10, 11, 12 } } );


            float actual = matrix.Determinant();

            Assert.AreEqual(float.NaN, actual);
        }

        [TestMethod]
        public void Matrix_Size_3_Inverse()
        {
            Matrix matrix = new(new float[,] { { 2, 5, 7 },
                                               { 6, 3, 4 },
                                               { 5, -2, -3} } );

            Matrix actual = matrix.GetInverse();

            Matrix expected = new(new float[,] { { 1, -1, 1 },
                                                 { -38, 41, -34 },
                                                 { 27, -29, 24} } );

            MatrixAssert(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionException))]
        public void Matrix_Non_Square_Inverse()
        {
            Matrix matrix = new(new float[,] { { 2, 5, 7 },
                                               { 6, 3, 4 } } );

            Matrix actual = matrix.GetInverse();

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void Matrix_Gram_3_Vectors()
        {
            Vector vector1 = new(new float[] { 2, 6, 3 });
            Vector vector2 = new(new float[] { 3, 1, 9 });
            Vector vector3 = new(new float[] { 9, 5, 1 });

            Matrix actual = Matrix.Gram(vector1, vector2, vector3);

            Matrix expected = new(new float[,] { {49, 39, 51 },
                                                 {39, 91, 41 },
                                                 {51, 41, 107 } } );

            MatrixAssert(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionException))]
        public void Matrix_Gram_Vectors_Wrong_Dimension()
        {
            Vector vector1 = new(new float[] { 2, 6, 3 });
            Vector vector2 = new(new float[] { 3, 1, 9 });
            Vector vector3 = new(new float[] { 9, 5 });

            Matrix actual = Matrix.Gram(vector1, vector2, vector3);

            MatrixAssert(null, actual);
        }
    }
}