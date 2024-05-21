using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture
{
    public class MovePlayer
    {
        public static void Move(Vector2 position)
        {
            var player = new Player();
            player.PositionChange(position);
        }
    }
}
