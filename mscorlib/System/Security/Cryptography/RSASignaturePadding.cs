using System;

namespace System.Security.Cryptography
{
	/// <summary>Specifies the padding mode and parameters to use with RSA signature creation or verification operations.</summary>
	// Token: 0x0200027C RID: 636
	public sealed class RSASignaturePadding : IEquatable<RSASignaturePadding>
	{
		// Token: 0x06002297 RID: 8855 RVA: 0x0007C68F File Offset: 0x0007A88F
		private RSASignaturePadding(RSASignaturePaddingMode mode)
		{
			this._mode = mode;
		}

		/// <summary>Gets an object that uses the PKCS #1 v1.5 padding mode.</summary>
		/// <returns>An object that uses the <see cref="F:System.Security.Cryptography.RSASignaturePaddingMode.Pkcs1" /> padding mode.</returns>
		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06002298 RID: 8856 RVA: 0x0007C69E File Offset: 0x0007A89E
		public static RSASignaturePadding Pkcs1
		{
			get
			{
				return RSASignaturePadding.s_pkcs1;
			}
		}

		/// <summary>Gets an object that uses PSS padding mode.</summary>
		/// <returns>An object that uses the <see cref="F:System.Security.Cryptography.RSASignaturePaddingMode.Pss" /> padding mode with the number of salt bytes equal to the size of the hash.</returns>
		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06002299 RID: 8857 RVA: 0x0007C6A5 File Offset: 0x0007A8A5
		public static RSASignaturePadding Pss
		{
			get
			{
				return RSASignaturePadding.s_pss;
			}
		}

		/// <summary>Gets the padding mode of this <see cref="T:System.Security.Cryptography.RSASignaturePadding" /> instance.</summary>
		/// <returns>The padding mode (either <see cref="F:System.Security.Cryptography.RSASignaturePaddingMode.Pkcs1" /> or <see cref="F:System.Security.Cryptography.RSASignaturePaddingMode.Pss" />) of this instance.</returns>
		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x0600229A RID: 8858 RVA: 0x0007C6AC File Offset: 0x0007A8AC
		public RSASignaturePaddingMode Mode
		{
			get
			{
				return this._mode;
			}
		}

		/// <summary>Returns the hash code for this <see cref="T:System.Security.Cryptography.RSASignaturePadding" /> instance.</summary>
		/// <returns>The hash code for this <see cref="T:System.Security.Cryptography.RSASignaturePadding" /> instance.</returns>
		// Token: 0x0600229B RID: 8859 RVA: 0x0007C6B4 File Offset: 0x0007A8B4
		public override int GetHashCode()
		{
			return this._mode.GetHashCode();
		}

		/// <summary>Returns a value that indicates whether this instance is equal to a specified object.</summary>
		/// <param name="obj">The object to compare with the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if the specified object is equal to the current object; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600229C RID: 8860 RVA: 0x0007C6D5 File Offset: 0x0007A8D5
		public override bool Equals(object obj)
		{
			return this.Equals(obj as RSASignaturePadding);
		}

		/// <summary>Returns a value that indicates whether this instance is equal to a specified <see cref="T:System.Security.Cryptography.RSASignaturePadding" /> object.</summary>
		/// <param name="other">The object to compare with the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if the specified object is equal to the current object; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600229D RID: 8861 RVA: 0x0007C6E3 File Offset: 0x0007A8E3
		public bool Equals(RSASignaturePadding other)
		{
			return other != null && this._mode == other._mode;
		}

		/// <summary>Indicates whether two specified <see cref="T:System.Security.Cryptography.RSASignaturePadding" /> objects are equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <see langword="left" /> and <see langword="right" /> are equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600229E RID: 8862 RVA: 0x0007C6FE File Offset: 0x0007A8FE
		public static bool operator ==(RSASignaturePadding left, RSASignaturePadding right)
		{
			if (left == null)
			{
				return right == null;
			}
			return left.Equals(right);
		}

		/// <summary>Indicates whether two specified <see cref="T:System.Security.Cryptography.RSASignaturePadding" /> objects are unequal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <see langword="left" /> and <see langword="right" /> are unequal; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600229F RID: 8863 RVA: 0x0007C70F File Offset: 0x0007A90F
		public static bool operator !=(RSASignaturePadding left, RSASignaturePadding right)
		{
			return !(left == right);
		}

		/// <summary>Returns the string representation of the current <see cref="T:System.Security.Cryptography.RSASignaturePadding" /> instance.</summary>
		/// <returns>The string representation of the current object.</returns>
		// Token: 0x060022A0 RID: 8864 RVA: 0x0007C71C File Offset: 0x0007A91C
		public override string ToString()
		{
			return this._mode.ToString();
		}

		// Token: 0x04000C8D RID: 3213
		private static readonly RSASignaturePadding s_pkcs1 = new RSASignaturePadding(RSASignaturePaddingMode.Pkcs1);

		// Token: 0x04000C8E RID: 3214
		private static readonly RSASignaturePadding s_pss = new RSASignaturePadding(RSASignaturePaddingMode.Pss);

		// Token: 0x04000C8F RID: 3215
		private readonly RSASignaturePaddingMode _mode;
	}
}
