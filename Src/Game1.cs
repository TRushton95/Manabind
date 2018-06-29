using Manabind.Src.Gameplay.AppStates;
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

        private AppState appState;

        #endregion

        #region Constructors

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            this.IsMouseVisible = true;

            Content.RootDirectory = "Content";

            appState = new MenuAppState();
        }

        #endregion

        #region methods
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            appState.Initialise(GraphicsDevice, Content, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height);

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            appState.Update();

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            GraphicsDevice.Clear(Color.CornflowerBlue);
            appState.Draw(spriteBatch);
            base.Draw(gameTime);

            spriteBatch.End();
        }

        #endregion
    }
}
