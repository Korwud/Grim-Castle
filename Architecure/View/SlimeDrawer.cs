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
    public class SlimeDrawer
    {
        public static void DrawSlime(Texture2D texture, Slime slime)
        {
            var spriteBatch = Game1.spriteBatch;
            var map = new Map();
            var (i, j) = map.FindCellByVector(slime.Position);
            if (map.Cells[i, j] is Slime)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(texture, new Vector2(slime.Position.X + 3, slime.Position.Y + 20), Color.White);
                spriteBatch.End();
            }
        }
    }
}
