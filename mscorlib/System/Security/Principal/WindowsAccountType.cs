using System;
using System.Runtime.InteropServices;

namespace System.Security.Principal
{
	/// <summary>Specifies the type of Windows account used.</summary>
	// Token: 0x020002FC RID: 764
	[ComVisible(true)]
	[Serializable]
	public enum WindowsAccountType
	{
		/// <summary>A standard user account.</summary>
		// Token: 0x04000F6C RID: 3948
		Normal,
		/// <summary>A Windows guest account.</summary>
		// Token: 0x04000F6D RID: 3949
		Guest,
		/// <summary>A Windows system account.</summary>
		// Token: 0x04000F6E RID: 3950
		System,
		/// <summary>An anonymous account.</summary>
		// Token: 0x04000F6F RID: 3951
		Anonymous
	}
}
