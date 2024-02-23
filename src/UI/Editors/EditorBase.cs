using UnityEngine;
using UnityEngine.UI;

namespace ICannotDie.Plugins.UI.Editors
{
    public abstract class EditorBase
    {
        protected ParticleEditor _particleEditorScript;
        protected UIManager _uiManager;

        public EditorBase(ParticleEditor particleEditor, UIManager uiManager)
        {
            _particleEditorScript = particleEditor;
            _uiManager = uiManager;
        }

        public abstract void Build();
        public abstract void Clear();
        public abstract void DeregisterStorables();
        public abstract void RegisterStorables();

        protected JSONStorableString CreateLabel(string id, string text, bool isRightSide = false)
        {
            var jsonStorableString = new JSONStorableString(id, text);
            var uiDynamic = _particleEditorScript.CreateTextField(jsonStorableString, isRightSide);
            uiDynamic.height = 12;
            uiDynamic.backgroundColor = Color.clear;
            uiDynamic.textColor = Color.black;
            uiDynamic.UItext.fontSize = 36;
            uiDynamic.UItext.alignment = TextAnchor.LowerCenter;

            var layoutElement = uiDynamic.GetComponent<LayoutElement>();
            layoutElement.minHeight = 0f;
            layoutElement.preferredHeight = 42f;

            return jsonStorableString;
        }
    }
}