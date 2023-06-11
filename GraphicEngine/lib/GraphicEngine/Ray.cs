using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics;
using Exceptions;

namespace GraphicEngine
{
    public class Ray
    {
        readonly CoordinateSystem coordinate_system;
        Point initial_point;
        Vector direction;

        public Ray(CoordinateSystem coordinateSystem, Point initialPt, Vector dir) 
        {
            coordinate_system = coordinateSystem;
            initial_point = initialPt;
            direction = dir;
        }

        public void Normalize()
        {
            float norma = 0;

            for (int i = 0; i < direction.Length();  i++) 
                norma += direction[i] * direction[i];

            direction = direction / (float)Math.Sqrt(norma);
        }

        public Point InitialPoint
        {
            get { return initial_point; }
            set { initial_point = value; }
        }

        public Vector Direction
        {
            get { return direction; }
            set { direction = value; }
        }
    }
}
