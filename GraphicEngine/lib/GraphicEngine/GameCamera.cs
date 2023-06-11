using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics;
using Exceptions;

namespace GraphicEngine
{
    public class GameCamera : GameObject
    {
        public GameCamera(Game game, Point position, Vector direction, float FoV, float drawDistance) 
            : base(game, position, direction)
        {
            this[EntityProperties.FoV] = FoV;
            this[EntityProperties.DrawDistance] = drawDistance;
        }

        public GameCamera(Game game, Point position, Vector direction, float FoV, float VFoV, float drawDistance)
            : base(game, position, direction)
        {
            this[EntityProperties.FoV] = FoV;
            this[EntityProperties.VFoV] = VFoV;
            this[EntityProperties.DrawDistance] = drawDistance;
        }

        public GameCamera(Game game, Point position, Point lookAt, float FoV, float drawDistance)
            : base(game, position, new Vector(3))
        {
            this[EntityProperties.FoV] = FoV;
            this[EntityProperties.DrawDistance] = drawDistance;
            this[EntityProperties.LookAt] = lookAt;
        }

        public GameCamera(Game game, Point position, Point lookAt, float FoV, float VFoV, float drawDistance)
            : base(game, position, new Vector(3))
        {
            this[EntityProperties.FoV] = FoV;
            this[EntityProperties.VFoV] = VFoV;
            this[EntityProperties.DrawDistance] = drawDistance;
            this[EntityProperties.LookAt] = lookAt;
        }

        public Ray[,] GetRays(int hBlocks, int wBlocks)
        {
            Ray[,] ray_matrix = new Ray[hBlocks, wBlocks];

            Vector tmp = this[EntityProperties.Direction];
            Vector vector_direction = new Vector(tmp.Size);

            bool flag = true;

            for (int i = 0; i < vector_direction.Size; i++)
                if (tmp[i] != 0)
                    flag = false;

            Point lookAt = this[EntityProperties.LookAt];
            Point position = this[EntityProperties.Position];

            if (flag)
                vector_direction = CoordinateSystem.VectorSpace.AsVector(lookAt) - CoordinateSystem.VectorSpace.AsVector(position);
            else
                vector_direction = tmp;

            float FoV = (float)EntityProperties.FoV;
            float VFoV = (float)EntityProperties.VFoV;

            float delta_FoV = FoV / hBlocks;
            float delta_VFoV = VFoV / wBlocks;

            for(int i = 0; i <  hBlocks; i++) 
                for (int j = 0; j < wBlocks; j++)
                {
                    float FoV_i = delta_FoV * i - FoV / 2;
                    float VFoV_i = delta_VFoV * i - VFoV / 2;

                    vector_direction = Matrix.Rotation3D(0, FoV_i, VFoV_i) * vector_direction;

                    Ray ray = new(CoordinateSystem, position, vector_direction);

                    ray_matrix[i, j] = ray;
                }

            return ray_matrix;
        }
    }
}
