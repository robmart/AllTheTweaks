using System.Collections.Generic;
using HugsLib.Settings;
using UnityEngine;
using Verse;

namespace AllTheTweaks.Settings {
	public class SettingsCategory {
		public static List<SettingsCategory> Categories = new List<SettingsCategory>();
		
		private SettingHandle<bool> _categorySetting;
		private List<SettingHandle> _containedSettings = new List<SettingHandle>();

		public string Name => _categorySetting.Name;
		public bool Value {
			get => _categorySetting;
			set => _categorySetting.Value = value;
		}

		public SettingsCategory(string name, ModSettingsPack settings) {
			_categorySetting = settings.GetHandle(name, (name + "_title").Translate(), (name + "_desc").Translate(), true);
			_categorySetting.CustomDrawerFullWidth = CustomDrawerFullWidth;
			Categories.Add(this);
		}

		/// <summary>
		/// Most of this code was taken from HugsLib
		/// </summary>
		/// <param name="rect"></param>
		/// <returns></returns>
		private bool CustomDrawerFullWidth(Rect rect) {
			Widgets.Label(rect, _categorySetting.Title);
			return false;
		}

		public void Add(SettingHandle setting) {
			_containedSettings.Add(setting);
		}
	}
}