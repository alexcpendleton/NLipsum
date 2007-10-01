using System;
using System.Collections.Generic;
using System.Text;

namespace NLipsum.Core {
	public class Word : TextFeature {
		#region Constructors
		/// <summary>
		/// Instantiates a medium sized sentence with Phrase formatting.
		/// </summary>
		public Word() : this(Word.Medium.MinimumValue, Word.Medium.MaximumValue) { }

		/// <summary>
		/// Instantiates a sentence with Phrase formatting.
		/// </summary>
		/// <param name="minWords">The minimum amount of words to be included in this sentence.</param>
		/// <param name="maxWords">The maximum amount of words to be included in this sentence.</param>
		public Word(uint minWords, uint maxWords)
			: this(minWords, maxWords, FormatStrings.Unformatted) { }

		/// <summary>
		/// Instantiates a sentence based on the passed criteria.
		/// </summary>
		/// <param name="minWords">The minimum amount of words to be included in this sentence.</param>
		/// <param name="maxWords">The maximum amount of words to be included in this sentence.</param>
		/// <param name="formatString">The string used to format this sentence.</param>
		public Word(uint minWords, uint maxWords, string formatString) {
			this.FormatString = formatString;
			this.MinimumValue = minWords;
			this.MaximumValue = maxWords;
		}
		#endregion

		#region Inheritance wrappers

		/// <summary>
		/// Gets or sets the minimum amount of characters in this word.
		/// </summary>
		public uint MinimumCharacters {
			get { return MinimumValue; }
			set { MinimumValue = value; }
		}

		/// <summary>
		/// Gets or sets the maximum amount of characters in this word.
		/// </summary>
		public uint MaximumCharacters {
			get { return MaximumValue; }
			set { MaximumValue = value; }
		}

		#endregion


		#region Static Sentence Types
		/// <summary>
		/// Gets a Short Sentence.  (MinimumWords = 2, MaximumWords=8)
		/// </summary>
		public static Word Short {
			get { return new Word(1, 3); }
		}

		/// <summary>
		/// Gets a Medium length Sentence.  (MinimumWords = 3, MaximumWords=20)
		/// </summary>
		public static Word Medium {
			get { return new Word(4, 8); }
		}

		/// <summary>
		/// Gets a Long Sentence.  (MinimumWords = 6, MaximumWords=40)
		/// </summary>
		public static Word Long {
			get { return new Word(10, 25); }
		}
		#endregion
	}
}
