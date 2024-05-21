using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture.Model
{
    public class Skeleton : Monster
    {
        public Skeleton(Vector2 position)
        {
            this.Position = position;
            this.Name = "Skeleton";
            this.Hp = 15;
            this.Damage = 3;
            this.Distance = 1;
        }
    }
}
