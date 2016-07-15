using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestMonoGameMinimal.Components
{
    public class SpriteBoxComponent : MonoGameComponent
    {
        private Texture2D _texture;

        public SpriteBoxComponent(GameContext context) : base(context)
        {
        }

        protected override void Load()
        {
            base.Load();
            _texture = Context.Game.Content.Load<Texture2D>("Героиня-А-аватар-256-384");
        }

        protected override void Draw()
        {
            base.Draw();
            Context.Sprites.Draw(_texture, Vector2.Zero);
        }
    }
}
