using WindowsOpenGL.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WindowsOpenGL.Entity.Background;
using MonoGame.Extended.BitmapFonts;


namespace WindowsOpenGL
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager _Graphics;
        SpriteBatch spriteBatch;

        Entity.Player player;
        Managers.BackgroundManager background;
        StarField starField;

        public static RenderEngine GameRenderEngine;
        public static RenderEngine GlobalRenderEngine;
        public static RenderEngine UIRenderEngine;

        private BitmapFont TestFont;


        public Game1()
        {
            _Graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1024,
                PreferredBackBufferHeight = 768
            };

            _Graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            GameRenderEngine = new RenderEngine(0);
            UIRenderEngine = new RenderEngine(1);
            GlobalRenderEngine = new RenderEngine();

            TestFont = Content.Load<BitmapFont>("Fonts\\ImpactBold");

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = new Managers.BackgroundManager(0);
            player = new Entity.Player(2);

            // Load the player resources

            Vector2 playerPosition = new Vector2(0, 0);//new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);

            player.Initialize(Content.Load<Texture2D>("Graphics\\SpaceShip"), playerPosition);

            Texture2D [] backgroundTexture = new Texture2D[1];
            Vector2 [] backgroundPosition = new Vector2[1];

            backgroundTexture[0] = Content.Load<Texture2D>("Graphics\\StarBG");
            background.Initialise(backgroundTexture, backgroundPosition);
        
            starField = new StarField(1,GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 100, new Vector2(-50, 0), Content.Load<Texture2D>("Graphics\\Star"), new Rectangle(0, 0, 4, 4));
           
            //add game render elements
            GameRenderEngine.AddRenderElement(player);
            GameRenderEngine.AddRenderElement(background);
            GameRenderEngine.AddRenderElement(starField);

            //add the game and the ui to the global RenderEngine - this will allow for the UI to always be on top
            GlobalRenderEngine.AddRenderElement(GameRenderEngine);
            GlobalRenderEngine.AddRenderElement(UIRenderEngine);
           
            GameRenderEngine.IsUpdateEnabled = GameRenderEngine.IsRenderEnabled = true;
            UIRenderEngine.IsUpdateEnabled = UIRenderEngine.IsRenderEnabled = true;
            GlobalRenderEngine.IsUpdateEnabled = GlobalRenderEngine.IsRenderEnabled = true;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            GlobalRenderEngine.Update(gameTime);

          //  starField.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Start drawing
            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend);

            GlobalRenderEngine.Draw(spriteBatch);

            spriteBatch.DrawString(TestFont, "Fuck Yeah It Works", new Vector2(100,100),Color.Red );

            //Draw the Background
          //  background.Draw(spriteBatch);

            //Draw the Star Field
           // starField.Draw(spriteBatch);

            // Draw the Player
          //  player.Draw(spriteBatch);

            

            // Stop drawing
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
