using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture.View
{
    public class HealthBarDrawer
    {
        public static void Draw(Texture2D healthBar)
        {
            var player = new Player();
            var spriteBatch = Game1.spriteBatch;
            var font = Game1.hpFont;
            spriteBatch.Begin();
            spriteBatch.Draw(healthBar, new Vector2(10, 15), Color.White);
            spriteBatch.DrawString(font, $"{player.Hp}/{player.MaxHp}", new Vector2(230, 65), Color.White);
            spriteBatch.End();
        }
    }
}
