using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Grim_Castle.Architecture
{
    public class PlayerDrawer
    {
        public static void DrawPlayer(Texture2D player)
        {
            var spriteBatch = Game1.spriteBatch;
            var basePlayer = new Player();
            var map = new Map();
            var (i, j) = map.FindCellByVector(basePlayer.Position);
            if (map.Cells[i, j] is Player)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(player, new Vector2(basePlayer.Position.X, basePlayer.Position.Y + 17), Color.White);
                spriteBatch.End();
            }
        }
    }
}
