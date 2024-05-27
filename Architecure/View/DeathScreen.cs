using Grim_Castle.Architecture.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture.View
{
    public class DeathScreen
    {
        public static void Draw(Texture2D deathScreen, Texture2D button)
        {
            if (!Player.IsAlive)
            {
                var spriteBatch = Game1.spriteBatch;
                var hpFont = Game1.hpFont;
                spriteBatch.Begin();
                spriteBatch.Draw(deathScreen, new Vector2(510, 340), Color.White);
                spriteBatch.DrawString(hpFont, "You died...", new Vector2(870, 450), Color.White);
                spriteBatch.DrawString(hpFont, "I hope you can do it next time", new Vector2(735, 520), Color.White);
                var positionButton = new Vector2(835, 600);
                spriteBatch.Draw(button, positionButton, Color.White);
                spriteBatch.DrawString(hpFont, "Try again", new Vector2(positionButton.X + 45, positionButton.Y + 25), Color.White);
                spriteBatch.End();
                var mouse = Mouse.GetState();
                if (mouse.X >= positionButton.X && mouse.X <= button.Width + positionButton.X
                    && mouse.X >= positionButton.Y && mouse.Y <= positionButton.Y + button.Height
                    && mouse.LeftButton == ButtonState.Pressed)
                {
                    Map.Reset();
                    Player.Reset();
                    Game1.Nulification();
                    Level1.InitializeMonsters();
                    Inventory.Reset();
                    Game1.FirstLevelCompleted = false;
                    Game1.SecondLevelCompleted = false;
                } 
            }
        }
    }
}
