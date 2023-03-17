using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Specifies the type of file access requested.</summary>
	// Token: 0x020002B4 RID: 692
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum FileIOPermissionAccess
	{
		/// <summary>No access to a file or directory. <see cref="F:System.Security.Permissions.FileIOPermissionAccess.NoAccess" /> represents no valid <see cref="T:System.Security.Permissions.FileIOPermissionAccess" /> values and causes an <see cref="T:System.ArgumentException" /> when used as the parameter for <see cref="M:System.Security.Permissions.FileIOPermission.GetPathList(System.Security.Permissions.FileIOPermissionAccess)" />, which expects a single value.</summary>
		// Token: 0x04000DC2 RID: 3522
		NoAccess = 0,
		/// <summary>Access to read from a file or directory.</summary>
		// Token: 0x04000DC3 RID: 3523
		Read = 1,
		/// <summary>Access to write to or delete a file or directory. <see cref="F:System.Security.Permissions.FileIOPermissionAccess.Write" /> access includes deleting and overwriting files or directories.</summary>
		// Token: 0x04000DC4 RID: 3524
		Write = 2,
		/// <summary>Access to append material to a file or directory. <see cref="F:System.Security.Permissions.FileIOPermissionAccess.Append" /> access includes the ability to create a new file or directory.</summary>
		// Token: 0x04000DC5 RID: 3525
		Append = 4,
		/// <summary>Access to the information in the path itself. This helps protect sensitive information in the path, such as user names, as well as information about the directory structure revealed in the path. This value does not grant access to files or folders represented by the path.</summary>
		// Token: 0x04000DC6 RID: 3526
		PathDiscovery = 8,
		/// <summary>
		///   <see cref="F:System.Security.Permissions.FileIOPermissionAccess.Append" />, <see cref="F:System.Security.Permissions.FileIOPermissionAccess.Read" />, <see cref="F:System.Security.Permissions.FileIOPermissionAccess.Write" />, and <see cref="F:System.Security.Permissions.FileIOPermissionAccess.PathDiscovery" /> access to a file or directory. <see cref="F:System.Security.Permissions.FileIOPermissionAccess.AllAccess" /> represents multiple <see cref="T:System.Security.Permissions.FileIOPermissionAccess" /> values and causes an <see cref="T:System.ArgumentException" /> when used as the <paramref name="access" /> parameter for the <see cref="M:System.Security.Permissions.FileIOPermission.GetPathList(System.Security.Permissions.FileIOPermissionAccess)" /> method, which expects a single value.</summary>
		// Token: 0x04000DC7 RID: 3527
		AllAccess = 15
	}
}
