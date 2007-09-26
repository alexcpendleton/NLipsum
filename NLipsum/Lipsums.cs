using System;
using System.Collections.Generic;
using System.Text;
using NLipsum.Properties;

namespace NLipsum {
	/// <summary>
	/// All of these Lipsums are derived from the files at http://lipsum.sourceforge.net/
	/// </summary>
	public static class Lipsums {
		public static string ChildHarold {
			get { return LipsumUtilities.GetTextFromRawXml(Resources.ChildHarold).ToString(); }
		}

		public static string Decameron {
			get { return LipsumUtilities.GetTextFromRawXml(Resources.Decameron).ToString(); }
		}

		public static string Faust {
			get { return LipsumUtilities.GetTextFromRawXml(Resources.Faust).ToString(); }
		}

		public static string InDerFremde {
			get { return LipsumUtilities.GetTextFromRawXml(Resources.InDerFremde).ToString(); }
		}

		public static string LeBateauIvre {
			get { return LipsumUtilities.GetTextFromRawXml(Resources.LeBateauIvre).ToString(); }
		}

		public static string LeMasque {
			get { return LipsumUtilities.GetTextFromRawXml(Resources.LeMasque).ToString(); }
		}

		public static string LoremIpsum {
			get { return LipsumUtilities.GetTextFromRawXml(Resources.LoremIpsum).ToString(); }
		}

		public static string NagyonFaj {
			get { return LipsumUtilities.GetTextFromRawXml(Resources.NagyonFaj).ToString(); }
		}

		public static string Omagyar {
			get { return LipsumUtilities.GetTextFromRawXml(Resources.Omagyar).ToString(); }
		}

		public static string RobinsonoKruso {
			get { return LipsumUtilities.GetTextFromRawXml(Resources.RobinsonoKruso).ToString(); }
		}

		public static string TheRaven {
			get { return LipsumUtilities.GetTextFromRawXml(Resources.TheRaven).ToString(); }
		}

		public static string TierrayLuna {
			get { return LipsumUtilities.GetTextFromRawXml(Resources.TierrayLuna).ToString(); }
		}
	}
}
