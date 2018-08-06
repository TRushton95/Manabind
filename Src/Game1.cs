using Manabind.Src.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Manabind.Src
{
    public class Game1 : Game
    {
        #region Fields

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameManager gameManager;

        #endregion

        #region Constructors

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = AppSettings.WindowWidth;
            graphics.PreferredBackBufferHeight = AppSettings.WindowHeight;
            this.IsMouseVisible = true;

            gameManager = new GameManager();

            Content.RootDirectory = "Content";
        }

        #endregion

        #region methods
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gameManager.Initialise(GraphicsDevice, Content);

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) || gameManager.ReadyToExit)
                Exit();

            // TODO: Add your update logic here
            MouseInfo.Update();
            KeyboardInfo.Update();

            gameManager.Update();

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            GraphicsDevice.Clear(Color.CornflowerBlue);
            gameManager.Draw(spriteBatch);
            base.Draw(gameTime);

            spriteBatch.End();
        }

        #endregion
    }
}
