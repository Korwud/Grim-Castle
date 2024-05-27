using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture.Controller
{
    public class ChangeLevel
    {
        public static void Change(Player player)
        {
            var map = new Map();
            if (player.Position == map.CellPositions[12, 2] && Map.MonsterCount == 0)
            {
                Map.Reset();
                if (!Game1.FirstLevelCompleted)
                {
                    Game1.FirstLevelCompleted = true;
                    Level2.InitializeMonsters();
                }
                else if (!Game1.SecondLevelCompleted)
                {
                    Game1.SecondLevelCompleted = true;
                    Level3.InitializeMonsters();
                }
                else
                    Game1.ThirdLevelCompleted = true;
                player.Position = Vector2.Zero;
            }
        }
    }
}
