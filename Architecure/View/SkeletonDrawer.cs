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
        public static void DrawSkeleton(SpriteBatch spriteBatch, Texture2D texture, Skeleton skeleton)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Vector2(skeleton.Position.X + 8, skeleton.Position.Y + 4), Color.White);
            spriteBatch.End();
        }
    }
}
