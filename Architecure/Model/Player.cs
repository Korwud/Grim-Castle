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
        private Map map = new Map();


        private double hp;
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
        public Vector2 Position { get 
            { 
                if (position == Vector2.Zero)
                    return map.CellPositions[0, 2];
                return position;
            } }


        private HashSet<Vector2> availableCells = new ();
        public HashSet<Vector2> AvailableCells { get 
            {
                FillAvailableCells();
                return availableCells; } }

        private void FillAvailableCells()
        {
            var (i, j) = map.FindCell((int)Position.X, (int)Position.Y);
            for (var dx = -1; dx < 2; dx++)
            {
                for (var dy = -1; dy < 2; dy++)
                {
                    if (i + dx >= 0 && j + dy >= 0)
                    {
                        var cell = map.CellPositions[i + dx, j + dy];
                        if (map.IsPossibleMove(Position, cell, 1))
                            availableCells.Add(cell);
                    }
                }
            }
        }

        public void GetDamage(Monster monster)
        {
            Hp -= monster.Damage;
        }

        public void PositionChange(Vector2 newPosition)
        {
            if (map.IsPossibleMove(Position, newPosition, 1))
            {
                position = newPosition;
                positionChanged?.Invoke();
            }
                
        }
    }
}
