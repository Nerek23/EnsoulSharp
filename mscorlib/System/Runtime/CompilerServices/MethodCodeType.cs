using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	/// <summary>Defines how a method is implemented.</summary>
	// Token: 0x02000891 RID: 2193
	[ComVisible(true)]
	[Serializable]
	public enum MethodCodeType
	{
		/// <summary>Specifies that the method implementation is in Microsoft intermediate language (MSIL).</summary>
		// Token: 0x0400296A RID: 10602
		IL,
		/// <summary>Specifies that the method is implemented in native code.</summary>
		// Token: 0x0400296B RID: 10603
		Native,
		/// <summary>Specifies that the method implementation is in optimized intermediate language (OPTIL).</summary>
		// Token: 0x0400296C RID: 10604
		OPTIL,
		/// <summary>Specifies that the method implementation is provided by the runtime.</summary>
		// Token: 0x0400296D RID: 10605
		Runtime
	}
}
