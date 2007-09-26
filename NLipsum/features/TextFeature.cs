using System;
using System.Collections.Generic;
using System.Text;

namespace NLipsum {
	/// <summary>
	/// Represents a part or section of text, such as a paragraph or sentence.
	/// </summary>
	public class TextFeature {
		#region Instance Variables
		private uint _minimumValue = 0;
		private uint _maximumValue = 0;
		private string _formatString = String.Empty;

		private string _delimiter = " ";
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the minimum amount of sub features in this feature.
		/// </summary>
		protected uint MinimumValue {
			get { return _minimumValue; }
			set { _minimumValue = value; }
		}

		/// <summary>
		/// Gets or sets the maximum amount of sub features in this feature.
		/// </summary>
		protected uint MaximumValue {
			get { return _maximumValue; }
			set { _maximumValue = value; }
		}

		/// <summary>
		/// Gets or sets how this feature should be rendered.  By default: "{0}." (ends with a period.)  
		/// For an html tag you could use "&lt;div&gt;{0}&lt;/div&gt;".  
		/// You get the picture.
		/// </summary>
		public string FormatString {
			get { return _formatString; }
			set { _formatString = value; }
		}

		/// <summary>
		/// Gets or sets the delimiter between the subparts.
		/// </summary>
		public string Delimiter {
			get { return _delimiter; }
			set { _delimiter = value; }
		}
		#endregion

		/// <summary>
		/// Formats this feature based on its FormatString.
		/// </summary>
		/// <param name="text">The text with which to format the string.</param>
		/// <returns></returns>
		public virtual string Format(string text) {
			return String.Format(FormatString, text);
		}

		/* This kind of smells */
		/// <summary>
		/// Gets the minimum subfeature value.
		/// </summary>
		/// <returns></returns>
		public uint GetMinimum() { return MinimumValue; }
		/// <summary>
		/// Gets the maximum subfeature value.
		/// </summary>
		/// <returns></returns>
		public uint GetMaximum() { return MaximumValue; }
	}


	public enum Features {
		Paragraphs, Sentences, Words, Characters
	}
}
