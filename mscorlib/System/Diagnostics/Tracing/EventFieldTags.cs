using System;

namespace System.Diagnostics.Tracing
{
	/// <summary>Specifies the user-defined tag that is placed on fields of user-defined types that are passed as <see cref="T:System.Diagnostics.Tracing.EventSource" /> payloads through the <see cref="T:System.Diagnostics.Tracing.EventFieldAttribute" />.</summary>
	// Token: 0x02000415 RID: 1045
	[Flags]
	[__DynamicallyInvokable]
	public enum EventFieldTags
	{
		/// <summary>Specifies no tag and is equal to zero.</summary>
		// Token: 0x04001768 RID: 5992
		[__DynamicallyInvokable]
		None = 0
	}
}
