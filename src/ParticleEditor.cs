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
	internal sealed class ParticleEditor : MVRScript
	{
		// Currently selected Atom/Components
		// private Atom _currentAtom;
		// private ParticleSystem _currentParticleSystem => _currentAtom != null ? _currentAtom.GetComponentInChildren<ParticleSystem>() : null;
		// private ParticleSystemRenderer _currentParticleSystemRenderer => _currentParticleSystem != null ? _currentParticleSystem.GetComponent<ParticleSystemRenderer>() : null;

		// // UI
		// public UIDynamicButton AddParticleSystemButton;
		// public UIDynamicButton FindParticleSystemsButton;
		// public JSONStorableStringChooser ParticleSystemChooser;
		// private string _previouslySelectedParticleSystemUid = null;
		// private List<Atom> _sceneParticleSystemAtoms = new List<Atom>();
		// private List<string> _particleSystems => _sceneParticleSystemAtoms.Any() ? _sceneParticleSystemAtoms.OrderBy(atom => atom.UidAsInt()).Select(atom => atom.uid).ToList() : new List<string>();
		// private UIDynamicButton SelectParticleSystemAtomButton;
		// private UIDynamicButton RemoveSelectedParticleSystemButton;

		// // Particle System Main
		// public JSONStorableString MainLabel;
		// public JSONStorableBool IsPlaying;
		// public JSONStorableBool IsLooping;
		// public JSONStorableBool Prewarm;
		// public JSONStorableFloat Duration;
		// public JSONStorableFloat StartDelay;
		// public JSONStorableFloat StartDelayMultiplier;
		// public JSONStorableFloat StartLifetime;
		// public JSONStorableFloat StartLifetimeMultiplier;
		// public JSONStorableFloat StartSpeed;
		// public JSONStorableFloat StartSpeedMultiplier;
		// public JSONStorableFloat StartSize;

		// // Particle System Renderer
		// public UIDynamicButton SelectParticleImageButton;
		// private string _lastAccessedDirectoryPath = "";

		public static ParticleEditor ParticleEditorScript { get; private set; }
		public bool? Initialised { get; private set; }

		public UIManager UiManager { get; private set; }
		public ParticleSystemManager ParticleSystemManager { get; private set; }
		public bool IsInitialised { get; set; } = false;

		public override void Init()
		{
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

		IEnumerator DeferInit()
		{
			yield return new WaitForEndOfFrame();
			while (SuperController.singleton.isLoading)
			{
				yield return null;
			}

			try
			{
				UiManager = new UIManager(this);
				ParticleSystemManager = new ParticleSystemManager(this);

				ParticleSystemManager.Initialise();
				UiManager.BuildUI();

				Initialised = true;
			}
			catch (Exception e)
			{
				LogError($"{nameof(Init)}: {e}");
				Initialised = false;
			}
		}

		#region Atom Actions

		// private void SetCurrentAtom(string uid) => SetCurrentAtom(SuperController.singleton.GetAtomByUid(uid));

		// private void SetCurrentAtom(Atom atom)
		// {
		// 	if (atom != null)
		// 	{
		// 		_currentAtom = atom;
		// 	}
		// 	else
		// 	{
		// 		_currentAtom = null;
		// 	}
		// }

		// public string GetNextAtomUID()
		// {
		// 	var usedUIDs = _sceneParticleSystemAtoms.Select(x => x.uid).ToList();

		// 	if (!usedUIDs.Contains(Constants.RootObjectName))
		// 	{
		// 		return Constants.RootObjectName;
		// 	}

		// 	for (int i = 2; i < 1000; i++)
		// 	{
		// 		var uid = $"{Constants.RootObjectName}#{i}";
		// 		if (!usedUIDs.Contains(uid))
		// 		{
		// 			return uid;
		// 		}
		// 	}

		// 	return Constants.RootObjectName + Guid.NewGuid();
		// }

		// public IEnumerator CreateAtomCoroutine()
		// {
		// 	// Get a new UID for the atom
		// 	var nextUID = GetNextAtomUID();

		// 	// Add an atom by type (always an Empty)
		// 	var atomEnumerator = SuperController.singleton.AddAtomByType(Constants.EmptyAtomTypeName, nextUID, true);

		// 	// Yield the enumerator
		// 	while (atomEnumerator.MoveNext())
		// 	{
		// 		yield return atomEnumerator.Current;
		// 	}

		// 	// Find the atom by uid to check it was added
		// 	var atom = SuperController.singleton.GetAtomByUid(nextUID);

		// 	if (atom == null)
		// 	{
		// 		throw new NullReferenceException("Atom did not spawn");
		// 	}

		// 	// Add the particle system to the atom
		// 	AddParticleSystemToAtom(atom);

		// 	// Find, Set & Build
		// 	FindParticleSystems();
		// 	SetCurrentAtom(atom);
		// 	SetParticleSystemDefaults(_currentParticleSystem);
		// 	SetParticleSystemRendererDefaults(_currentParticleSystemRenderer);
		// 	BuildUI();
		// }

		// private void AddParticleSystemToAtom(Atom atom)
		// {
		// 	if (atom.type != Constants.EmptyAtomTypeName)
		// 	{
		// 		throw new ArgumentException(nameof(atom));
		// 	}

		// 	// Gets the Empty atom's sphere collider
		// 	var sphereCollider = atom.transform.GetComponentsInChildren<SphereCollider>().First();

		// 	if (sphereCollider != null)
		// 	{
		// 		// Add a ParticleSystem to the sphere collider
		// 		_sceneParticleSystemAtoms.Add(atom);
		// 		sphereCollider.transform.gameObject.AddComponent<ParticleSystem>();
		// 	}
		// }

		// private void SetParticleSystemDefaults(ParticleSystem particleSystem)
		// {

		// }

		// private void SetParticleSystemRendererDefaults(ParticleSystemRenderer particleSystemRenderer)
		// {
		// 	var texturePath = $"{GetPackagePath(this)}{Constants.DefaultShaderTextureFolderPath}/{Constants.DefaultShaderTextureName}";
		// 	particleSystemRenderer.material = GetMaterial(Constants.ShaderName_ParticlesAdditive, texturePath);
		// }

		// public IEnumerator RemoveAtomCoroutine(string uid)
		// {
		// 	// Get atom to remove by uid
		// 	var atomToRemove = SuperController.singleton.GetAtomByUid(uid);

		// 	// Remove the atom
		// 	SuperController.singleton.RemoveAtom(atomToRemove);

		// 	// Yield now so the atom gets removed before we continue 
		// 	yield return new WaitForEndOfFrame();

		// 	// Get the atom by uid again, to confirm it was removed
		// 	var atom = SuperController.singleton.GetAtomByUid(uid);

		// 	if (atom != null)
		// 	{
		// 		throw new NullReferenceException("Atom was not removed");
		// 	}

		// 	// Choose a new atom to be set as current, or set null
		// 	// Do this before we change the list to ensurre we select correctly
		// 	var nextAtom = GetAtomBefore(atomToRemove);

		// 	// Remove the atom from the local list
		// 	_sceneParticleSystemAtoms.Remove(atomToRemove);

		// 	// Find, Set & Build
		// 	FindParticleSystems();
		// 	SetCurrentAtom(nextAtom);
		// 	BuildUI();
		// }

		// private void FindParticleSystems(bool findAll = false)
		// {
		// 	_sceneParticleSystemAtoms.Clear();

		// 	List<ParticleSystem> foundParticleSystems = new List<ParticleSystem>();

		// 	if (findAll = false)
		// 	{
		// 		// Finds ALL particle systems, even if they're disabled or inside assetbundles
		// 		foundParticleSystems = (Resources.FindObjectsOfTypeAll(typeof(ParticleSystem)) as ParticleSystem[]).ToList();
		// 	}
		// 	else
		// 	{
		// 		// Finds active particle systems, not those that are disabled or inside assetbundles
		// 		foundParticleSystems = FindObjectsOfType<ParticleSystem>().ToList();
		// 	}

		// 	foreach (var particleSystem in foundParticleSystems)
		// 	{
		// 		var atom = particleSystem.GetComponentInParent<Atom>();

		// 		var allowedAtomTypes = new List<string>() { "Empty", "CustomUnityAsset" };

		// 		if (atom != null && allowedAtomTypes.Contains(atom.type))
		// 		{
		// 			_sceneParticleSystemAtoms.Add(atom);
		// 		}
		// 	}

		// 	_sceneParticleSystemAtoms = _sceneParticleSystemAtoms.OrderBy(atom => atom.UidAsInt()).ToList();
		// }

		#endregion

		#region UI

		// private void ClearUI()
		// {
		// 	RemoveButton(AddParticleSystemButton);
		// 	RemoveButton(FindParticleSystemsButton);

		// 	if (ParticleSystemChooser != null)
		// 	{
		// 		RemovePopup(ParticleSystemChooser);
		// 		DeregisterStringChooser(ParticleSystemChooser);
		// 	}

		// 	RemoveButton(SelectParticleSystemAtomButton);
		// 	RemoveButton(RemoveSelectedParticleSystemButton);

		// 	// Particle System Main
		// 	if (MainLabel != null)
		// 	{
		// 		RemoveTextField(MainLabel);
		// 	}

		// 	if (IsPlaying != null)
		// 	{
		// 		RemoveToggle(IsPlaying);
		// 		DeregisterBool(IsPlaying);
		// 	}

		// 	if (IsLooping != null)
		// 	{
		// 		RemoveToggle(IsLooping);
		// 		DeregisterBool(IsLooping);
		// 	}

		// 	if (Prewarm != null)
		// 	{
		// 		RemoveToggle(Prewarm);
		// 		DeregisterBool(Prewarm);
		// 	}

		// 	if (Duration != null)
		// 	{
		// 		RemoveSlider(Duration);
		// 		DeregisterFloat(Duration);
		// 	}

		// 	if (StartDelay != null)
		// 	{
		// 		RemoveSlider(StartDelay);
		// 		DeregisterFloat(StartDelay);
		// 	}

		// 	if (StartDelayMultiplier != null)
		// 	{
		// 		RemoveSlider(StartDelayMultiplier);
		// 		DeregisterFloat(StartDelayMultiplier);
		// 	}

		// 	if (StartLifetime != null)
		// 	{
		// 		RemoveSlider(StartLifetime);
		// 		DeregisterFloat(StartLifetime);
		// 	}

		// 	if (StartLifetimeMultiplier != null)
		// 	{
		// 		RemoveSlider(StartLifetimeMultiplier);
		// 		DeregisterFloat(StartLifetimeMultiplier);
		// 	}

		// 	if (StartSpeed != null)
		// 	{
		// 		RemoveSlider(StartSpeed);
		// 		DeregisterFloat(StartSpeed);
		// 	}

		// 	if (StartSpeedMultiplier != null)
		// 	{
		// 		RemoveSlider(StartSpeedMultiplier);
		// 		DeregisterFloat(StartSpeedMultiplier);
		// 	}

		// 	if (StartSize != null)
		// 	{
		// 		RemoveSlider(StartSize);
		// 		DeregisterFloat(StartSize);
		// 	}

		// 	// Particle System Renderer
		// 	RemoveButton(SelectParticleImageButton);
		// }

		// private void BuildUI()
		// {
		// 	ClearUI();

		// 	// Add Particle System Button
		// 	AddParticleSystemButton = CreateButton("Add Particle System");
		// 	AddParticleSystemButton.button.onClick.AddListener(() =>
		// 	{
		// 		StartCoroutine(CreateAtomCoroutine());
		// 	});

		// 	// Find Particle Systems Button
		// 	FindParticleSystemsButton = CreateButton("Find Particle Systems");
		// 	FindParticleSystemsButton.button.onClick.AddListener(() =>
		// 	{
		// 		FindParticleSystems();
		// 		BuildUI();
		// 	});

		// 	// Particle System Chooser
		// 	ParticleSystemChooser = new JSONStorableStringChooser
		// 	(
		// 		"ParticleSystemChooser",
		// 		_particleSystems,
		// 		_currentAtom ? _currentAtom.uid : null,
		// 		"Particle Systems",
		// 		(selectedParticleSystemUid) =>
		// 		{
		// 			SetCurrentAtom(selectedParticleSystemUid);
		// 			FindParticleSystems();
		// 			BuildUI();
		// 		}
		// 	);

		// 	CreatePopup(ParticleSystemChooser);
		// 	RegisterStringChooser(ParticleSystemChooser);

		// 	// Select Particle System Atom Button
		// 	SelectParticleSystemAtomButton = CreateButton("Select Particle System Atom");
		// 	SelectParticleSystemAtomButton.button.onClick.AddListener(() =>
		// 	{
		// 		if (_currentAtom != null)
		// 		{
		// 			SuperController.singleton.SelectController(_currentAtom.uid, "control");
		// 		}
		// 	});

		// 	// Remove Particle System Button
		// 	RemoveSelectedParticleSystemButton = CreateButton("Remove Selected Particle System");
		// 	RemoveSelectedParticleSystemButton.button.onClick.AddListener(() =>
		// 	{
		// 		StartCoroutine(RemoveAtomCoroutine(_currentAtom.uid));
		// 	});

		// 	// Main Label
		// 	MainLabel = CreateLabel("mainLabel", "Main", true);

		// 	// Is Playing Toggle
		// 	var isPlayingDefaultValue = true;
		// 	IsPlaying = new JSONStorableBool
		// 	(
		// 		"Is Playing",
		// 		isPlayingDefaultValue,
		// 		(isPlaying) =>
		// 		{
		// 			if (_currentParticleSystem)
		// 			{
		// 				if (isPlaying)
		// 				{
		// 					_currentParticleSystem.Play();
		// 				}
		// 				else
		// 				{
		// 					_currentParticleSystem.Stop();
		// 				}
		// 			}
		// 		}
		// 	);
		// 	IsPlaying.SetVal(_currentParticleSystem ? _currentParticleSystem.isPlaying : isPlayingDefaultValue);

		// 	CreateToggle(IsPlaying, true);
		// 	RegisterBool(IsPlaying);

		// 	// Is Looping Toggle
		// 	var isLoopingDefaultValue = true;
		// 	IsLooping = new JSONStorableBool
		// 	(
		// 		"Is Looping",
		// 		isLoopingDefaultValue,
		// 		(isLooping) =>
		// 		{
		// 			if (_currentParticleSystem)
		// 			{
		// 				var main = _currentParticleSystem.main;
		// 				main.loop = isLooping;
		// 			}
		// 		}
		// 	);
		// 	IsLooping.SetVal(_currentParticleSystem ? _currentParticleSystem.main.loop : isLoopingDefaultValue);

		// 	CreateToggle(IsLooping, true);
		// 	RegisterBool(IsLooping);

		// 	// Prewarm
		// 	var prewarmDefaultValue = false;
		// 	Prewarm = new JSONStorableBool
		// 	(
		// 		"Prewarm",
		// 		prewarmDefaultValue,
		// 		(prewarm) =>
		// 		{
		// 			if (_currentParticleSystem)
		// 			{
		// 				var main = _currentParticleSystem.main;
		// 				main.prewarm = prewarm;
		// 			}
		// 		}
		// 	);
		// 	Prewarm.SetVal(_currentParticleSystem ? _currentParticleSystem.main.prewarm : prewarmDefaultValue);

		// 	CreateToggle(Prewarm, true);
		// 	RegisterBool(Prewarm);

		// 	// Duration Slider
		// 	var durationDefaultValue = 5.0f;
		// 	Duration = new JSONStorableFloat
		// 	(
		// 		"Duration",
		// 		durationDefaultValue,
		// 		(duration) =>
		// 		{
		// 			if (_currentParticleSystem)
		// 			{
		// 				var main = _currentParticleSystem.main;

		// 				if (_currentParticleSystem.isPlaying)
		// 				{
		// 					_currentParticleSystem.Stop();
		// 					main.duration = duration;
		// 					_currentParticleSystem.Play();
		// 				}
		// 				else
		// 				{
		// 					main.duration = duration;
		// 				}
		// 			}
		// 		},
		// 		0f,
		// 		60.0f
		// 	);
		// 	Duration.SetVal(_currentParticleSystem ? _currentParticleSystem.main.duration : durationDefaultValue);

		// 	CreateSlider(Duration, true);
		// 	RegisterFloat(Duration);

		// 	// Start Delay Slider - MinMaxCurve
		// 	var startDelayDefaultValue = 0f;
		// 	StartDelay = new JSONStorableFloat
		// 	(
		// 		"Start Delay",
		// 		startDelayDefaultValue,
		// 		(startDelay) =>
		// 		{
		// 			if (_currentParticleSystem)
		// 			{
		// 				var main = _currentParticleSystem.main;
		// 				main.startDelay = startDelay;
		// 			}
		// 		},
		// 		0f,
		// 		60.0f
		// 	);
		// 	StartDelay.SetVal(_currentParticleSystem ? _currentParticleSystem.main.startDelay.constant : startDelayDefaultValue);

		// 	CreateSlider(StartDelay, true);
		// 	RegisterFloat(StartDelay);

		// 	// Start Delay Multiplier Slider
		// 	var startDelayMultiplierDefaultValue = 0.0f;
		// 	StartDelayMultiplier = new JSONStorableFloat
		// 	(
		// 		"Start Delay Multiplier",
		// 		startDelayMultiplierDefaultValue,
		// 		(startDelayMultiplier) =>
		// 		{
		// 			if (_currentParticleSystem)
		// 			{
		// 				var main = _currentParticleSystem.main;
		// 				main.startDelayMultiplier = startDelayMultiplier;
		// 			}
		// 		},
		// 		0f,
		// 		100.0f
		// 	);
		// 	StartDelayMultiplier.SetVal(_currentParticleSystem ? _currentParticleSystem.main.startDelayMultiplier : startDelayMultiplierDefaultValue);

		// 	CreateSlider(StartDelayMultiplier, true);
		// 	RegisterFloat(StartDelayMultiplier);

		// 	// Start Lifetime Slider - MinMaxCurve
		// 	var startLifetimeDefaultValue = 5.0f;
		// 	StartLifetime = new JSONStorableFloat
		// 	(
		// 		"Start Lifetime",
		// 		startLifetimeDefaultValue,
		// 		(startLifetime) =>
		// 		{
		// 			if (_currentParticleSystem)
		// 			{
		// 				var main = _currentParticleSystem.main;
		// 				main.startLifetime = startLifetime;
		// 			}
		// 		},
		// 		0f,
		// 		60.0f
		// 	);
		// 	StartLifetime.SetVal(_currentParticleSystem ? _currentParticleSystem.main.startLifetime.constant : startLifetimeDefaultValue);

		// 	CreateSlider(StartLifetime, true);
		// 	RegisterFloat(StartLifetime);

		// 	// Start Lifetime Multiplier Slider
		// 	var startLifetimeMultiplierDefaultValue = 5.0f;
		// 	StartLifetimeMultiplier = new JSONStorableFloat
		// 	(
		// 		"Start Lifetime Multiplier",
		// 		startLifetimeMultiplierDefaultValue,
		// 		(startLifetimeMultiplier) =>
		// 		{
		// 			if (_currentParticleSystem)
		// 			{
		// 				var main = _currentParticleSystem.main;
		// 				main.startLifetimeMultiplier = startLifetimeMultiplier;
		// 			}
		// 		},
		// 		0f,
		// 		100.0f
		// 	);
		// 	StartLifetimeMultiplier.SetVal(_currentParticleSystem ? _currentParticleSystem.main.startLifetimeMultiplier : startLifetimeMultiplierDefaultValue);

		// 	CreateSlider(StartLifetimeMultiplier, true);
		// 	RegisterFloat(StartLifetimeMultiplier);

		// 	// Start Speed Slider - MinMaxCurve
		// 	var startSpeedDefaultValue = 5.0f;
		// 	StartSpeed = new JSONStorableFloat
		// 	(
		// 		"Start Speed",
		// 		startSpeedDefaultValue,
		// 		(startSpeed) =>
		// 		{
		// 			if (_currentParticleSystem)
		// 			{
		// 				var main = _currentParticleSystem.main;
		// 				main.startSpeed = startSpeed;
		// 			}
		// 		},
		// 		0f,
		// 		60.0f
		// 	);
		// 	StartSpeed.SetVal(_currentParticleSystem ? _currentParticleSystem.main.startSpeed.constant : startSpeedDefaultValue);

		// 	CreateSlider(StartSpeed, true);
		// 	RegisterFloat(StartSpeed);

		// 	// Start Speed Multiplier Slider
		// 	var startSpeedMultiplierDefaultValue = 5.0f;
		// 	StartSpeedMultiplier = new JSONStorableFloat
		// 	(
		// 		"Start Speed Multiplier",
		// 		startSpeedMultiplierDefaultValue,
		// 		(startSpeedMultiplier) =>
		// 		{
		// 			if (_currentParticleSystem)
		// 			{
		// 				var main = _currentParticleSystem.main;
		// 				main.startSpeedMultiplier = startSpeedMultiplier;
		// 			}
		// 		},
		// 		0f,
		// 		100.0f
		// 	);
		// 	StartSpeedMultiplier.SetVal(_currentParticleSystem ? _currentParticleSystem.main.startSpeedMultiplier : startSpeedMultiplierDefaultValue);

		// 	CreateSlider(StartSpeedMultiplier, true);
		// 	RegisterFloat(StartSpeedMultiplier);

		// 	// Start Size Slider
		// 	var startSizeDefaultValue = 1.0f;
		// 	StartSize = new JSONStorableFloat
		// 	(
		// 		"Start Size",
		// 		startSizeDefaultValue,
		// 		(startSize) =>
		// 		{
		// 			if (_currentParticleSystem)
		// 			{
		// 				var main = _currentParticleSystem.main;
		// 				main.startSize = startSize;
		// 			}
		// 		},
		// 		0f,
		// 		10.0f
		// 	);
		// 	StartSize.SetVal(_currentParticleSystem ? _currentParticleSystem.startSize : startSizeDefaultValue);

		// 	CreateSlider(StartSize, true);
		// 	RegisterFloat(StartSize);

		// 	// Select Particle Image Buttom
		// 	SelectParticleImageButton = CreateButton("Select Particle Image", true);
		// 	SelectParticleImageButton.button.onClick.AddListener(() =>
		// 	{
		// 		if (_lastAccessedDirectoryPath == string.Empty)
		// 		{
		// 			_lastAccessedDirectoryPath = Constants.DefaultShaderTextureFolderPath;
		// 		}

		// 		SuperController.singleton.GetMediaPathDialog
		// 		(
		// 			(string path) =>
		// 			{
		// 				if (!string.IsNullOrEmpty(path))
		// 				{
		// 					_currentParticleSystemRenderer.material = GetMaterial(Constants.ShaderName_ParticlesAdditive, path);
		// 				}
		// 			},
		// 			filter: "png|jpg|jpeg",
		// 			suggestedFolder: _lastAccessedDirectoryPath,
		// 			fullComputerBrowse: true,
		// 			showDirs: true,
		// 			showKeepOpt: true,
		// 			fileRemovePrefix: null,
		// 			hideExtenstion: false,
		// 			shortCuts: new List<ShortCut>(),
		// 			browseVarFilesAsDirectories: true,
		// 			showInstallFolderInDirectoryList: false
		// 		);

		// 	});
		// }

		// private JSONStorableString CreateLabel(string id, string text, bool isRightSide = false)
		// {
		// 	var jsonStorableString = new JSONStorableString(id, text);
		// 	var uiDynamic = CreateTextField(jsonStorableString, isRightSide);
		// 	uiDynamic.height = 12;
		// 	uiDynamic.backgroundColor = Color.clear;
		// 	uiDynamic.textColor = Color.black;
		// 	uiDynamic.UItext.fontSize = 36;
		// 	uiDynamic.UItext.alignment = TextAnchor.LowerCenter;

		// 	var layoutElement = uiDynamic.GetComponent<LayoutElement>();
		// 	layoutElement.minHeight = 0f;
		// 	layoutElement.preferredHeight = 42f;

		// 	return jsonStorableString;
		// }

		#endregion

		// #region Shaders/Textures

		// private Material GetMaterial(string shaderName, string texturePath)
		// {
		// 	Texture2D texture2D = TextureLoader.LoadTexture(texturePath);

		// 	var material = new Material(Shader.Find(shaderName));
		// 	material.mainTexture = (Texture)texture2D;

		// 	return material;
		// }

		// #endregion

		#region Utility

		// private void LogDebug(string message)
		// {
		// 	SuperController.LogMessage(message);
		// }

		// private void LogError(string message)
		// {
		// 	SuperController.LogError(message);
		// }

		// // Macgruber PostMagic
		// // Get directory path where the plugin is located. Based on Alazi's & VAMDeluxe's method.
		// public static string GetPluginPath(MVRScript self)
		// {
		// 	var id = self.name.Substring(0, self.name.IndexOf('_'));
		// 	var filename = self.manager.GetJSON()["plugins"][id].Value;

		// 	return filename.Substring(0, filename.LastIndexOfAny(new char[] { '/', '\\' }));
		// }

		// // Macgruber PostMagic
		// // Get path prefix of the package that contains our plugin.
		// public static string GetPackagePath(MVRScript self)
		// {
		// 	var filename = GetPluginPath(self);
		// 	var index = filename.IndexOf(":/");

		// 	return index >= 0 ? filename.Substring(0, index + 2) : string.Empty;
		// }

		// /// <summary>
		// /// Get the atom before the specified one in the list 
		// /// Circular - if the first atom in list is specified, this will return the last atom in the list
		// /// </summary>
		// private Atom GetAtomBefore(Atom atom)
		// {
		// 	return _sceneParticleSystemAtoms
		// 	.TakeWhile(x => x.UidAsInt() != atom.UidAsInt())
		// 	.DefaultIfEmpty(_sceneParticleSystemAtoms.Any() ? _sceneParticleSystemAtoms[_sceneParticleSystemAtoms.Count - 1] : null)
		// 	.LastOrDefault();
		// }

		// /// <summary>
		// /// Get the atom after the specified one in the list 
		// /// Circular - if the last atom in list is specified, this will return the first atom in the list
		// /// </summary>
		// private Atom GetAtomAfter(Atom atom)
		// {
		// 	return _sceneParticleSystemAtoms
		// 	.SkipWhile(x => x.UidAsInt() != atom.UidAsInt())
		// 	.Skip(1)
		// 	.DefaultIfEmpty(_sceneParticleSystemAtoms.Any() ? _sceneParticleSystemAtoms[0] : null)
		// 	.FirstOrDefault();
		// }

		#endregion

	}
}