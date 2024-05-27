using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture.Model
{
    public class Arachna : Monster
    {
        Map map = new();
        public Arachna(Vector2 startPosition)
        {
            this.Position = startPosition;
            this.Name = "Arachna";
            this.Hp = 25;
            this.MaxHp = 25;
            this.Damage = 4;
            this.Distance = 1;
            map.SetGameObject(this, Position, Position, Distance);
        }
    }
}
