using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestMonoGameMinimal.Components
{
    public class TextureBoxComponent : MonoGameComponent
    {
        private const int _speed = 200;
        private Texture2D _texture;
        private Vector2 _position;

        public TextureBoxComponent(GameContext context) : base(context)
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            _position = new Vector2(0, 0);
            _texture = new Texture2D(Context.Game.GraphicsDevice, 100, 100);
            Color[] colors = new Color[100 * 100];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = Color.OrangeRed;
            }
            _texture.SetData(colors);
        }

        protected override void Update()
        {
            base.Update();
            _position.X = _position.X >= Context.Game.GraphicsDevice.Viewport.Width ? -_texture.Width : _position.X + _speed * (float)Context.UpdateTime.ElapsedGameTime.TotalSeconds;
        }

        protected override void Draw()
        {
            base.Draw();
            Context.Sprites.Draw(_texture, _position);
        }
    }
}
