using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicEngine;
using Mathematics;
using Exceptions;
using static Exceptions.EngineException;

namespace GraphicEngine.Tests
{
    [TestClass]
    public class BilinearFormTests
    {
        [TestMethod]
        public void Matrix_Size_4_Vectors_Size_3_BiLinear()
        {
            Matrix matrix = new(new float[,] { { 2, 4, 1, 8 },
                                               { 6, 8, 1, 5 },
                                               { 3, 1, 7, 0 },
                                               { 4, 9, 1, 2 } });

            Vector vector1 = new(new float[] { 2, 6, 3, 9 });
            Vector vector2 = new(new float[] { 3, 1, 9, 5 });

            float actual = BiLinearForm.Count(matrix, vector1, vector2);

            Assert.AreEqual(1057f, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionException))]
        public void Bilinear_Wrong_Input_Size()
        {
            Matrix matrix = new(new float[,] { { 2, 4, 1, 8 },
                                               { 6, 8, 1, 5 },
                                               { 3, 1, 7, 0 } });

            Vector vector1 = new(new float[] { 2, 6, 3, 9 });
            Vector vector2 = new(new float[] { 3, 1, 9, 5 });

            float actual = BiLinearForm.Count(matrix, vector1, vector2);

            Assert.AreEqual(float.NaN, actual);
        }
    }
}
