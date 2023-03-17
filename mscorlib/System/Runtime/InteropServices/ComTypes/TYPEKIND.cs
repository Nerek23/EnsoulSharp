using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Specifies various types of data and functions.</summary>
	// Token: 0x02000A0D RID: 2573
	[__DynamicallyInvokable]
	[Serializable]
	public enum TYPEKIND
	{
		/// <summary>A set of enumerators.</summary>
		// Token: 0x04002CA8 RID: 11432
		[__DynamicallyInvokable]
		TKIND_ENUM,
		/// <summary>A structure with no methods.</summary>
		// Token: 0x04002CA9 RID: 11433
		[__DynamicallyInvokable]
		TKIND_RECORD,
		/// <summary>A module that can have only static functions and data (for example, a DLL).</summary>
		// Token: 0x04002CAA RID: 11434
		[__DynamicallyInvokable]
		TKIND_MODULE,
		/// <summary>A type that has virtual functions, all of which are pure.</summary>
		// Token: 0x04002CAB RID: 11435
		[__DynamicallyInvokable]
		TKIND_INTERFACE,
		/// <summary>A set of methods and properties that are accessible through <see langword="IDispatch::Invoke" />. By default, dual interfaces return <see langword="TKIND_DISPATCH" />.</summary>
		// Token: 0x04002CAC RID: 11436
		[__DynamicallyInvokable]
		TKIND_DISPATCH,
		/// <summary>A set of implemented components interfaces.</summary>
		// Token: 0x04002CAD RID: 11437
		[__DynamicallyInvokable]
		TKIND_COCLASS,
		/// <summary>A type that is an alias for another type.</summary>
		// Token: 0x04002CAE RID: 11438
		[__DynamicallyInvokable]
		TKIND_ALIAS,
		/// <summary>A union of all members that have an offset of zero.</summary>
		// Token: 0x04002CAF RID: 11439
		[__DynamicallyInvokable]
		TKIND_UNION,
		/// <summary>End-of-enumeration marker.</summary>
		// Token: 0x04002CB0 RID: 11440
		[__DynamicallyInvokable]
		TKIND_MAX
	}
}
