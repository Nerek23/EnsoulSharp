using System;

namespace System.Threading.Tasks
{
	/// <summary>Represents the current stage in the lifecycle of a <see cref="T:System.Threading.Tasks.Task" />.</summary>
	// Token: 0x02000530 RID: 1328
	[__DynamicallyInvokable]
	public enum TaskStatus
	{
		/// <summary>The task has been initialized but has not yet been scheduled.</summary>
		// Token: 0x04001A34 RID: 6708
		[__DynamicallyInvokable]
		Created,
		/// <summary>The task is waiting to be activated and scheduled internally by the .NET Framework infrastructure.</summary>
		// Token: 0x04001A35 RID: 6709
		[__DynamicallyInvokable]
		WaitingForActivation,
		/// <summary>The task has been scheduled for execution but has not yet begun executing.</summary>
		// Token: 0x04001A36 RID: 6710
		[__DynamicallyInvokable]
		WaitingToRun,
		/// <summary>The task is running but has not yet completed.</summary>
		// Token: 0x04001A37 RID: 6711
		[__DynamicallyInvokable]
		Running,
		/// <summary>The task has finished executing and is implicitly waiting for attached child tasks to complete.</summary>
		// Token: 0x04001A38 RID: 6712
		[__DynamicallyInvokable]
		WaitingForChildrenToComplete,
		/// <summary>The task completed execution successfully.</summary>
		// Token: 0x04001A39 RID: 6713
		[__DynamicallyInvokable]
		RanToCompletion,
		/// <summary>The task acknowledged cancellation by throwing an OperationCanceledException with its own CancellationToken while the token was in signaled state, or the task's CancellationToken was already signaled before the task started executing. For more information, see Task Cancellation.</summary>
		// Token: 0x04001A3A RID: 6714
		[__DynamicallyInvokable]
		Canceled,
		/// <summary>The task completed due to an unhandled exception.</summary>
		// Token: 0x04001A3B RID: 6715
		[__DynamicallyInvokable]
		Faulted
	}
}
