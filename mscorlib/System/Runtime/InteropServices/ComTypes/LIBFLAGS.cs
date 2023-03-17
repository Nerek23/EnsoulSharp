using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Defines flags that apply to type libraries.</summary>
	// Token: 0x02000A23 RID: 2595
	[Flags]
	[__DynamicallyInvokable]
	[Serializable]
	public enum LIBFLAGS : short
	{
		/// <summary>The type library is restricted, and should not be displayed to users.</summary>
		// Token: 0x04002D4C RID: 11596
		[__DynamicallyInvokable]
		LIBFLAG_FRESTRICTED = 1,
		/// <summary>The type library describes controls and should not be displayed in type browsers intended for nonvisual objects.</summary>
		// Token: 0x04002D4D RID: 11597
		[__DynamicallyInvokable]
		LIBFLAG_FCONTROL = 2,
		/// <summary>The type library should not be displayed to users, although its use is not restricted. The type library should be used by controls. Hosts should create a new type library that wraps the control with extended properties.</summary>
		// Token: 0x04002D4E RID: 11598
		[__DynamicallyInvokable]
		LIBFLAG_FHIDDEN = 4,
		/// <summary>The type library exists in a persisted form on disk.</summary>
		// Token: 0x04002D4F RID: 11599
		[__DynamicallyInvokable]
		LIBFLAG_FHASDISKIMAGE = 8
	}
}
