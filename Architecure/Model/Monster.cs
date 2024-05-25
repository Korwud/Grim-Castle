using Grim_Castle.Architecture.Model;
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
    public class Monster : IGameObject
    {
        private double hp;
        private double maxHp;
        private string name;
        private int damage;
        private int distance;
        private Vector2 position = Vector2.Zero;

        public double Hp { get { return hp; } set { hp = value; } }
        public double MaxHp { get { return maxHp; } set { maxHp = value; } }
        public event Action hpChanged;
        public string Name { get { return name; } set { name = value; } }
        public int Damage { get { return damage; } set { damage = value; } }
        public int Distance { get { return distance; } set { distance = value; } }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        Map map = new();
        Player player = new();

        public bool IsAlive = true;
        public void GetDamage(Monster monster)
        {
            monster.Hp -= player.CurrentWeapon.Damage;
            if (monster.Hp <= 0 && IsAlive)
            {
                var random = new Random();
                var position = monster.Position;
                Weapon weapon = null;
                if (random.Next(0, 10) > 7)
                {
                    var weapons = new List<Weapon> { new Sword(), new Spear() };
                    weapon = weapons[random.Next(0, 2)];
                } 
                map.DeleteCreature(monster.Position);
                if (weapon is not null)
                    map.SetGameObject(weapon, position, position);
                IsAlive = false;
            } 
        }

        private (int, int) GetNextMove(Monster monster)
        {
            var playerPosition = map.FindCellByVector(player.Position);
            var availableCells = map.FillAvailableCells(monster.Distance, monster.Position);
            var (i, j) = map.FindCellByVector(monster.Position);
            var nextMove = (i, j);
            if (!availableCells.Contains(map.CellPositions[playerPosition.Item1, playerPosition.Item2]) && IsAlive)
            {
                var minDifference = int.MaxValue;
                foreach (var cell in availableCells)
                {
                    var possibleMove = map.FindCellByVector(cell);
                    var difference = Math.Abs(possibleMove.Item1 - playerPosition.Item1)
                        + Math.Abs(possibleMove.Item2 - playerPosition.Item2);
                    if (difference < minDifference && (map.Cells[possibleMove.Item1, possibleMove.Item2] is null 
                        || map.Cells[possibleMove.Item1, possibleMove.Item2] is Weapon))
                    {
                        minDifference = difference;
                        nextMove = possibleMove;
                    }
                }
            }
            else if (map.Cells[playerPosition.Item1, playerPosition.Item2] is Player && IsAlive)
                HitPlayer(monster);
            return nextMove;
        }

        private void HitPlayer(Monster monster)
        {
            player.GetDamage(monster);
        }

        public void SetPosition(Monster monster)
        {
            if (IsAlive)
            {
                var (i, j) = monster.GetNextMove(monster);
                map.SetGameObject(monster, monster.Position, map.CellPositions[i, j], monster.Distance);
                monster.Position = map.CellPositions[i, j];
            }
        }
    }
}
