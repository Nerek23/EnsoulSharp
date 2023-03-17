using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Specifies the type of clipboard access that is allowed to the calling code.</summary>
	// Token: 0x020002E0 RID: 736
	[ComVisible(true)]
	[Serializable]
	public enum UIPermissionClipboard
	{
		/// <summary>Clipboard cannot be used.</summary>
		// Token: 0x04000E95 RID: 3733
		NoClipboard,
		/// <summary>The ability to put data on the clipboard (<see langword="Copy" />, <see langword="Cut" />) is unrestricted. Intrinsic controls that accept <see langword="Paste" />, such as text box, can accept the clipboard data, but user controls that must programmatically read the clipboard cannot.</summary>
		// Token: 0x04000E96 RID: 3734
		OwnClipboard,
		/// <summary>Clipboard can be used without restriction.</summary>
		// Token: 0x04000E97 RID: 3735
		AllClipboard
	}
}
