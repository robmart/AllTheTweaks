using System.Collections.Generic;
using System.Xml;
using Verse;

namespace AllTheTweaks.PatchOperation {
	/// <summary>
	/// A toggleable PatchOperation. This code was copied from VFECore. 
	/// </summary>
	public class ATTPatchOperationToggleable : Verse.PatchOperation {
		public bool enabled;
		public string label;
		public List<string> mods = new List<string>();
		private Verse.PatchOperation match;

		protected override bool ApplyWorker(XmlDocument xml) {
			bool flag = false;
			for (int index = 0; index < this.mods.Count; ++index) {
				if (ModLister.HasActiveModWithName(this.mods[index])) {
					flag = true;
				}
				else {
					flag = false;
					break;
				}
			}
			return !(this.enabled & flag) || this.match == null || this.match.Apply(xml);
		}
	}
}