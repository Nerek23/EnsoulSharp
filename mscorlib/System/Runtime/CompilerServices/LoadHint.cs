using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Specifies the preferred default binding for a dependent assembly.</summary>
	// Token: 0x02000896 RID: 2198
	[Serializable]
	public enum LoadHint
	{
		/// <summary>No preference specified.</summary>
		// Token: 0x04002972 RID: 10610
		Default,
		/// <summary>The dependency is always loaded.</summary>
		// Token: 0x04002973 RID: 10611
		Always,
		/// <summary>The dependency is sometimes loaded.</summary>
		// Token: 0x04002974 RID: 10612
		Sometimes
	}
}
