using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace System.Threading
{
	/// <summary>Represents a lightweight alternative to <see cref="T:System.Threading.Semaphore" /> that limits the number of threads that can access a resource or pool of resources concurrently.</summary>
	// Token: 0x02000515 RID: 1301
	[ComVisible(false)]
	[DebuggerDisplay("Current Count = {m_currentCount}")]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public class SemaphoreSlim : IDisposable
	{
		/// <summary>Gets the number of remaining threads that can enter the <see cref="T:System.Threading.SemaphoreSlim" /> object.</summary>
		/// <returns>The number of remaining threads that can enter the semaphore.</returns>
		// Token: 0x1700093C RID: 2364
		// (get) Token: 0x06003DE4 RID: 15844 RVA: 0x000E5D35 File Offset: 0x000E3F35
		[__DynamicallyInvokable]
		public int CurrentCount
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_currentCount;
			}
		}

		/// <summary>Returns a <see cref="T:System.Threading.WaitHandle" /> that can be used to wait on the semaphore.</summary>
		/// <returns>A <see cref="T:System.Threading.WaitHandle" /> that can be used to wait on the semaphore.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.SemaphoreSlim" /> has been disposed.</exception>
		// Token: 0x1700093D RID: 2365
		// (get) Token: 0x06003DE5 RID: 15845 RVA: 0x000E5D40 File Offset: 0x000E3F40
		[__DynamicallyInvokable]
		public WaitHandle AvailableWaitHandle
		{
			[__DynamicallyInvokable]
			get
			{
				this.CheckDispose();
				if (this.m_waitHandle != null)
				{
					return this.m_waitHandle;
				}
				object lockObj = this.m_lockObj;
				lock (lockObj)
				{
					if (this.m_waitHandle == null)
					{
						this.m_waitHandle = new ManualResetEvent(this.m_currentCount != 0);
					}
				}
				return this.m_waitHandle;
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.SemaphoreSlim" /> class, specifying the initial number of requests that can be granted concurrently.</summary>
		/// <param name="initialCount">The initial number of requests for the semaphore that can be granted concurrently.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="initialCount" /> is less than 0.</exception>
		// Token: 0x06003DE6 RID: 15846 RVA: 0x000E5DC0 File Offset: 0x000E3FC0
		[__DynamicallyInvokable]
		public SemaphoreSlim(int initialCount) : this(initialCount, int.MaxValue)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.SemaphoreSlim" /> class, specifying the initial and maximum number of requests that can be granted concurrently.</summary>
		/// <param name="initialCount">The initial number of requests for the semaphore that can be granted concurrently.</param>
		/// <param name="maxCount">The maximum number of requests for the semaphore that can be granted concurrently.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="initialCount" /> is less than 0, or <paramref name="initialCount" /> is greater than <paramref name="maxCount" />, or <paramref name="maxCount" /> is equal to or less than 0.</exception>
		// Token: 0x06003DE7 RID: 15847 RVA: 0x000E5DD0 File Offset: 0x000E3FD0
		[__DynamicallyInvokable]
		public SemaphoreSlim(int initialCount, int maxCount)
		{
			if (initialCount < 0 || initialCount > maxCount)
			{
				throw new ArgumentOutOfRangeException("initialCount", initialCount, SemaphoreSlim.GetResourceString("SemaphoreSlim_ctor_InitialCountWrong"));
			}
			if (maxCount <= 0)
			{
				throw new ArgumentOutOfRangeException("maxCount", maxCount, SemaphoreSlim.GetResourceString("SemaphoreSlim_ctor_MaxCountWrong"));
			}
			this.m_maxCount = maxCount;
			this.m_lockObj = new object();
			this.m_currentCount = initialCount;
		}

		/// <summary>Blocks the current thread until it can enter the <see cref="T:System.Threading.SemaphoreSlim" />.</summary>
		/// <exception cref="T:System.ObjectDisposedException">The current instance has already been disposed.</exception>
		// Token: 0x06003DE8 RID: 15848 RVA: 0x000E5E40 File Offset: 0x000E4040
		[__DynamicallyInvokable]
		public void Wait()
		{
			this.Wait(-1, default(CancellationToken));
		}

		/// <summary>Blocks the current thread until it can enter the <see cref="T:System.Threading.SemaphoreSlim" />, while observing a <see cref="T:System.Threading.CancellationToken" />.</summary>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> token to observe.</param>
		/// <exception cref="T:System.OperationCanceledException">
		///   <paramref name="cancellationToken" /> was canceled.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The current instance has already been disposed.  
		///  -or-  
		///  The <see cref="T:System.Threading.CancellationTokenSource" /> that created <paramref name="cancellationToken" /> has already been disposed.</exception>
		// Token: 0x06003DE9 RID: 15849 RVA: 0x000E5E5E File Offset: 0x000E405E
		[__DynamicallyInvokable]
		public void Wait(CancellationToken cancellationToken)
		{
			this.Wait(-1, cancellationToken);
		}

		/// <summary>Blocks the current thread until it can enter the <see cref="T:System.Threading.SemaphoreSlim" />, using a <see cref="T:System.TimeSpan" /> to specify the timeout.</summary>
		/// <param name="timeout">A <see cref="T:System.TimeSpan" /> that represents the number of milliseconds to wait, a <see cref="T:System.TimeSpan" /> that represents -1 milliseconds to wait indefinitely, or a <see cref="T:System.TimeSpan" /> that represents 0 milliseconds to test the wait handle and return immediately.</param>
		/// <returns>
		///   <see langword="true" /> if the current thread successfully entered the <see cref="T:System.Threading.SemaphoreSlim" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="timeout" /> is a negative number other than -1, which represents an infinite timeout -or- timeout is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The semaphoreSlim instance has been disposed <paramref name="." /></exception>
		// Token: 0x06003DEA RID: 15850 RVA: 0x000E5E6C File Offset: 0x000E406C
		[__DynamicallyInvokable]
		public bool Wait(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", timeout, SemaphoreSlim.GetResourceString("SemaphoreSlim_Wait_TimeoutWrong"));
			}
			return this.Wait((int)timeout.TotalMilliseconds, default(CancellationToken));
		}

		/// <summary>Blocks the current thread until it can enter the <see cref="T:System.Threading.SemaphoreSlim" />, using a <see cref="T:System.TimeSpan" /> that specifies the timeout, while observing a <see cref="T:System.Threading.CancellationToken" />.</summary>
		/// <param name="timeout">A <see cref="T:System.TimeSpan" /> that represents the number of milliseconds to wait, a <see cref="T:System.TimeSpan" /> that represents -1 milliseconds to wait indefinitely, or a <see cref="T:System.TimeSpan" /> that represents 0 milliseconds to test the wait handle and return immediately.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> to observe.</param>
		/// <returns>
		///   <see langword="true" /> if the current thread successfully entered the <see cref="T:System.Threading.SemaphoreSlim" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.OperationCanceledException">
		///   <paramref name="cancellationToken" /> was canceled.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="timeout" /> is a negative number other than -1, which represents an infinite timeout -or- timeout is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The semaphoreSlim instance has been disposed <paramref name="." /><paramref name="-or-" />  
		///  The <see cref="T:System.Threading.CancellationTokenSource" /> that created <paramref name="cancellationToken" /> has already been disposed.</exception>
		// Token: 0x06003DEB RID: 15851 RVA: 0x000E5EC4 File Offset: 0x000E40C4
		[__DynamicallyInvokable]
		public bool Wait(TimeSpan timeout, CancellationToken cancellationToken)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", timeout, SemaphoreSlim.GetResourceString("SemaphoreSlim_Wait_TimeoutWrong"));
			}
			return this.Wait((int)timeout.TotalMilliseconds, cancellationToken);
		}

		/// <summary>Blocks the current thread until it can enter the <see cref="T:System.Threading.SemaphoreSlim" />, using a 32-bit signed integer that specifies the timeout.</summary>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait, <see cref="F:System.Threading.Timeout.Infinite" />(-1) to wait indefinitely, or zero to test the state of the wait handle and return immediately.</param>
		/// <returns>
		///   <see langword="true" /> if the current thread successfully entered the <see cref="T:System.Threading.SemaphoreSlim" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="millisecondsTimeout" /> is a negative number other than -1, which represents an infinite timeout -or- timeout is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.SemaphoreSlim" /> has been disposed.</exception>
		// Token: 0x06003DEC RID: 15852 RVA: 0x000E5F14 File Offset: 0x000E4114
		[__DynamicallyInvokable]
		public bool Wait(int millisecondsTimeout)
		{
			return this.Wait(millisecondsTimeout, default(CancellationToken));
		}

		/// <summary>Blocks the current thread until it can enter the <see cref="T:System.Threading.SemaphoreSlim" />, using a 32-bit signed integer that specifies the timeout, while observing a <see cref="T:System.Threading.CancellationToken" />.</summary>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait, <see cref="F:System.Threading.Timeout.Infinite" />(-1) to wait indefinitely, or zero to test the state of the wait handle and return immediately.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> to observe.</param>
		/// <returns>
		///   <see langword="true" /> if the current thread successfully entered the <see cref="T:System.Threading.SemaphoreSlim" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.OperationCanceledException">
		///   <paramref name="cancellationToken" /> was canceled.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="millisecondsTimeout" /> is a negative number other than -1, which represents an infinite timeout -or- timeout is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.SemaphoreSlim" /> instance has been disposed, or the <see cref="T:System.Threading.CancellationTokenSource" /> that created <paramref name="cancellationToken" /> has been disposed.</exception>
		// Token: 0x06003DED RID: 15853 RVA: 0x000E5F34 File Offset: 0x000E4134
		[__DynamicallyInvokable]
		public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken)
		{
			this.CheckDispose();
			if (millisecondsTimeout < -1)
			{
				throw new ArgumentOutOfRangeException("totalMilliSeconds", millisecondsTimeout, SemaphoreSlim.GetResourceString("SemaphoreSlim_Wait_TimeoutWrong"));
			}
			cancellationToken.ThrowIfCancellationRequested();
			uint startTime = 0U;
			if (millisecondsTimeout != -1 && millisecondsTimeout > 0)
			{
				startTime = TimeoutHelper.GetTime();
			}
			bool result = false;
			Task<bool> task = null;
			bool flag = false;
			CancellationTokenRegistration cancellationTokenRegistration = cancellationToken.InternalRegisterWithoutEC(SemaphoreSlim.s_cancellationTokenCanceledEventHandler, this);
			try
			{
				SpinWait spinWait = default(SpinWait);
				while (this.m_currentCount == 0 && !spinWait.NextSpinWillYield)
				{
					spinWait.SpinOnce();
				}
				try
				{
				}
				finally
				{
					Monitor.Enter(this.m_lockObj, ref flag);
					if (flag)
					{
						this.m_waitCount++;
					}
				}
				if (this.m_asyncHead != null)
				{
					task = this.WaitAsync(millisecondsTimeout, cancellationToken);
				}
				else
				{
					OperationCanceledException ex = null;
					if (this.m_currentCount == 0)
					{
						if (millisecondsTimeout == 0)
						{
							return false;
						}
						try
						{
							result = this.WaitUntilCountOrTimeout(millisecondsTimeout, startTime, cancellationToken);
						}
						catch (OperationCanceledException ex2)
						{
							ex = ex2;
						}
					}
					if (this.m_currentCount > 0)
					{
						result = true;
						this.m_currentCount--;
					}
					else if (ex != null)
					{
						throw ex;
					}
					if (this.m_waitHandle != null && this.m_currentCount == 0)
					{
						this.m_waitHandle.Reset();
					}
				}
			}
			finally
			{
				if (flag)
				{
					this.m_waitCount--;
					Monitor.Exit(this.m_lockObj);
				}
				cancellationTokenRegistration.Dispose();
			}
			if (task == null)
			{
				return result;
			}
			return task.GetAwaiter().GetResult();
		}

		// Token: 0x06003DEE RID: 15854 RVA: 0x000E60D4 File Offset: 0x000E42D4
		private bool WaitUntilCountOrTimeout(int millisecondsTimeout, uint startTime, CancellationToken cancellationToken)
		{
			int num = -1;
			while (this.m_currentCount == 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
				if (millisecondsTimeout != -1)
				{
					num = TimeoutHelper.UpdateTimeOut(startTime, millisecondsTimeout);
					if (num <= 0)
					{
						return false;
					}
				}
				if (!Monitor.Wait(this.m_lockObj, num))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>Asynchronously waits to enter the <see cref="T:System.Threading.SemaphoreSlim" />.</summary>
		/// <returns>A task that will complete when the semaphore has been entered.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.SemaphoreSlim" /> has been disposed.</exception>
		// Token: 0x06003DEF RID: 15855 RVA: 0x000E611C File Offset: 0x000E431C
		[__DynamicallyInvokable]
		public Task WaitAsync()
		{
			return this.WaitAsync(-1, default(CancellationToken));
		}

		/// <summary>Asynchronously waits to enter the <see cref="T:System.Threading.SemaphoreSlim" />, while observing a <see cref="T:System.Threading.CancellationToken" />.</summary>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> token to observe.</param>
		/// <returns>A task that will complete when the semaphore has been entered.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The current instance has already been disposed.</exception>
		/// <exception cref="T:System.OperationCanceledException">
		///   <paramref name="cancellationToken" /> was canceled.</exception>
		// Token: 0x06003DF0 RID: 15856 RVA: 0x000E6139 File Offset: 0x000E4339
		[__DynamicallyInvokable]
		public Task WaitAsync(CancellationToken cancellationToken)
		{
			return this.WaitAsync(-1, cancellationToken);
		}

		/// <summary>Asynchronously waits to enter the <see cref="T:System.Threading.SemaphoreSlim" />, using a 32-bit signed integer to measure the time interval.</summary>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait, <see cref="F:System.Threading.Timeout.Infinite" /> (-1) to wait indefinitely, or zero to test the state of the wait handle and return immediately.</param>
		/// <returns>A task that will complete with a result of <see langword="true" /> if the current thread successfully entered the <see cref="T:System.Threading.SemaphoreSlim" />, otherwise with a result of <see langword="false" />.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The current instance has already been disposed.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="millisecondsTimeout" /> is a negative number other than -1, which represents an infinite timeout -or- timeout is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		// Token: 0x06003DF1 RID: 15857 RVA: 0x000E6144 File Offset: 0x000E4344
		[__DynamicallyInvokable]
		public Task<bool> WaitAsync(int millisecondsTimeout)
		{
			return this.WaitAsync(millisecondsTimeout, default(CancellationToken));
		}

		/// <summary>Asynchronously waits to enter the <see cref="T:System.Threading.SemaphoreSlim" />, using a <see cref="T:System.TimeSpan" /> to measure the time interval.</summary>
		/// <param name="timeout">A <see cref="T:System.TimeSpan" /> that represents the number of milliseconds to wait, a <see cref="T:System.TimeSpan" /> that represents -1 milliseconds to wait indefinitely, or a <see cref="T:System.TimeSpan" /> that represents 0 milliseconds to test the wait handle and return immediately.</param>
		/// <returns>A task that will complete with a result of <see langword="true" /> if the current thread successfully entered the <see cref="T:System.Threading.SemaphoreSlim" />, otherwise with a result of <see langword="false" />.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The current instance has already been disposed.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="millisecondsTimeout" /> is a negative number other than -1, which represents an infinite timeout -or- timeout is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		// Token: 0x06003DF2 RID: 15858 RVA: 0x000E6164 File Offset: 0x000E4364
		[__DynamicallyInvokable]
		public Task<bool> WaitAsync(TimeSpan timeout)
		{
			return this.WaitAsync(timeout, default(CancellationToken));
		}

		/// <summary>Asynchronously waits to enter the <see cref="T:System.Threading.SemaphoreSlim" />, using a <see cref="T:System.TimeSpan" /> to measure the time interval, while observing a <see cref="T:System.Threading.CancellationToken" />.</summary>
		/// <param name="timeout">A <see cref="T:System.TimeSpan" /> that represents the number of milliseconds to wait, a <see cref="T:System.TimeSpan" /> that represents -1 milliseconds to wait indefinitely, or a <see cref="T:System.TimeSpan" /> that represents 0 milliseconds to test the wait handle and return immediately.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> token to observe.</param>
		/// <returns>A task that will complete with a result of <see langword="true" /> if the current thread successfully entered the <see cref="T:System.Threading.SemaphoreSlim" />, otherwise with a result of <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="millisecondsTimeout" /> is a negative number other than -1, which represents an infinite timeout -or- timeout is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.OperationCanceledException">
		///   <paramref name="cancellationToken" /> was canceled.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.SemaphoreSlim" /> has been disposed.</exception>
		// Token: 0x06003DF3 RID: 15859 RVA: 0x000E6184 File Offset: 0x000E4384
		[__DynamicallyInvokable]
		public Task<bool> WaitAsync(TimeSpan timeout, CancellationToken cancellationToken)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", timeout, SemaphoreSlim.GetResourceString("SemaphoreSlim_Wait_TimeoutWrong"));
			}
			return this.WaitAsync((int)timeout.TotalMilliseconds, cancellationToken);
		}

		/// <summary>Asynchronously waits to enter the <see cref="T:System.Threading.SemaphoreSlim" />, using a 32-bit signed integer to measure the time interval, while observing a <see cref="T:System.Threading.CancellationToken" />.</summary>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait, <see cref="F:System.Threading.Timeout.Infinite" /> (-1) to wait indefinitely, or zero to test the state of the wait handle and return immediately.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> to observe.</param>
		/// <returns>A task that will complete with a result of <see langword="true" /> if the current thread successfully entered the <see cref="T:System.Threading.SemaphoreSlim" />, otherwise with a result of <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="millisecondsTimeout" /> is a number other than -1, which represents an infinite timeout -or- timeout is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The current instance has already been disposed.</exception>
		/// <exception cref="T:System.OperationCanceledException">
		///   <paramref name="cancellationToken" /> was canceled.</exception>
		// Token: 0x06003DF4 RID: 15860 RVA: 0x000E61D4 File Offset: 0x000E43D4
		[__DynamicallyInvokable]
		public Task<bool> WaitAsync(int millisecondsTimeout, CancellationToken cancellationToken)
		{
			this.CheckDispose();
			if (millisecondsTimeout < -1)
			{
				throw new ArgumentOutOfRangeException("totalMilliSeconds", millisecondsTimeout, SemaphoreSlim.GetResourceString("SemaphoreSlim_Wait_TimeoutWrong"));
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCancellation<bool>(cancellationToken);
			}
			object lockObj = this.m_lockObj;
			Task<bool> result;
			lock (lockObj)
			{
				if (this.m_currentCount > 0)
				{
					this.m_currentCount--;
					if (this.m_waitHandle != null && this.m_currentCount == 0)
					{
						this.m_waitHandle.Reset();
					}
					result = SemaphoreSlim.s_trueTask;
				}
				else
				{
					SemaphoreSlim.TaskNode taskNode = this.CreateAndAddAsyncWaiter();
					result = ((millisecondsTimeout == -1 && !cancellationToken.CanBeCanceled) ? taskNode : this.WaitUntilCountOrTimeoutAsync(taskNode, millisecondsTimeout, cancellationToken));
				}
			}
			return result;
		}

		// Token: 0x06003DF5 RID: 15861 RVA: 0x000E62AC File Offset: 0x000E44AC
		private SemaphoreSlim.TaskNode CreateAndAddAsyncWaiter()
		{
			SemaphoreSlim.TaskNode taskNode = new SemaphoreSlim.TaskNode();
			if (this.m_asyncHead == null)
			{
				this.m_asyncHead = taskNode;
				this.m_asyncTail = taskNode;
			}
			else
			{
				this.m_asyncTail.Next = taskNode;
				taskNode.Prev = this.m_asyncTail;
				this.m_asyncTail = taskNode;
			}
			return taskNode;
		}

		// Token: 0x06003DF6 RID: 15862 RVA: 0x000E62F8 File Offset: 0x000E44F8
		private bool RemoveAsyncWaiter(SemaphoreSlim.TaskNode task)
		{
			bool result = this.m_asyncHead == task || task.Prev != null;
			if (task.Next != null)
			{
				task.Next.Prev = task.Prev;
			}
			if (task.Prev != null)
			{
				task.Prev.Next = task.Next;
			}
			if (this.m_asyncHead == task)
			{
				this.m_asyncHead = task.Next;
			}
			if (this.m_asyncTail == task)
			{
				this.m_asyncTail = task.Prev;
			}
			task.Next = (task.Prev = null);
			return result;
		}

		// Token: 0x06003DF7 RID: 15863 RVA: 0x000E6388 File Offset: 0x000E4588
		private async Task<bool> WaitUntilCountOrTimeoutAsync(SemaphoreSlim.TaskNode asyncWaiter, int millisecondsTimeout, CancellationToken cancellationToken)
		{
			using (CancellationTokenSource cts = cancellationToken.CanBeCanceled ? CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, default(CancellationToken)) : new CancellationTokenSource())
			{
				Task<Task> task = Task.WhenAny(new Task[]
				{
					asyncWaiter,
					Task.Delay(millisecondsTimeout, cts.Token)
				});
				object obj = asyncWaiter;
				Task task2 = await task.ConfigureAwait(false);
				if (obj == task2)
				{
					obj = null;
					cts.Cancel();
					return true;
				}
			}
			CancellationTokenSource cts = null;
			object lockObj = this.m_lockObj;
			lock (lockObj)
			{
				if (this.RemoveAsyncWaiter(asyncWaiter))
				{
					cancellationToken.ThrowIfCancellationRequested();
					return false;
				}
			}
			return await asyncWaiter.ConfigureAwait(false);
		}

		/// <summary>Releases the <see cref="T:System.Threading.SemaphoreSlim" /> object once.</summary>
		/// <returns>The previous count of the <see cref="T:System.Threading.SemaphoreSlim" />.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The current instance has already been disposed.</exception>
		/// <exception cref="T:System.Threading.SemaphoreFullException">The <see cref="T:System.Threading.SemaphoreSlim" /> has already reached its maximum size.</exception>
		// Token: 0x06003DF8 RID: 15864 RVA: 0x000E63E5 File Offset: 0x000E45E5
		[__DynamicallyInvokable]
		public int Release()
		{
			return this.Release(1);
		}

		/// <summary>Releases the <see cref="T:System.Threading.SemaphoreSlim" /> object a specified number of times.</summary>
		/// <param name="releaseCount">The number of times to exit the semaphore.</param>
		/// <returns>The previous count of the <see cref="T:System.Threading.SemaphoreSlim" />.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The current instance has already been disposed.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="releaseCount" /> is less than 1.</exception>
		/// <exception cref="T:System.Threading.SemaphoreFullException">The <see cref="T:System.Threading.SemaphoreSlim" /> has already reached its maximum size.</exception>
		// Token: 0x06003DF9 RID: 15865 RVA: 0x000E63F0 File Offset: 0x000E45F0
		[__DynamicallyInvokable]
		public int Release(int releaseCount)
		{
			this.CheckDispose();
			if (releaseCount < 1)
			{
				throw new ArgumentOutOfRangeException("releaseCount", releaseCount, SemaphoreSlim.GetResourceString("SemaphoreSlim_Release_CountWrong"));
			}
			object lockObj = this.m_lockObj;
			int num2;
			lock (lockObj)
			{
				int num = this.m_currentCount;
				num2 = num;
				if (this.m_maxCount - num < releaseCount)
				{
					throw new SemaphoreFullException();
				}
				num += releaseCount;
				int waitCount = this.m_waitCount;
				if (num == 1 || waitCount == 1)
				{
					Monitor.Pulse(this.m_lockObj);
				}
				else if (waitCount > 1)
				{
					Monitor.PulseAll(this.m_lockObj);
				}
				if (this.m_asyncHead != null)
				{
					int num3 = num - waitCount;
					while (num3 > 0 && this.m_asyncHead != null)
					{
						num--;
						num3--;
						SemaphoreSlim.TaskNode asyncHead = this.m_asyncHead;
						this.RemoveAsyncWaiter(asyncHead);
						SemaphoreSlim.QueueWaiterTask(asyncHead);
					}
				}
				this.m_currentCount = num;
				if (this.m_waitHandle != null && num2 == 0 && num > 0)
				{
					this.m_waitHandle.Set();
				}
			}
			return num2;
		}

		// Token: 0x06003DFA RID: 15866 RVA: 0x000E6508 File Offset: 0x000E4708
		[SecuritySafeCritical]
		private static void QueueWaiterTask(SemaphoreSlim.TaskNode waiterTask)
		{
			ThreadPool.UnsafeQueueCustomWorkItem(waiterTask, false);
		}

		/// <summary>Releases all resources used by the current instance of the <see cref="T:System.Threading.SemaphoreSlim" /> class.</summary>
		// Token: 0x06003DFB RID: 15867 RVA: 0x000E6511 File Offset: 0x000E4711
		[__DynamicallyInvokable]
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>Releases the unmanaged resources used by the <see cref="T:System.Threading.SemaphoreSlim" />, and optionally releases the managed resources.</summary>
		/// <param name="disposing">
		///   <see langword="true" /> to release both managed and unmanaged resources; <see langword="false" /> to release only unmanaged resources.</param>
		// Token: 0x06003DFC RID: 15868 RVA: 0x000E6520 File Offset: 0x000E4720
		[__DynamicallyInvokable]
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.m_waitHandle != null)
				{
					this.m_waitHandle.Close();
					this.m_waitHandle = null;
				}
				this.m_lockObj = null;
				this.m_asyncHead = null;
				this.m_asyncTail = null;
			}
		}

		// Token: 0x06003DFD RID: 15869 RVA: 0x000E655C File Offset: 0x000E475C
		private static void CancellationTokenCanceledEventHandler(object obj)
		{
			SemaphoreSlim semaphoreSlim = obj as SemaphoreSlim;
			object lockObj = semaphoreSlim.m_lockObj;
			lock (lockObj)
			{
				Monitor.PulseAll(semaphoreSlim.m_lockObj);
			}
		}

		// Token: 0x06003DFE RID: 15870 RVA: 0x000E65A8 File Offset: 0x000E47A8
		private void CheckDispose()
		{
			if (this.m_lockObj == null)
			{
				throw new ObjectDisposedException(null, SemaphoreSlim.GetResourceString("SemaphoreSlim_Disposed"));
			}
		}

		// Token: 0x06003DFF RID: 15871 RVA: 0x000E65C3 File Offset: 0x000E47C3
		private static string GetResourceString(string str)
		{
			return Environment.GetResourceString(str);
		}

		// Token: 0x040019C5 RID: 6597
		private volatile int m_currentCount;

		// Token: 0x040019C6 RID: 6598
		private readonly int m_maxCount;

		// Token: 0x040019C7 RID: 6599
		private volatile int m_waitCount;

		// Token: 0x040019C8 RID: 6600
		private object m_lockObj;

		// Token: 0x040019C9 RID: 6601
		private volatile ManualResetEvent m_waitHandle;

		// Token: 0x040019CA RID: 6602
		private SemaphoreSlim.TaskNode m_asyncHead;

		// Token: 0x040019CB RID: 6603
		private SemaphoreSlim.TaskNode m_asyncTail;

		// Token: 0x040019CC RID: 6604
		private static readonly Task<bool> s_trueTask = new Task<bool>(false, true, (TaskCreationOptions)16384, default(CancellationToken));

		// Token: 0x040019CD RID: 6605
		private const int NO_MAXIMUM = 2147483647;

		// Token: 0x040019CE RID: 6606
		private static Action<object> s_cancellationTokenCanceledEventHandler = new Action<object>(SemaphoreSlim.CancellationTokenCanceledEventHandler);

		// Token: 0x02000BC9 RID: 3017
		private sealed class TaskNode : Task<bool>, IThreadPoolWorkItem
		{
			// Token: 0x06006E62 RID: 28258 RVA: 0x0017BD18 File Offset: 0x00179F18
			internal TaskNode()
			{
			}

			// Token: 0x06006E63 RID: 28259 RVA: 0x0017BD20 File Offset: 0x00179F20
			[SecurityCritical]
			void IThreadPoolWorkItem.ExecuteWorkItem()
			{
				bool flag = base.TrySetResult(true);
			}

			// Token: 0x06006E64 RID: 28260 RVA: 0x0017BD35 File Offset: 0x00179F35
			[SecurityCritical]
			void IThreadPoolWorkItem.MarkAborted(ThreadAbortException tae)
			{
			}

			// Token: 0x04003565 RID: 13669
			internal SemaphoreSlim.TaskNode Prev;

			// Token: 0x04003566 RID: 13670
			internal SemaphoreSlim.TaskNode Next;
		}
	}
}
