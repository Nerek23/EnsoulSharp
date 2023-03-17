using System;
using System.Runtime.InteropServices;

namespace System.Configuration.Assemblies
{
	/// <summary>Represents a hash of an assembly manifest's contents.</summary>
	// Token: 0x02000171 RID: 369
	[ComVisible(true)]
	[Obsolete("The AssemblyHash class has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
	[Serializable]
	public struct AssemblyHash : ICloneable
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Configuration.Assemblies.AssemblyHash" /> structure with the specified hash value. The hash algorithm defaults to <see cref="F:System.Configuration.Assemblies.AssemblyHashAlgorithm.SHA1" />.</summary>
		/// <param name="value">The hash value.</param>
		// Token: 0x06001670 RID: 5744 RVA: 0x00046EE4 File Offset: 0x000450E4
		[Obsolete("The AssemblyHash class has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		public AssemblyHash(byte[] value)
		{
			this._Algorithm = AssemblyHashAlgorithm.SHA1;
			this._Value = null;
			if (value != null)
			{
				int num = value.Length;
				this._Value = new byte[num];
				Array.Copy(value, this._Value, num);
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Configuration.Assemblies.AssemblyHash" /> structure with the specified hash algorithm and the hash value.</summary>
		/// <param name="algorithm">The algorithm used to generate the hash. Values for this parameter come from the <see cref="T:System.Configuration.Assemblies.AssemblyHashAlgorithm" /> enumeration.</param>
		/// <param name="value">The hash value.</param>
		// Token: 0x06001671 RID: 5745 RVA: 0x00046F24 File Offset: 0x00045124
		[Obsolete("The AssemblyHash class has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		public AssemblyHash(AssemblyHashAlgorithm algorithm, byte[] value)
		{
			this._Algorithm = algorithm;
			this._Value = null;
			if (value != null)
			{
				int num = value.Length;
				this._Value = new byte[num];
				Array.Copy(value, this._Value, num);
			}
		}

		/// <summary>Gets or sets the hash algorithm.</summary>
		/// <returns>An assembly hash algorithm.</returns>
		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06001672 RID: 5746 RVA: 0x00046F5F File Offset: 0x0004515F
		// (set) Token: 0x06001673 RID: 5747 RVA: 0x00046F67 File Offset: 0x00045167
		[Obsolete("The AssemblyHash class has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		public AssemblyHashAlgorithm Algorithm
		{
			get
			{
				return this._Algorithm;
			}
			set
			{
				this._Algorithm = value;
			}
		}

		/// <summary>Gets the hash value.</summary>
		/// <returns>The hash value.</returns>
		// Token: 0x06001674 RID: 5748 RVA: 0x00046F70 File Offset: 0x00045170
		[Obsolete("The AssemblyHash class has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		public byte[] GetValue()
		{
			return this._Value;
		}

		/// <summary>Sets the hash value.</summary>
		/// <param name="value">The hash value.</param>
		// Token: 0x06001675 RID: 5749 RVA: 0x00046F78 File Offset: 0x00045178
		[Obsolete("The AssemblyHash class has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		public void SetValue(byte[] value)
		{
			this._Value = value;
		}

		/// <summary>Clones this object.</summary>
		/// <returns>An exact copy of this object.</returns>
		// Token: 0x06001676 RID: 5750 RVA: 0x00046F81 File Offset: 0x00045181
		[Obsolete("The AssemblyHash class has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		public object Clone()
		{
			return new AssemblyHash(this._Algorithm, this._Value);
		}

		// Token: 0x040007DC RID: 2012
		private AssemblyHashAlgorithm _Algorithm;

		// Token: 0x040007DD RID: 2013
		private byte[] _Value;

		/// <summary>An empty <see cref="T:System.Configuration.Assemblies.AssemblyHash" /> object.</summary>
		// Token: 0x040007DE RID: 2014
		[Obsolete("The AssemblyHash class has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		public static readonly AssemblyHash Empty = new AssemblyHash(AssemblyHashAlgorithm.None, null);
	}
}
