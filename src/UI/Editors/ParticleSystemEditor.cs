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
        public JSONStorableBool IsStopped;

        public ParticleSystemEditor(ParticleEditor particleEditor, UIManager uiManager)
        : base(particleEditor, uiManager)
        {
            _particleEditorScript.LogForDebug($"Constructed {nameof(ParticleSystemEditor)}");
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

            if (IsStopped != null)
            {
                _particleEditorScript.RemoveToggle(IsStopped);
                _particleEditorScript.DeregisterBool(IsStopped);
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

            // Is Stopped Toggle
            var isStoppedDefaultValue = true;
            IsStopped = new JSONStorableBool
            (
                "Is Stopped",
                isStoppedDefaultValue,
                (selectedIsStopped) =>
                {
                    if (_particleEditorScript.ParticleSystemManager.CurrentParticleSystem)
                    {
                        if (selectedIsStopped)
                        {
                            _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.Stop();
                        }
                        else
                        {
                            _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.Play();
                        }
                    }
                }
            );
            IsStopped.SetVal(_particleEditorScript.ParticleSystemManager.CurrentParticleSystem ? _particleEditorScript.ParticleSystemManager.CurrentParticleSystem.isStopped : isStoppedDefaultValue);

            _particleEditorScript.CreateToggle(IsStopped, true);
            _particleEditorScript.RegisterBool(IsStopped);
        }
    }
}