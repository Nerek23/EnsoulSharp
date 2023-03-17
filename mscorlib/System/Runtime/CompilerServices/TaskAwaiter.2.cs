using System;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
	/// <summary>Represents an object that waits for the completion of an asynchronous task and provides a parameter for the result.</summary>
	/// <typeparam name="TResult">The result for the task.</typeparam>
	// Token: 0x020008CA RID: 2250
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public struct TaskAwaiter<TResult> : ICriticalNotifyCompletion, INotifyCompletion
	{
		// Token: 0x06005D29 RID: 23849 RVA: 0x0014693C File Offset: 0x00144B3C
		internal TaskAwaiter(Task<TResult> task)
		{
			this.m_task = task;
		}

		/// <summary>Gets a value that indicates whether the asynchronous task has completed.</summary>
		/// <returns>
		///   <see langword="true" /> if the task has completed; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.NullReferenceException">The <see cref="T:System.Runtime.CompilerServices.TaskAwaiter`1" /> object was not properly initialized.</exception>
		// Token: 0x17001018 RID: 4120
		// (get) Token: 0x06005D2A RID: 23850 RVA: 0x00146945 File Offset: 0x00144B45
		[__DynamicallyInvokable]
		public bool IsCompleted
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_task.IsCompleted;
			}
		}

		/// <summary>Sets the action to perform when the <see cref="T:System.Runtime.CompilerServices.TaskAwaiter`1" /> object stops waiting for the asynchronous task to complete.</summary>
		/// <param name="continuation">The action to perform when the wait operation completes.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="continuation" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NullReferenceException">The <see cref="T:System.Runtime.CompilerServices.TaskAwaiter`1" /> object was not properly initialized.</exception>
		// Token: 0x06005D2B RID: 23851 RVA: 0x00146952 File Offset: 0x00144B52
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public void OnCompleted(Action continuation)
		{
			TaskAwaiter.OnCompletedInternal(this.m_task, continuation, true, true);
		}

		/// <summary>Schedules the continuation action for the asynchronous task associated with this awaiter.</summary>
		/// <param name="continuation">The action to invoke when the await operation completes.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="continuation" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The awaiter was not properly initialized.</exception>
		// Token: 0x06005D2C RID: 23852 RVA: 0x00146962 File Offset: 0x00144B62
		[SecurityCritical]
		[__DynamicallyInvokable]
		public void UnsafeOnCompleted(Action continuation)
		{
			TaskAwaiter.OnCompletedInternal(this.m_task, continuation, true, false);
		}

		/// <summary>Ends the wait for the completion of the asynchronous task.</summary>
		/// <returns>The result of the completed task.</returns>
		/// <exception cref="T:System.NullReferenceException">The <see cref="T:System.Runtime.CompilerServices.TaskAwaiter`1" /> object was not properly initialized.</exception>
		/// <exception cref="T:System.Threading.Tasks.TaskCanceledException">The task was canceled.</exception>
		/// <exception cref="T:System.Exception">The task completed in a <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" /> state.</exception>
		// Token: 0x06005D2D RID: 23853 RVA: 0x00146972 File Offset: 0x00144B72
		[__DynamicallyInvokable]
		public TResult GetResult()
		{
			TaskAwaiter.ValidateEnd(this.m_task);
			return this.m_task.ResultOnSuccess;
		}

		// Token: 0x0400299B RID: 10651
		private readonly Task<TResult> m_task;
	}
}
