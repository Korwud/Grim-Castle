using Grim_Castle.Architecture.Model;
using Grim_Castle.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle
{
    public class Level1
    {
        public static void InitializeMonsters()
        {
            var map = new Map();
            Game1.slime = new Slime(map.CellPositions[11, 1]);
            Game1.skeleton = new Skeleton(map.CellPositions[7, 3]);
            Map.SetMonsterCount(2);
        }
    }
}
