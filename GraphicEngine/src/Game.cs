using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics;

namespace GraphicEngine
{
    public class Game
    {
        CoordinateSystem coordinate_system;
        public EntitiesList entities;

        public Game(CoordinateSystem CS, EntitiesList entities)
        {
            coordinate_system = CS;
            this.entities = entities;
        }

        public CoordinateSystem CoordinateSystem
        {
            get { return coordinate_system; }
        }

        public void Add(Entity entity)
        {
            entities.Add(entity);
        }

        public EntitiesList Entities
        {
            get { return entities; }
            set { entities = value; }
        }

        public int EntitiesCount
        {
            get { return entities.Count; }
        }

        public void Run() { }

        public void Update() { }

        public void Exit() { }
    }
}
