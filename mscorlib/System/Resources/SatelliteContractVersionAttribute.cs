using System;
using System.Runtime.InteropServices;

namespace System.Resources
{
	/// <summary>Instructs a <see cref="T:System.Resources.ResourceManager" /> object to ask for a particular version of a satellite assembly.</summary>
	// Token: 0x02000371 RID: 881
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class SatelliteContractVersionAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Resources.SatelliteContractVersionAttribute" /> class.</summary>
		/// <param name="version">A string that specifies the version of the satellite assemblies to load.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="version" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06002C7A RID: 11386 RVA: 0x000A9FCC File Offset: 0x000A81CC
		[__DynamicallyInvokable]
		public SatelliteContractVersionAttribute(string version)
		{
			if (version == null)
			{
				throw new ArgumentNullException("version");
			}
			this._version = version;
		}

		/// <summary>Gets the version of the satellite assemblies with the required resources.</summary>
		/// <returns>A string that contains the version of the satellite assemblies with the required resources.</returns>
		// Token: 0x170005D9 RID: 1497
		// (get) Token: 0x06002C7B RID: 11387 RVA: 0x000A9FE9 File Offset: 0x000A81E9
		[__DynamicallyInvokable]
		public string Version
		{
			[__DynamicallyInvokable]
			get
			{
				return this._version;
			}
		}

		// Token: 0x040011D7 RID: 4567
		private string _version;
	}
}
