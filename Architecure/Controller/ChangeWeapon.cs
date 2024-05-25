using Grim_Castle.Architecture.Model;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture.Controller
{
    public class ChangeWeapon
    {
        public static void Change(int x, int y)
        {
            var player = new Player();
            var weapon = Inventory.GetWeaponFromCell(x, y);
            if (weapon is not null)
                player.ChangeCurrentWeapon(weapon);
        }
    }
}
