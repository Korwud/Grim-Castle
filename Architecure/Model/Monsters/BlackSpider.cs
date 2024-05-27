using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture.Model
{
    public class BlackSpider : Monster
    {
        Map map = new();
        public BlackSpider(Vector2 startPosition)
        {
            this.Position = startPosition;
            this.Name = "Black Spider";
            this.Hp = 20;
            this.MaxHp = 20;
            this.Damage = 3;
            this.Distance = 1;
            map.SetGameObject(this, Position, Position, Distance);
        }
    }
}
