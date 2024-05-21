using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Grim_Castle.Architecture
{
    public class PlayerDrawer
    {
        public static void PlayerDraw(SpriteBatch spriteBatch, Texture2D player)
        {
            var basePlayer = new Player();
            spriteBatch.Begin();
            spriteBatch.Draw(player, new Vector2(basePlayer.Position.X, basePlayer.Position.Y + 17), Color.White);
            spriteBatch.End();
        }
    }
}
