using Grim_Castle.Architecture.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grim_Castle.Architecture.View
{
    public class SlimeDrawer
    {
        public static void DrawSlime(SpriteBatch spriteBatch, Texture2D texture, Slime slime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Vector2(slime.Position.X + 3, slime.Position.Y + 20), Color.White);
            spriteBatch.End();
        }
    }
}
