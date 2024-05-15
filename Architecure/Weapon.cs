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
        private double distanceDamage;
        public string Name { get { return name; } }
        public double Damage { get { return damage; } }
        public double DistanceDamage { get { return distanceDamage; } }
    }
}
