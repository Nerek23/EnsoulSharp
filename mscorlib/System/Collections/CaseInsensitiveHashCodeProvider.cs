using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Collections
{
	/// <summary>Supplies a hash code for an object, using a hashing algorithm that ignores the case of strings.</summary>
	// Token: 0x0200045E RID: 1118
	[Obsolete("Please use StringComparer instead.")]
	[ComVisible(true)]
	[Serializable]
	public class CaseInsensitiveHashCodeProvider : IHashCodeProvider
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.CaseInsensitiveHashCodeProvider" /> class using the <see cref="P:System.Threading.Thread.CurrentCulture" /> of the current thread.</summary>
		// Token: 0x06003652 RID: 13906 RVA: 0x000D0BB4 File Offset: 0x000CEDB4
		public CaseInsensitiveHashCodeProvider()
		{
			this.m_text = CultureInfo.CurrentCulture.TextInfo;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.CaseInsensitiveHashCodeProvider" /> class using the specified <see cref="T:System.Globalization.CultureInfo" />.</summary>
		/// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> to use for the new <see cref="T:System.Collections.CaseInsensitiveHashCodeProvider" />.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="culture" /> is <see langword="null" />.</exception>
		// Token: 0x06003653 RID: 13907 RVA: 0x000D0BCC File Offset: 0x000CEDCC
		public CaseInsensitiveHashCodeProvider(CultureInfo culture)
		{
			if (culture == null)
			{
				throw new ArgumentNullException("culture");
			}
			this.m_text = culture.TextInfo;
		}

		/// <summary>Gets an instance of <see cref="T:System.Collections.CaseInsensitiveHashCodeProvider" /> that is associated with the <see cref="P:System.Threading.Thread.CurrentCulture" /> of the current thread and that is always available.</summary>
		/// <returns>An instance of <see cref="T:System.Collections.CaseInsensitiveHashCodeProvider" /> that is associated with the <see cref="P:System.Threading.Thread.CurrentCulture" /> of the current thread.</returns>
		// Token: 0x1700080A RID: 2058
		// (get) Token: 0x06003654 RID: 13908 RVA: 0x000D0BEE File Offset: 0x000CEDEE
		public static CaseInsensitiveHashCodeProvider Default
		{
			get
			{
				return new CaseInsensitiveHashCodeProvider(CultureInfo.CurrentCulture);
			}
		}

		/// <summary>Gets an instance of <see cref="T:System.Collections.CaseInsensitiveHashCodeProvider" /> that is associated with <see cref="P:System.Globalization.CultureInfo.InvariantCulture" /> and that is always available.</summary>
		/// <returns>An instance of <see cref="T:System.Collections.CaseInsensitiveHashCodeProvider" /> that is associated with <see cref="P:System.Globalization.CultureInfo.InvariantCulture" />.</returns>
		// Token: 0x1700080B RID: 2059
		// (get) Token: 0x06003655 RID: 13909 RVA: 0x000D0BFA File Offset: 0x000CEDFA
		public static CaseInsensitiveHashCodeProvider DefaultInvariant
		{
			get
			{
				if (CaseInsensitiveHashCodeProvider.m_InvariantCaseInsensitiveHashCodeProvider == null)
				{
					CaseInsensitiveHashCodeProvider.m_InvariantCaseInsensitiveHashCodeProvider = new CaseInsensitiveHashCodeProvider(CultureInfo.InvariantCulture);
				}
				return CaseInsensitiveHashCodeProvider.m_InvariantCaseInsensitiveHashCodeProvider;
			}
		}

		/// <summary>Returns a hash code for the given object, using a hashing algorithm that ignores the case of strings.</summary>
		/// <param name="obj">The <see cref="T:System.Object" /> for which a hash code is to be returned.</param>
		/// <returns>A hash code for the given object, using a hashing algorithm that ignores the case of strings.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="obj" /> is <see langword="null" />.</exception>
		// Token: 0x06003656 RID: 13910 RVA: 0x000D0C20 File Offset: 0x000CEE20
		public int GetHashCode(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			string text = obj as string;
			if (text == null)
			{
				return obj.GetHashCode();
			}
			return this.m_text.GetCaseInsensitiveHashCode(text);
		}

		// Token: 0x040017FB RID: 6139
		private TextInfo m_text;

		// Token: 0x040017FC RID: 6140
		private static volatile CaseInsensitiveHashCodeProvider m_InvariantCaseInsensitiveHashCodeProvider;
	}
}
