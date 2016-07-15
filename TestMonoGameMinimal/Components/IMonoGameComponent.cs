namespace TestMonoGameMinimal.Components
{
    public interface IMonoGameComponent
    {
        void Initialize();

        void Load();

        void Unload();

        void Update();

        void Draw();
    }
}
