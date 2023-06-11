using GraphicEngine;
using Mathematics;
using Exceptions;

namespace study
{
    class Program
    {
        enum DaysOfWeek
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        static void Main(string[] args)
        {
            GameObject CreateGameObject()
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

            /*GameObject game_object = CreateGameObject();

            game_object.Rotate3D(0, 90, 0);
            game_object.Rotate3D(45, 0, 0);

            Vector vector = new(new float[] { 0, (float)Math.Sqrt(2) / 2, -(float)Math.Sqrt(2) / 2 });

            Vector v = (Vector)game_object[EntityProperties.Direction];
            v.Print();
            Console.WriteLine();

            vector.Print();*/


            //VectorTests.VectorAssert(vector, (Vector)game_object[EntityProperties.Direction]);

            /*Console.WriteLine();

            vector.Print();*/


            //Dictionary<DaysOfWeek, object> dict = new()
            //{
            //    { DaysOfWeek.Monday, 3 },
            //    { DaysOfWeek.Tuesday, "Вторник" },
            //    { DaysOfWeek.Wednesday, 'С'},
            //    { DaysOfWeek.Thursday, 6 }
            //};

            //VectorSpace vector_space = new(new Vector[] { new Vector(new float[] { 1, 2, 3 } ),
            //                                              new Vector(new float[] { 1, 3, 6 } ),
            //                                              new Vector(new float[] { 2, 4, 7 } ) });
            //Point point = new(3);
            //CoordinateSystem coordinate_system = new(point, vector_space);
            //Entity[] entities1 = new Entity[] { new Entity(coordinate_system),
            //                                    new Entity(coordinate_system),
            //                                    new Entity(coordinate_system),
            //                                    new Entity(coordinate_system) } ;
            //EntitiesList entities = new(entities1);


            /*Entity CreateEntity()
            {
                Point point = new(3);
                VectorSpace vector_space = new(new Vector[] { new Vector(new float[] { 1, 0, 0 } ),
                                                              new Vector(new float[] { 0, 1, 0 } ),
                                                              new Vector(new float[] { 0, 0, 1 } ) });

                CoordinateSystem coordinate_system = new(point, vector_space);

                Entity entity = new(coordinate_system);

                return entity;
            }

            Entity entity = CreateEntity();

            entity[EntityProperties.DrawDistance] = 10;*/


            /*Entity entity = CreateEntity();

            Point point = new(new float[] { 0, 0, 0 });
            point.Print();

            entity[EntityProperties.Position] = point;
            Console.WriteLine(EntityProperties.Position);
            point.Print();*/

            /*Entity entity = CreateEntity();

            Point point = new(new float[] { 0, 0, 0 });
            point.Print();

            entity.SetProperty(EntityProperties.Position, point);
            Console.WriteLine(EntityProperties.Position);
            point.Print();*/




            //Assert.AreEqual(point, EntityProperties.Position);

            /*for(int i = 0; i < entities.Count; i++)
            {
                Console.WriteLine(entities[i].Identifier.ID);
            }*/

            //Console.WriteLine(diict);
        }
    }
}

