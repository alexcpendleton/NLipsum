using System;
using System.Text;
using System.Collections.Specialized;
using System.Xml;
using System.Text.RegularExpressions;
using System.Collections;

namespace NLipsum.Core {
	/// <summary>
	/// Represents a utility that generates Lipsum from a source.
	/// </summary>
	public class LipsumGenerator {
		private StringBuilder _lipsumText = null;
		private string[] _preparedWords = new string[] { };

		#region Constructors

		/// <summary>
		/// Instantiates a LipsumGenerator.
		/// </summary>
		public LipsumGenerator() { }

		/// <summary>
		/// Instantiates a LipsumGenerator with the passed data.
		/// </summary>
		/// <param name="rawData">The data to be used as LipsumText.</param>
		/// <param name="isXml">Whether the data is in an Xml format and should be parsed for the LipsumText.</param>
		public LipsumGenerator(string rawData, bool isXml) {
			/*
			 * If we're receiving an XML string we need to do some
			 * parsing to retrieve the lipsum text.
			 */
			this.LipsumText = isXml ?
				LipsumUtilities.GetTextFromRawXml(rawData) : new StringBuilder(rawData);
		}

		#endregion

		#region General/TopLevel Generators
		/// <summary>
		/// Generates 'count' medium length paragraphs separated by environment linebreaks.
		/// </summary>
		/// <param name="count">The number of paragraphs desired.</param>
		/// <returns></returns>
		public string GenerateLipsum(int count) {
			return GenerateLipsum(count, Features.Paragraphs, FormatStrings.Paragraph.LineBreaks);
		}

		/// <summary>
		/// Generates 'count' medium length paragraphs surrounded by html paragraph tags.
		/// </summary>
		/// <param name="count">The number of paragraphs desired.</param>
		/// <returns></returns>
		public string GenerateLipsumHtml(int count) {
			return GenerateLipsum(count, Features.Paragraphs, FormatStrings.Paragraph.Html);
		}

		/// <summary>
		/// Generates 'count' features.  The format string will be applied to the feature not the result.
		/// </summary>
		/// <param name="count">How many features are desired.</param>
		/// <param name="feature">The desired feature, such as Paragraph or Sentence.</param>
		/// <param name="formatString">The formatting to apply to each feature.</param>
		/// <returns></returns>
		public string GenerateLipsum(int count, Features part, string formatString) {
			StringBuilder results = new StringBuilder();
			string[] data = new string[] { };
			if (part == Features.Paragraphs) {
				data = GenerateParagraphs(count, formatString);
			} else if (part == Features.Sentences) {
				data = GenerateSentences(count, formatString);
			} else if (part == Features.Words) {
				data = GenerateWords(count);
			} else if (part == Features.Characters) {
				data = GenerateCharacters(count);
			} else {
				throw new NotImplementedException("Sorry, this is not yet implemented.");
			}

			int length = data.Length;
			for (int i = 0; i < length; i++) {
				results.Append(data[i]);
			}

			return results.ToString();
		}

		#endregion

		#region Static Generators

		/// <summary>
		/// Generates 'count' medium length paragraphs separated by environment linebreaks.
		/// Standard Lorem Ipsum text will be used.
		/// </summary>
		/// <param name="count">The number of paragraphs desired.</param>
		/// <returns></returns>
		public static string Generate(int count) {
			return Generate(count, Lipsums.LoremIpsum);
		}

		/// <summary>
		/// Generates 'count' medium length paragraphs surrounded by Html paragraph tags.
		/// Standard Lorem Ipsum text will be used.
		/// </summary>
		/// <param name="count">The number of paragraphs desired.</param>
		/// <returns></returns>
		public static string GenerateHtml(int count) {
			return Generate(count, FormatStrings.Paragraph.Html, Lipsums.LoremIpsum);
		}

		/// <summary>
		/// Generates 'count' medium length paragraphs separated by environment linebreaks.
		/// </summary>
		/// <param name="count">The number of paragraphs desired.</param>
		/// <param name="rawText">The text from which to generate the Lipsum.</param>
		/// <returns></returns>
		public static string Generate(int count, string rawText) {
			return Generate(count, FormatStrings.Paragraph.LineBreaks, rawText);
		}

		/// <summary>
		/// Generates 'count' medium length paragraphs.
		/// </summary>
		/// <param name="count">The number of paragraphs desired.</param>
		/// <param name="formatString">The string with which to format the feature.</param>
		/// <param name="rawText">The text from which to generate the Lipsum.</param>
		/// <returns></returns>
		public static string Generate(int count, string formatString, string rawText) {
			return Generate(count, Features.Paragraphs, formatString, rawText);
		}


		/// <summary>
		/// Generates 'count' features.
		/// </summary>
		/// <param name="count">The number of features desired.</param>
		/// <param name="feature">The type of feature desired.</param>
		/// <param name="formatString">The string with which to format the feature.</param>
		/// <param name="rawText">The text from which to generate the Lipsum.</param>
		/// <returns></returns>
		public static string Generate(int count, Features feature, string formatString, string rawText) {
			LipsumGenerator generator = new LipsumGenerator(rawText, false);
			return generator.GenerateLipsum(count, feature, formatString);			
		}
		#endregion

		#region Characters
		/// <summary>
		/// Generates a single string (in an array with only this as an element) 
		/// by getting the first 'count' characters from LipsumText.
		/// </summary>
		/// <param name="count"></param>
		/// <param name="formatString"></param>
		/// <returns></returns>
		public string[] GenerateCharacters(int count) {
			string[] result = new string[1];

			/* This whole method needs some thought.  
			 * Right now it just grabs 'count' amount 
			 * of characters from the beginning of the
			 * LipsumText.  It'd be nice if it could 
			 * generate sentences and then truncate them 
			 * but I can't think of an elegant way to 
			 * do that at the moment.  TODO. */

			if (count >= LipsumText.Length) {
				count = LipsumText.Length - 1;
			}
			char[] chars = LipsumText.ToString().ToCharArray(0, count);

			result[0] = new String(chars);

			return result;
		}
		#endregion

		#region Paragraphs
		/// <summary>
		/// Generates 'count' medium-sized paragraphs of lipsum text.
		/// </summary>
		/// <param name="count">The number of paragraphs desired.</param>
		public string[] GenerateParagraphs(int count) {
			return GenerateParagraphs(count, "");
		}

		/// <summary>
		/// Generates 'count' medium-sized paragraphs of lipsum text.
		/// </summary>
		/// <param name="count">The number of paragraphs desired.</param>
		/// <param name="formatString">The string used to format the paragraphs.  Will not perform formatting if null or empty.</param>
		public string[] GenerateParagraphs(int count, string formatString) {
			Paragraph options = Paragraph.Medium;
			options.FormatString = formatString;
			return GenerateParagraphs(count, options);
		}

		/// <summary>
		/// Generates 'count' paragraphs of lipsum text.
		/// </summary>
		/// <param name="count">The number of paragraphs desired.</param>
		/// <param name="options">Used to determine the minimum and maximum sentences per paragraphs, and format string if applicable.</param>
		/// <returns></returns>
		public string[] GenerateParagraphs(int count, Paragraph options) {
			/*
			 * TODO:  These generate methods could probably be 
			 * refactored into one method that takes a count 
			 * and a TextFeature. */ 
			string[] paragraphs = new string[count];
			string[] sentences = new string[] { };
			for (int i = 0; i < count; i++) {
				/* Get a random amount of sentences based on the
				 * min and max from the paragraph options */
				sentences = GenerateSentences(LipsumUtilities.
					RandomInt((int)options.GetMinimum(), (int)options.GetMaximum()));

				// Shove them all together in sentence fashion.
				string joined = String.Join(options.Delimiter, sentences);

				// Format if allowed.
				paragraphs[i] = String.IsNullOrEmpty(options.FormatString) ?
					joined : options.Format(joined);
			}

			return paragraphs;
		}

		#endregion

		#region Sentences

		/// <summary>
		/// Generates 'count' sentences of lipsum text, using a Medium length sentence.  Will not perform any formatting.
		/// </summary>
		/// <param name="count">The number of sentences desired.</param>
		public string[] GenerateSentences(int count) {
			return GenerateSentences(count, "");
		}

		/// <summary>
		/// Generates 'count' sentences of lipsum text, using a Medium length sentence.
		/// </summary>
		/// <param name="count">The number of sentences desired.</param>
		/// <param name="formatString">The string used to format the sentences.  Will not perform formatting if null or empty.</param>
		/// <returns></returns>
		public string[] GenerateSentences(int count, string formatString) {
			Sentence options = Sentence.Medium;
			options.FormatString = formatString;
			return GenerateSentences(count, options);
		}

		/// <summary>
		/// Generates 'count' sentences of lipsum text.  
		/// If options.FormatString is not null or empty that string used to format the sentences.
		/// </summary>
		/// <param name="count">The number of sentences desired.</param>
		/// <param name="options">Used to determine the minimum and maximum words per sentence, and format string if applicable.</param>
		/// <returns></returns>
		public string[] GenerateSentences(int count, Sentence options) {
			string[] sentences = new string[count];
			string[] words = new string[] { };			
			
			for (int i = 0; i < count; i++) {
				/* Get a random amount of words based on the
				 * min and max from the Sentence options */
				 words = GenerateWords(LipsumUtilities.
					 RandomInt((int)options.MinimumWords, (int)options.MaximumWords));

				// Shove them all together in sentence fashion.
				string joined = String.Join(options.Delimiter, words);

				// Format if allowed.
				sentences[i] = String.IsNullOrEmpty(options.FormatString) ?
					joined : options.Format(joined);
			}

			return sentences;
		}
		#endregion

		#region Words
		/// <summary>
		/// Generates the amount of lipsum words.
		/// </summary>
		/// <param name="count">The amount of words to generate.</param>
		/// <returns></returns>
		public string[] GenerateWords(int count) {
			string[] words = new string[count];

			for (int i = 0; i < count; i++) {
				words[i] = LipsumUtilities.RandomElement(PreparedWords);
			}

			return words;
		}


		/// <summary>
		/// Retreives all of the words in the LipsumText as an array.
		/// </summary>
		/// <returns></returns>
		public string[] PrepareWords() {
			return LipsumUtilities.RemoveEmptyElements(
				Regex.Split(this.LipsumText.ToString(), @"\s")); 
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the text used to generate lipsum.
		/// </summary>
		public StringBuilder LipsumText {
			get { return _lipsumText; }
			set { 
				_lipsumText = value; 
				PreparedWords = PrepareWords();				
			}
		}

		/// <summary>
		/// Gets the words prepared from the LipsumText.
		/// </summary>
		public string[] PreparedWords {
			get { return _preparedWords; }
			protected set { _preparedWords = value; }
		}

		#endregion

		public string RandomWord() {
			return LipsumUtilities.RandomElement(PreparedWords);
		}

	}
}
