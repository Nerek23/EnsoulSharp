using System;

namespace System.Diagnostics.Tracing
{
	/// <summary>Defines the standard keywords that apply to events.</summary>
	// Token: 0x0200040C RID: 1036
	[Flags]
	[__DynamicallyInvokable]
	public enum EventKeywords : long
	{
		/// <summary>No filtering on keywords is performed when the event is published.</summary>
		// Token: 0x04001748 RID: 5960
		[__DynamicallyInvokable]
		None = 0L,
		/// <summary>All the bits are set to 1, representing every possible group of events.</summary>
		// Token: 0x04001749 RID: 5961
		[__DynamicallyInvokable]
		All = -1L,
		/// <summary>Attached to all Microsoft telemetry events.</summary>
		// Token: 0x0400174A RID: 5962
		MicrosoftTelemetry = 562949953421312L,
		/// <summary>Attached to all Windows Diagnostics Infrastructure (WDI) context events.</summary>
		// Token: 0x0400174B RID: 5963
		[__DynamicallyInvokable]
		WdiContext = 562949953421312L,
		/// <summary>Attached to all Windows Diagnostics Infrastructure (WDI) diagnostic events.</summary>
		// Token: 0x0400174C RID: 5964
		[__DynamicallyInvokable]
		WdiDiagnostic = 1125899906842624L,
		/// <summary>Attached to all Service Quality Mechanism (SQM) events.</summary>
		// Token: 0x0400174D RID: 5965
		[__DynamicallyInvokable]
		Sqm = 2251799813685248L,
		/// <summary>Attached to all failed security audit events. Use this keyword only  for events in the security log.</summary>
		// Token: 0x0400174E RID: 5966
		[__DynamicallyInvokable]
		AuditFailure = 4503599627370496L,
		/// <summary>Attached to all successful security audit events. Use this keyword only for events in the security log.</summary>
		// Token: 0x0400174F RID: 5967
		[__DynamicallyInvokable]
		AuditSuccess = 9007199254740992L,
		/// <summary>Attached to transfer events where the related activity ID (correlation ID) is a computed value and is not guaranteed to be unique (that is, it is not a real GUID).</summary>
		// Token: 0x04001750 RID: 5968
		[__DynamicallyInvokable]
		CorrelationHint = 4503599627370496L,
		/// <summary>Attached to events that are raised by using the <see langword="RaiseEvent" /> function.</summary>
		// Token: 0x04001751 RID: 5969
		[__DynamicallyInvokable]
		EventLogClassic = 36028797018963968L
	}
}
