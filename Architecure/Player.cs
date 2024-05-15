using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture
{
    public class Player : IGameObject
    {
        private double hp;
        private Point position;
        private Weapon weapon;
        public double Hp
        {   get { return hp; }
            private set 
            {
                hp = value;
                hpChanged?.Invoke();
            }
        }
        public event Action hpChanged;
        public event Action positionChanged;
        public Point Position { get { return position; } }
        public Weapon CurrentWeapon { get { return weapon; } }

        public void GetDamage(Monster monster)
        {
            Hp -= monster.Damage;
        }
    }
}
