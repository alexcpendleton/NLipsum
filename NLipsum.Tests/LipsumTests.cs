using System;
using System.Text;
using MbUnit.Framework;
using NLipsum.Core;

namespace NLipsum.Tests {
	[TestFixture]
	public class LipsumTests {
		#region Constructor tests
		[Test]
		public void TestLoadXml() {
			string template ="<root><text>{0}</text></root>";
			string expectedText = "Lorem ipsum dolor sit amet";
			string formatted = String.Format(template, expectedText);
			
			LipsumGenerator lipsum = new LipsumGenerator(formatted, true);
			Assert.AreEqual(lipsum.LipsumText.ToString(), expectedText);
		}

		[Test]
		public void TestLoadPlainText() {
			string expectedText = "Lorem ipsum dolor sit amet";
			
			LipsumGenerator lipsum = new LipsumGenerator(expectedText, false);
			Assert.AreEqual(lipsum.LipsumText.ToString(), expectedText);
		}
		#endregion

		#region Words

		[Test]
		public void TestPrepareWords() {
			string rawText = "lorem ipsum dolor sit amet consetetur";
			string[] expectedArray = new string[] {
				"lorem", "ipsum", "dolor", "sit", "amet", "consetetur"
			};
			int wordsInRawText = 6;

			LipsumGenerator lipsum = new LipsumGenerator(rawText, false);
			string[] wordsPrepared = lipsum.PreparedWords;

			Assert.AreEqual(wordsInRawText, wordsPrepared.Length);
			CollectionAssert.AreElementsEqual(wordsPrepared, expectedArray);

		}

		[Test]
		public void TestGenerateWords() {
			string rawText = "lorem ipsum dolor sit amet consetetur";

			LipsumGenerator lipsum = new LipsumGenerator(rawText, false);

			int wordCount = 4;
			
			string[] generatedWords = lipsum.GenerateWords(wordCount);

			Assert.AreEqual(wordCount, generatedWords.Length);
			
			for (int i = 0; i < wordCount; i++) {
				Assert.Contains(rawText, generatedWords[i]);
			}
		}
		#endregion

		#region Sentences

		[Test]
		public void TestGenerateSentences() {
			string rawText = Lipsums.LoremIpsum;
			LipsumGenerator lipsum = new LipsumGenerator(rawText, false);

			int desiredSentenceCount = 5;
			string[] generatedSentences = lipsum.
				GenerateSentences(desiredSentenceCount, Sentence.Medium);

			Assert.AreEqual(desiredSentenceCount, generatedSentences.Length, 
				"Retrieved sentence count mismatch.");

			for (int i = 0; i < desiredSentenceCount; i++) {
				Assert.IsNotNull(generatedSentences[i], 
					String.Format("Generated sentence [{0}] is null.", i));
				StringAssert.IsNonEmpty(generatedSentences[i]);
			}
		}

		[Test]
		public void TestSentenceCapitalizationAndPunctuation() {
			string rawText = "this";
			LipsumGenerator lipsum = new LipsumGenerator(rawText, false);
			string[] generatedSentences = lipsum.GenerateSentences(1, new Sentence(1, 1));
			string desiredSentence = "This.";
			Assert.AreEqual(desiredSentence, generatedSentences[0]);
		}

		#endregion

		#region Paragraphs

		[Test]
		public void TestGenerateParagraphs() {
			string rawText = Lipsums.LoremIpsum;
			LipsumGenerator lipsum = new LipsumGenerator(rawText, false);

			int desiredParagraphCount = 5;
			string[] generatedParagraphs = lipsum.
				GenerateParagraphs(desiredParagraphCount, Paragraph.Medium);


			Assert.AreEqual(desiredParagraphCount, generatedParagraphs.Length,
				"Retrieved sentence count mismatch.");

			for (int i = 0; i < desiredParagraphCount; i++) {
				Assert.IsNotNull(generatedParagraphs[i],
					String.Format("Generated paragraph [{0}] is null.", i));
				StringAssert.IsNonEmpty(generatedParagraphs[i]);
			}

		}

		#endregion

		#region Characters

		[Test]
		public void TestGenerateCharacters() {
			string rawText = "lorem ipsum dolor sit amet consetetur";
			int desiredCharacterCount = 10;
			string expectedText = rawText.Substring(0, desiredCharacterCount);

			LipsumGenerator lipsum = new LipsumGenerator(rawText, false);


			string[] charsRetrieved = lipsum.GenerateCharacters(desiredCharacterCount);
			
			// This should only retrieve one string
			Assert.AreEqual(1, charsRetrieved.Length);

			string generatedString = charsRetrieved[0];
			Assert.IsNotNull(generatedString);
			Assert.IsNotEmpty(generatedString);

			Assert.AreEqual(expectedText, generatedString);			

		}
		#endregion

		#region Utilities Tests
		[Test]
		public void TestRemoveEmptyElements() {
			string[] arrayWithEmpties = new string[] {
				"", "lorem", "ipsum", null, String.Empty, "xxx"
			};

			string[] expectedArray = new string[] {
				"lorem", "ipsum", "xxx"
			};

			int expectedLength = 3;

			string[] returnedArray = LipsumUtilities.RemoveEmptyElements(arrayWithEmpties);

			CollectionAssert.DoesNotContain(returnedArray, "");
			CollectionAssert.AllItemsAreNotNull(returnedArray);
			CollectionAssert.AllItemsAreInstancesOfType(returnedArray, typeof(String));
			CollectionAssert.AreCountEqual(expectedLength, returnedArray);
			CollectionAssert.AreElementsEqual(expectedArray, returnedArray);
		}

		#endregion

		#region Static Method Tests

		[Test]
		public void TestGenerateNoParams() {
			string rawText = Lipsums.LoremIpsum;
			string generated = LipsumGenerator.Generate(1);

			// What can I test to make sure this is working properly?
			// Null and empty don't seem like valid tests.

			Assert.IsNotNull(generated);
			Assert.IsNotEmpty(generated);
		}

		[Test]
		public void TestGenerateHtmlNoParams() {
			string rawText = Lipsums.LoremIpsum;
			string generated = LipsumGenerator.GenerateHtml(1);

			// What can I test to make sure this is working properly?
			// Null and empty don't seem like valid tests.

			Assert.IsNotNull(generated);
			Assert.IsNotEmpty(generated);
			StringAssert.StartsWith(generated, "<p>");
			StringAssert.EndsWith(generated, "</p>");
		}		
		#endregion

		/*
		 * I realize there are some tests lacking
		 * Feel free to write them.
		 */
	}
}
