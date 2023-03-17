using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Specifies the type of key container access allowed.</summary>
	// Token: 0x020002E7 RID: 743
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum KeyContainerPermissionFlags
	{
		/// <summary>No access to a key container.</summary>
		// Token: 0x04000EA3 RID: 3747
		NoFlags = 0,
		/// <summary>Create a key container.</summary>
		// Token: 0x04000EA4 RID: 3748
		Create = 1,
		/// <summary>Open a key container and use the public key.</summary>
		// Token: 0x04000EA5 RID: 3749
		Open = 2,
		/// <summary>Delete a key container.</summary>
		// Token: 0x04000EA6 RID: 3750
		Delete = 4,
		/// <summary>Import a key into a key container.</summary>
		// Token: 0x04000EA7 RID: 3751
		Import = 16,
		/// <summary>Export a key from a key container.</summary>
		// Token: 0x04000EA8 RID: 3752
		Export = 32,
		/// <summary>Sign a file using a key.</summary>
		// Token: 0x04000EA9 RID: 3753
		Sign = 256,
		/// <summary>Decrypt a key container.</summary>
		// Token: 0x04000EAA RID: 3754
		Decrypt = 512,
		/// <summary>View the access control list (ACL) for a key container.</summary>
		// Token: 0x04000EAB RID: 3755
		ViewAcl = 4096,
		/// <summary>Change the access control list (ACL) for a key container.</summary>
		// Token: 0x04000EAC RID: 3756
		ChangeAcl = 8192,
		/// <summary>Create, decrypt, delete, and open a key container; export and import a key; sign files using a key; and view and change the access control list for a key container.</summary>
		// Token: 0x04000EAD RID: 3757
		AllFlags = 13111
	}
}
