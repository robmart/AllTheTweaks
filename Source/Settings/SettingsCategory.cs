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
		
		private bool CustomDrawerFullWidth(Rect rect) {
			Widgets.Label(rect, _categorySetting.Title);
			if (Widgets.ButtonText(
				new Rect(new Vector2(rect.width - 53, rect.position.y - 1), new Vector2(56 - 2, rect.height + 3)),
				Value ? "ATT_Open".Translate() : "ATT_Close".Translate())) Value = !Value;
			return false;
		}

		public void Add(SettingHandle setting) {
			_containedSettings.Add(setting);
		}
	}
}