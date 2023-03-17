using System;

namespace System.Diagnostics.Tracing
{
	/// <summary>Identifies the level of an event.</summary>
	// Token: 0x02000408 RID: 1032
	[__DynamicallyInvokable]
	public enum EventLevel
	{
		/// <summary>No level filtering is done on the event.</summary>
		// Token: 0x0400172D RID: 5933
		[__DynamicallyInvokable]
		LogAlways,
		/// <summary>This level corresponds to a critical error, which is a serious error that has caused a major failure.</summary>
		// Token: 0x0400172E RID: 5934
		[__DynamicallyInvokable]
		Critical,
		/// <summary>This level adds standard errors that signify a problem.</summary>
		// Token: 0x0400172F RID: 5935
		[__DynamicallyInvokable]
		Error,
		/// <summary>This level adds warning events (for example, events that are published because a disk is nearing full capacity).</summary>
		// Token: 0x04001730 RID: 5936
		[__DynamicallyInvokable]
		Warning,
		/// <summary>This level adds informational events or messages that are not errors. These events can help trace the progress or state of an application.</summary>
		// Token: 0x04001731 RID: 5937
		[__DynamicallyInvokable]
		Informational,
		/// <summary>This level adds lengthy events or messages. It causes all events to be logged.</summary>
		// Token: 0x04001732 RID: 5938
		[__DynamicallyInvokable]
		Verbose
	}
}
