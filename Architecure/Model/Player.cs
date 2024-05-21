using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture
{
    public class Player : ICreature
    {
        private Map map = new();

        private double hp = 20;
        public event Action hpChanged;
        public double Hp
        {   get { return hp; }
            private set 
            {
                hp = value;
                hpChanged?.Invoke();
            }
        }

        private Weapon weapon;
        public Weapon CurrentWeapon { get { return weapon; } }


        private static Vector2 position = Vector2.Zero;
        public event Action positionChanged;
        public Vector2 Position 
        { get 
            { 
                if (position == Vector2.Zero)
                {
                    map.SetCreaturePosition(new Player(), map.CellPositions[0, 2], map.CellPositions[0, 2], Distance);
                    position = map.CellPositions[0, 2];
                }
                return position;
            } 
        }
        public int Distance = 1;


        private HashSet<Vector2> availableCells = new ();
        public HashSet<Vector2> AvailableCells { get 
            {
                availableCells = map.FillAvailableCells(Distance, Position);
                return availableCells; } }

        public void GetDamage(Monster monster)
        {
            Hp -= monster.Damage;
        }

        public void PositionChange(Vector2 newPosition)
        {
            if (map.IsPossibleMove(Position, newPosition, Distance))
            {
                map.SetCreaturePosition(new Player(), Position, newPosition, Distance);
                position = newPosition;
                positionChanged?.Invoke();
            }       
        }
    }
}
