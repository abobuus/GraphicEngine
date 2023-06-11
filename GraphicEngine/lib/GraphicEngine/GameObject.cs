using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics;
using Exceptions;

namespace GraphicEngine
{
    public class GameObject : Entity 
    {
        readonly Game game;
        public GameObject(Game game, Point position, Vector direction) : base(game.CoordinateSystem)
        {
            SetProperty(EntityProperties.Position, position);
            SetProperty(EntityProperties.Direction, direction);

            this.game = game;
            game.Add(this);
        }

        public void Move(Vector direction)
        {
            this[EntityProperties.Position] = (Point)this[EntityProperties.Position] + direction;
        }

        public void PlanarRotate(int axis_1, int axis_2, float angle)
        {
            this[EntityProperties.Direction] = Matrix.GeneralRotation(game.CoordinateSystem.VectorSpace.Basis.Length, axis_1, axis_2, angle) * (Vector)this[EntityProperties.Direction];
        }

        public void Rotate3D(float angleX, float angleY, float angleZ)
        {
            this[EntityProperties.Direction] = Matrix.Rotation3D(angleX, angleY, angleZ) * this[EntityProperties.Direction];
        }

        public void SetPosition(Point point)
        {
            this[EntityProperties.Position] = point;
        }

        public void SetDirection(Vector vector)
        {
            this[EntityProperties.Direction] = vector;
        }
    }
}
