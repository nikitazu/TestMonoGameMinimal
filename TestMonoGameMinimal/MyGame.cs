using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TestMonoGameMinimal.Components;

namespace TestMonoGameMinimal
{
    public class MyGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private readonly GameContext _context;
        private readonly IMonoGameComponent _simpleTextureBox;

        /// <summary>
        /// Create a game.
        /// </summary>
        public MyGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _context = new GameContext(this);
            _simpleTextureBox = new TextureBoxComponent(_context);

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Prepair data before loading resources.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            _simpleTextureBox.Initialize();
        }

        /// <summary>
        /// Load game resources.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
            _context.Load();
            _simpleTextureBox.Load();
        }

        /// <summary>
        /// Unload game resources.
        /// </summary>
        protected override void UnloadContent()
        {
            base.UnloadContent();
            _simpleTextureBox.Unload();
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

            _simpleTextureBox.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// Render game.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _context.Sprites.Begin();
            _simpleTextureBox.Draw();
            _context.Sprites.End();

            base.Draw(gameTime);
        }
    }
}
