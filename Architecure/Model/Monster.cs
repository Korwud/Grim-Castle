using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture
{
    public class Monster : IGameObject
    {
        private double hp;
        private string name;
        private double damage;
        private double distanceDamage;
        private Point position;

        public Monster(double hp, string name, double damage, double distanceDamage, Point position)
        {
            this.hp = hp;
            this.name = name;
            this.damage = damage;
            this.distanceDamage = distanceDamage;
            this.position = position;
        }

        public double Hp
        {
            get { return hp; }
            private set
            {
                Hp -= value;
                hpChanged.Invoke();
            }
        }
        public event Action hpChanged;
        public string Name { get { return name; } }
        public double Damage { get { return damage; } }
        public double DistanceDamage { get { return distanceDamage; } }
        public Point Position { get { return position; } }

        public void GetDamage(Player player)
        {
            Hp -= player.CurrentWeapon.Damage;
        }
    }
}
