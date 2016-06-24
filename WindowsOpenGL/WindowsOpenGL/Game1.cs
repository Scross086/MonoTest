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


        public Game1()
        {
            _Graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1024,
                PreferredBackBufferHeight = 768
            };

            _Graphics.ApplyChanges();

            Content.RootDirectory = "Content";

            player = new Entity.Player();
        
            background = new Managers.BackgroundManager();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

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

            // Load the player resources

            Vector2 playerPosition = new Vector2(0, 0);//new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);

            player.Initialize(Content.Load<Texture2D>("Graphics\\SpaceShip.png"), playerPosition);

            Texture2D [] backgroundTexture = new Texture2D[1];
            Vector2 [] backgroundPosition = new Vector2[1];

            backgroundTexture[0] = Content.Load<Texture2D>("Graphics\\StarBackground.png");
            background.Initialise(backgroundTexture, backgroundPosition);

            starField = new StarField(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 100, new Vector2(-50, 0), Content.Load<Texture2D>("Graphics\\Star.png"), new Rectangle(0, 0, 4, 4));

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

            starField.Update(gameTime);

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
            
            //Draw the Background
            background.Draw(spriteBatch);

            //Draw the Star Field
            starField.Draw(spriteBatch);

            // Draw the Player
            player.Draw(spriteBatch);

            

            // Stop drawing
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
