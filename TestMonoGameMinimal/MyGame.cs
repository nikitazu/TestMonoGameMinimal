using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestMonoGameMinimal
{
    public class MyGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _sprites;

        private Texture2D _texture;
        private Vector2 _position;

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
            _position = new Vector2(0, 0);
            _texture = new Texture2D(GraphicsDevice, 100, 100);
            Color[] colors = new Color[100 * 100];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = Color.OrangeRed;
            }
            _texture.SetData(colors);

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

            _position.X = _position.X >= GraphicsDevice.Viewport.Width ? -_texture.Width : _position.X + 5;

            base.Update(gameTime);
        }

        /// <summary>
        /// Render game.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _sprites.Begin();
            _sprites.Draw(_texture, _position);
            _sprites.End();

            base.Draw(gameTime);
        }
    }
}
