using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture
{
    public class MapDrawer
    {
        public static void DrawMap(Texture2D tile_1, Texture2D tile_2, Texture2D tile_3, Texture2D tile_4)
        {
            var spriteBatch = Game1.spriteBatch;
            var map = new Map();
            var player = new Player();
            var tile = tile_1;
            for (var i = 0; i < map.Width; i++)
            {
                for (var j = 0; j < map.Height; j++)
                {
                    tile = TileSelect(tile_1, tile_2, tile_3, tile_4, tile, i, j);
                    var cell = map.CellPositions[i, j];
                    spriteBatch.Begin();
                    if (player.AvailableCells.Contains(cell) && (map.Cells[i, j] is null || map.Cells[i, j] is Weapon))
                        spriteBatch.Draw(tile, cell, Color.LightYellow);
                    else
                        spriteBatch.Draw(tile, cell, Color.White);
                    spriteBatch.End();
                }
            }
        }

        private static Texture2D TileSelect(Texture2D tile_1, Texture2D tile_2, Texture2D tile_3, Texture2D tile_4, Texture2D tile, int i, int j)
        {
            if (i % 2 == 0 && j % 2 == 0)
                tile = tile_1;
            else if (i % 2 == 1 && j % 2 == 0)
                tile = tile_2;
            else if (i % 2 == 0 && j % 2 == 1)
                tile = tile_3;
            else if (i % 2 == 1 && j % 2 == 1)
                tile = tile_4;
            return tile;
        }
    }
}
