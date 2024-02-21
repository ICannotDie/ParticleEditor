using UnityEngine;
using UnityEngine.UI;
using ICannotDie.Plugins;
using ICannotDie.Plugins.UI;

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

        public virtual void Clear()
        {

        }

        public virtual void Build()
        {

        }

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