using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Verse;

namespace AllTheTweaks.Utilities {
	
	internal class GlobalSettingsUtilities {
		/// <summary>
		/// Copied from VFECore
		/// </summary>
		/// <see cref="VFECore.GlobalSettingsUtilities"/>
		public static string PrettyXml(string xml) {
			StringBuilder output = new StringBuilder();
			using (XmlWriter writer = XmlWriter.Create(output, new XmlWriterSettings() {
				OmitXmlDeclaration = true,
				Indent = true,
				NewLineOnAttributes = false
			})) 
				XElement.Parse(xml).Save(writer); 
			return output.ToString();
		}
		
		public static Dictionary<XmlDocument, Verse.PatchOperation> GetDocumentFromModContentPack(ModContentPack modContentPack, string fileName) {
			if (modContentPack == null) {
				throw new ArgumentException("ModContentPack is null");
			}

			foreach (var patch in modContentPack.Patches) {
				if (patch == null || !patch.sourceFile.Contains(fileName)) continue;
				var xmlDocument = new XmlDocument();
				xmlDocument.Load(patch.sourceFile);
				return new Dictionary<XmlDocument, Verse.PatchOperation> {{xmlDocument, patch}};
			}

			throw new ArgumentException("No patch file by that name found");
		}
	}
}