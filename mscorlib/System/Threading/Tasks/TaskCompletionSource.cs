using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Security.Permissions;

namespace System.Threading.Tasks
{
	/// <summary>Represents the producer side of a <see cref="T:System.Threading.Tasks.Task`1" /> unbound to a delegate, providing access to the consumer side through the <see cref="P:System.Threading.Tasks.TaskCompletionSource`1.Task" /> property.</summary>
	/// <typeparam name="TResult">The type of the result value assocatied with this <see cref="T:System.Threading.Tasks.TaskCompletionSource`1" />.</typeparam>
	// Token: 0x0200054E RID: 1358
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public class TaskCompletionSource<TResult>
	{
		/// <summary>Creates a <see cref="T:System.Threading.Tasks.TaskCompletionSource`1" />.</summary>
		// Token: 0x0600410E RID: 16654 RVA: 0x000F1C66 File Offset: 0x000EFE66
		[__DynamicallyInvokable]
		public TaskCompletionSource()
		{
			this.m_task = new Task<TResult>();
		}

		/// <summary>Creates a <see cref="T:System.Threading.Tasks.TaskCompletionSource`1" /> with the specified options.</summary>
		/// <param name="creationOptions">The options to use when creating the underlying <see cref="T:System.Threading.Tasks.Task`1" />.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="creationOptions" /> represent options invalid for use with a <see cref="T:System.Threading.Tasks.TaskCompletionSource`1" />.</exception>
		// Token: 0x0600410F RID: 16655 RVA: 0x000F1C79 File Offset: 0x000EFE79
		[__DynamicallyInvokable]
		public TaskCompletionSource(TaskCreationOptions creationOptions) : this(null, creationOptions)
		{
		}

		/// <summary>Creates a <see cref="T:System.Threading.Tasks.TaskCompletionSource`1" /> with the specified state.</summary>
		/// <param name="state">The state to use as the underlying <see cref="T:System.Threading.Tasks.Task`1" />'s AsyncState.</param>
		// Token: 0x06004110 RID: 16656 RVA: 0x000F1C83 File Offset: 0x000EFE83
		[__DynamicallyInvokable]
		public TaskCompletionSource(object state) : this(state, TaskCreationOptions.None)
		{
		}

		/// <summary>Creates a <see cref="T:System.Threading.Tasks.TaskCompletionSource`1" /> with the specified state and options.</summary>
		/// <param name="state">The state to use as the underlying <see cref="T:System.Threading.Tasks.Task`1" />'s AsyncState.</param>
		/// <param name="creationOptions">The options to use when creating the underlying <see cref="T:System.Threading.Tasks.Task`1" />.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="creationOptions" /> represent options invalid for use with a <see cref="T:System.Threading.Tasks.TaskCompletionSource`1" />.</exception>
		// Token: 0x06004111 RID: 16657 RVA: 0x000F1C8D File Offset: 0x000EFE8D
		[__DynamicallyInvokable]
		public TaskCompletionSource(object state, TaskCreationOptions creationOptions)
		{
			this.m_task = new Task<TResult>(state, creationOptions);
		}

		/// <summary>Gets the <see cref="T:System.Threading.Tasks.Task`1" /> created by this <see cref="T:System.Threading.Tasks.TaskCompletionSource`1" />.</summary>
		/// <returns>Returns the <see cref="T:System.Threading.Tasks.Task`1" /> created by this <see cref="T:System.Threading.Tasks.TaskCompletionSource`1" />.</returns>
		// Token: 0x170009BC RID: 2492
		// (get) Token: 0x06004112 RID: 16658 RVA: 0x000F1CA2 File Offset: 0x000EFEA2
		[__DynamicallyInvokable]
		public Task<TResult> Task
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_task;
			}
		}

		// Token: 0x06004113 RID: 16659 RVA: 0x000F1CAC File Offset: 0x000EFEAC
		private void SpinUntilCompleted()
		{
			SpinWait spinWait = default(SpinWait);
			while (!this.m_task.IsCompleted)
			{
				spinWait.SpinOnce();
			}
		}

		/// <summary>Attempts to transition the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" /> state and binds it to a specified exception.</summary>
		/// <param name="exception">The exception to bind to this <see cref="T:System.Threading.Tasks.Task`1" />.</param>
		/// <returns>True if the operation was successful; otherwise, false.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="P:System.Threading.Tasks.TaskCompletionSource`1.Task" /> was disposed.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="exception" /> argument is null.</exception>
		// Token: 0x06004114 RID: 16660 RVA: 0x000F1CD8 File Offset: 0x000EFED8
		[__DynamicallyInvokable]
		public bool TrySetException(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			bool flag = this.m_task.TrySetException(exception);
			if (!flag && !this.m_task.IsCompleted)
			{
				this.SpinUntilCompleted();
			}
			return flag;
		}

		/// <summary>Attempts to transition the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" /> state and binds a collection of exception objects to it.</summary>
		/// <param name="exceptions">The collection of exceptions to bind to this <see cref="T:System.Threading.Tasks.Task`1" />.</param>
		/// <returns>True if the operation was successful; otherwise, false.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="P:System.Threading.Tasks.TaskCompletionSource`1.Task" /> was disposed.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="exceptions" /> argument is null.</exception>
		/// <exception cref="T:System.ArgumentException">There are one or more null elements in <paramref name="exceptions" />.  
		///  -or-  
		///  The <paramref name="exceptions" /> collection is empty.</exception>
		// Token: 0x06004115 RID: 16661 RVA: 0x000F1D18 File Offset: 0x000EFF18
		[__DynamicallyInvokable]
		public bool TrySetException(IEnumerable<Exception> exceptions)
		{
			if (exceptions == null)
			{
				throw new ArgumentNullException("exceptions");
			}
			List<Exception> list = new List<Exception>();
			foreach (Exception ex in exceptions)
			{
				if (ex == null)
				{
					throw new ArgumentException(Environment.GetResourceString("TaskCompletionSourceT_TrySetException_NullException"), "exceptions");
				}
				list.Add(ex);
			}
			if (list.Count == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("TaskCompletionSourceT_TrySetException_NoExceptions"), "exceptions");
			}
			bool flag = this.m_task.TrySetException(list);
			if (!flag && !this.m_task.IsCompleted)
			{
				this.SpinUntilCompleted();
			}
			return flag;
		}

		// Token: 0x06004116 RID: 16662 RVA: 0x000F1DD0 File Offset: 0x000EFFD0
		internal bool TrySetException(IEnumerable<ExceptionDispatchInfo> exceptions)
		{
			bool flag = this.m_task.TrySetException(exceptions);
			if (!flag && !this.m_task.IsCompleted)
			{
				this.SpinUntilCompleted();
			}
			return flag;
		}

		/// <summary>Transitions the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" /> state and binds it to a specified exception.</summary>
		/// <param name="exception">The exception to bind to this <see cref="T:System.Threading.Tasks.Task`1" />.</param>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="P:System.Threading.Tasks.TaskCompletionSource`1.Task" /> was disposed.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="exception" /> argument is null.</exception>
		/// <exception cref="T:System.InvalidOperationException">The underlying <see cref="T:System.Threading.Tasks.Task`1" /> is already in one of the three final states: <see cref="F:System.Threading.Tasks.TaskStatus.RanToCompletion" />, <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" />, or <see cref="F:System.Threading.Tasks.TaskStatus.Canceled" />.</exception>
		// Token: 0x06004117 RID: 16663 RVA: 0x000F1E01 File Offset: 0x000F0001
		[__DynamicallyInvokable]
		public void SetException(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			if (!this.TrySetException(exception))
			{
				throw new InvalidOperationException(Environment.GetResourceString("TaskT_TransitionToFinal_AlreadyCompleted"));
			}
		}

		/// <summary>Transitions the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" /> state and binds a collection of exception objects to it.</summary>
		/// <param name="exceptions">The collection of exceptions to bind to this <see cref="T:System.Threading.Tasks.Task`1" />.</param>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="P:System.Threading.Tasks.TaskCompletionSource`1.Task" /> was disposed.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="exceptions" /> argument is null.</exception>
		/// <exception cref="T:System.ArgumentException">There are one or more null elements in <paramref name="exceptions" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The underlying <see cref="T:System.Threading.Tasks.Task`1" /> is already in one of the three final states: <see cref="F:System.Threading.Tasks.TaskStatus.RanToCompletion" />, <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" />, or <see cref="F:System.Threading.Tasks.TaskStatus.Canceled" />.</exception>
		// Token: 0x06004118 RID: 16664 RVA: 0x000F1E2A File Offset: 0x000F002A
		[__DynamicallyInvokable]
		public void SetException(IEnumerable<Exception> exceptions)
		{
			if (!this.TrySetException(exceptions))
			{
				throw new InvalidOperationException(Environment.GetResourceString("TaskT_TransitionToFinal_AlreadyCompleted"));
			}
		}

		/// <summary>Attempts to transition the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the <see cref="F:System.Threading.Tasks.TaskStatus.RanToCompletion" /> state.</summary>
		/// <param name="result">The result value to bind to this <see cref="T:System.Threading.Tasks.Task`1" />.</param>
		/// <returns>True if the operation was successful; otherwise, false.</returns>
		// Token: 0x06004119 RID: 16665 RVA: 0x000F1E48 File Offset: 0x000F0048
		[__DynamicallyInvokable]
		public bool TrySetResult(TResult result)
		{
			bool flag = this.m_task.TrySetResult(result);
			if (!flag && !this.m_task.IsCompleted)
			{
				this.SpinUntilCompleted();
			}
			return flag;
		}

		/// <summary>Transitions the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the <see cref="F:System.Threading.Tasks.TaskStatus.RanToCompletion" /> state.</summary>
		/// <param name="result">The result value to bind to this <see cref="T:System.Threading.Tasks.Task`1" />.</param>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="P:System.Threading.Tasks.TaskCompletionSource`1.Task" /> was disposed.</exception>
		/// <exception cref="T:System.InvalidOperationException">The underlying <see cref="T:System.Threading.Tasks.Task`1" /> is already in one of the three final states: <see cref="F:System.Threading.Tasks.TaskStatus.RanToCompletion" />, <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" />, or <see cref="F:System.Threading.Tasks.TaskStatus.Canceled" />.</exception>
		// Token: 0x0600411A RID: 16666 RVA: 0x000F1E79 File Offset: 0x000F0079
		[__DynamicallyInvokable]
		public void SetResult(TResult result)
		{
			if (!this.TrySetResult(result))
			{
				throw new InvalidOperationException(Environment.GetResourceString("TaskT_TransitionToFinal_AlreadyCompleted"));
			}
		}

		/// <summary>Attempts to transition the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the <see cref="F:System.Threading.Tasks.TaskStatus.Canceled" /> state.</summary>
		/// <returns>True if the operation was successful; false if the operation was unsuccessful or the object has already been disposed.</returns>
		// Token: 0x0600411B RID: 16667 RVA: 0x000F1E94 File Offset: 0x000F0094
		[__DynamicallyInvokable]
		public bool TrySetCanceled()
		{
			return this.TrySetCanceled(default(CancellationToken));
		}

		/// <summary>Attempts to transition the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the <see cref="F:System.Threading.Tasks.TaskStatus.Canceled" /> state and enables a cancellation token to be stored in the canceled task.</summary>
		/// <param name="cancellationToken">A cancellation token.</param>
		/// <returns>
		///   <see langword="true" /> if the operation is successful; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600411C RID: 16668 RVA: 0x000F1EB0 File Offset: 0x000F00B0
		[__DynamicallyInvokable]
		public bool TrySetCanceled(CancellationToken cancellationToken)
		{
			bool flag = this.m_task.TrySetCanceled(cancellationToken);
			if (!flag && !this.m_task.IsCompleted)
			{
				this.SpinUntilCompleted();
			}
			return flag;
		}

		/// <summary>Transitions the underlying <see cref="T:System.Threading.Tasks.Task`1" /> into the <see cref="F:System.Threading.Tasks.TaskStatus.Canceled" /> state.</summary>
		/// <exception cref="T:System.InvalidOperationException">The underlying <see cref="T:System.Threading.Tasks.Task`1" /> is already in one of the three final states: <see cref="F:System.Threading.Tasks.TaskStatus.RanToCompletion" />, <see cref="F:System.Threading.Tasks.TaskStatus.Faulted" />, or <see cref="F:System.Threading.Tasks.TaskStatus.Canceled" />, or if the underlying <see cref="T:System.Threading.Tasks.Task`1" /> has already been disposed.</exception>
		// Token: 0x0600411D RID: 16669 RVA: 0x000F1EE1 File Offset: 0x000F00E1
		[__DynamicallyInvokable]
		public void SetCanceled()
		{
			if (!this.TrySetCanceled())
			{
				throw new InvalidOperationException(Environment.GetResourceString("TaskT_TransitionToFinal_AlreadyCompleted"));
			}
		}

		// Token: 0x04001ABD RID: 6845
		private readonly Task<TResult> m_task;
	}
}
