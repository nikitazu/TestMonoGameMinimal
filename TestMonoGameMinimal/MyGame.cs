using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestMonoGameMinimal
{
    public class MyGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _sprites;

        /// <summary>
        /// Create a game.
        /// </summary>
        public MyGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Prepair data before loading resources.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Load game resources.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
            _sprites = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// Unload game resources.
        /// </summary>
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        /// <summary>
        /// Update game state.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Render game.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}
