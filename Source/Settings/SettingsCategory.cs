using System.Collections.Generic;
using HugsLib.Settings;
using UnityEngine;
using Verse;

namespace AllTheTweaks.Settings {
	public class SettingsCategory { //TODO: This thing is a mess. Auto hide options if category is hidden.
		public static List<SettingsCategory> Categories = new List<SettingsCategory>();
		
		private SettingHandle<bool> _categorySetting;
		private List<SettingHandle> _containedSettings = new List<SettingHandle>();

		public string Name => _categorySetting.Name;
		public bool Value {
			get => _categorySetting;
			set => _categorySetting.Value = value;
		}

		public SettingsCategory(string name, ModSettingsPack settings) {
			_categorySetting = settings.GetHandle(name, (name + "_title").Translate(), (name + "_desc").Translate(), false);
			_categorySetting.CustomDrawerFullWidth = CustomDrawerFullWidth;
			_categorySetting.Unsaved = true;
			Categories.Add(this);
			_categorySetting.DisplayOrder = Categories.Count;
		}
		
		private bool CustomDrawerFullWidth(Rect rect) {
			Widgets.Label(rect, _categorySetting.Title);
			if (Widgets.ButtonText(
				new Rect(new Vector2(rect.width - 53, rect.position.y - 1), new Vector2(56 - 2, rect.height + 3)),
				Value ? "ATT_Close".Translate() : "ATT_Open".Translate())) Value = !Value;
			var color = GUI.color;
			GUI.color = new Color(0.3f, 0.3f, 0.3f);;
			Widgets.DrawLineHorizontal(2f, rect.position.y + rect.height + 2, rect.width - 2);
			if (Value) {
				var totalheight = 0f;
				var normalcount = 1;
				foreach (var setting in _containedSettings) {
					if (setting.CustomDrawerHeight > 0)
						totalheight += setting.CustomDrawerHeight;
					else 
						normalcount++;
				}
				Widgets.DrawLineHorizontal(
					2f,
					rect.position.y + rect.ExpandedBy(2.85f).height * normalcount + totalheight,
					rect.width - 2
				);
			}

			GUI.color = color;
			return false;
		}

		public void Add(SettingHandle setting) {
			_containedSettings.Add(setting);
			setting.DisplayOrder = _categorySetting.DisplayOrder;
		}
	}
}