﻿using Microsoft.Xna.Framework;
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
        public int Width = 13;
        public int Height = 6;
        private static IGameObject[,] map = new IGameObject[13, 6];
        public IGameObject[,] Cells { get { return map; } set { } }
        private int CellWidth = 140;
        private int CellHeight = 142;
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
            cellPositions = new Vector2[Width, Height];
            var x = 22;
            for (var i = 0; i < Width; i++)
            {
                var y = 160;
                for (var j = 0; j < Height; j++)
                {
                    cellPositions[i, j] = new Vector2(x, y);
                    y += CellHeight + 4;
                }
                x += CellWidth + 4;
            }
        }

        public (int, int) FindCell(int x, int y)
        {
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    var vector = CellPositions[i, j];
                    if (vector.X <= x && x <= vector.X + CellWidth && vector.Y <= y && y <= vector.Y + CellHeight)
                        return (i, j);
                }
            }
            return (x, y);
        }

        public (int, int) FindCellByVector(Vector2 position)
        {
            return FindCell((int)position.X, (int)position.Y);
        }

        public bool IsPossibleMove(Vector2 position, Vector2 newPosition, int distance)
        {
            var initialCoordinates = (0, 0);
            var newCoordinates = (0, 0);
            if (position != newPosition)
            {
                for (var i = 0; i < Width; i++)
                {
                    for (var j = 0; j < Height; j++)
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
                && Math.Abs(initialCoordinates.Item2 - newCoordinates.Item2) < distance + 1;
        }

        public void SetGameObject(IGameObject gameObject, Vector2 position, Vector2 newPosition, int distance = 1)
        {
            var (i, j) = FindCellByVector(position);
            if (position != newPosition)
            {
                if (IsPossibleMove(position, newPosition, distance))
                {
                    map[i, j] = null;
                    (i, j) = FindCellByVector(newPosition);
                }
            }
            map[i, j] = gameObject;
        }

        public HashSet<Vector2> FillAvailableCells(int distance, Vector2 position)
        {
            var availableCells = new HashSet<Vector2>();
            var (i, j) = FindCellByVector(position);
            for (var dx = -distance; dx < distance + 1; dx++)
            {
                for (var dy = -distance; dy < distance + 1; dy++)
                {
                    var x = i + dx;
                    var y = j + dy;
                    if (x >= 0 && x < Width && y >= 0 && y < Height)
                    {
                        var cell = CellPositions[x, y];
                        if (IsPossibleMove(position, cell, distance))
                            availableCells.Add(cell);
                    }
                }
            }
            return availableCells;
        }

        public Monster IsMonsterHere(Vector2 position)
        {
            var (i, j) = FindCellByVector(position);
            if (Cells[i, j] is Monster)
                return Cells[i, j] as Monster;
            return null;
        }

        public void DeleteCreature(Vector2 position)
        {
            var (i, j) = FindCellByVector(position);
            if (map[i, j] is not null)
                map[i, j] = null;
        }
    }
}
