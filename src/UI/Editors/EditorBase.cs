using UnityEngine;
using UnityEngine.UI;

namespace ICannotDie.Plugins.UI.Editors
{
    public abstract class EditorBase : IEditor
    {
        private readonly ParticleEditor _particleEditor;

        public EditorBase(ParticleEditor particleEditor)
        {
            _particleEditor = particleEditor;
        }

        public abstract void Build();
        public abstract void Clear();
        public abstract void DeregisterStorables();
        public abstract void RegisterStorables();

        protected JSONStorableString CreateLabel(string id, string text, bool isRightSide = false)
        {
            var jsonStorableString = new JSONStorableString(id, text);
            var uiDynamic = _particleEditor.CreateTextField(jsonStorableString, isRightSide);
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

        protected JSONStorableString CreateHeadingLabel(string id, string text, bool isRightSide = false)
        {
            var jsonStorableString = new JSONStorableString(id, text);
            var uiDynamic = _particleEditor.CreateTextField(jsonStorableString, isRightSide);
            uiDynamic.height = 48f;
            uiDynamic.backgroundColor = Color.clear;
            uiDynamic.textColor = Color.black;
            uiDynamic.UItext.fontSize = 32;
            uiDynamic.UItext.fontStyle = FontStyle.Bold;
            uiDynamic.UItext.alignment = TextAnchor.LowerCenter;

            var layoutElement = uiDynamic.GetComponent<LayoutElement>();
            layoutElement.minHeight = 48f;
            layoutElement.preferredHeight = 48f;

            return jsonStorableString;
        }

        protected JSONStorableString CreateUrlLabel(string id, string text, bool isRightSide = false)
        {
            var jsonStorableString = new JSONStorableString(id, text);
            var uiDynamic = _particleEditor.CreateTextField(jsonStorableString, isRightSide);
            uiDynamic.height = 36f;
            uiDynamic.backgroundColor = Color.clear;
            uiDynamic.textColor = Color.black;
            uiDynamic.UItext.fontSize = 20;
            uiDynamic.UItext.alignment = TextAnchor.UpperLeft;
            uiDynamic.UItext.resizeTextForBestFit = true;

            var layoutElement = uiDynamic.GetComponent<LayoutElement>();
            layoutElement.minHeight = 24f;
            layoutElement.preferredHeight = 36f;

            return jsonStorableString;
        }

    }
}