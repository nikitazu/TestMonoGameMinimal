using Microsoft.Xna.Framework.Media;

namespace TestMonoGameMinimal.Components
{
    public class MusicPlayerComponent : MonoGameComponent
    {
        private Song _song;

        public MusicPlayerComponent(GameContext context) : base(context)
        {
        }

        protected override void Load()
        {
            base.Load();
            _song = Context.Game.Content.Load<Song>("music/Lesson12");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(_song);
        }
    }
}
