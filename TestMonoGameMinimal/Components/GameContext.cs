using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestMonoGameMinimal.Components
{
    public class GameContext
    {
        public Game Game { get; }
        public SpriteBatch Sprites { get; private set; }
        public GameTime UpdateTime { get; private set; }
        public GameTime DrawTime { get; private set; }

        public GameContext(Game game)
        {
            Game = game;
        }

        public void Load()
        {
            Sprites = new SpriteBatch(Game.GraphicsDevice);
        }

        public void Update(GameTime gameTime)
        {
            UpdateTime = gameTime;
        }

        public void Draw(GameTime gameTime)
        {
            DrawTime = gameTime;
        }
    }
}
