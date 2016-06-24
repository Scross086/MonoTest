using WindowsOpenGL.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WindowsOpenGL.Entity.Background;


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

        private RenderEngine _RenderEngine;


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
            _RenderEngine = new RenderEngine();

           

            background = new Managers.BackgroundManager(0);

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

            player = new Entity.Player(2);
         

            // Load the player resources

            Vector2 playerPosition = new Vector2(0, 0);//new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);

            player.Initialize(Content.Load<Texture2D>("Graphics\\SpaceShip.png"), playerPosition);

            Texture2D [] backgroundTexture = new Texture2D[1];
            Vector2 [] backgroundPosition = new Vector2[1];

            backgroundTexture[0] = Content.Load<Texture2D>("Graphics\\StarBackground.png");
            background.Initialise(backgroundTexture, backgroundPosition);
        
            starField = new StarField(0,GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 100, new Vector2(-50, 0), Content.Load<Texture2D>("Graphics\\Star.png"), new Rectangle(0, 0, 4, 4));
           
            _RenderEngine.AddRenderElement(player);
            _RenderEngine.AddRenderElement(background);
            _RenderEngine.AddRenderElement(starField);
            _RenderEngine.IsUpdateEnabled = true;
            _RenderEngine.IsRenderEnabled = true;

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
            _RenderEngine.Update(gameTime);

          //  starField.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Start drawing
            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend);

            _RenderEngine.Draw(spriteBatch);

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
