using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture
{
    public class Map
    {
        private IGameObject[,] map = new IGameObject[10, 6];
        public IGameObject[,] Cells { get { return map; } set { } }
        private int CellWidth = 150;
        private int CellHeight = 152;
        private Vector2[,] cellPositions;

        public Vector2[,] CellPositions 
        { get 
            {
                if (cellPositions == null)
                    FillCellPositions();
                return cellPositions; 
            } 
        }

        private void FillCellPositions()
        {
            cellPositions = new Vector2[10, 6];
            var x = 2;
            for (var i = 0; i < 10; i++)
            {
                var y = 200;
                for (var j = 0; j < 6; j++)
                {
                    cellPositions[i, j] = new Vector2(x, y);
                    y += CellHeight + 4;
                }
                x += CellWidth + 4;
            }
        }

        public (int, int) FindCell(int x, int y)
        {
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 6; j++)
                {
                    var vector = CellPositions[i, j];
                    if (vector.X <= x && x <= vector.X + CellWidth && vector.Y <= y && y <= vector.Y + CellHeight)
                        return (i, j);
                }
            }
            return (-1, -1);
        }

        public bool IsPossibleMove(Vector2 position, Vector2 newPosition, int distance)
        {
            var initialCoordinates = (0, 0);
            var newCoordinates = (0, 0);
            if (position != newPosition)
            {
                for (var i = 0; i < 10; i++)
                {
                    for (var j = 0; j < 6; j++)
                    {
                        if (position == CellPositions[i, j])
                            initialCoordinates = (i, j);
                        else if (newPosition == CellPositions[i, j])
                            newCoordinates = (i, j);
                    }
                }
            }
            else return false;
            return Math.Abs(initialCoordinates.Item1 - newCoordinates.Item1) < distance + 1
                && Math.Abs(initialCoordinates.Item2 - newCoordinates.Item2) < distance + 1
                && Cells[newCoordinates.Item1, newCoordinates.Item2] is null;
        }
    }
}
