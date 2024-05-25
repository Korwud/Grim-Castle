using Grim_Castle.Architecture.Model;
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
    public class Player : IGameObject
    {
        private Map map = new();

        private double maxHp = 100;
        public double MaxHp { get { return maxHp; } }
        private static double hp = 100;
        public event Action hpChanged;
        public double Hp
        {   get { return hp; }
            private set 
            {
                hp = value;
                hpChanged?.Invoke();
            }
        }


        private static Weapon currentWeapon;
        public Weapon CurrentWeapon { get 
            {
                if (currentWeapon is null)
                    currentWeapon = Inventory.Weapons[0];
                return currentWeapon; 
            } }


        public void ChangeCurrentWeapon(Weapon weapon)
        {
            if (Inventory.Weapons.Contains(weapon))
                currentWeapon = weapon;
        }


        public int Distance = 1;
        private static Vector2 position = Vector2.Zero;
        public event Action positionChanged;
        public Vector2 Position
        {
            get
            {
                if (position == Vector2.Zero)
                {
                    var startPosition = map.CellPositions[0, 2];
                    map.SetGameObject(new Player(), startPosition, startPosition, Distance);
                    position = startPosition;
                }
                return position;
            }
        }

        public void PositionChange(Vector2 newPosition)
        {
            if (map.IsPossibleMove(Position, newPosition, Distance) && IsAlive)
            {
                var (i, j) = map.FindCellByVector(newPosition);
                if (map.Cells[i, j] is null || map.Cells[i, j] is Weapon)
                {
                    if (map.Cells[i, j] is Weapon)
                        Inventory.AddWeapon(i, j);
                    map.SetGameObject(new Player(), Position, newPosition, Distance);
                    position = newPosition;
                    positionChanged?.Invoke();
                }
            }
        }


        private HashSet<Vector2> availableCells = new ();
        public HashSet<Vector2> AvailableCells 
        { get 
            {
                availableCells = map.FillAvailableCells(Distance, Position);
                return availableCells; 
            } 
        }


        public static bool IsAlive = true;

        public void GetDamage(Monster monster)
        {
            Hp -= monster.Damage;
            if (Hp <= 0)
            {
                map.DeleteCreature(Position);
                IsAlive = false;
            }
        }

        public void TakeDamage(Monster monster)
        {
            if (IsAlive)
                monster.GetDamage(monster);
        }
    }
}
