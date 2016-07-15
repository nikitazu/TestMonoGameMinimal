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

        /// <summary>
        /// Create a game.
        /// </summary>
        public MyGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _context = new GameContext(this);
            _context.Components.Add(new TextureBoxComponent(_context));
            _context.Components.Add(new SpriteBoxComponent(_context));

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
            _context.Initialize();
        }

        /// <summary>
        /// Load game resources.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
            _context.Load();
        }

        /// <summary>
        /// Unload game resources.
        /// </summary>
        protected override void UnloadContent()
        {
            base.UnloadContent();
            _context.Unload();
            Content.Unload();
        }

        /// <summary>
        /// Update game state.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            if (IsActive)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                    || Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    Exit();
                }
                _context.Update(gameTime);
                base.Update(gameTime);
            }
        }

        /// <summary>
        /// Render game.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _context.Sprites.Begin();
            _context.Draw(gameTime);
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
