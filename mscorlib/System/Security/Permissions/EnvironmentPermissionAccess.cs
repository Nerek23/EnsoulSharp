using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Specifies access to environment variables.</summary>
	// Token: 0x020002AF RID: 687
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum EnvironmentPermissionAccess
	{
		/// <summary>No access to environment variables. <see cref="F:System.Security.Permissions.EnvironmentPermissionAccess.NoAccess" /> represents no valid <see cref="T:System.Security.Permissions.EnvironmentPermissionAccess" /> values and causes an <see cref="T:System.ArgumentException" /> when used as the parameter for <see cref="M:System.Security.Permissions.EnvironmentPermission.GetPathList(System.Security.Permissions.EnvironmentPermissionAccess)" />, which expects a single value.</summary>
		// Token: 0x04000DB4 RID: 3508
		NoAccess = 0,
		/// <summary>Only read access to environment variables is specified. Changing, deleting and creating environment variables is not included in this access level.</summary>
		// Token: 0x04000DB5 RID: 3509
		Read = 1,
		/// <summary>Only write access to environment variables is specified. Write access includes creating and deleting environment variables as well as changing existing values. Reading environment variables is not included in this access level.</summary>
		// Token: 0x04000DB6 RID: 3510
		Write = 2,
		/// <summary>
		///   <see cref="F:System.Security.Permissions.EnvironmentPermissionAccess.Read" /> and <see cref="F:System.Security.Permissions.EnvironmentPermissionAccess.Write" /> access to environment variables. <see cref="F:System.Security.Permissions.EnvironmentPermissionAccess.AllAccess" /> represents multiple <see cref="T:System.Security.Permissions.EnvironmentPermissionAccess" /> values and causes an <see cref="T:System.ArgumentException" /> when used as the <paramref name="flag" /> parameter for the <see cref="M:System.Security.Permissions.EnvironmentPermission.GetPathList(System.Security.Permissions.EnvironmentPermissionAccess)" /> method, which expects a single value.</summary>
		// Token: 0x04000DB7 RID: 3511
		AllAccess = 3
	}
}
