using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture.Model
{
    public class Slime : Monster
    {
        public Slime(Vector2 startPosition)
        {
            this.Position = startPosition;
            this.Name = "Slime";
            this.Hp = 10;
            this.Damage = 2;
            this.Distance = 1;
        }
    }
}

