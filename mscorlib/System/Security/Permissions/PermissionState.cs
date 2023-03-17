using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Specifies whether a permission should have all or no access to resources at creation.</summary>
	// Token: 0x020002C0 RID: 704
	[ComVisible(true)]
	[Serializable]
	public enum PermissionState
	{
		/// <summary>Full access to the resource protected by the permission.</summary>
		// Token: 0x04000E1F RID: 3615
		Unrestricted = 1,
		/// <summary>No access to the resource protected by the permission.</summary>
		// Token: 0x04000E20 RID: 3616
		None = 0
	}
}
