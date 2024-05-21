using Grim_Castle.Architecture;
using Grim_Castle.Architecture.Controller;
using Grim_Castle.Architecture.Model;
using Grim_Castle.Architecture.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Grim_Castle
{
    public class Game1 : Game
    {
        Texture2D tile_1;
        Texture2D tile_2;
        Texture2D tile_3;
        Texture2D tile_4;
        Texture2D player;
        Texture2D slime;
        Texture2D skeleton;
        Texture2D healthBar;

        Map map;
        Player basePlayer;
        Slime slime_1;
        Skeleton skeleton_1;

        private GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public SpriteFont font;

        static bool flag = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            map = new Map();
            basePlayer = new Player();
            slime_1 = new Slime(map.CellPositions[10, 2]);
            skeleton_1 = new Skeleton(map.CellPositions[7, 3]);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            tile_1 = Content.Load<Texture2D>("tile_1");
            tile_2 = Content.Load<Texture2D>("tile_2");
            tile_3 = Content.Load<Texture2D>("tile_3");
            tile_4 = Content.Load<Texture2D>("tile_4");

            player = Content.Load<Texture2D>("player");
            slime = Content.Load<Texture2D>("slime");
            skeleton = Content.Load<Texture2D>("skeleton-sword");

            healthBar = Content.Load<Texture2D>("health bar");
            font = Content.Load<SpriteFont>("HealthBar");
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState currentMouseState = Mouse.GetState();
            var (i, j) = map.FindCell(currentMouseState.X, currentMouseState.Y);
            if (currentMouseState.LeftButton == ButtonState.Pressed && flag && i != currentMouseState.X
                && basePlayer.AvailableCells.Contains(map.CellPositions[i, j]))
            {
                MovePlayer.Move(map.CellPositions[i, j]);
                MoveMonster.Move(slime_1);
                MoveMonster.Move(skeleton_1);
                flag = false;
            }
            else if (currentMouseState.LeftButton == ButtonState.Released)
                flag = true;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            MapDrawer.DrawMap(spriteBatch, tile_1, tile_2, tile_3, tile_4);
            PlayerDrawer.PlayerDraw(spriteBatch, player);
            SlimeDrawer.DrawSlime(spriteBatch, slime, slime_1);
            SkeletonDrawer.DrawSkeleton(spriteBatch, skeleton, skeleton_1);
            spriteBatch.Begin();
            spriteBatch.Draw(healthBar, new Vector2(30, 10), Color.White);
            spriteBatch.DrawString(font, $"{basePlayer.Hp}/20", new Vector2(260, 65), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
