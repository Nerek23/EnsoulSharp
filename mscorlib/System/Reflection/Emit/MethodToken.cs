using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>The <see langword="MethodToken" /> struct is an object representation of a token that represents a method.</summary>
	// Token: 0x02000622 RID: 1570
	[ComVisible(true)]
	[Serializable]
	public struct MethodToken
	{
		// Token: 0x06004AE1 RID: 19169 RVA: 0x0010E740 File Offset: 0x0010C940
		internal MethodToken(int str)
		{
			this.m_method = str;
		}

		/// <summary>Returns the metadata token for this method.</summary>
		/// <returns>Read-only. Returns the metadata token for this method.</returns>
		// Token: 0x17000BD7 RID: 3031
		// (get) Token: 0x06004AE2 RID: 19170 RVA: 0x0010E749 File Offset: 0x0010C949
		public int Token
		{
			get
			{
				return this.m_method;
			}
		}

		/// <summary>Returns the generated hash code for this method.</summary>
		/// <returns>The hash code for this instance.</returns>
		// Token: 0x06004AE3 RID: 19171 RVA: 0x0010E751 File Offset: 0x0010C951
		public override int GetHashCode()
		{
			return this.m_method;
		}

		/// <summary>Tests whether the given object is equal to this <see langword="MethodToken" /> object.</summary>
		/// <param name="obj">The object to compare to this object.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is an instance of <see langword="MethodToken" /> and is equal to this object; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004AE4 RID: 19172 RVA: 0x0010E759 File Offset: 0x0010C959
		public override bool Equals(object obj)
		{
			return obj is MethodToken && this.Equals((MethodToken)obj);
		}

		/// <summary>Indicates whether the current instance is equal to the specified <see cref="T:System.Reflection.Emit.MethodToken" />.</summary>
		/// <param name="obj">The <see cref="T:System.Reflection.Emit.MethodToken" /> to compare to the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if the value of <paramref name="obj" /> is equal to the value of the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004AE5 RID: 19173 RVA: 0x0010E771 File Offset: 0x0010C971
		public bool Equals(MethodToken obj)
		{
			return obj.m_method == this.m_method;
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Emit.MethodToken" /> structures are equal.</summary>
		/// <param name="a">The <see cref="T:System.Reflection.Emit.MethodToken" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Reflection.Emit.MethodToken" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004AE6 RID: 19174 RVA: 0x0010E781 File Offset: 0x0010C981
		public static bool operator ==(MethodToken a, MethodToken b)
		{
			return a.Equals(b);
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Emit.MethodToken" /> structures are not equal.</summary>
		/// <param name="a">The <see cref="T:System.Reflection.Emit.MethodToken" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Reflection.Emit.MethodToken" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is not equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004AE7 RID: 19175 RVA: 0x0010E78B File Offset: 0x0010C98B
		public static bool operator !=(MethodToken a, MethodToken b)
		{
			return !(a == b);
		}

		/// <summary>The default <see langword="MethodToken" /> with <see cref="P:System.Reflection.Emit.MethodToken.Token" /> value 0.</summary>
		// Token: 0x04001E98 RID: 7832
		public static readonly MethodToken Empty;

		// Token: 0x04001E99 RID: 7833
		internal int m_method;
	}
}
