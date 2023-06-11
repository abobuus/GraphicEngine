using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics;
using static Exceptions.EngineException;

namespace GraphicEngine.Tests
{
    [TestClass]
    public class RayTests
    {
        [TestMethod]
        public void a()
        {
            Point point = new(3);
            VectorSpace vector_space = new(new Vector[] { new Vector(new float[] { 1, 0, 0 } ),
                                                          new Vector(new float[] { 0, 1, 0 } ),
                                                          new Vector(new float[] { 0, 0, 1 } ) });

            CoordinateSystem coordinate_system = new(point, vector_space);
            Vector direction = new(new float[] { 1, 2, 3 });
            Point initial_point = new(3);

            Ray ray = new(coordinate_system, initial_point, direction);
        }
    }
}
