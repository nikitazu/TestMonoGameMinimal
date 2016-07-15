using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestMonoGameMinimal.Components
{
    public class SpriteBoxComponent : MonoGameComponent
    {
        private const float _gamePadSticksSensitivity = 5;

        private Vector2 _position = Vector2.Zero;
        private Texture2D _texture;
        private SoundEffect _bodyImpact;
        private SoundEffect _heartbeat;
        private SoundEffectInstance _bodyImpactInstance;
        private SoundEffectInstance _heartbeatInstance;

        public SpriteBoxComponent(GameContext context) : base(context)
        {
        }

        protected override void Load()
        {
            base.Load();
            _texture = Context.Game.Content.Load<Texture2D>("sprites/Героиня-А-аватар-256-384");
            _bodyImpact = Context.Game.Content.Load<SoundEffect>("sounds/bodyimpact");
            _heartbeat = Context.Game.Content.Load<SoundEffect>("sounds/heartbeat");
            _bodyImpactInstance = _bodyImpact.CreateInstance();
            _heartbeatInstance = _heartbeat.CreateInstance();
        }

        protected override void Update()
        {
            base.Update();

            var oldPosition = _position;

            var padCaps = GamePad.GetCapabilities(PlayerIndex.One);
            if (padCaps.IsConnected)
            {
                var padState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular);
                if (padCaps.HasLeftXThumbStick)
                {
                    _position.X += padState.ThumbSticks.Left.X * _gamePadSticksSensitivity;
                    _position.Y -= padState.ThumbSticks.Left.Y * _gamePadSticksSensitivity;
                }
            }

            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                _position.X += 10;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                _position.X -= 10;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                _position.Y -= 10;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                _position.Y += 10;
            }

            if (_position != oldPosition && _heartbeatInstance.State == SoundState.Stopped)
            {
                _heartbeatInstance.Play();
            }
            if (_position.X < 0 || _position.X > Context.Game.Window.ClientBounds.Width - _texture.Width && _bodyImpactInstance.State == SoundState.Stopped)
            {
                _bodyImpactInstance.Play();
            }
        }

        protected override void Draw()
        {
            base.Draw();
            Context.Sprites.Draw(_texture, _position);
        }
    }
}
