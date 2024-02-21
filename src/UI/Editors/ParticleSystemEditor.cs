using UnityEngine;
using MVR.FileManagementSecure;
using ICannotDie.Plugins;
using ICannotDie.Plugins.Common;
using ICannotDie.Plugins.UI;
using System.Collections.Generic;

namespace ICannotDie.Plugins.UI.Editors
{
    public class ParticleSystemEditor : EditorBase
    {
        public JSONStorableString ParticleSystemLabel;
        public JSONStorableBool IsPlaying;

        public ParticleSystemEditor(ParticleEditor particleEditor, UIManager uiManager)
        : base(particleEditor, uiManager)
        {

        }

        public override void Clear()
        {
            if (ParticleSystemLabel != null)
            {
                _particleEditorScript.RemoveTextField(ParticleSystemLabel);
            }

            if (IsPlaying != null)
            {
                _particleEditorScript.RemoveToggle(IsPlaying);
                _particleEditorScript.DeregisterBool(IsPlaying);
            }
        }

        public override void Build()
        {
            // Renderer Label
            ParticleSystemLabel = CreateLabel("particleSystemLabel", "Particle System", true);
            // Is Playing Toggle
            var isPlayingDefaultValue = true;
            IsPlaying = new JSONStorableBool
            (
                "Is Playing",
                isPlayingDefaultValue,
                (selectedIsPlaying) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        if (selectedIsPlaying)
                        {
                            _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.Play();
                        }
                        else
                        {
                            _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.Stop();
                        }
                    }
                }
            );
            IsPlaying.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.isPlaying : isPlayingDefaultValue);

            _particleEditorScript.CreateToggle(IsPlaying, true);
            _particleEditorScript.RegisterBool(IsPlaying);
        }
    }
}