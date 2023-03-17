using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Identifies a particular type library and provides localization support for member names.</summary>
	// Token: 0x02000A24 RID: 2596
	[__DynamicallyInvokable]
	[Serializable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TYPELIBATTR
	{
		/// <summary>Represents a globally unique library ID of a type library.</summary>
		// Token: 0x04002D50 RID: 11600
		[__DynamicallyInvokable]
		public Guid guid;

		/// <summary>Represents a locale ID of a type library.</summary>
		// Token: 0x04002D51 RID: 11601
		[__DynamicallyInvokable]
		public int lcid;

		/// <summary>Represents the target hardware platform of a type library.</summary>
		// Token: 0x04002D52 RID: 11602
		[__DynamicallyInvokable]
		public SYSKIND syskind;

		/// <summary>Represents the major version number of a type library.</summary>
		// Token: 0x04002D53 RID: 11603
		[__DynamicallyInvokable]
		public short wMajorVerNum;

		/// <summary>Represents the minor version number of a type library.</summary>
		// Token: 0x04002D54 RID: 11604
		[__DynamicallyInvokable]
		public short wMinorVerNum;

		/// <summary>Represents library flags.</summary>
		// Token: 0x04002D55 RID: 11605
		[__DynamicallyInvokable]
		public LIBFLAGS wLibFlags;
	}
}
