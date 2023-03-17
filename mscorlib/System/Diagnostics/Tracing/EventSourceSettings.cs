﻿using System;

namespace System.Diagnostics.Tracing
{
	/// <summary>Specifies configuration options for an event source.</summary>
	// Token: 0x020003F4 RID: 1012
	[Flags]
	[__DynamicallyInvokable]
	public enum EventSourceSettings
	{
		/// <summary>None of the special configuration options are enabled.</summary>
		// Token: 0x040016B6 RID: 5814
		[__DynamicallyInvokable]
		Default = 0,
		/// <summary>The event source throws an exception when an error occurs.</summary>
		// Token: 0x040016B7 RID: 5815
		[__DynamicallyInvokable]
		ThrowOnEventWriteErrors = 1,
		/// <summary>The ETW listener should use a manifest-based format when raising events. Setting this option is a directive to the ETW listener should use manifest-based format when raising events. This is the default option when defining a type derived from <see cref="T:System.Diagnostics.Tracing.EventSource" /> using one of the protected <see cref="T:System.Diagnostics.Tracing.EventSource" /> constructors.</summary>
		// Token: 0x040016B8 RID: 5816
		[__DynamicallyInvokable]
		EtwManifestEventFormat = 4,
		/// <summary>The ETW listener should use self-describing event format. This is the default option when creating a new instance of the <see cref="T:System.Diagnostics.Tracing.EventSource" /> using one of the public <see cref="T:System.Diagnostics.Tracing.EventSource" /> constructors.</summary>
		// Token: 0x040016B9 RID: 5817
		[__DynamicallyInvokable]
		EtwSelfDescribingEventFormat = 8
	}
}
