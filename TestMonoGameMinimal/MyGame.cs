using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TestMonoGameMinimal.Components;

namespace TestMonoGameMinimal
{
    public class MyGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private readonly GameContext _context;
        private readonly IMonoGameComponent _simpleTextureBox;
        private readonly IMonoGameComponent _simpleSpriteBox;

        /// <summary>
        /// Create a game.
        /// </summary>
        public MyGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _context = new GameContext(this);
            _simpleTextureBox = new TextureBoxComponent(_context);
            _simpleSpriteBox = new SpriteBoxComponent(_context);

            IsFixedTimeStep = true;
            _graphics.SynchronizeWithVerticalRetrace = true;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Prepair data before loading resources.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            _simpleTextureBox.Initialize();
            _simpleSpriteBox.Initialize();
        }

        /// <summary>
        /// Load game resources.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
            _context.Load();
            _simpleTextureBox.Load();
            _simpleSpriteBox.Load();
        }

        /// <summary>
        /// Unload game resources.
        /// </summary>
        protected override void UnloadContent()
        {
            base.UnloadContent();
            _simpleTextureBox.Unload();
            _simpleSpriteBox.Unload();
            Content.Unload();
        }

        /// <summary>
        /// Update game state.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            _context.Update(gameTime);
            if (IsActive)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                    || Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    Exit();
                }

                _simpleTextureBox.Update();
                _simpleSpriteBox.Update();

                base.Update(gameTime);
            }
        }

        /// <summary>
        /// Render game.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            _context.Draw(gameTime);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _context.Sprites.Begin();
            _simpleTextureBox.Draw();
            _simpleSpriteBox.Draw();
            _context.Sprites.End();

            base.Draw(gameTime);
        }

        protected override void OnActivated(object sender, EventArgs args)
        {
            base.OnActivated(sender, args);
            Window.Title = "Active app";
        }

        protected override void OnDeactivated(object sender, EventArgs args)
        {
            base.OnDeactivated(sender, args);
            Window.Title = "Inactive app";
        }
    }
}
