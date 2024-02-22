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
		public Atom ContainingAtom { get; private set; }
		public bool? IsInitialised { get; private set; }
		public UIManager UiManager { get; private set; }
		public ParticleSystemManager ParticleSystemManager { get; private set; }
		public bool EnableDebug { get; private set; } = true;

		public override void Init()
		{
			base.Init();

			ContainingAtom = this.containingAtom;

			UiManager = new UIManager(this);
			ParticleSystemManager = new ParticleSystemManager(this);

			ParticleSystemManager.Initialise();
			UiManager.BuildUI();
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