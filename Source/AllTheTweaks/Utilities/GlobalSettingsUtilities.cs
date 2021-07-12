using System.Text;
using System.Xml;
using System.Xml.Linq;

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
	}
}