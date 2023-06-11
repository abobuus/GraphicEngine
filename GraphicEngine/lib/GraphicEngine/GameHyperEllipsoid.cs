using Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEngine.lib.GraphicEngine
{
    public class GameHyperEllipsoid : GameObject
    {
        Vector[] axes;
        Game game;

        public GameHyperEllipsoid(Game game, Point position, Vector direction, Vector[] axes) : base(game, position, direction)
        {
            this.axes = axes;
            this[EntityProperties.Position] = position;
            this[EntityProperties.Direction] = direction;
            this.game = game;
        }

        public new void Rotate3D(float angle_x, float angle_y, float angle_z)
        {
            for (int i = 0; i < axes.Length; i++)
                axes[i] = Matrix.Rotation3D(angle_x, angle_y, angle_z) * axes[i];
        }

        public new void RotatePlanar(int axis1, int axis2, float angle)
        {
            for (int i = 0; i < axes.Length; i++)
                axes[i] = Matrix.GeneralRotation(axes.Length, axis1, axis2, angle) * axes[i];
        }
    }
}
