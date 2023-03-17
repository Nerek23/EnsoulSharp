using System;
using System.Runtime.InteropServices;

namespace System.Security.Principal
{
	/// <summary>Specifies common roles to be used with <see cref="M:System.Security.Principal.WindowsPrincipal.IsInRole(System.String)" />.</summary>
	// Token: 0x02000305 RID: 773
	[ComVisible(true)]
	[Serializable]
	public enum WindowsBuiltInRole
	{
		/// <summary>Administrators have complete and unrestricted access to the computer or domain.</summary>
		// Token: 0x04000FC8 RID: 4040
		Administrator = 544,
		/// <summary>Users are prevented from making accidental or intentional system-wide changes. Thus, users can run certified applications, but not most legacy applications.</summary>
		// Token: 0x04000FC9 RID: 4041
		User,
		/// <summary>Guests are more restricted than users.</summary>
		// Token: 0x04000FCA RID: 4042
		Guest,
		/// <summary>Power users possess most administrative permissions with some restrictions. Thus, power users can run legacy applications, in addition to certified applications.</summary>
		// Token: 0x04000FCB RID: 4043
		PowerUser,
		/// <summary>Account operators manage the user accounts on a computer or domain.</summary>
		// Token: 0x04000FCC RID: 4044
		AccountOperator,
		/// <summary>System operators manage a particular computer.</summary>
		// Token: 0x04000FCD RID: 4045
		SystemOperator,
		/// <summary>Print operators can take control of a printer.</summary>
		// Token: 0x04000FCE RID: 4046
		PrintOperator,
		/// <summary>Backup operators can override security restrictions for the sole purpose of backing up or restoring files.</summary>
		// Token: 0x04000FCF RID: 4047
		BackupOperator,
		/// <summary>Replicators support file replication in a domain.</summary>
		// Token: 0x04000FD0 RID: 4048
		Replicator
	}
}
