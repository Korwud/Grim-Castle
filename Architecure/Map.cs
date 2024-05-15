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
        private IGameObject[,] map;
        private static int positionToMap = 0;
        private Player player;
        public IGameObject[,] window { get { return GetWindow();  } }

        public IGameObject[,] GetWindow()
        {
            var position = player.Position;
            var window = new IGameObject[10, 6];
            if (position.X == 0)
                FillWindow(window, 0);
            else if (position.X - positionToMap == 5)
            {
                FillWindow(window, positionToMap + 1);
                positionToMap++;
            }
            return window;
        }

        private void FillWindow(IGameObject[,] window, int x)
        {
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 6; j++)
                    window[x + i, j] = map[x + i, j];
            }
        }
    }
}
