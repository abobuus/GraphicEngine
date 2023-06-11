using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Mathematics;
using Exceptions;

namespace GraphicEngine
{
    public enum EntityProperties { Position, Direction, LookAt, FoV, VFoV, DrawDistance, Normal }

    public class Entity
    {
        readonly static Type[] properties_types =
            { typeof(Point), typeof(Vector), typeof(Point), typeof(float), typeof(float), typeof(float), typeof(Vector) };

        readonly CoordinateSystem coordinate_system;
        readonly Identifier identifier = new();
        Dictionary<EntityProperties, object> properties = new();

        public Entity(CoordinateSystem CS)
        {
            coordinate_system = CS;
        }

        public CoordinateSystem CoordinateSystem
        {
            get { return coordinate_system; }
        }

        public Identifier Identifier
        {
            get { return identifier; }
        }

        public dynamic this[EntityProperties property]
        {
            get 
            { 
                return properties[property]; 
            }
            set
            {
                if (properties_types[(int)property] != value.GetType()) 
                    throw new EngineException.PropertyTypeException();

                else properties[property] = value;
            }
        }

        public void SetProperty(EntityProperties property, object value)
        {
            this[property] = value;
        }

        public object GetProperty(EntityProperties property)
        {
            return properties[property];
        }

        public void RemoveProperty(EntityProperties property)
        {
            if (!properties.ContainsKey(property)) 
                throw new EngineException.ExceptionOfNonExistentProperty();

            properties.Remove(property);
        }

        public Dictionary<EntityProperties, object>.KeyCollection ExistingProperties()
        {
            return properties.Keys;
        }

        public bool Contains(EntityProperties property)
        {
            return properties.ContainsKey(property);
        }
    }
}
