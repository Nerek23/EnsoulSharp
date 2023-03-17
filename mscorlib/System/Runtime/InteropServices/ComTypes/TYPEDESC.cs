﻿using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Describes the type of a variable, return type of a function, or the type of a function parameter.</summary>
	// Token: 0x02000A16 RID: 2582
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TYPEDESC
	{
		/// <summary>If the variable is <see langword="VT_SAFEARRAY" /> or <see langword="VT_PTR" />, the <see langword="lpValue" /> field contains a pointer to a <see langword="TYPEDESC" /> that specifies the element type.</summary>
		// Token: 0x04002CF8 RID: 11512
		public IntPtr lpValue;

		/// <summary>Indicates the variant type for the item described by this <see langword="TYPEDESC" />.</summary>
		// Token: 0x04002CF9 RID: 11513
		[__DynamicallyInvokable]
		public short vt;
	}
}
