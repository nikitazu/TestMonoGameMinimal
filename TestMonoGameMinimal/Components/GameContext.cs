using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestMonoGameMinimal.Components
{
    public class GameContext
    {
        public Game Game { get; }
        public SpriteBatch Sprites { get; private set; }

        public GameContext(Game game)
        {
            Game = game;
        }

        public void Load()
        {
            Sprites = new SpriteBatch(Game.GraphicsDevice);
        }
    }
}
