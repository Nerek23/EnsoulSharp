using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Specifies the resource location.</summary>
	// Token: 0x020005C7 RID: 1479
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum ResourceLocation
	{
		/// <summary>Specifies an embedded (that is, non-linked) resource.</summary>
		// Token: 0x04001C21 RID: 7201
		[__DynamicallyInvokable]
		Embedded = 1,
		/// <summary>Specifies that the resource is contained in another assembly.</summary>
		// Token: 0x04001C22 RID: 7202
		[__DynamicallyInvokable]
		ContainedInAnotherAssembly = 2,
		/// <summary>Specifies that the resource is contained in the manifest file.</summary>
		// Token: 0x04001C23 RID: 7203
		[__DynamicallyInvokable]
		ContainedInManifestFile = 4
	}
}
