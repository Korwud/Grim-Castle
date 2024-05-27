using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture.View
{
    public class WinnerScreen
    {
        public static void Draw(Texture2D screen, Texture2D button, Game1 game)
        {
            if (Game1.ThirdLevelCompleted)
            {
                var spriteBatch = Game1.spriteBatch;
                var hpFont = Game1.hpFont;
                spriteBatch.Begin();
                spriteBatch.Draw(screen, new Vector2(510, 340), Color.White);
                spriteBatch.DrawString(hpFont, "You did it!", new Vector2(870, 450), Color.White);
                spriteBatch.DrawString(hpFont, "You completed the dungeon! Congratulations!", new Vector2(640, 520), Color.White);
                var positionButton = new Vector2(835, 600);
                spriteBatch.Draw(button, positionButton, Color.White);
                spriteBatch.DrawString(hpFont, "Finish", new Vector2(positionButton.X + 70, positionButton.Y + 25), Color.White);
                spriteBatch.End();
                var mouse = Mouse.GetState();
                if (mouse.X >= positionButton.X && mouse.X <= button.Width + positionButton.X
                    && mouse.X >= positionButton.Y && mouse.Y <= positionButton.Y + button.Height
                    && mouse.LeftButton == ButtonState.Pressed)
                    game.Exit();
            }
        }
    }
}
