using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture
{
    public class Monster : ICreature
    {
        private double hp;
        private string name;
        private int damage;
        private int distance;
        private Vector2 position = Vector2.Zero;

        public double Hp
        {
            get { return hp; }
            set
            {
                hp = value;
            }
        }
        public event Action hpChanged;
        public string Name { get { return name; } set { name = value; } }
        public int Damage { get { return damage; } set { damage = value; } }
        public int Distance { get { return distance; } set { distance = value; } }
        public Vector2 Position
        {
            get
            {
                if (position == Vector2.Zero)
                    map.SetCreaturePosition(new Monster(), Position, Position, Distance);
                return position;
            }
            set { position = value; }
        }
        Map map = new();
        Player player = new();
        public void GetDamage()
        {
            Hp -= player.CurrentWeapon.Damage;
        }

        private (int, int) GetNextMove(Monster monster)
        {
            var playerPosition = map.FindCell((int)player.Position.X, (int)player.Position.Y);
            var availableCells = map.FillAvailableCells(monster.Distance, monster.Position);
            var nextMove = (0, 0);
            var minDifference = int.MaxValue;
            foreach (var cell in availableCells)
            {
                var possibleMove = map.FindCell((int)cell.X, (int)cell.Y);
                var d = Math.Abs(possibleMove.Item1 - playerPosition.Item1)
                    + Math.Abs(possibleMove.Item2 - playerPosition.Item2);
                if (d < minDifference)
                {
                    minDifference = d;
                    nextMove = possibleMove;
                }
            }
            return nextMove;
        }

        public void SetPosition(Monster monster)
        {
            var (i, j) = monster.GetNextMove(monster);
            map.SetCreaturePosition(monster, monster.Position, map.CellPositions[i, j], monster.Distance);
            monster.Position = map.CellPositions[i, j];
        }
    }
}
