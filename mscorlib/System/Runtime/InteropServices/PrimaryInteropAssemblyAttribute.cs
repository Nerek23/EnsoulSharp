using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Indicates that the attributed assembly is a primary interop assembly.</summary>
	// Token: 0x0200090C RID: 2316
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = true)]
	[ComVisible(true)]
	public sealed class PrimaryInteropAssemblyAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.PrimaryInteropAssemblyAttribute" /> class with the major and minor version numbers of the type library for which this assembly is the primary interop assembly.</summary>
		/// <param name="major">The major version of the type library for which this assembly is the primary interop assembly.</param>
		/// <param name="minor">The minor version of the type library for which this assembly is the primary interop assembly.</param>
		// Token: 0x06005F30 RID: 24368 RVA: 0x0014739B File Offset: 0x0014559B
		public PrimaryInteropAssemblyAttribute(int major, int minor)
		{
			this._major = major;
			this._minor = minor;
		}

		/// <summary>Gets the major version number of the type library for which this assembly is the primary interop assembly.</summary>
		/// <returns>The major version number of the type library for which this assembly is the primary interop assembly.</returns>
		// Token: 0x170010D0 RID: 4304
		// (get) Token: 0x06005F31 RID: 24369 RVA: 0x001473B1 File Offset: 0x001455B1
		public int MajorVersion
		{
			get
			{
				return this._major;
			}
		}

		/// <summary>Gets the minor version number of the type library for which this assembly is the primary interop assembly.</summary>
		/// <returns>The minor version number of the type library for which this assembly is the primary interop assembly.</returns>
		// Token: 0x170010D1 RID: 4305
		// (get) Token: 0x06005F32 RID: 24370 RVA: 0x001473B9 File Offset: 0x001455B9
		public int MinorVersion
		{
			get
			{
				return this._minor;
			}
		}

		// Token: 0x04002A68 RID: 10856
		internal int _major;

		// Token: 0x04002A69 RID: 10857
		internal int _minor;
	}
}
