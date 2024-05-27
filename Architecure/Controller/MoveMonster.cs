using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture.Controller
{
    public class MoveMonster
    {
        public static void Move(Monster monster)
        {
            if (monster is not null)
                monster.SetPosition(monster);
        }
    }
}
