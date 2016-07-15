using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace TestMonoGameMinimal.Components
{
    public class GameContext
    {
        public Game Game { get; }
        public IList<IMonoGameComponent> Components { get; } = new List<IMonoGameComponent>();
        public SpriteBatch Sprites { get; private set; }
        public GameTime UpdateTime { get; private set; }
        public GameTime DrawTime { get; private set; }

        public GameContext(Game game)
        {
            Game = game;
        }

        public void Initialize()
        {
            foreach (var c in Components)
            {
                c.Initialize();
            }
        }

        public void Load()
        {
            Sprites = new SpriteBatch(Game.GraphicsDevice);
            foreach (var c in Components)
            {
                c.Load();
            }
        }

        public void Unload()
        {
            foreach (var c in Components)
            {
                c.Unload();
            }
        }

        public void Update(GameTime gameTime)
        {
            UpdateTime = gameTime;
            foreach (var c in Components)
            {
                c.Update();
            }
        }

        public void Draw(GameTime gameTime)
        {
            DrawTime = gameTime;
            foreach (var c in Components)
            {
                c.Draw();
            }
        }
    }
}
