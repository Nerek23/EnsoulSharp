using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Defines the attributes of an implemented or inherited interface of a type.</summary>
	// Token: 0x02000A0F RID: 2575
	[Flags]
	[__DynamicallyInvokable]
	[Serializable]
	public enum IMPLTYPEFLAGS
	{
		/// <summary>The interface or dispinterface represents the default for the source or sink.</summary>
		// Token: 0x04002CC2 RID: 11458
		[__DynamicallyInvokable]
		IMPLTYPEFLAG_FDEFAULT = 1,
		/// <summary>This member of a coclass is called rather than implemented.</summary>
		// Token: 0x04002CC3 RID: 11459
		[__DynamicallyInvokable]
		IMPLTYPEFLAG_FSOURCE = 2,
		/// <summary>The member should not be displayed or programmable by users.</summary>
		// Token: 0x04002CC4 RID: 11460
		[__DynamicallyInvokable]
		IMPLTYPEFLAG_FRESTRICTED = 4,
		/// <summary>Sinks receive events through the virtual function table (VTBL).</summary>
		// Token: 0x04002CC5 RID: 11461
		[__DynamicallyInvokable]
		IMPLTYPEFLAG_FDEFAULTVTABLE = 8
	}
}
