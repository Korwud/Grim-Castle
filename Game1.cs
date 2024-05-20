using Grim_Castle.Architecture;
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
        Texture2D healthBar;
        Map map;
        Player basePlayer;

        private GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public SpriteFont font;

        Vector2 position = Vector2.Zero;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 980;
            graphics.PreferredBackBufferWidth = 1550;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            basePlayer = new Player();
            map = new Map();

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
            healthBar = Content.Load<Texture2D>("health bar");
            font = Content.Load<SpriteFont>("HealthBar");
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Pressed)
            {
                var (i, j) = map.FindCell(currentMouseState.X, currentMouseState.Y);
                if (i != -1)
                    position = map.CellPositions[i, j];
                Draw(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            MapDrawer.DrawMap(spriteBatch, tile_1, tile_2, tile_3, tile_4);
            PlayerDrawer.PlayerDraw(spriteBatch, player, position);
            spriteBatch.Begin();
            spriteBatch.Draw(healthBar, new Vector2(5, 5), Color.White);
            spriteBatch.DrawString(font, "5/20", new Vector2(100, 100), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
