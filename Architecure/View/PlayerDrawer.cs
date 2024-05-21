using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grim_Castle.Architecture
{
    public class PlayerDrawer
    {
        public static void PlayerDraw(SpriteBatch spriteBatch, Texture2D player, Vector2 position)
        {
            var basePlayer = new Player();
            var playerPosition = basePlayer.Position;
            spriteBatch.Begin();
            basePlayer.PositionChange(position);
            spriteBatch.Draw(player, new Vector2(playerPosition.X + 4, playerPosition.Y + 22), Color.White);
            spriteBatch.End();
        }
    }
}
