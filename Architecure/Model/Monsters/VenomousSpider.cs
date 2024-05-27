using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture.Model
{
    public class VenomousSpider : Monster
    {
        Map map = new();
        public VenomousSpider(Vector2 startPosition)
        {
            this.Position = startPosition;
            this.Name = "Venomous Spider";
            this.Hp = 10;
            this.MaxHp = 10;
            this.Damage = 4;
            this.Distance = 1;
            map.SetGameObject(this, Position, Position, Distance);
        }
    }
}
