using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using NLipsum.Properties;
using System.Collections;
using System.Text.RegularExpressions;

namespace NLipsum {
	public static class LipsumUtilities {

		/// <summary>
		/// Creates an XmlDocument from a string.
		/// </summary>
		/// <param name="rawXml">The Xml from which to load the XmlDocument</param>
		/// <returns></returns>
		public static XmlDocument LoadXmlDocument(string rawXml) {
			XmlDocument document = new XmlDocument();
			document.LoadXml(rawXml);
			return document;
		}

		
		/// <summary>
		/// Reads raw Xml and grabs the &lt;text&gt; node's inner text.
		/// </summary>
		/// <param name="rawXml">The Xml to be parsed.  
		/// It should follow the lipsum.dtd but really all it needs 
		/// a text node as a child of the document element. 
		/// (&lt;root&gt;&lt;text&gt;your lipsum text&lt;/text&gt;&lt;/root&gt;
		/// </param>
		/// <returns></returns>
		public static StringBuilder GetTextFromRawXml(string rawXml) {
			StringBuilder text = new StringBuilder();
			XmlDocument data = LipsumUtilities.LoadXmlDocument(rawXml);
			XmlNode textNode = data.DocumentElement.SelectSingleNode("text");
			if (textNode != null) {
				text.Append(textNode.InnerText);
			}

			return text;
		}

		#region Random
		/* Is this the best way to do this?
		 * It seems smelly to have a static member 
		 * for randoms.	
		 */
		private static Random rand = new Random();

		/// <summary>
		/// Get a random integer.
		/// </summary>
		/// <param name="min">The minimum value.</param>
		/// <param name="max">The maximum value.</param>
		/// <returns></returns>
		public static int RandomInt(int min, int max) {
			int i = rand.Next(min, max);
			return i;
		}

		/// <summary>
		/// Gets a random element from a string array.
		/// </summary>
		/// <param name="source">The array from which to retrieve a random element.</param>
		/// <returns></returns>
		public static string RandomElement(string[] source) {
			return source[RandomInt(0, source.Length - 1)];
		}

		#endregion

		/// <summary>
		/// Removes empty elements from an array.
		/// </summary>
		/// <param name="source">The array from which to remove empty items.</param>
		/// <returns></returns>
		public static string[] RemoveEmptyElements(string[] source) {
			ArrayList results = new ArrayList();
			int length = source.Length;
			
			for (int i = 0; i < length; i++) {
				if (source[i] != null && source[i].Trim().Length > 0) {
					results.Add(source[i]);
				}
			}

			return (string[])results.ToArray(typeof(string));
			
		}
	}
}