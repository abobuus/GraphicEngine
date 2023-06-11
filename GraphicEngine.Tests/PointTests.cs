using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicEngine;
using Mathematics;
using Exceptions;
using static Exceptions.EngineException;

namespace GraphicEngine.Tests
{
    [TestClass]
    public class PointTests
    {
        public static void PointAssert(Point expected, Point actual)
        {
            bool flag = true;

            if (expected.Size != actual.Size)
                flag = false;

            for (int i = 0; i < expected.Size; ++i)
                Assert.AreEqual(expected[i], actual[i], 1e-3);

            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void Point_Size_3_Constructor_Only_0()
        {
            Point actual = new(3);
            Point expected = new(new float[] { 0, 0, 0 });

            PointAssert(expected, actual);
        }

        [TestMethod]
        public void Point_Size_3_Constructor_From_Vector()
        {
            Point actual = new(new float[] {1, 2, 3 });
            Vector vector = new(new float[] { 1, 2, 3 });

            Point expected = new(vector);

            PointAssert(expected, actual);
        }

        [TestMethod]
        public void Point_Size_3_Get_Size()
        {
            Point point = new(new float[] { 1, 2, 3 });

            Assert.AreEqual(3, point.Size);
        }

        [TestMethod]
        public void Point_Size_3_Get_This()
        {
            Point point = new(new float[] { 1, 2, 3 });

            Assert.AreEqual(1, point[0]);
        }

        [TestMethod]
        public void Vector_Point_Size_4_Sum()
        {
            Vector vector = new(new float[] { 1, 3, 5, 4 });
            Point point = new(new float[] { 8, 1, 5, 4 });

            Point expected = new(new float[] { 9, 4, 10, 8 });
            Point actual = point + vector;

            PointAssert(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DimensionException))]
        public void Vector_Point_Different_Size_Sum()
        {
            Vector vector = new(new float[] { 1, 3, 5, 4 });
            Point point = new(new float[] { 8, 1, 5 });

            Point actual = point + vector;

            PointAssert(null, actual);
        }

        [TestMethod]
        public void Point_Vector_Size_3_Substruction()
        {
            Point point = new(new float[] { 8, 1, 5, 4 });
            Vector vector = new(new float[] { 1, 3, 5, 4 });
            
            Point expected = new(new float[] { 7, -2, 0, 0 });
            Point actual = point - vector;

            PointAssert(expected, actual);
        }
    }
}
