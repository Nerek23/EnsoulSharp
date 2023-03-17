using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization.Formatters
{
	/// <summary>Indicates the method that will be used during deserialization for locating and loading assemblies.</summary>
	// Token: 0x02000731 RID: 1841
	[ComVisible(true)]
	[Serializable]
	public enum FormatterAssemblyStyle
	{
		/// <summary>In simple mode, the assembly used during deserialization need not match exactly the assembly used during serialization. Specifically, the version numbers need not match as the <see cref="Overload:System.Reflection.Assembly.LoadWithPartialName" /> method is used to load the assembly.</summary>
		// Token: 0x04002416 RID: 9238
		Simple,
		/// <summary>In full mode, the assembly used during deserialization must match exactly the assembly used during serialization. The <see cref="Overload:System.Reflection.Assembly.Load" /> method of the <see cref="T:System.Reflection.Assembly" /> class is used to load the assembly.</summary>
		// Token: 0x04002417 RID: 9239
		Full
	}
}
