using Grim_Castle.Architecture.Model;
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
    public class WeaponInfoDrawer
    {
        public static void Draw(Texture2D longCell)
        {
            var spriteBatch = Game1.spriteBatch;
            var infoFont = Game1.infoFont;
            var mouseCursor = Mouse.GetState();
            var weapon = Inventory.GetWeaponFromCell(mouseCursor.X, mouseCursor.Y);
            if (weapon is not null)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(longCell, new Vector2(mouseCursor.X, mouseCursor.Y), Color.White);
                spriteBatch.DrawString(infoFont, weapon.Name, new Vector2(mouseCursor.X + 50, mouseCursor.Y + 30), Color.White);
                spriteBatch.DrawString(infoFont, $"Damage: {weapon.Damage}", new Vector2(mouseCursor.X + 50, mouseCursor.Y + 70), Color.White);
                spriteBatch.End();
            }
        }
    }
}
