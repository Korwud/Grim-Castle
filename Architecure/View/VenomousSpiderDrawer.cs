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
    public class VenomousSpiderDrawer
    {
        public static void Draw(Texture2D texture)
        {
            var venomousSpider = Game1.venomousSpider;
            if (venomousSpider is not null)
            {
                var spriteBatch = Game1.spriteBatch;
                var map = new Map();
                var (i, j) = map.FindCellByVector(venomousSpider.Position);
                if (map.Cells[i, j] is VenomousSpider)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(texture, new Vector2(venomousSpider.Position.X + 8, venomousSpider.Position.Y + 20), Color.White);
                    spriteBatch.End();
                }
            }
        }
    }
}
