using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Collections
{
	/// <summary>Compares two objects for equivalence, ignoring the case of strings.</summary>
	// Token: 0x0200045D RID: 1117
	[ComVisible(true)]
	[Serializable]
	public class CaseInsensitiveComparer : IComparer
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.CaseInsensitiveComparer" /> class using the <see cref="P:System.Threading.Thread.CurrentCulture" /> of the current thread.</summary>
		// Token: 0x0600364D RID: 13901 RVA: 0x000D0B0E File Offset: 0x000CED0E
		public CaseInsensitiveComparer()
		{
			this.m_compareInfo = CultureInfo.CurrentCulture.CompareInfo;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.CaseInsensitiveComparer" /> class using the specified <see cref="T:System.Globalization.CultureInfo" />.</summary>
		/// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> to use for the new <see cref="T:System.Collections.CaseInsensitiveComparer" />.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="culture" /> is <see langword="null" />.</exception>
		// Token: 0x0600364E RID: 13902 RVA: 0x000D0B26 File Offset: 0x000CED26
		public CaseInsensitiveComparer(CultureInfo culture)
		{
			if (culture == null)
			{
				throw new ArgumentNullException("culture");
			}
			this.m_compareInfo = culture.CompareInfo;
		}

		/// <summary>Gets an instance of <see cref="T:System.Collections.CaseInsensitiveComparer" /> that is associated with the <see cref="P:System.Threading.Thread.CurrentCulture" /> of the current thread and that is always available.</summary>
		/// <returns>An instance of <see cref="T:System.Collections.CaseInsensitiveComparer" /> that is associated with the <see cref="P:System.Threading.Thread.CurrentCulture" /> of the current thread.</returns>
		// Token: 0x17000808 RID: 2056
		// (get) Token: 0x0600364F RID: 13903 RVA: 0x000D0B48 File Offset: 0x000CED48
		public static CaseInsensitiveComparer Default
		{
			get
			{
				return new CaseInsensitiveComparer(CultureInfo.CurrentCulture);
			}
		}

		/// <summary>Gets an instance of <see cref="T:System.Collections.CaseInsensitiveComparer" /> that is associated with <see cref="P:System.Globalization.CultureInfo.InvariantCulture" /> and that is always available.</summary>
		/// <returns>An instance of <see cref="T:System.Collections.CaseInsensitiveComparer" /> that is associated with <see cref="P:System.Globalization.CultureInfo.InvariantCulture" />.</returns>
		// Token: 0x17000809 RID: 2057
		// (get) Token: 0x06003650 RID: 13904 RVA: 0x000D0B54 File Offset: 0x000CED54
		public static CaseInsensitiveComparer DefaultInvariant
		{
			get
			{
				if (CaseInsensitiveComparer.m_InvariantCaseInsensitiveComparer == null)
				{
					CaseInsensitiveComparer.m_InvariantCaseInsensitiveComparer = new CaseInsensitiveComparer(CultureInfo.InvariantCulture);
				}
				return CaseInsensitiveComparer.m_InvariantCaseInsensitiveComparer;
			}
		}

		/// <summary>Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.</summary>
		/// <param name="a">The first object to compare.</param>
		/// <param name="b">The second object to compare.</param>
		/// <returns>A signed integer that indicates the relative values of <paramref name="a" /> and <paramref name="b" />, as shown in the following table.  
		///   Value  
		///
		///   Meaning  
		///
		///   Less than zero  
		///
		///  <paramref name="a" /> is less than <paramref name="b" />, with casing ignored.  
		///
		///   Zero  
		///
		///  <paramref name="a" /> equals <paramref name="b" />, with casing ignored.  
		///
		///   Greater than zero  
		///
		///  <paramref name="a" /> is greater than <paramref name="b" />, with casing ignored.</returns>
		/// <exception cref="T:System.ArgumentException">Neither <paramref name="a" /> nor <paramref name="b" /> implements the <see cref="T:System.IComparable" /> interface.  
		///  -or-  
		///  <paramref name="a" /> and <paramref name="b" /> are of different types.</exception>
		// Token: 0x06003651 RID: 13905 RVA: 0x000D0B78 File Offset: 0x000CED78
		public int Compare(object a, object b)
		{
			string text = a as string;
			string text2 = b as string;
			if (text != null && text2 != null)
			{
				return this.m_compareInfo.Compare(text, text2, CompareOptions.IgnoreCase);
			}
			return Comparer.Default.Compare(a, b);
		}

		// Token: 0x040017F9 RID: 6137
		private CompareInfo m_compareInfo;

		// Token: 0x040017FA RID: 6138
		private static volatile CaseInsensitiveComparer m_InvariantCaseInsensitiveComparer;
	}
}
