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
    public class WeaponDrawer
    {
        public static void Draw(Texture2D spear, Texture2D sword, params Monster[] monsters)
        {
            var spriteBatch = Game1.spriteBatch;
            var map = new Map();
            spriteBatch.Begin();
            foreach (var monster in monsters)
            {
                var (i, j) = map.FindCellByVector(monster.Position);
                var cell = map.CellPositions[i, j];
                if (map.Cells[i, j] is Spear)
                    spriteBatch.Draw(spear, new Vector2(cell.X + 10, cell.Y + 5), Color.White);
                else if (map.Cells[i, j] is Sword)
                    spriteBatch.Draw(sword, new Vector2(cell.X + 10, cell.Y + 5), Color.White);
            }
            spriteBatch.End();
        }
    }
}
