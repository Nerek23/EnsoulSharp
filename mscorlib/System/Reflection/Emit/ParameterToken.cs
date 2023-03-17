using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>The <see langword="ParameterToken" /> struct is an opaque representation of the token returned by the metadata to represent a parameter.</summary>
	// Token: 0x0200062F RID: 1583
	[ComVisible(true)]
	[Serializable]
	public struct ParameterToken
	{
		// Token: 0x06004BA9 RID: 19369 RVA: 0x0011251C File Offset: 0x0011071C
		internal ParameterToken(int tkParam)
		{
			this.m_tkParameter = tkParam;
		}

		/// <summary>Retrieves the metadata token for this parameter.</summary>
		/// <returns>Read-only. Retrieves the metadata token for this parameter.</returns>
		// Token: 0x17000BF2 RID: 3058
		// (get) Token: 0x06004BAA RID: 19370 RVA: 0x00112525 File Offset: 0x00110725
		public int Token
		{
			get
			{
				return this.m_tkParameter;
			}
		}

		/// <summary>Generates the hash code for this parameter.</summary>
		/// <returns>The hash code for this parameter.</returns>
		// Token: 0x06004BAB RID: 19371 RVA: 0x0011252D File Offset: 0x0011072D
		public override int GetHashCode()
		{
			return this.m_tkParameter;
		}

		/// <summary>Checks if the given object is an instance of <see langword="ParameterToken" /> and is equal to this instance.</summary>
		/// <param name="obj">The object to compare to this object.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is an instance of <see langword="ParameterToken" /> and equals the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004BAC RID: 19372 RVA: 0x00112535 File Offset: 0x00110735
		public override bool Equals(object obj)
		{
			return obj is ParameterToken && this.Equals((ParameterToken)obj);
		}

		/// <summary>Indicates whether the current instance is equal to the specified <see cref="T:System.Reflection.Emit.ParameterToken" />.</summary>
		/// <param name="obj">The <see cref="T:System.Reflection.Emit.ParameterToken" /> to compare to the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if the value of <paramref name="obj" /> is equal to the value of the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004BAD RID: 19373 RVA: 0x0011254D File Offset: 0x0011074D
		public bool Equals(ParameterToken obj)
		{
			return obj.m_tkParameter == this.m_tkParameter;
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Emit.ParameterToken" /> structures are equal.</summary>
		/// <param name="a">The <see cref="T:System.Reflection.Emit.ParameterToken" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Reflection.Emit.ParameterToken" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004BAE RID: 19374 RVA: 0x0011255D File Offset: 0x0011075D
		public static bool operator ==(ParameterToken a, ParameterToken b)
		{
			return a.Equals(b);
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Emit.ParameterToken" /> structures are not equal.</summary>
		/// <param name="a">The <see cref="T:System.Reflection.Emit.ParameterToken" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Reflection.Emit.ParameterToken" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is not equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004BAF RID: 19375 RVA: 0x00112567 File Offset: 0x00110767
		public static bool operator !=(ParameterToken a, ParameterToken b)
		{
			return !(a == b);
		}

		/// <summary>The default <see langword="ParameterToken" /> with <see cref="P:System.Reflection.Emit.ParameterToken.Token" /> value 0.</summary>
		// Token: 0x040020D4 RID: 8404
		public static readonly ParameterToken Empty;

		// Token: 0x040020D5 RID: 8405
		internal int m_tkParameter;
	}
}
