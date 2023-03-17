using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization.Formatters
{
	/// <summary>Specifies the level of automatic deserialization for .NET Framework remoting.</summary>
	// Token: 0x02000732 RID: 1842
	[ComVisible(true)]
	public enum TypeFilterLevel
	{
		/// <summary>The low deserialization level for .NET Framework remoting. It supports types associated with basic remoting functionality.</summary>
		// Token: 0x04002419 RID: 9241
		Low = 2,
		/// <summary>The full deserialization level for .NET Framework remoting. It supports all types that remoting supports in all situations.</summary>
		// Token: 0x0400241A RID: 9242
		Full
	}
}
