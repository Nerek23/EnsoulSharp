using System;
using System.Runtime.CompilerServices;

namespace System.Diagnostics.Tracing
{
	/// <summary>Specifies the event log channel for the event.</summary>
	// Token: 0x0200040B RID: 1035
	[FriendAccessAllowed]
	[__DynamicallyInvokable]
	public enum EventChannel : byte
	{
		/// <summary>No channel specified.</summary>
		// Token: 0x04001742 RID: 5954
		[__DynamicallyInvokable]
		None,
		/// <summary>The administrator log channel.</summary>
		// Token: 0x04001743 RID: 5955
		[__DynamicallyInvokable]
		Admin = 16,
		/// <summary>The operational channel.</summary>
		// Token: 0x04001744 RID: 5956
		[__DynamicallyInvokable]
		Operational,
		/// <summary>The analytic channel.</summary>
		// Token: 0x04001745 RID: 5957
		[__DynamicallyInvokable]
		Analytic,
		/// <summary>The debug channel.</summary>
		// Token: 0x04001746 RID: 5958
		[__DynamicallyInvokable]
		Debug
	}
}
