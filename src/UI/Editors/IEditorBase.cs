namespace ICannotDie.Plugins.UI.Editors
{
    public interface IEditorBase
    {
        void Build();
        void Clear();
        void DeregisterStorables();
        void RegisterStorables();
    }
}