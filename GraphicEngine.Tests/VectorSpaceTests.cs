using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicEngine;
using Mathematics;
using Exceptions;
using static Exceptions.EngineException;

namespace GraphicEngine.Tests
{
    [TestClass]
    public class VectorSpaceTests
    {
        VectorSpace vector_space = new(new Vector[] { new Vector(new float[] { 1, 2, 3 } ),
                                                      new Vector(new float[] { 1, 3, 6 } ),
                                                      new Vector(new float[] { 2, 4, 7 } ) } );

        [TestMethod]
        public void Vectors_Size_3_Scalar_Product()
        {
            Vector vector1 = new(new float[] { 3, 5, 6 });
            Vector vector2 = new(new float[] { 5, 6, 7 });

            float actual = vector_space.ScalarProduct(vector1, vector2);

            Assert.AreEqual(11120, actual);
        }

        [TestMethod]
        public void Point_As_Vector()
        {
            Point point = new(new float[] { 1, 3, 7 });

            Vector result = vector_space.AsVector(point);

            Vector actual = new(new float[] { 18, 39, 70 });

            for (int i = 0; i < 3; i++)
                Assert.AreEqual(result[i], actual[i]);
        }
    }
}
