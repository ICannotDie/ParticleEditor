using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MVR.FileManagementSecure;
using ICannotDie.Plugins.UI;
using ICannotDie.Plugins.ParticleSystems;
using ICannotDie.Plugins.Common;
using ICannotDie.Plugins.Common.Extensions;

namespace ICannotDie.Plugins
{
	public class ParticleEditor : MVRScript
	{
		public static ParticleEditor ParticleEditorScript { get; private set; }
		public bool? IsInitialised { get; private set; }
		public UIManager UiManager { get; private set; }
		public ParticleSystemManager ParticleSystemManager { get; private set; }
		public bool EnableDebug { get; private set; } = true;

		public override void Init()
		{
			base.Init();

			try
			{
				ParticleEditorScript = this;
				StartCoroutine(DeferInit());
			}
			catch (Exception e)
			{
				enabled = false;
				Utility.LogError($"{nameof(Init)}: {e}");
			}
		}

		private IEnumerator DeferInit()
		{
			yield return new WaitForEndOfFrame();
			while (SuperController.singleton.isLoading)
			{
				yield return null;
			}

			// Wait for other plugin permissions to be accepted
			var confirmPanel = SuperController.singleton.errorLogPanel.parent.Find(Constants.UserConfirmCanvas);
			while (confirmPanel != null && confirmPanel.childCount > 0)
			{
				yield return null;
			}

			try
			{
				UiManager = new UIManager(this);
				ParticleSystemManager = new ParticleSystemManager(this);

				ParticleSystemManager.Initialise();
				UiManager.BuildUI();

				IsInitialised = true;
			}
			catch (Exception e)
			{
				Utility.LogError($"{nameof(DeferInit)}: {e}");
				IsInitialised = false;
			}
		}

		public List<ParticleSystem> FindParticleSystems() => FindObjectsOfType<ParticleSystem>().ToList();

		public void LogForDebug(params string[] args)
		{
			if (EnableDebug)
			{
				Utility.LogMessage(args);
			}
		}
	}
}