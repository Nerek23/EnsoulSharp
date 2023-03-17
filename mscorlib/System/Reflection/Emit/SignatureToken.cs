using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>Represents the <see langword="Token" /> returned by the metadata to represent a signature.</summary>
	// Token: 0x02000633 RID: 1587
	[ComVisible(true)]
	public struct SignatureToken
	{
		// Token: 0x06004C13 RID: 19475 RVA: 0x00113B18 File Offset: 0x00111D18
		internal SignatureToken(int str, ModuleBuilder mod)
		{
			this.m_signature = str;
			this.m_moduleBuilder = mod;
		}

		/// <summary>Retrieves the metadata token for the local variable signature for this method.</summary>
		/// <returns>Read-only. Retrieves the metadata token of this signature.</returns>
		// Token: 0x17000BFF RID: 3071
		// (get) Token: 0x06004C14 RID: 19476 RVA: 0x00113B28 File Offset: 0x00111D28
		public int Token
		{
			get
			{
				return this.m_signature;
			}
		}

		/// <summary>Generates the hash code for this signature.</summary>
		/// <returns>The hash code for this signature.</returns>
		// Token: 0x06004C15 RID: 19477 RVA: 0x00113B30 File Offset: 0x00111D30
		public override int GetHashCode()
		{
			return this.m_signature;
		}

		/// <summary>Checks if the given object is an instance of <see langword="SignatureToken" /> and is equal to this instance.</summary>
		/// <param name="obj">The object to compare with this <see langword="SignatureToken" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is an instance of <see langword="SignatureToken" /> and is equal to this object; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004C16 RID: 19478 RVA: 0x00113B38 File Offset: 0x00111D38
		public override bool Equals(object obj)
		{
			return obj is SignatureToken && this.Equals((SignatureToken)obj);
		}

		/// <summary>Indicates whether the current instance is equal to the specified <see cref="T:System.Reflection.Emit.SignatureToken" />.</summary>
		/// <param name="obj">The <see cref="T:System.Reflection.Emit.SignatureToken" /> to compare to the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if the value of <paramref name="obj" /> is equal to the value of the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004C17 RID: 19479 RVA: 0x00113B50 File Offset: 0x00111D50
		public bool Equals(SignatureToken obj)
		{
			return obj.m_signature == this.m_signature;
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Emit.SignatureToken" /> structures are equal.</summary>
		/// <param name="a">The <see cref="T:System.Reflection.Emit.SignatureToken" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Reflection.Emit.SignatureToken" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004C18 RID: 19480 RVA: 0x00113B60 File Offset: 0x00111D60
		public static bool operator ==(SignatureToken a, SignatureToken b)
		{
			return a.Equals(b);
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Emit.SignatureToken" /> structures are not equal.</summary>
		/// <param name="a">The <see cref="T:System.Reflection.Emit.SignatureToken" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Reflection.Emit.SignatureToken" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is not equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004C19 RID: 19481 RVA: 0x00113B6A File Offset: 0x00111D6A
		public static bool operator !=(SignatureToken a, SignatureToken b)
		{
			return !(a == b);
		}

		/// <summary>The default <see langword="SignatureToken" /> with <see cref="P:System.Reflection.Emit.SignatureToken.Token" /> value 0.</summary>
		// Token: 0x040020E9 RID: 8425
		public static readonly SignatureToken Empty;

		// Token: 0x040020EA RID: 8426
		internal int m_signature;

		// Token: 0x040020EB RID: 8427
		internal ModuleBuilder m_moduleBuilder;
	}
}
