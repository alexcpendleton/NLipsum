using System;
using System.Collections.Generic;
using System.Text;

namespace NLipsum {
	/// <summary>
	/// Common formatting strings.
	/// </summary>
	public static class FormatStrings {
		/// <summary>
		/// Formatting strings for Paragraphs.
		/// </summary>
		public static class Paragraph {
			/// <summary>
			/// An Html paragraph.  "&lt;p&gt;Lorem ipsum dolor sit amet&lt;/p&gt;"
			/// </summary>
			public static string Html {
				get { return "<p>{0}</p>"; }
			}

			/// <summary>
			/// A block of text ending with a new line and/or carriage return (based on Environment).
			/// </summary>
			public static string LineBreaks {
				get { return "{0}" + Environment.NewLine; }
			}
		}

		/// <summary>
		/// Formatting strings for Sentences.
		/// </summary>
		public static class Sentence {
			/// <summary>
			/// A typical sentence ending with a period/full stop.  "Lorem ipsum dolor sit amet."
			/// </summary>
			public static string Phrase {
				get { return "{0}."; }
			}

			/// <summary>
			/// A sentence ending with a question mark..  "Lorem ipsum dolor sit amet?"
			/// </summary>
			public static string Question {
				get { return "{0}?"; }
			}

			/// <summary>
			/// An sentence ending with an exclamation point/mark.  "Lorem ipsum dolor sit amet!"
			/// </summary>
			public static string Exclamation {
				get { return "{0}!"; }
			}
		}

		/// <summary>
		/// A string with no formatting.
		/// </summary>
		public static string Unformatted {
			get { return "{0}"; }
		}
	}
}
