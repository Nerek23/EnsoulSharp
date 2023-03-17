using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.IMPLTYPEFLAGS" /> instead.</summary>
	// Token: 0x02000966 RID: 2406
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IMPLTYPEFLAGS instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Flags]
	[Serializable]
	public enum IMPLTYPEFLAGS
	{
		/// <summary>The interface or dispinterface represents the default for the source or sink.</summary>
		// Token: 0x04002B5E RID: 11102
		IMPLTYPEFLAG_FDEFAULT = 1,
		/// <summary>This member of a coclass is called rather than implemented.</summary>
		// Token: 0x04002B5F RID: 11103
		IMPLTYPEFLAG_FSOURCE = 2,
		/// <summary>The member should not be displayed or programmable by users.</summary>
		// Token: 0x04002B60 RID: 11104
		IMPLTYPEFLAG_FRESTRICTED = 4,
		/// <summary>Sinks receive events through the virtual function table (VTBL).</summary>
		// Token: 0x04002B61 RID: 11105
		IMPLTYPEFLAG_FDEFAULTVTABLE = 8
	}
}
