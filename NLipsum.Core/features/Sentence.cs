using System;
using System.Collections.Generic;
using System.Text;

namespace NLipsum.Core {

	/// <summary>
	/// A sentence that can be formatted.
	/// </summary>
	public class Sentence : TextFeature {
		#region Constructors
		/// <summary>
		/// Instantiates a medium sized sentence with Phrase formatting.
		/// </summary>
		public Sentence() : this(Sentence.Medium.MinimumValue, Sentence.Medium.MaximumValue) { }

		/// <summary>
		/// Instantiates a sentence with Phrase formatting.
		/// </summary>
		/// <param name="minWords">The minimum amount of words to be included in this sentence.</param>
		/// <param name="maxWords">The maximum amount of words to be included in this sentence.</param>
		public Sentence(uint minWords, uint maxWords)
			: this(minWords, maxWords, FormatStrings.Sentence.Phrase) { }

		/// <summary>
		/// Instantiates a sentence based on the passed criteria.
		/// </summary>
		/// <param name="minWords">The minimum amount of words to be included in this sentence.</param>
		/// <param name="maxWords">The maximum amount of words to be included in this sentence.</param>
		/// <param name="formatString">The string used to format this sentence.</param>
		public Sentence(uint minWords, uint maxWords, string formatString) {
			this.FormatString = formatString;
			this.MinimumWords = minWords;
			this.MaximumWords = maxWords;
		}
		#endregion

		#region Inheritance wrappers

		/// <summary>
		/// Gets or sets the minimum amount of words in this sentence.
		/// </summary>
		public uint MinimumWords {
			get { return MinimumValue; }
			set { MinimumValue = value; }
		}

		/// <summary>
		/// Gets or sets the maximum amount of words in this sentence.
		/// </summary>
		public uint MaximumWords {
			get { return MaximumValue; }
			set { MaximumValue = value; }
		}

		#endregion


		#region Static Sentence Types
		/// <summary>
		/// Gets a Short Sentence.  (MinimumWords = 2, MaximumWords=8)
		/// </summary>
		public static Sentence Short {
			get { return new Sentence(2, 8); }
		}

		/// <summary>
		/// Gets a Medium length Sentence.  (MinimumWords = 3, MaximumWords=20)
		/// </summary>
		public static Sentence Medium {
			get { return new Sentence(3, 20); }
		}

		/// <summary>
		/// Gets a Long Sentence.  (MinimumWords = 6, MaximumWords=40)
		/// </summary>
		public static Sentence Long {
			get { return new Sentence(6, 40); }
		}
		#endregion



	}

}
