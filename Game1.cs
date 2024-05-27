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
        Texture2D exit;
        Texture2D lockedExit;

        Texture2D playerSprite;
        Texture2D slimeSprite;
        Texture2D skeletonSprite;
        Texture2D blackSpiderSprite;
        Texture2D venomousSpiderSprite;
        Texture2D arachnaSprite;

        Texture2D healthBar;
        Texture2D monsterHealth;
        Texture2D skeletonInfo;
        Texture2D slimeInfo;
        Texture2D blackSpiderInfo;
        Texture2D venomousSpiderInfo;

        Texture2D cell;
        Texture2D longCell;
        Texture2D shortSword;
        Texture2D sword;
        Texture2D spear;

        Texture2D deathScreen;
        Texture2D button;

        Map map;
        Player player;
        public static Slime slime;
        public static Skeleton skeleton;
        public static BlackSpider blackSpider;
        public static VenomousSpider venomousSpider;
        public static Arachna arachna;

        private GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static SpriteFont hpFont;
        public static SpriteFont infoFont;

        static bool IsClicked = true;
        public static bool FirstLevelCompleted = false;
        public static bool SecondLevelCompleted = false;
        public static bool ThirdLevelCompleted = false;


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
            player = new Player();
            Level1.InitializeMonsters();

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
            exit = Content.Load<Texture2D>("exit");
            lockedExit = Content.Load<Texture2D>("lock");

            cell = Content.Load<Texture2D>("cell");
            shortSword = Content.Load<Texture2D>("short sword");
            sword = Content.Load<Texture2D>("sword");
            spear = Content.Load<Texture2D>("spear");

            playerSprite = Content.Load<Texture2D>("player");
            slimeSprite = Content.Load<Texture2D>("slime");
            skeletonSprite = Content.Load<Texture2D>("skeleton-sword");
            blackSpiderSprite = Content.Load<Texture2D>("black spider");
            venomousSpiderSprite = Content.Load<Texture2D>("venomous spider");
            arachnaSprite = Content.Load<Texture2D>("arachna");

            healthBar = Content.Load<Texture2D>("health bar");
            monsterHealth = Content.Load<Texture2D>("monster health");
            longCell = Content.Load<Texture2D>("longCell");
            skeletonInfo = Content.Load<Texture2D>("skeletonSmall");
            slimeInfo = Content.Load<Texture2D>("slimeSmall");
            blackSpiderInfo = Content.Load<Texture2D>("blackSpiderSmall");
            venomousSpiderInfo = Content.Load<Texture2D>("venomousSpiderSmall");

            deathScreen = Content.Load<Texture2D>("deathScreen");
            button = Content.Load<Texture2D>("button");
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState currentMouseState = Mouse.GetState();
            var (i, j) = map.FindCell(currentMouseState.X, currentMouseState.Y);
            if (currentMouseState.LeftButton == ButtonState.Pressed && IsClicked && i != currentMouseState.X)
            {
                if (player.AvailableCells.Contains(map.CellPositions[i, j]))
                {
                    MovePlayer.Move(map.CellPositions[i, j]);
                    HitMonster.Hit(new Vector2(currentMouseState.X, currentMouseState.Y));

                    MoveMonster.Move(slime);
                    MoveMonster.Move(skeleton);
                    MoveMonster.Move(blackSpider);
                    MoveMonster.Move(venomousSpider);
                    MoveMonster.Move(arachna);

                    ChangeLevel.Change(player);
                    IsClicked = false;
                }
            }
            else if (currentMouseState.LeftButton == ButtonState.Pressed && IsClicked)
            {
                ChangeWeapon.Change(currentMouseState.X, currentMouseState.Y);
                IsClicked = false;
            }
            else if (currentMouseState.LeftButton == ButtonState.Released)
                IsClicked = true;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            MapDrawer.DrawMap(tile_1, tile_2, tile_3, tile_4, exit, lockedExit);
            PlayerDrawer.DrawPlayer(playerSprite);

            SlimeDrawer.DrawSlime(slimeSprite);
            SkeletonDrawer.DrawSkeleton(skeletonSprite);
            BlackSpiderDrawer.Draw(blackSpiderSprite);
            VenomousSpiderDrawer.Draw(venomousSpiderSprite);
            ArachnaDrawer.Draw(arachnaSprite);

            HealthBarDrawer.Draw(healthBar);
            InventoryDrawer.Draw(cell, shortSword, sword, spear);
            MonsterInfoDrawer.Draw(monsterHealth, longCell, slimeInfo, skeletonInfo,
                blackSpiderInfo, venomousSpiderInfo, arachnaSprite);
            WeaponInfoDrawer.Draw(longCell);
            WeaponDrawer.Draw(spear, sword, new Monster[] { slime, skeleton, blackSpider, venomousSpider, arachna });

            DeathScreen.Draw(deathScreen, button);
            WinnerScreen.Draw(deathScreen, button, this);

            base.Draw(gameTime);
        }

        public static void Nulification()
        {
            slime = null;
            skeleton = null;
            blackSpider = null;
            venomousSpider = null;
            arachna = null;
        }
    }
}
