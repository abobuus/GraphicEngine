using Mathematics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Exceptions;
using static Exceptions.EngineException;

namespace GraphicEngine.Tests
{
    [TestClass]
    public class EntityTests
    {
        public static Entity CreateEntity()
        {
            Point point = new(3);
            VectorSpace vector_space = new(new Vector[] { new Vector(new float[] { 1, 0, 0 } ),
                                                          new Vector(new float[] { 0, 1, 0 } ),
                                                          new Vector(new float[] { 0, 0, 1 } ) });

            CoordinateSystem coordinate_system = new(point, vector_space);

            Entity entity = new(coordinate_system);

            return entity;
        }

        [TestMethod]
        public void Return_Coordinate_System()
        {

            Point point = new(3);
            VectorSpace vector_space = new(new Vector[] { new Vector(new float[] { 1, 0, 0 } ),
                                                          new Vector(new float[] { 0, 1, 0 } ),
                                                          new Vector(new float[] { 0, 0, 1 } ) });

            CoordinateSystem expected = new(point, vector_space);

            Entity entity = new(expected);

            Assert.AreEqual(expected, entity.CoordinateSystem);
        }

        [TestMethod]
        public void Propetry_Add_Position()
        {
            Entity entity = CreateEntity();

            Point point = new(new float[] { 0, 0, 0 } );

            entity[EntityProperties.Position] = point;

            Assert.AreEqual(point, entity[EntityProperties.Position]);
        }

        [TestMethod]
        public void Propetry_Add_Direction()
        {
            Entity entity = CreateEntity();

            Vector direction = new(new float[] { 0, 1, 2 });

            entity[EntityProperties.Direction] = direction;

            Assert.AreEqual(direction, entity[EntityProperties.Direction]);
        }

        [TestMethod]
        public void Propetry_Add_DrawDistance()
        {
            Entity entity = CreateEntity();

            float distance = 3f;

            entity[EntityProperties.DrawDistance] = distance;

            Assert.AreEqual(distance, entity[EntityProperties.DrawDistance]);
        }

        [TestMethod]
        public void Set_Property_DrawDistance()
        {
            Entity entity = CreateEntity();

            float distance = 3f;

            entity.SetProperty(EntityProperties.DrawDistance, distance);

            Assert.AreEqual(distance, entity[EntityProperties.DrawDistance]);
        }

        [TestMethod]
        public void Get_Property_DrawDistance()
        {
            Entity entity = CreateEntity();

            float expected = 3f;

            entity[EntityProperties.DrawDistance] = expected;
            object actual = entity.GetProperty(EntityProperties.DrawDistance);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_Property_DrawDistance()
        {
            Entity entity = CreateEntity();

            float distance = 3f;

            entity[EntityProperties.DrawDistance] = distance;

            entity.RemoveProperty(EntityProperties.DrawDistance);

            Assert.IsFalse(entity.Contains(EntityProperties.DrawDistance));
        }

        [TestMethod]
        public void Remove_Property_Position()
        {
            Entity entity = CreateEntity();

            entity[EntityProperties.Position] = (Point)new(new float[] { 1, 1, 1 });
            entity[EntityProperties.DrawDistance] = 3f;
            entity.RemoveProperty(EntityProperties.Position);

            Assert.IsTrue(entity.Contains(EntityProperties.DrawDistance));
        }


        [TestMethod]
        [ExpectedException(typeof(ExceptionOfNonExistentProperty))]
        public void PropRemoveNonExistant()
        {
            Entity entity = CreateEntity(); 

            entity.RemoveProperty(EntityProperties.Position);
        }

        [TestMethod]
        [ExpectedException(typeof(PropertyTypeException))]
        public void Property_Set_Type_Exception()
        {
            Entity entity = CreateEntity();

            entity[EntityProperties.DrawDistance] = 'с';
        }
    }
}
