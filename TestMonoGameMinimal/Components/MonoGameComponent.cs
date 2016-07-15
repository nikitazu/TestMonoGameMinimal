namespace TestMonoGameMinimal.Components
{
    public abstract class MonoGameComponent : IMonoGameComponent
    {
        protected GameContext Context { get; }

        public MonoGameComponent(GameContext context)
        {
            Context = context;
        }

        void IMonoGameComponent.Initialize()
        {
            Initialize();
        }

        void IMonoGameComponent.Load()
        {
            Load();
        }

        void IMonoGameComponent.Unload()
        {
            Unload();
        }

        void IMonoGameComponent.Update()
        {
            Update();
        }

        void IMonoGameComponent.Draw()
        {
            Draw();
        }

        protected virtual void Initialize()
        {
        }

        protected virtual void Load()
        {
        }

        protected virtual void Unload()
        {
        }

        protected virtual void Update()
        {
        }

        protected virtual void Draw()
        {
        }
    }
}
