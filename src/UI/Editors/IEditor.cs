namespace ICannotDie.Plugins.UI.Editors
{
    public interface IEditor
    {
        void Build();
        void Clear();
        void DeregisterStorables();
        void RegisterStorables();
    }
}