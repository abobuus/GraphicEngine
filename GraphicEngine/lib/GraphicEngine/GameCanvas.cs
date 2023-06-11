using Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEngine.lib.GraphicEngine.obj
{
    public class GameCanvas
    {
        int height, width;
        public float?[,] distances;
        Game game;

        public GameCanvas(Game game, int n, int m)
        {
            height = n;
            width = m;
            distances = new float?[height, width];
            this.game = game;
        }

        public void Draw()
        {
            //
        }

        public void Update(GameCamera camera)
        {
            Ray[,] rays = camera.GetRays(height, width);

            for (int i = 0; i < height; i++) 
                for (int j = 0; j < width; j++)
                    foreach(var entity in game.Entities)
                    {
                        float? distance = entity.IntersectionDist(rays[i, j]);

                        if (distance == null || distance > camera[EntityProperties.DrawDistance]) 
                            continue;

                        if (distances[i, j] == null) 
                            distances[i, j] = distance;
                        else if (distances[i, j] > distance) 
                            distances[i, j] = distance;
                    }
        }
    }
}
