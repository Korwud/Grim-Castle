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
    public class MonsterInfoDrawer
    {
        public static void Draw(Texture2D monsterHealth, Texture2D longCell, Texture2D slime, Texture2D skeleton)
        {
            var spriteBatch = Game1.spriteBatch;
            var hpFont = Game1.hpFont;
            var infoFont = Game1.infoFont;

            var map = new Map();
            var mouseCursor = Mouse.GetState();
            var (i, j) = map.FindCell(mouseCursor.X, mouseCursor.Y);
            if (i < map.Width && i >= 0 && j < map.Height && j >= 0 && map.Cells[i, j] is Monster)
            {
                var monster = map.Cells[i, j] as Monster;
                spriteBatch.Begin();
                spriteBatch.Draw(monsterHealth, new Vector2(1400, 15), Color.White);
                spriteBatch.Draw(longCell, new Vector2(1100, 15), Color.White);

                if (map.Cells[i, j] is Slime)
                    spriteBatch.Draw(slime, new Vector2(1265, 35), Color.White);
                else if (map.Cells[i, j] is Skeleton)
                    spriteBatch.Draw(skeleton, new Vector2(1270, 25), Color.White);

                spriteBatch.DrawString(hpFont, $"{(map.Cells[i, j] as Monster).Hp}/{(map.Cells[i, j] as Monster).MaxHp}",
                    new Vector2(1600, 65), Color.White);
                spriteBatch.DrawString(infoFont, $"{monster.Name}", new Vector2(1115, 30), Color.White);
                spriteBatch.DrawString(infoFont, $"Damage: {monster.Damage}", new Vector2(1115, 65), Color.White);
                spriteBatch.DrawString(infoFont, $"Distance: {monster.Distance}", new Vector2(1115, 100), Color.White);
                spriteBatch.End();
            }
        }
    }
}
