using System;
using System.Runtime.InteropServices;

namespace System.Resources
{
	/// <summary>Specifies whether a <see cref="T:System.Resources.ResourceManager" /> object looks for the resources of the app's default culture in the main assembly or in a satellite assembly.</summary>
	// Token: 0x02000372 RID: 882
	[ComVisible(true)]
	[Serializable]
	public enum UltimateResourceFallbackLocation
	{
		/// <summary>Fallback resources are located in the main assembly.</summary>
		// Token: 0x040011D9 RID: 4569
		MainAssembly,
		/// <summary>Fallback resources are located in a satellite assembly.</summary>
		// Token: 0x040011DA RID: 4570
		Satellite
	}
}
