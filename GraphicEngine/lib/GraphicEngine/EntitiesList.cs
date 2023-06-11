using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics;
using Exceptions;

namespace GraphicEngine
{
    public class EntitiesList
    {
        public Dictionary<Identifier, Entity> entities = new();

        public EntitiesList(Entity[] entities) 
        {
            for (int i = 0; i < entities.Length; i++)
                this.entities.Add(entities[i].Identifier, entities[i]);
        }

        public Entity this[Identifier key]
        {
            get
            {
                if (!entities.ContainsKey(key))
                    throw new EngineException.NotAnExistingIdentifierException();

                return entities[key];
            }
        }

        public void Add(Entity entity)
        {
            entities.Add(entity.Identifier, entity);
        }

        public void RemoveAt(Identifier key)
        {
            if (!entities.ContainsKey(key))
                throw new EngineException.NotAnExistingIdentifierException();

            entities.Remove(key);
        }

        public void Remove(Entity entity)
        {
            if (!entities.ContainsValue(entity))
                throw new EngineException.NotAnExistingEntityException();

            entities.Remove(entity.Identifier);
        }

        public Entity Get(Identifier key)
        {
            if (!entities.ContainsKey(key))
                throw new EngineException.NotAnExistingIdentifierException();

            return entities[key];
        }

        public void Execute(Action<Entity> executable)
        {
            foreach (Entity entity in entities.Values)
                executable(entity);
        }

        public bool Contains(Identifier key)
        {
            return entities.ContainsKey(key);
        }

        public int Count
        {
            get { return entities.Count; }
        }
    }
}
