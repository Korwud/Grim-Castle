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
    public class ArachnaDrawer
    {
        public static void Draw(Texture2D texture)
        {
            var arachna = Game1.arachna;
            if (arachna is not null)
            {
                var spriteBatch = Game1.spriteBatch;
                var map = new Map();
                var (i, j) = map.FindCellByVector(arachna.Position);
                if (map.Cells[i, j] is Arachna)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(texture, new Vector2(arachna.Position.X + 8, arachna.Position.Y + 15), Color.White);
                    spriteBatch.End();
                }
            }
        }
    }
}
