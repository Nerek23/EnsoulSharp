using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Represents an operating system platform.</summary>
	// Token: 0x0200097D RID: 2429
	public struct OSPlatform : IEquatable<OSPlatform>
	{
		/// <summary>Gets an object that represents the Linux operating system.</summary>
		/// <returns>An object that represents the Linux operating system.</returns>
		// Token: 0x17001101 RID: 4353
		// (get) Token: 0x060061DE RID: 25054 RVA: 0x0014CC64 File Offset: 0x0014AE64
		public static OSPlatform Linux { get; } = new OSPlatform("LINUX");

		/// <summary>Gets an object that represents the OSX operating system.</summary>
		/// <returns>An object that represents the OSX operating system.</returns>
		// Token: 0x17001102 RID: 4354
		// (get) Token: 0x060061DF RID: 25055 RVA: 0x0014CC6B File Offset: 0x0014AE6B
		public static OSPlatform OSX { get; } = new OSPlatform("OSX");

		/// <summary>Gets an object that represents the Windows operating system.</summary>
		/// <returns>An object that represents the Windows operating system.</returns>
		// Token: 0x17001103 RID: 4355
		// (get) Token: 0x060061E0 RID: 25056 RVA: 0x0014CC72 File Offset: 0x0014AE72
		public static OSPlatform Windows { get; } = new OSPlatform("WINDOWS");

		// Token: 0x060061E1 RID: 25057 RVA: 0x0014CC79 File Offset: 0x0014AE79
		private OSPlatform(string osPlatform)
		{
			if (osPlatform == null)
			{
				throw new ArgumentNullException("osPlatform");
			}
			if (osPlatform.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyValue"), "osPlatform");
			}
			this._osPlatform = osPlatform;
		}

		/// <summary>Creates a new <see cref="T:System.Runtime.InteropServices.OSPlatform" /> instance.</summary>
		/// <param name="osPlatform">The name of the platform that this instance represents.</param>
		/// <returns>An object that represents the <paramref name="osPlatform" /> operating system.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="osPlatform" /> is an empty string.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="osPlatform" /> is <see langword="null" />.</exception>
		// Token: 0x060061E2 RID: 25058 RVA: 0x0014CCAD File Offset: 0x0014AEAD
		public static OSPlatform Create(string osPlatform)
		{
			return new OSPlatform(osPlatform);
		}

		/// <summary>Determines whether the current instance and the specified <see cref="T:System.Runtime.InteropServices.OSPlatform" /> instance are equal.</summary>
		/// <param name="other">The object to compare with the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if the current instance and <paramref name="other" /> are equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x060061E3 RID: 25059 RVA: 0x0014CCB5 File Offset: 0x0014AEB5
		public bool Equals(OSPlatform other)
		{
			return this.Equals(other._osPlatform);
		}

		// Token: 0x060061E4 RID: 25060 RVA: 0x0014CCC3 File Offset: 0x0014AEC3
		internal bool Equals(string other)
		{
			return string.Equals(this._osPlatform, other, StringComparison.Ordinal);
		}

		/// <summary>Determines whether the current <see cref="T:System.Runtime.InteropServices.OSPlatform" /> instance is equal to the specified object.</summary>
		/// <param name="obj">
		///   <see langword="true" /> if <paramref name="obj" /> is a <see cref="T:System.Runtime.InteropServices.OSPlatform" /> instance and its name is the same as the current object; otherwise, false.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is a <see cref="T:System.Runtime.InteropServices.OSPlatform" /> instance and its name is the same as the current object.</returns>
		// Token: 0x060061E5 RID: 25061 RVA: 0x0014CCD2 File Offset: 0x0014AED2
		public override bool Equals(object obj)
		{
			return obj is OSPlatform && this.Equals((OSPlatform)obj);
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>The hash code for this instance.</returns>
		// Token: 0x060061E6 RID: 25062 RVA: 0x0014CCEA File Offset: 0x0014AEEA
		public override int GetHashCode()
		{
			if (this._osPlatform != null)
			{
				return this._osPlatform.GetHashCode();
			}
			return 0;
		}

		/// <summary>Returns the string representation of this <see cref="T:System.Runtime.InteropServices.OSPlatform" /> instance.</summary>
		/// <returns>A string that represents this <see cref="T:System.Runtime.InteropServices.OSPlatform" /> instance.</returns>
		// Token: 0x060061E7 RID: 25063 RVA: 0x0014CD01 File Offset: 0x0014AF01
		public override string ToString()
		{
			return this._osPlatform ?? string.Empty;
		}

		/// <summary>Determines whether two <see cref="T:System.Runtime.InteropServices.OSPlatform" /> objects are equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x060061E8 RID: 25064 RVA: 0x0014CD12 File Offset: 0x0014AF12
		public static bool operator ==(OSPlatform left, OSPlatform right)
		{
			return left.Equals(right);
		}

		/// <summary>Determines whether two <see cref="T:System.Runtime.InteropServices.OSPlatform" /> instances are unequal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are unequal; otherwise, <see langword="false" />.</returns>
		// Token: 0x060061E9 RID: 25065 RVA: 0x0014CD1C File Offset: 0x0014AF1C
		public static bool operator !=(OSPlatform left, OSPlatform right)
		{
			return !(left == right);
		}

		// Token: 0x04002BEF RID: 11247
		private readonly string _osPlatform;
	}
}
