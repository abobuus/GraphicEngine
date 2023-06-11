using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
    public class GameObjectTests
    {
        public GameObject CreateGameObject()
        {
            Vector direction = new(new float[] { 1, 0, 0 });

            VectorSpace vector_space = new(new Vector[] { direction,
                                                          new Vector(new float[] { 0, 1, 0 } ),
                                                          new Vector(new float[] { 0, 0, 1 } ) });
            Point point = new(3);

            CoordinateSystem coordinate_system = new(point, vector_space);

            Entity[] entities1 = new Entity[] { new Entity(coordinate_system),
                                                new Entity(coordinate_system),
                                                new Entity(coordinate_system),
                                                new Entity(coordinate_system) };

            EntitiesList entities = new(entities1);

            Game game = new(coordinate_system, entities);

            GameObject game_object = new(game, point, direction);

            return game_object;
        }

        [TestMethod]
        public void GameObject_Move()
        {
            GameObject game_object = CreateGameObject();

            Vector vector = new(new float[] { 1, 1, 1 });
            Point point = new(new float[] { 1, 1, 1 });

            game_object.Move(vector);

            PointTests.PointAssert(point, game_object[EntityProperties.Position]);
        }

        [TestMethod]
        public void GameObject_Set_Position()
        {
            GameObject game_object = CreateGameObject();

            Point point = new(new float[] { 2, 3, -4 });

            game_object.SetPosition(point);

            Assert.AreEqual(point, game_object[EntityProperties.Position]);
        }

        [TestMethod]
        public void GameObject_Set_Position_2_Points()
        {
            GameObject game_object = CreateGameObject();

            Point point1 = new(new float[] { 2, 3, -4 });
            Point point2 = new(new float[] { 1, 1, 1 });

            game_object.SetPosition(point2);

            PointTests.PointAssert(point2, game_object[EntityProperties.Position]);
        }

        [TestMethod]
        public void Game_Object_3D_Rotation()
        {
            GameObject game_object = CreateGameObject();

            game_object.Rotate3D(0, 90, 0);
            game_object.Rotate3D(45, 0, 0);

            Vector vector = new(new float[] { 0, (float)Math.Sqrt(2) / 2, -(float)Math.Sqrt(2) / 2 });

            VectorTests.VectorAssert(vector, game_object[EntityProperties.Direction]);
        }

        [TestMethod]
        public void Game_Object_Planar_Rotate()
        {
            GameObject game_object = CreateGameObject();

            game_object.PlanarRotate(0, 2, 90);

            Vector vector = new(new float[] { 0, 0, -1 });

            VectorTests.VectorAssert(vector, game_object[EntityProperties.Direction]);
        }

        [TestMethod]
        public void Game_Object_Set_Direction()
        {
            GameObject game_object = CreateGameObject();

            Vector vector = new(new float[] { 2, 3, -4 });

            game_object.SetDirection(vector);

            VectorTests.VectorAssert(vector, game_object[EntityProperties.Direction]);
        }

        [TestMethod]
        public void Game_Object_Set_Direction_2_Vectors()
        {
            GameObject game_object = CreateGameObject();

            Vector vector1 = new(new float[] { 2, 3, -4 });
            Vector vector2 = new(new float[] { 1, 1, 1 });

            game_object.SetDirection(vector1);
            game_object.SetDirection(vector2);

            VectorTests.VectorAssert(vector2, game_object[EntityProperties.Direction]);
        }
    }
}
