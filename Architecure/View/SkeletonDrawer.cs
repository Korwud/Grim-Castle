using Grim_Castle.Architecture.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture.View
{
    public class SkeletonDrawer
    {
        public static void DrawSkeleton(Texture2D texture)
        {
            var skeleton = Game1.skeleton;
            if (skeleton is not null)
            {
                var spriteBatch = Game1.spriteBatch;
                var map = new Map();
                var (i, j) = map.FindCellByVector(skeleton.Position);
                if (map.Cells[i, j] is Skeleton)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(texture, new Vector2(skeleton.Position.X + 8, skeleton.Position.Y + 4), Color.White);
                    spriteBatch.End();
                }
            }
        }
    }
}
