using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture.Controller
{
    public class HitMonster
    {
        public static void Hit(Vector2 position)
        {
            var player = new Player();
            var map = new Map();
            var monster = map.IsMonsterHere(position);
            if (monster is not null)
            {
                player.TakeDamage(monster);
            }
        }
    }
}
