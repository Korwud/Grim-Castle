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
    public class BlackSpiderDrawer
    {
        public static void Draw(Texture2D texture)
        {
            var blackSpider = Game1.blackSpider;
            if (blackSpider is not null)
            {
                var spriteBatch = Game1.spriteBatch;
                var map = new Map();
                var (i, j) = map.FindCellByVector(blackSpider.Position);
                if (map.Cells[i, j] is BlackSpider)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(texture, new Vector2(blackSpider.Position.X + 4, blackSpider.Position.Y + 20), Color.White);
                    spriteBatch.End();
                }
            }
        }
    }
}
