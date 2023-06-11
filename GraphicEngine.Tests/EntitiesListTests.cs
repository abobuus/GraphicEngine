using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics;
using Exceptions;
using static Exceptions.EngineException;

namespace GraphicEngine.Tests
{
    [TestClass]
    public class EntitiesListTests
    {
        public static EntitiesList CreateEntitiesList()
        {
            VectorSpace vector_space = new(new Vector[] { new Vector(new float[] { 1, 0, 0 } ),
                                                          new Vector(new float[] { 0, 1, 0 } ),
                                                          new Vector(new float[] { 0, 0, 1 } ) });
            Point point = new(3);

            CoordinateSystem coordinate_system = new(point, vector_space);

            Entity[] entities1 = new Entity[] { new Entity(coordinate_system),
                                                new Entity(coordinate_system),
                                                new Entity(coordinate_system),
                                                new Entity(coordinate_system) };

            EntitiesList entities = new(entities1);

            return entities;
        }

        [TestMethod]
        public void EntitiesList_Add()
        {
            EntitiesList entities = CreateEntitiesList();

            Entity entity = EntityTests.CreateEntity();

            entities.Add(entity);

            Assert.AreEqual(entities[entity.Identifier], entity);
        }

        [TestMethod]
        public void EntitiesList_RemoveAt()
        {
            EntitiesList entities = CreateEntitiesList();

            Entity entity = EntityTests.CreateEntity();

            entities.Add(entity);

            Identifier identifier = entity.Identifier;

            entities.RemoveAt(identifier);

            Assert.IsFalse(entities.Contains(identifier));
        }

        [TestMethod]
        [ExpectedException(typeof(NotAnExistingIdentifierException))]
        public void EntitiesList_RemoveAt_Exception()
        {
            EntitiesList entities = CreateEntitiesList();

            Entity entity = EntityTests.CreateEntity();

            Identifier identifier = entity.Identifier;

            entities.RemoveAt(identifier);
        }

        [TestMethod]
        public void EntitiesList_Remove()
        {
            EntitiesList entities = CreateEntitiesList();

            Entity entity = EntityTests.CreateEntity();

            entities.Add(entity);

            Identifier identifier = entity.Identifier;

            entities.Remove(entity);

            Assert.IsFalse(entities.Contains(identifier));
        }

        [TestMethod]
        [ExpectedException(typeof(NotAnExistingEntityException))]
        public void EntitiesList_Remove_Exception()
        {
            EntitiesList entities = CreateEntitiesList();

            Entity entity = EntityTests.CreateEntity();

            Identifier identifier = entity.Identifier;

            entities.Remove(entity);
        }

        [TestMethod]
        public void EntityList_Get() 
        { 
            EntitiesList entities = CreateEntitiesList();

            Entity expected = EntityTests.CreateEntity();

            entities.Add(expected);

            Identifier identifier = expected.Identifier;

            Entity actual = entities.Get(identifier);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod] 
        [ExpectedException(typeof(NotAnExistingIdentifierException))]
        public void EntityList_Get_Exception()
        {
            EntitiesList entities = CreateEntitiesList();

            Entity expected = EntityTests.CreateEntity();

            Identifier identifier = expected.Identifier;

            Entity actual = entities.Get(identifier);
        }
    }
}
