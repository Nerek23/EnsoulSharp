using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>Represents a token that represents a string.</summary>
	// Token: 0x02000634 RID: 1588
	[ComVisible(true)]
	[Serializable]
	public struct StringToken
	{
		// Token: 0x06004C1B RID: 19483 RVA: 0x00113B78 File Offset: 0x00111D78
		internal StringToken(int str)
		{
			this.m_string = str;
		}

		/// <summary>Retrieves the metadata token for this string.</summary>
		/// <returns>Read-only. Retrieves the metadata token of this string.</returns>
		// Token: 0x17000C00 RID: 3072
		// (get) Token: 0x06004C1C RID: 19484 RVA: 0x00113B81 File Offset: 0x00111D81
		public int Token
		{
			get
			{
				return this.m_string;
			}
		}

		/// <summary>Returns the hash code for this string.</summary>
		/// <returns>The underlying string token.</returns>
		// Token: 0x06004C1D RID: 19485 RVA: 0x00113B89 File Offset: 0x00111D89
		public override int GetHashCode()
		{
			return this.m_string;
		}

		/// <summary>Checks if the given object is an instance of <see langword="StringToken" /> and is equal to this instance.</summary>
		/// <param name="obj">The object to compare with this <see langword="StringToken" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is an instance of <see langword="StringToken" /> and is equal to this object; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004C1E RID: 19486 RVA: 0x00113B91 File Offset: 0x00111D91
		public override bool Equals(object obj)
		{
			return obj is StringToken && this.Equals((StringToken)obj);
		}

		/// <summary>Indicates whether the current instance is equal to the specified <see cref="T:System.Reflection.Emit.StringToken" />.</summary>
		/// <param name="obj">The <see cref="T:System.Reflection.Emit.StringToken" /> to compare to the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if the value of <paramref name="obj" /> is equal to the value of the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004C1F RID: 19487 RVA: 0x00113BA9 File Offset: 0x00111DA9
		public bool Equals(StringToken obj)
		{
			return obj.m_string == this.m_string;
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Emit.StringToken" /> structures are equal.</summary>
		/// <param name="a">The <see cref="T:System.Reflection.Emit.StringToken" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Reflection.Emit.StringToken" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004C20 RID: 19488 RVA: 0x00113BB9 File Offset: 0x00111DB9
		public static bool operator ==(StringToken a, StringToken b)
		{
			return a.Equals(b);
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Emit.StringToken" /> structures are not equal.</summary>
		/// <param name="a">The <see cref="T:System.Reflection.Emit.StringToken" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Reflection.Emit.StringToken" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is not equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004C21 RID: 19489 RVA: 0x00113BC3 File Offset: 0x00111DC3
		public static bool operator !=(StringToken a, StringToken b)
		{
			return !(a == b);
		}

		// Token: 0x040020EC RID: 8428
		internal int m_string;
	}
}
