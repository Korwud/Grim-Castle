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
    public class InventoryDrawer
    {
        public static void Draw(Texture2D cell, Texture2D shortSword,
            Texture2D sword, Texture2D spear)
        {
            var spriteBatch = Game1.spriteBatch;
            var player = new Player();
            spriteBatch.Begin();
            var x = 530;
            for (var i = 0; i < 3; i++)
            {
                var color = Color.White;
                if (Inventory.Weapons.Count > i && Inventory.Weapons[i] == player.CurrentWeapon)
                    color = Color.LightSlateGray;
                spriteBatch.Draw(cell, new Vector2(x, 15), color);
                if (Inventory.Weapons.Count > i)
                {
                    var weaponName = Inventory.Weapons[i].Name;
                    Texture2D texture;
                    if (weaponName == "ShortSword")
                        texture = shortSword;
                    else if (weaponName == "Sword")
                        texture = sword;
                    else
                        texture = spear;
                    spriteBatch.Draw(texture, new Vector2(x + 10, 25), Color.White);
                }
                x += 20 + cell.Width;
            }
            spriteBatch.End();
        }
    }
}
