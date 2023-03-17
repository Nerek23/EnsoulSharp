using System;
using System.Diagnostics;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
	/// <summary>Represents a builder for asynchronous methods that return a task.</summary>
	// Token: 0x020008C2 RID: 2242
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public struct AsyncTaskMethodBuilder
	{
		/// <summary>Creates an instance of the <see cref="T:System.Runtime.CompilerServices.AsyncTaskMethodBuilder" /> class.</summary>
		/// <returns>A new instance of the builder.</returns>
		// Token: 0x06005CF8 RID: 23800 RVA: 0x00145DB4 File Offset: 0x00143FB4
		[__DynamicallyInvokable]
		public static AsyncTaskMethodBuilder Create()
		{
			return default(AsyncTaskMethodBuilder);
		}

		/// <summary>Begins running the builder with the associated state machine.</summary>
		/// <param name="stateMachine">The state machine instance, passed by reference.</param>
		/// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="stateMachine" /> is <see langword="null" />.</exception>
		// Token: 0x06005CF9 RID: 23801 RVA: 0x00145DCC File Offset: 0x00143FCC
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
		// Token: 0x06005CFA RID: 23802 RVA: 0x00145E2C File Offset: 0x0014402C
		[__DynamicallyInvokable]
		public void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.m_builder.SetStateMachine(stateMachine);
		}

		/// <summary>Schedules the state machine to proceed to the next action when the specified awaiter completes.</summary>
		/// <param name="awaiter">The awaiter.</param>
		/// <param name="stateMachine">The state machine.</param>
		/// <typeparam name="TAwaiter">The type of the awaiter.</typeparam>
		/// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
		// Token: 0x06005CFB RID: 23803 RVA: 0x00145E3A File Offset: 0x0014403A
		[__DynamicallyInvokable]
		public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
		{
			this.m_builder.AwaitOnCompleted<TAwaiter, TStateMachine>(ref awaiter, ref stateMachine);
		}

		/// <summary>Schedules the state machine to proceed to the next action when the specified awaiter completes. This method can be called from partially trusted code.</summary>
		/// <param name="awaiter">The awaiter.</param>
		/// <param name="stateMachine">The state machine.</param>
		/// <typeparam name="TAwaiter">The type of the awaiter.</typeparam>
		/// <typeparam name="TStateMachine">The type of the state machine.</typeparam>
		// Token: 0x06005CFC RID: 23804 RVA: 0x00145E49 File Offset: 0x00144049
		[__DynamicallyInvokable]
		public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
		{
			this.m_builder.AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref awaiter, ref stateMachine);
		}

		/// <summary>Gets the task for this builder.</summary>
		/// <returns>The task for this builder.</returns>
		/// <exception cref="T:System.InvalidOperationException">The builder is not initialized.</exception>
		// Token: 0x17001013 RID: 4115
		// (get) Token: 0x06005CFD RID: 23805 RVA: 0x00145E58 File Offset: 0x00144058
		[__DynamicallyInvokable]
		public Task Task
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_builder.Task;
			}
		}

		/// <summary>Marks the task as successfully completed.</summary>
		/// <exception cref="T:System.InvalidOperationException">The task has already completed.  
		///  -or-  
		///  The builder is not initialized.</exception>
		// Token: 0x06005CFE RID: 23806 RVA: 0x00145E65 File Offset: 0x00144065
		[__DynamicallyInvokable]
		public void SetResult()
		{
			this.m_builder.SetResult(AsyncTaskMethodBuilder.s_cachedCompleted);
		}

		/// <summary>Marks the task as failed and binds the specified exception to the task.</summary>
		/// <param name="exception">The exception to bind to the task.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="exception" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The task has already completed.  
		///  -or-  
		///  The builder is not initialized.</exception>
		// Token: 0x06005CFF RID: 23807 RVA: 0x00145E77 File Offset: 0x00144077
		[__DynamicallyInvokable]
		public void SetException(Exception exception)
		{
			this.m_builder.SetException(exception);
		}

		// Token: 0x06005D00 RID: 23808 RVA: 0x00145E85 File Offset: 0x00144085
		internal void SetNotificationForWaitCompletion(bool enabled)
		{
			this.m_builder.SetNotificationForWaitCompletion(enabled);
		}

		// Token: 0x17001014 RID: 4116
		// (get) Token: 0x06005D01 RID: 23809 RVA: 0x00145E93 File Offset: 0x00144093
		private object ObjectIdForDebugger
		{
			get
			{
				return this.Task;
			}
		}

		// Token: 0x0400298E RID: 10638
		private static readonly Task<VoidTaskResult> s_cachedCompleted = AsyncTaskMethodBuilder<VoidTaskResult>.s_defaultResultTask;

		// Token: 0x0400298F RID: 10639
		private AsyncTaskMethodBuilder<VoidTaskResult> m_builder;
	}
}
