using System;
using System.Runtime.InteropServices;

namespace System.Security.Principal
{
	/// <summary>Defines the privileges of the user account associated with the access token.</summary>
	// Token: 0x020002FA RID: 762
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum TokenAccessLevels
	{
		/// <summary>The user can attach a primary token to a process.</summary>
		// Token: 0x04000F58 RID: 3928
		AssignPrimary = 1,
		/// <summary>The user can duplicate the token.</summary>
		// Token: 0x04000F59 RID: 3929
		Duplicate = 2,
		/// <summary>The user can impersonate a client.</summary>
		// Token: 0x04000F5A RID: 3930
		Impersonate = 4,
		/// <summary>The user can query the token.</summary>
		// Token: 0x04000F5B RID: 3931
		Query = 8,
		/// <summary>The user can query the source of the token.</summary>
		// Token: 0x04000F5C RID: 3932
		QuerySource = 16,
		/// <summary>The user can enable or disable privileges in the token.</summary>
		// Token: 0x04000F5D RID: 3933
		AdjustPrivileges = 32,
		/// <summary>The user can change the attributes of the groups in the token.</summary>
		// Token: 0x04000F5E RID: 3934
		AdjustGroups = 64,
		/// <summary>The user can change the default owner, primary group, or discretionary access control list (DACL) of the token.</summary>
		// Token: 0x04000F5F RID: 3935
		AdjustDefault = 128,
		/// <summary>The user can adjust the session identifier of the token.</summary>
		// Token: 0x04000F60 RID: 3936
		AdjustSessionId = 256,
		/// <summary>The user has standard read rights and the <see cref="F:System.Security.Principal.TokenAccessLevels.Query" /> privilege for the token.</summary>
		// Token: 0x04000F61 RID: 3937
		Read = 131080,
		/// <summary>The user has standard write rights and the <see cref="F:System.Security.Principal.TokenAccessLevels.AdjustPrivileges" />, <see cref="F:System.Security.Principal.TokenAccessLevels.AdjustGroups" /> and <see cref="F:System.Security.Principal.TokenAccessLevels.AdjustDefault" /> privileges for the token.</summary>
		// Token: 0x04000F62 RID: 3938
		Write = 131296,
		/// <summary>The user has all possible access to the token.</summary>
		// Token: 0x04000F63 RID: 3939
		AllAccess = 983551,
		/// <summary>The maximum value that can be assigned for the <see cref="T:System.Security.Principal.TokenAccessLevels" /> enumeration.</summary>
		// Token: 0x04000F64 RID: 3940
		MaximumAllowed = 33554432
	}
}
