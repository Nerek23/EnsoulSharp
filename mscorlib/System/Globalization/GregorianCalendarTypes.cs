using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	/// <summary>Defines the different language versions of the Gregorian calendar.</summary>
	// Token: 0x02000391 RID: 913
	[ComVisible(true)]
	[Serializable]
	public enum GregorianCalendarTypes
	{
		/// <summary>Refers to the localized version of the Gregorian calendar, based on the language of the <see cref="T:System.Globalization.CultureInfo" /> that uses the <see cref="T:System.Globalization.DateTimeFormatInfo" />.</summary>
		// Token: 0x04001373 RID: 4979
		Localized = 1,
		/// <summary>Refers to the U.S. English version of the Gregorian calendar.</summary>
		// Token: 0x04001374 RID: 4980
		USEnglish,
		/// <summary>Refers to the Middle East French version of the Gregorian calendar.</summary>
		// Token: 0x04001375 RID: 4981
		MiddleEastFrench = 9,
		/// <summary>Refers to the Arabic version of the Gregorian calendar.</summary>
		// Token: 0x04001376 RID: 4982
		Arabic,
		/// <summary>Refers to the transliterated English version of the Gregorian calendar.</summary>
		// Token: 0x04001377 RID: 4983
		TransliteratedEnglish,
		/// <summary>Refers to the transliterated French version of the Gregorian calendar.</summary>
		// Token: 0x04001378 RID: 4984
		TransliteratedFrench
	}
}
