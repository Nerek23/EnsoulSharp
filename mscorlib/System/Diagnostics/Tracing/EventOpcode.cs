using System;
using System.Runtime.CompilerServices;

namespace System.Diagnostics.Tracing
{
	/// <summary>Defines the standard operation codes that the event source attaches to events.</summary>
	// Token: 0x0200040A RID: 1034
	[FriendAccessAllowed]
	[__DynamicallyInvokable]
	public enum EventOpcode
	{
		/// <summary>An informational event.</summary>
		// Token: 0x04001736 RID: 5942
		[__DynamicallyInvokable]
		Info,
		/// <summary>An event that is published when an application starts a new transaction or activity. This operation code can be embedded within another transaction or activity when multiple events that have the <see cref="F:System.Diagnostics.Tracing.EventOpcode.Start" /> code follow each other without an intervening event that has a <see cref="F:System.Diagnostics.Tracing.EventOpcode.Stop" /> code.</summary>
		// Token: 0x04001737 RID: 5943
		[__DynamicallyInvokable]
		Start,
		/// <summary>An event that is published when an activity or a transaction in an application ends. The event corresponds to the last unpaired event that has a <see cref="F:System.Diagnostics.Tracing.EventOpcode.Start" /> operation code.</summary>
		// Token: 0x04001738 RID: 5944
		[__DynamicallyInvokable]
		Stop,
		/// <summary>A trace collection start event.</summary>
		// Token: 0x04001739 RID: 5945
		[__DynamicallyInvokable]
		DataCollectionStart,
		/// <summary>A trace collection stop event.</summary>
		// Token: 0x0400173A RID: 5946
		[__DynamicallyInvokable]
		DataCollectionStop,
		/// <summary>An extension event.</summary>
		// Token: 0x0400173B RID: 5947
		[__DynamicallyInvokable]
		Extension,
		/// <summary>An event that is published after an activity in an application replies to an event.</summary>
		// Token: 0x0400173C RID: 5948
		[__DynamicallyInvokable]
		Reply,
		/// <summary>An event that is published after an activity in an application resumes from a suspended state. The event should follow an event that has the <see cref="F:System.Diagnostics.Tracing.EventOpcode.Suspend" /> operation code.</summary>
		// Token: 0x0400173D RID: 5949
		[__DynamicallyInvokable]
		Resume,
		/// <summary>An event that is published when an activity in an application is suspended.</summary>
		// Token: 0x0400173E RID: 5950
		[__DynamicallyInvokable]
		Suspend,
		/// <summary>An event that is published when one activity in an application transfers data or system resources to another activity.</summary>
		// Token: 0x0400173F RID: 5951
		[__DynamicallyInvokable]
		Send,
		/// <summary>An event that is published when one activity in an application receives data.</summary>
		// Token: 0x04001740 RID: 5952
		[__DynamicallyInvokable]
		Receive = 240
	}
}
