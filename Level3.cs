using Grim_Castle.Architecture;
using Grim_Castle.Architecture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle
{
    public class Level3
    {
        public static void InitializeMonsters()
        {
            var map = new Map();
            Game1.Nulification();
            Game1.arachna = new Arachna(map.CellPositions[12, 3]);
            Game1.blackSpider = new BlackSpider(map.CellPositions[9, 0]);
            Game1.venomousSpider = new VenomousSpider(map.CellPositions[5, 5]);
            Map.SetMonsterCount(3);
        }
    }
}
