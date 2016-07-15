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

        protected abstract void Initialize();

        protected abstract void Load();

        protected abstract void Unload();

        protected abstract void Update();

        protected abstract void Draw();
    }
}
