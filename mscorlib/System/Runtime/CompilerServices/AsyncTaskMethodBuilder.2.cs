using System;
using System.Diagnostics;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
	/// <summary>Represents a builder for asynchronous methods that returns a task and provides a parameter for the result.</summary>
	/// <typeparam name="TResult">The result to use to complete the task.</typeparam>
	// Token: 0x020008C3 RID: 2243
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public struct AsyncTaskMethodBuilder<TResult>
	{
		/// <summary>Creates an instance of the <see cref="T:System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1" /> class.</summary>
		/// <returns>A new instance of the builder.</returns>
		// Token: 0x06005D03 RID: 23811 RVA: 0x00145EA8 File Offset: 0x001440A8
		[__DynamicallyInvokable]
		public static AsyncTaskMethodBuilder<TResult> Create()
		{
			return default(AsyncTaskMethodBuilder<TResult>);
		}

		/// <summary>Begins running the builder with the associated state machine.</summary>
		/// <param name="stateMachine">The state machine instance, passed by reference.</param>
		/// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="stateMachine" /> is <see langword="null" />.</exception>
		// Token: 0x06005D04 RID: 23812 RVA: 0x00145EC0 File Offset: 0x001440C0
		[SecuritySafeCritical]
		[DebuggerStepThrough]
		[__DynamicallyInvokable]
		public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
		{
			if (stateMachine == null)
			{
				throw new ArgumentNullException("stateMachine");
			}
			ExecutionContextSwitcher executionContextSwitcher = default(ExecutionContextSwitcher);
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				ExecutionContext.EstablishCopyOnWriteScope(ref executionContextSwitcher);
				stateMachine.MoveNext();
			}
			finally
			{
				executionContextSwitcher.Undo();
			}
		}

		/// <summary>Associates the builder with the specified state machine.</summary>
		/// <param name="stateMachine">The state machine instance to associate with the builder.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="stateMachine" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The state machine was previously set.</exception>
		// Token: 0x06005D05 RID: 23813 RVA: 0x00145F20 File Offset: 0x00144120
		[__DynamicallyInvokable]
		public void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.m_coreState.SetStateMachine(stateMachine);
		}

		/// <summary>Schedules the state machine to proceed to the next action when the specified awaiter completes.</summary>
		/// <param name="awaiter">The awaiter.</param>
		/// <param name="stateMachine">The state machine.</param>
		/// <typeparam name="TAwaiter">The type of the awaiter.</typeparam>
		/// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
		// Token: 0x06005D06 RID: 23814 RVA: 0x00145F30 File Offset: 0x00144130
		[__DynamicallyInvokable]
		public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
		{
			try
			{
				AsyncMethodBuilderCore.MoveNextRunner runner = null;
				Action completionAction = this.m_coreState.GetCompletionAction(AsyncCausalityTracer.LoggingOn ? this.Task : null, ref runner);
				if (this.m_coreState.m_stateMachine == null)
				{
					Task<TResult> task = this.Task;
					this.m_coreState.PostBoxInitialization(stateMachine, runner, task);
				}
				awaiter.OnCompleted(completionAction);
			}
			catch (Exception exception)
			{
				AsyncMethodBuilderCore.ThrowAsync(exception, null);
			}
		}

		/// <summary>Schedules the state machine to proceed to the next action when the specified awaiter completes. This method can be called from partially trusted code.</summary>
		/// <param name="awaiter">The awaiter.</param>
		/// <param name="stateMachine">The state machine.</param>
		/// <typeparam name="TAwaiter">The type of the awaiter.</typeparam>
		/// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
		// Token: 0x06005D07 RID: 23815 RVA: 0x00145FB4 File Offset: 0x001441B4
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
		{
			try
			{
				AsyncMethodBuilderCore.MoveNextRunner runner = null;
				Action completionAction = this.m_coreState.GetCompletionAction(AsyncCausalityTracer.LoggingOn ? this.Task : null, ref runner);
				if (this.m_coreState.m_stateMachine == null)
				{
					Task<TResult> task = this.Task;
					this.m_coreState.PostBoxInitialization(stateMachine, runner, task);
				}
				awaiter.UnsafeOnCompleted(completionAction);
			}
			catch (Exception exception)
			{
				AsyncMethodBuilderCore.ThrowAsync(exception, null);
			}
		}

		/// <summary>Gets the task for this builder.</summary>
		/// <returns>The task for this builder.</returns>
		// Token: 0x17001015 RID: 4117
		// (get) Token: 0x06005D08 RID: 23816 RVA: 0x00146038 File Offset: 0x00144238
		[__DynamicallyInvokable]
		public Task<TResult> Task
		{
			[__DynamicallyInvokable]
			get
			{
				Task<TResult> task = this.m_task;
				if (task == null)
				{
					task = (this.m_task = new Task<TResult>());
				}
				return task;
			}
		}

		/// <summary>Marks the task as successfully completed.</summary>
		/// <param name="result">The result to use to complete the task.</param>
		/// <exception cref="T:System.InvalidOperationException">The task has already completed.</exception>
		// Token: 0x06005D09 RID: 23817 RVA: 0x00146060 File Offset: 0x00144260
		[__DynamicallyInvokable]
		public void SetResult(TResult result)
		{
			Task<TResult> task = this.m_task;
			if (task == null)
			{
				this.m_task = this.GetTaskForResult(result);
				return;
			}
			if (AsyncCausalityTracer.LoggingOn)
			{
				AsyncCausalityTracer.TraceOperationCompletion(CausalityTraceLevel.Required, task.Id, AsyncCausalityStatus.Completed);
			}
			if (System.Threading.Tasks.Task.s_asyncDebuggingEnabled)
			{
				System.Threading.Tasks.Task.RemoveFromActiveTasks(task.Id);
			}
			if (!task.TrySetResult(result))
			{
				throw new InvalidOperationException(Environment.GetResourceString("TaskT_TransitionToFinal_AlreadyCompleted"));
			}
		}

		// Token: 0x06005D0A RID: 23818 RVA: 0x001460C4 File Offset: 0x001442C4
		internal void SetResult(Task<TResult> completedTask)
		{
			if (this.m_task == null)
			{
				this.m_task = completedTask;
				return;
			}
			this.SetResult(default(TResult));
		}

		/// <summary>Marks the task as failed and binds the specified exception to the task.</summary>
		/// <param name="exception">The exception to bind to the task.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="exception" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The task has already completed.</exception>
		// Token: 0x06005D0B RID: 23819 RVA: 0x001460F4 File Offset: 0x001442F4
		[__DynamicallyInvokable]
		public void SetException(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			Task<TResult> task = this.m_task;
			if (task == null)
			{
				task = this.Task;
			}
			OperationCanceledException ex = exception as OperationCanceledException;
			if (!((ex != null) ? task.TrySetCanceled(ex.CancellationToken, ex) : task.TrySetException(exception)))
			{
				throw new InvalidOperationException(Environment.GetResourceString("TaskT_TransitionToFinal_AlreadyCompleted"));
			}
		}

		// Token: 0x06005D0C RID: 23820 RVA: 0x00146154 File Offset: 0x00144354
		internal void SetNotificationForWaitCompletion(bool enabled)
		{
			this.Task.SetNotificationForWaitCompletion(enabled);
		}

		// Token: 0x17001016 RID: 4118
		// (get) Token: 0x06005D0D RID: 23821 RVA: 0x00146162 File Offset: 0x00144362
		private object ObjectIdForDebugger
		{
			get
			{
				return this.Task;
			}
		}

		// Token: 0x06005D0E RID: 23822 RVA: 0x0014616C File Offset: 0x0014436C
		[SecuritySafeCritical]
		private Task<TResult> GetTaskForResult(TResult result)
		{
			if (default(TResult) != null)
			{
				if (typeof(TResult) == typeof(bool))
				{
					Task<bool> o = ((bool)((object)result)) ? AsyncTaskCache.TrueTask : AsyncTaskCache.FalseTask;
					return JitHelpers.UnsafeCast<Task<TResult>>(o);
				}
				if (typeof(TResult) == typeof(int))
				{
					int num = (int)((object)result);
					if (num < 9 && num >= -1)
					{
						Task<int> o2 = AsyncTaskCache.Int32Tasks[num - -1];
						return JitHelpers.UnsafeCast<Task<TResult>>(o2);
					}
				}
				else if ((typeof(TResult) == typeof(uint) && (uint)((object)result) == 0U) || (typeof(TResult) == typeof(byte) && (byte)((object)result) == 0) || (typeof(TResult) == typeof(sbyte) && (sbyte)((object)result) == 0) || (typeof(TResult) == typeof(char) && (char)((object)result) == '\0') || (typeof(TResult) == typeof(decimal) && 0m == (decimal)((object)result)) || (typeof(TResult) == typeof(long) && (long)((object)result) == 0L) || (typeof(TResult) == typeof(ulong) && (ulong)((object)result) == 0UL) || (typeof(TResult) == typeof(short) && (short)((object)result) == 0) || (typeof(TResult) == typeof(ushort) && (ushort)((object)result) == 0) || (typeof(TResult) == typeof(IntPtr) && (IntPtr)0 == (IntPtr)((object)result)) || (typeof(TResult) == typeof(UIntPtr) && (UIntPtr)0 == (UIntPtr)((object)result)))
				{
					return AsyncTaskMethodBuilder<TResult>.s_defaultResultTask;
				}
			}
			else if (result == null)
			{
				return AsyncTaskMethodBuilder<TResult>.s_defaultResultTask;
			}
			return new Task<TResult>(result);
		}

		// Token: 0x04002990 RID: 10640
		internal static readonly Task<TResult> s_defaultResultTask = AsyncTaskCache.CreateCacheableTask<TResult>(default(TResult));

		// Token: 0x04002991 RID: 10641
		private AsyncMethodBuilderCore m_coreState;

		// Token: 0x04002992 RID: 10642
		private Task<TResult> m_task;
	}
}
