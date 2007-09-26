using System;
using System.Collections.Generic;
using System.Text;

namespace NLipsum {
	/// <summary>
	/// A Paragraph that can be formatted..
	/// </summary>
	public class Paragraph : TextFeature {
		private Sentence _sentenceOptions = Sentence.Medium;

		#region Constructors
		/// <summary>
		/// Intiates a medium sized paragraph with no formatting.
		/// </summary>
		public Paragraph() : this(3, 20) { }

		/// <summary>
		/// Instantiates a paragraph with no formatting.
		/// </summary>
		/// <param name="minSentences">The minimum amount of sentences to be included in this paragraph.</param>
		/// <param name="maxSentences">The maximum amount of sentences to be included in this paragraph.</param>
		public Paragraph(uint minSentences, uint maxSentences) 
			: this(minSentences, maxSentences, FormatStrings.Unformatted) { }

		public Paragraph(uint minSentences, uint maxSentences, string formatString) {
			this.MinimumSentences = minSentences;
			this.MaximumSentences = maxSentences;
			this.FormatString = formatString;
		}
		#endregion

		#region Inheritance wrappers

		/// <summary>
		/// Gets or sets the minimum amount of sentences in this paragraph.
		/// </summary>
		public uint MinimumSentences {
			get { return MinimumValue; }
			set { MinimumValue = value; }
		}

		/// <summary>
		/// Gets or sets the maximum amount of words in this paragraph.
		/// </summary>
		public uint MaximumSentences {
			get { return MaximumValue; }
			set { MaximumValue = value; }
		}

		#endregion

		#region Static Sentence Types
		/// <summary>
		/// Gets a Short Paragraph.  (MinimumSentences = 2, MaximumSentences=8)
		/// </summary>
		public static Paragraph Short {
			get { return new Paragraph(2, 8); }
		}

		/// <summary>
		/// Gets a Medium length Paragraph.  (MinimumSentences = 3, MaximumSentences=20)
		/// </summary>
		public static Paragraph Medium {
			get { return new Paragraph(3, 20); }
		}

		/// <summary>
		/// Gets a Long Paragraph.  (MinimumSentences = 6, MaximumSentences=40)
		/// </summary>
		public static Paragraph Long {
			get { return new Paragraph(6, 40); }
		}
		#endregion

		/// <summary>
		/// Gets or sets the options for the sentences in this paragraph.  Default is Sentence.Medium
		/// </summary>
		public Sentence SentenceOptions {
			get { return _sentenceOptions; }
			set { _sentenceOptions = value; }
		}
	}
}
