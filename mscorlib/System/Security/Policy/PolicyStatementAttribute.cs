using System;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	/// <summary>Defines special attribute flags for security policy on code groups.</summary>
	// Token: 0x0200033B RID: 827
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum PolicyStatementAttribute
	{
		/// <summary>No flags are set.</summary>
		// Token: 0x040010D6 RID: 4310
		Nothing = 0,
		/// <summary>The exclusive code group flag. When a code group has this flag set, only the permissions associated with that code group are granted to code belonging to the code group. At most, one code group matching a given piece of code can be set as exclusive.</summary>
		// Token: 0x040010D7 RID: 4311
		Exclusive = 1,
		/// <summary>The flag representing a policy statement that causes lower policy levels to not be evaluated as part of the resolve operation, effectively allowing the policy level to override lower levels.</summary>
		// Token: 0x040010D8 RID: 4312
		LevelFinal = 2,
		/// <summary>All attribute flags are set.</summary>
		// Token: 0x040010D9 RID: 4313
		All = 3
	}
}
