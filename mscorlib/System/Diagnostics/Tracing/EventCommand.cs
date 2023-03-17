using System;

namespace System.Diagnostics.Tracing
{
	/// <summary>Describes the command (<see cref="P:System.Diagnostics.Tracing.EventCommandEventArgs.Command" /> property) that is passed to the <see cref="M:System.Diagnostics.Tracing.EventSource.OnEventCommand(System.Diagnostics.Tracing.EventCommandEventArgs)" /> callback.</summary>
	// Token: 0x020003FE RID: 1022
	[__DynamicallyInvokable]
	public enum EventCommand
	{
		/// <summary>Update the event.</summary>
		// Token: 0x040016F1 RID: 5873
		[__DynamicallyInvokable]
		Update,
		/// <summary>Send the manifest.</summary>
		// Token: 0x040016F2 RID: 5874
		[__DynamicallyInvokable]
		SendManifest = -1,
		/// <summary>Enable the event.</summary>
		// Token: 0x040016F3 RID: 5875
		[__DynamicallyInvokable]
		Enable = -2,
		/// <summary>Disable the event.</summary>
		// Token: 0x040016F4 RID: 5876
		[__DynamicallyInvokable]
		Disable = -3
	}
}
