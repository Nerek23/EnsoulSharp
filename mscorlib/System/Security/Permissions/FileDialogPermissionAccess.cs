using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Specifies the type of access to files allowed through the File dialog boxes.</summary>
	// Token: 0x020002B2 RID: 690
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum FileDialogPermissionAccess
	{
		/// <summary>No access to files through the File dialog boxes.</summary>
		// Token: 0x04000DBC RID: 3516
		None = 0,
		/// <summary>Ability to open files through the File dialog boxes.</summary>
		// Token: 0x04000DBD RID: 3517
		Open = 1,
		/// <summary>Ability to save files through the File dialog boxes.</summary>
		// Token: 0x04000DBE RID: 3518
		Save = 2,
		/// <summary>Ability to open and save files through the File dialog boxes.</summary>
		// Token: 0x04000DBF RID: 3519
		OpenSave = 3
	}
}
