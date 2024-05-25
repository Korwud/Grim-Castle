using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture 
{
    public class Weapon : IGameObject
    {
        private string name;
        private double damage;
        public string Name { get { return name; }  set { name = value; } }
        public double Damage { get { return damage; } set { damage = value; } }
    }
}
