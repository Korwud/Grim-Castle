using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture.Model
{
    public class Inventory
    {
        private static List<Weapon> weapons = new List<Weapon> { new ShortSword() };
        public static List<Weapon> Weapons { get { return weapons; } }

        public static int Width = 128;
        public static int Height = 128;
        public static Vector2[] cells = new Vector2[] { new Vector2(530, 15), new Vector2(678, 15), new Vector2(826, 15) };

        public static void AddWeapon(int i, int j)
        {
            var map = new Map();
            if (weapons.Count < 3)
            {
                var weapon = map.Cells[i, j] as Weapon;
                map.DeleteCreature(map.CellPositions[i, j]);
                weapons.Add(weapon);
            }
        }

        public static Weapon GetWeaponFromCell(int x, int y)
        {
            for (var i = 0; i < 3; i++)
            {
                var cell = cells[i];
                if (cell.X + Width > x && x > cell.X && cell.Y + Height > y && y > cell.Y && weapons.Count - 1 >= i)
                    return weapons[i];
            }
            return null;
        }
    }
}
