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
        Texture2D monsterHealth;
        Texture2D skeletonSmall;
        Texture2D slimeSmall;

        Texture2D cell;
        Texture2D longCell;
        Texture2D shortSword;
        Texture2D sword;
        Texture2D spear;

        Map map;
        Player basePlayer;
        Slime slime_1;
        Skeleton skeleton_1;

        private GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static SpriteFont hpFont;
        public static SpriteFont infoFont;

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
            hpFont = Content.Load<SpriteFont>("hpFont");
            infoFont = Content.Load<SpriteFont>("infoFont");


            tile_1 = Content.Load<Texture2D>("tile_1");
            tile_2 = Content.Load<Texture2D>("tile_2");
            tile_3 = Content.Load<Texture2D>("tile_3");
            tile_4 = Content.Load<Texture2D>("tile_4");

            cell = Content.Load<Texture2D>("cell");
            shortSword = Content.Load<Texture2D>("short sword");
            sword = Content.Load<Texture2D>("sword");
            spear = Content.Load<Texture2D>("spear");

            player = Content.Load<Texture2D>("player");
            slime = Content.Load<Texture2D>("slime");
            skeleton = Content.Load<Texture2D>("skeleton-sword");

            healthBar = Content.Load<Texture2D>("health bar");
            monsterHealth = Content.Load<Texture2D>("monster health");
            longCell = Content.Load<Texture2D>("longCell");
            skeletonSmall = Content.Load<Texture2D>("skeletonSmall");
            slimeSmall = Content.Load<Texture2D>("slimeSmall");
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState currentMouseState = Mouse.GetState();
            var (i, j) = map.FindCell(currentMouseState.X, currentMouseState.Y);
            if (currentMouseState.LeftButton == ButtonState.Pressed && flag && i != currentMouseState.X)
            {
                if (basePlayer.AvailableCells.Contains(map.CellPositions[i, j]))
                {
                    MovePlayer.Move(map.CellPositions[i, j]);
                    HitMonster.Hit(new Vector2(currentMouseState.X, currentMouseState.Y));
                    MoveMonster.Move(slime_1);
                    MoveMonster.Move(skeleton_1);
                    flag = false;
                }
            }
            else if (currentMouseState.LeftButton == ButtonState.Pressed && flag)
            {
                ChangeWeapon.Change(currentMouseState.X, currentMouseState.Y);
                flag = false;
            }
            else if (currentMouseState.LeftButton == ButtonState.Released)
                flag = true;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            MapDrawer.DrawMap(tile_1, tile_2, tile_3, tile_4);
            PlayerDrawer.DrawPlayer(player);
            SlimeDrawer.DrawSlime(slime, slime_1);
            SkeletonDrawer.DrawSkeleton(skeleton, skeleton_1);
            HealthBarDrawer.Draw(healthBar);
            InventoryDrawer.Draw(cell, shortSword, sword, spear);
            MonsterInfoDrawer.Draw(monsterHealth, longCell, slimeSmall, skeletonSmall);
            WeaponInfoDrawer.Draw(longCell);
            WeaponDrawer.Draw(spear, sword, new Monster[] { slime_1, skeleton_1 });

            base.Draw(gameTime);
        }
    }
}
