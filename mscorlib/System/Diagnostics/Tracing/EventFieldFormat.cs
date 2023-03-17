using System;

namespace System.Diagnostics.Tracing
{
	/// <summary>Specifies how to format the value of a user-defined type and can be used to override the default formatting for a field.</summary>
	// Token: 0x02000417 RID: 1047
	[__DynamicallyInvokable]
	public enum EventFieldFormat
	{
		/// <summary>Default.</summary>
		// Token: 0x0400176D RID: 5997
		[__DynamicallyInvokable]
		Default,
		/// <summary>String.</summary>
		// Token: 0x0400176E RID: 5998
		[__DynamicallyInvokable]
		String = 2,
		/// <summary>Boolean</summary>
		// Token: 0x0400176F RID: 5999
		[__DynamicallyInvokable]
		Boolean,
		/// <summary>Hexadecimal.</summary>
		// Token: 0x04001770 RID: 6000
		[__DynamicallyInvokable]
		Hexadecimal,
		/// <summary>XML.</summary>
		// Token: 0x04001771 RID: 6001
		[__DynamicallyInvokable]
		Xml = 11,
		/// <summary>JSON.</summary>
		// Token: 0x04001772 RID: 6002
		[__DynamicallyInvokable]
		Json,
		/// <summary>HResult.</summary>
		// Token: 0x04001773 RID: 6003
		[__DynamicallyInvokable]
		HResult = 15
	}
}
