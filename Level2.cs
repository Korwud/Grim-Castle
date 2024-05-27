using Grim_Castle.Architecture;
using Grim_Castle.Architecture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle
{
    public class Level2
    {
        public static void InitializeMonsters()
        {
            var map = new Map();
            Game1.Nulification();
            Game1.slime = new Slime(map.CellPositions[2, 4]);
            Game1.blackSpider = new BlackSpider(map.CellPositions[8, 1]);
            Map.SetMonsterCount(2);
        }
    }
}
