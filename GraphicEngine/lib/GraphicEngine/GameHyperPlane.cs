using Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEngine.lib.GraphicEngine
{
    public class GameHyperPlane : GameObject
    {
        public GameHyperPlane(Game game, CoordinateSystem coordinateSystem, Point position, Vector normal, Vector direction) : base(game, position, direction)
        {
            this[EntityProperties.Normal] = normal;
            this[EntityProperties.Position] = position;
        }

        public float? IntersectionDistance(Ray ray)
        {
            Point position = this[EntityProperties.Position];
            Vector normal = this[EntityProperties.Normal];

            VectorSpace vector_space = CoordinateSystem.VectorSpace;
            Vector ray_position_to_plane_position = vector_space.AsVector(position) - vector_space.AsVector(ray.InitialPoint);

            float scalar_product_ray_direction_normal = vector_space.ScalarProduct(ray.Direction, normal);
            float scalar_product_ray_position_normal = vector_space.ScalarProduct(ray_position_to_plane_position, normal);

            float distance;

            if (scalar_product_ray_direction_normal == 0)
            {
                if (scalar_product_ray_position_normal == 0)
                    return 0;
                else
                    return null;
            }
            else 
                distance = scalar_product_ray_position_normal / scalar_product_ray_direction_normal;

            if (distance >= 0)
                return distance;
            else
                return 0;
        }
        public void RotatePlanar(int axis1, int axis2, float angle)
        {
            this[EntityProperties.Normal] = Matrix.GeneralRotation(CoordinateSystem.VectorSpace.Basis.Length, axis1, axis2, angle) * this[EntityProperties.Normal];
        }

        public void Rotate3D(float angleX, float angleY, float angleZ)
        {
            this[EntityProperties.Normal] = Matrix.Rotation3D(angleX, angleY, angleZ) * this[EntityProperties.Normal];
        }
    }
}
