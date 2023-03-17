using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Security;
using System.Security.Permissions;

namespace System.Threading
{
	/// <summary>Provides a pool of threads that can be used to execute tasks, post work items, process asynchronous I/O, wait on behalf of other threads, and process timers.</summary>
	// Token: 0x020004F9 RID: 1273
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public static class ThreadPool
	{
		/// <summary>Sets the number of requests to the thread pool that can be active concurrently. All requests above that number remain queued until thread pool threads become available.</summary>
		/// <param name="workerThreads">The maximum number of worker threads in the thread pool.</param>
		/// <param name="completionPortThreads">The maximum number of asynchronous I/O threads in the thread pool.</param>
		/// <returns>
		///   <see langword="true" /> if the change is successful; otherwise, <see langword="false" />.</returns>
		// Token: 0x06003CD6 RID: 15574 RVA: 0x000E2CA4 File Offset: 0x000E0EA4
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		public static bool SetMaxThreads(int workerThreads, int completionPortThreads)
		{
			return ThreadPool.SetMaxThreadsNative(workerThreads, completionPortThreads);
		}

		/// <summary>Retrieves the number of requests to the thread pool that can be active concurrently. All requests above that number remain queued until thread pool threads become available.</summary>
		/// <param name="workerThreads">The maximum number of worker threads in the thread pool.</param>
		/// <param name="completionPortThreads">The maximum number of asynchronous I/O threads in the thread pool.</param>
		// Token: 0x06003CD7 RID: 15575 RVA: 0x000E2CAD File Offset: 0x000E0EAD
		[SecuritySafeCritical]
		public static void GetMaxThreads(out int workerThreads, out int completionPortThreads)
		{
			ThreadPool.GetMaxThreadsNative(out workerThreads, out completionPortThreads);
		}

		/// <summary>Sets the minimum number of threads the thread pool creates on demand, as new requests are made, before switching to an algorithm for managing thread creation and destruction.</summary>
		/// <param name="workerThreads">The minimum number of worker threads that the thread pool creates on demand.</param>
		/// <param name="completionPortThreads">The minimum number of asynchronous I/O threads that the thread pool creates on demand.</param>
		/// <returns>
		///   <see langword="true" /> if the change is successful; otherwise, <see langword="false" />.</returns>
		// Token: 0x06003CD8 RID: 15576 RVA: 0x000E2CB6 File Offset: 0x000E0EB6
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		public static bool SetMinThreads(int workerThreads, int completionPortThreads)
		{
			return ThreadPool.SetMinThreadsNative(workerThreads, completionPortThreads);
		}

		/// <summary>Retrieves the minimum number of threads the thread pool creates on demand, as new requests are made, before switching to an algorithm for managing thread creation and destruction.</summary>
		/// <param name="workerThreads">When this method returns, contains the minimum number of worker threads that the thread pool creates on demand.</param>
		/// <param name="completionPortThreads">When this method returns, contains the minimum number of asynchronous I/O threads that the thread pool creates on demand.</param>
		// Token: 0x06003CD9 RID: 15577 RVA: 0x000E2CBF File Offset: 0x000E0EBF
		[SecuritySafeCritical]
		public static void GetMinThreads(out int workerThreads, out int completionPortThreads)
		{
			ThreadPool.GetMinThreadsNative(out workerThreads, out completionPortThreads);
		}

		/// <summary>Retrieves the difference between the maximum number of thread pool threads returned by the <see cref="M:System.Threading.ThreadPool.GetMaxThreads(System.Int32@,System.Int32@)" /> method, and the number currently active.</summary>
		/// <param name="workerThreads">The number of available worker threads.</param>
		/// <param name="completionPortThreads">The number of available asynchronous I/O threads.</param>
		// Token: 0x06003CDA RID: 15578 RVA: 0x000E2CC8 File Offset: 0x000E0EC8
		[SecuritySafeCritical]
		public static void GetAvailableThreads(out int workerThreads, out int completionPortThreads)
		{
			ThreadPool.GetAvailableThreadsNative(out workerThreads, out completionPortThreads);
		}

		/// <summary>Registers a delegate to wait for a <see cref="T:System.Threading.WaitHandle" />, specifying a 32-bit unsigned integer for the time-out in milliseconds.</summary>
		/// <param name="waitObject">The <see cref="T:System.Threading.WaitHandle" /> to register. Use a <see cref="T:System.Threading.WaitHandle" /> other than <see cref="T:System.Threading.Mutex" />.</param>
		/// <param name="callBack">The <see cref="T:System.Threading.WaitOrTimerCallback" /> delegate to call when the <paramref name="waitObject" /> parameter is signaled.</param>
		/// <param name="state">The object passed to the delegate.</param>
		/// <param name="millisecondsTimeOutInterval">The time-out in milliseconds. If the <paramref name="millisecondsTimeOutInterval" /> parameter is 0 (zero), the function tests the object's state and returns immediately. If <paramref name="millisecondsTimeOutInterval" /> is -1, the function's time-out interval never elapses.</param>
		/// <param name="executeOnlyOnce">
		///   <see langword="true" /> to indicate that the thread will no longer wait on the <paramref name="waitObject" /> parameter after the delegate has been called; <see langword="false" /> to indicate that the timer is reset every time the wait operation completes until the wait is unregistered.</param>
		/// <returns>The <see cref="T:System.Threading.RegisteredWaitHandle" /> that can be used to cancel the registered wait operation.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="millisecondsTimeOutInterval" /> parameter is less than -1.</exception>
		// Token: 0x06003CDB RID: 15579 RVA: 0x000E2CD4 File Offset: 0x000E0ED4
		[SecuritySafeCritical]
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, uint millisecondsTimeOutInterval, bool executeOnlyOnce)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return ThreadPool.RegisterWaitForSingleObject(waitObject, callBack, state, millisecondsTimeOutInterval, executeOnlyOnce, ref stackCrawlMark, true);
		}

		/// <summary>Registers a delegate to wait for a <see cref="T:System.Threading.WaitHandle" />, specifying a 32-bit unsigned integer for the time-out in milliseconds. This method does not propagate the calling stack to the worker thread.</summary>
		/// <param name="waitObject">The <see cref="T:System.Threading.WaitHandle" /> to register. Use a <see cref="T:System.Threading.WaitHandle" /> other than <see cref="T:System.Threading.Mutex" />.</param>
		/// <param name="callBack">The delegate to call when the <paramref name="waitObject" /> parameter is signaled.</param>
		/// <param name="state">The object that is passed to the delegate.</param>
		/// <param name="millisecondsTimeOutInterval">The time-out in milliseconds. If the <paramref name="millisecondsTimeOutInterval" /> parameter is 0 (zero), the function tests the object's state and returns immediately. If <paramref name="millisecondsTimeOutInterval" /> is -1, the function's time-out interval never elapses.</param>
		/// <param name="executeOnlyOnce">
		///   <see langword="true" /> to indicate that the thread will no longer wait on the <paramref name="waitObject" /> parameter after the delegate has been called; <see langword="false" /> to indicate that the timer is reset every time the wait operation completes until the wait is unregistered.</param>
		/// <returns>The <see cref="T:System.Threading.RegisteredWaitHandle" /> object that can be used to cancel the registered wait operation.</returns>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x06003CDC RID: 15580 RVA: 0x000E2CF4 File Offset: 0x000E0EF4
		[SecurityCritical]
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, uint millisecondsTimeOutInterval, bool executeOnlyOnce)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return ThreadPool.RegisterWaitForSingleObject(waitObject, callBack, state, millisecondsTimeOutInterval, executeOnlyOnce, ref stackCrawlMark, false);
		}

		// Token: 0x06003CDD RID: 15581 RVA: 0x000E2D14 File Offset: 0x000E0F14
		[SecurityCritical]
		private static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, uint millisecondsTimeOutInterval, bool executeOnlyOnce, ref StackCrawlMark stackMark, bool compressStack)
		{
			if (RemotingServices.IsTransparentProxy(waitObject))
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_WaitOnTransparentProxy"));
			}
			RegisteredWaitHandle registeredWaitHandle = new RegisteredWaitHandle();
			if (callBack != null)
			{
				_ThreadPoolWaitOrTimerCallback threadPoolWaitOrTimerCallback = new _ThreadPoolWaitOrTimerCallback(callBack, state, compressStack, ref stackMark);
				state = threadPoolWaitOrTimerCallback;
				registeredWaitHandle.SetWaitObject(waitObject);
				IntPtr handle = ThreadPool.RegisterWaitForSingleObjectNative(waitObject, state, millisecondsTimeOutInterval, executeOnlyOnce, registeredWaitHandle, ref stackMark, compressStack);
				registeredWaitHandle.SetHandle(handle);
				return registeredWaitHandle;
			}
			throw new ArgumentNullException("WaitOrTimerCallback");
		}

		/// <summary>Registers a delegate to wait for a <see cref="T:System.Threading.WaitHandle" />, specifying a 32-bit signed integer for the time-out in milliseconds.</summary>
		/// <param name="waitObject">The <see cref="T:System.Threading.WaitHandle" /> to register. Use a <see cref="T:System.Threading.WaitHandle" /> other than <see cref="T:System.Threading.Mutex" />.</param>
		/// <param name="callBack">The <see cref="T:System.Threading.WaitOrTimerCallback" /> delegate to call when the <paramref name="waitObject" /> parameter is signaled.</param>
		/// <param name="state">The object that is passed to the delegate.</param>
		/// <param name="millisecondsTimeOutInterval">The time-out in milliseconds. If the <paramref name="millisecondsTimeOutInterval" /> parameter is 0 (zero), the function tests the object's state and returns immediately. If <paramref name="millisecondsTimeOutInterval" /> is -1, the function's time-out interval never elapses.</param>
		/// <param name="executeOnlyOnce">
		///   <see langword="true" /> to indicate that the thread will no longer wait on the <paramref name="waitObject" /> parameter after the delegate has been called; <see langword="false" /> to indicate that the timer is reset every time the wait operation completes until the wait is unregistered.</param>
		/// <returns>The <see cref="T:System.Threading.RegisteredWaitHandle" /> that encapsulates the native handle.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="millisecondsTimeOutInterval" /> parameter is less than -1.</exception>
		// Token: 0x06003CDE RID: 15582 RVA: 0x000E2D80 File Offset: 0x000E0F80
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, int millisecondsTimeOutInterval, bool executeOnlyOnce)
		{
			if (millisecondsTimeOutInterval < -1)
			{
				throw new ArgumentOutOfRangeException("millisecondsTimeOutInterval", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return ThreadPool.RegisterWaitForSingleObject(waitObject, callBack, state, (uint)millisecondsTimeOutInterval, executeOnlyOnce, ref stackCrawlMark, true);
		}

		/// <summary>Registers a delegate to wait for a <see cref="T:System.Threading.WaitHandle" />, using a 32-bit signed integer for the time-out in milliseconds. This method does not propagate the calling stack to the worker thread.</summary>
		/// <param name="waitObject">The <see cref="T:System.Threading.WaitHandle" /> to register. Use a <see cref="T:System.Threading.WaitHandle" /> other than <see cref="T:System.Threading.Mutex" />.</param>
		/// <param name="callBack">The delegate to call when the <paramref name="waitObject" /> parameter is signaled.</param>
		/// <param name="state">The object that is passed to the delegate.</param>
		/// <param name="millisecondsTimeOutInterval">The time-out in milliseconds. If the <paramref name="millisecondsTimeOutInterval" /> parameter is 0 (zero), the function tests the object's state and returns immediately. If <paramref name="millisecondsTimeOutInterval" /> is -1, the function's time-out interval never elapses.</param>
		/// <param name="executeOnlyOnce">
		///   <see langword="true" /> to indicate that the thread will no longer wait on the <paramref name="waitObject" /> parameter after the delegate has been called; <see langword="false" /> to indicate that the timer is reset every time the wait operation completes until the wait is unregistered.</param>
		/// <returns>The <see cref="T:System.Threading.RegisteredWaitHandle" /> object that can be used to cancel the registered wait operation.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="millisecondsTimeOutInterval" /> parameter is less than -1.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x06003CDF RID: 15583 RVA: 0x000E2DB8 File Offset: 0x000E0FB8
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, int millisecondsTimeOutInterval, bool executeOnlyOnce)
		{
			if (millisecondsTimeOutInterval < -1)
			{
				throw new ArgumentOutOfRangeException("millisecondsTimeOutInterval", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return ThreadPool.RegisterWaitForSingleObject(waitObject, callBack, state, (uint)millisecondsTimeOutInterval, executeOnlyOnce, ref stackCrawlMark, false);
		}

		/// <summary>Registers a delegate to wait for a <see cref="T:System.Threading.WaitHandle" />, specifying a 64-bit signed integer for the time-out in milliseconds.</summary>
		/// <param name="waitObject">The <see cref="T:System.Threading.WaitHandle" /> to register. Use a <see cref="T:System.Threading.WaitHandle" /> other than <see cref="T:System.Threading.Mutex" />.</param>
		/// <param name="callBack">The <see cref="T:System.Threading.WaitOrTimerCallback" /> delegate to call when the <paramref name="waitObject" /> parameter is signaled.</param>
		/// <param name="state">The object passed to the delegate.</param>
		/// <param name="millisecondsTimeOutInterval">The time-out in milliseconds. If the <paramref name="millisecondsTimeOutInterval" /> parameter is 0 (zero), the function tests the object's state and returns immediately. If <paramref name="millisecondsTimeOutInterval" /> is -1, the function's time-out interval never elapses.</param>
		/// <param name="executeOnlyOnce">
		///   <see langword="true" /> to indicate that the thread will no longer wait on the <paramref name="waitObject" /> parameter after the delegate has been called; <see langword="false" /> to indicate that the timer is reset every time the wait operation completes until the wait is unregistered.</param>
		/// <returns>The <see cref="T:System.Threading.RegisteredWaitHandle" /> that encapsulates the native handle.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="millisecondsTimeOutInterval" /> parameter is less than -1.</exception>
		// Token: 0x06003CE0 RID: 15584 RVA: 0x000E2DF0 File Offset: 0x000E0FF0
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, long millisecondsTimeOutInterval, bool executeOnlyOnce)
		{
			if (millisecondsTimeOutInterval < -1L)
			{
				throw new ArgumentOutOfRangeException("millisecondsTimeOutInterval", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return ThreadPool.RegisterWaitForSingleObject(waitObject, callBack, state, (uint)millisecondsTimeOutInterval, executeOnlyOnce, ref stackCrawlMark, true);
		}

		/// <summary>Registers a delegate to wait for a <see cref="T:System.Threading.WaitHandle" />, specifying a 64-bit signed integer for the time-out in milliseconds. This method does not propagate the calling stack to the worker thread.</summary>
		/// <param name="waitObject">The <see cref="T:System.Threading.WaitHandle" /> to register. Use a <see cref="T:System.Threading.WaitHandle" /> other than <see cref="T:System.Threading.Mutex" />.</param>
		/// <param name="callBack">The delegate to call when the <paramref name="waitObject" /> parameter is signaled.</param>
		/// <param name="state">The object that is passed to the delegate.</param>
		/// <param name="millisecondsTimeOutInterval">The time-out in milliseconds. If the <paramref name="millisecondsTimeOutInterval" /> parameter is 0 (zero), the function tests the object's state and returns immediately. If <paramref name="millisecondsTimeOutInterval" /> is -1, the function's time-out interval never elapses.</param>
		/// <param name="executeOnlyOnce">
		///   <see langword="true" /> to indicate that the thread will no longer wait on the <paramref name="waitObject" /> parameter after the delegate has been called; <see langword="false" /> to indicate that the timer is reset every time the wait operation completes until the wait is unregistered.</param>
		/// <returns>The <see cref="T:System.Threading.RegisteredWaitHandle" /> object that can be used to cancel the registered wait operation.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="millisecondsTimeOutInterval" /> parameter is less than -1.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x06003CE1 RID: 15585 RVA: 0x000E2E28 File Offset: 0x000E1028
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, long millisecondsTimeOutInterval, bool executeOnlyOnce)
		{
			if (millisecondsTimeOutInterval < -1L)
			{
				throw new ArgumentOutOfRangeException("millisecondsTimeOutInterval", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return ThreadPool.RegisterWaitForSingleObject(waitObject, callBack, state, (uint)millisecondsTimeOutInterval, executeOnlyOnce, ref stackCrawlMark, false);
		}

		/// <summary>Registers a delegate to wait for a <see cref="T:System.Threading.WaitHandle" />, specifying a <see cref="T:System.TimeSpan" /> value for the time-out.</summary>
		/// <param name="waitObject">The <see cref="T:System.Threading.WaitHandle" /> to register. Use a <see cref="T:System.Threading.WaitHandle" /> other than <see cref="T:System.Threading.Mutex" />.</param>
		/// <param name="callBack">The <see cref="T:System.Threading.WaitOrTimerCallback" /> delegate to call when the <paramref name="waitObject" /> parameter is signaled.</param>
		/// <param name="state">The object passed to the delegate.</param>
		/// <param name="timeout">The time-out represented by a <see cref="T:System.TimeSpan" />. If <paramref name="timeout" /> is 0 (zero), the function tests the object's state and returns immediately. If <paramref name="timeout" /> is -1, the function's time-out interval never elapses.</param>
		/// <param name="executeOnlyOnce">
		///   <see langword="true" /> to indicate that the thread will no longer wait on the <paramref name="waitObject" /> parameter after the delegate has been called; <see langword="false" /> to indicate that the timer is reset every time the wait operation completes until the wait is unregistered.</param>
		/// <returns>The <see cref="T:System.Threading.RegisteredWaitHandle" /> that encapsulates the native handle.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="timeout" /> parameter is less than -1.</exception>
		/// <exception cref="T:System.NotSupportedException">The <paramref name="timeout" /> parameter is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		// Token: 0x06003CE2 RID: 15586 RVA: 0x000E2E60 File Offset: 0x000E1060
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, TimeSpan timeout, bool executeOnlyOnce)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_LessEqualToIntegerMaxVal"));
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return ThreadPool.RegisterWaitForSingleObject(waitObject, callBack, state, (uint)num, executeOnlyOnce, ref stackCrawlMark, true);
		}

		/// <summary>Registers a delegate to wait for a <see cref="T:System.Threading.WaitHandle" />, specifying a <see cref="T:System.TimeSpan" /> value for the time-out. This method does not propagate the calling stack to the worker thread.</summary>
		/// <param name="waitObject">The <see cref="T:System.Threading.WaitHandle" /> to register. Use a <see cref="T:System.Threading.WaitHandle" /> other than <see cref="T:System.Threading.Mutex" />.</param>
		/// <param name="callBack">The delegate to call when the <paramref name="waitObject" /> parameter is signaled.</param>
		/// <param name="state">The object that is passed to the delegate.</param>
		/// <param name="timeout">The time-out represented by a <see cref="T:System.TimeSpan" />. If <paramref name="timeout" /> is 0 (zero), the function tests the object's state and returns immediately. If <paramref name="timeout" /> is -1, the function's time-out interval never elapses.</param>
		/// <param name="executeOnlyOnce">
		///   <see langword="true" /> to indicate that the thread will no longer wait on the <paramref name="waitObject" /> parameter after the delegate has been called; <see langword="false" /> to indicate that the timer is reset every time the wait operation completes until the wait is unregistered.</param>
		/// <returns>The <see cref="T:System.Threading.RegisteredWaitHandle" /> object that can be used to cancel the registered wait operation.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="timeout" /> parameter is less than -1.</exception>
		/// <exception cref="T:System.NotSupportedException">The <paramref name="timeout" /> parameter is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x06003CE3 RID: 15587 RVA: 0x000E2EC0 File Offset: 0x000E10C0
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RegisteredWaitHandle UnsafeRegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, TimeSpan timeout, bool executeOnlyOnce)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_LessEqualToIntegerMaxVal"));
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return ThreadPool.RegisterWaitForSingleObject(waitObject, callBack, state, (uint)num, executeOnlyOnce, ref stackCrawlMark, false);
		}

		/// <summary>Queues a method for execution, and specifies an object containing data to be used by the method. The method executes when a thread pool thread becomes available.</summary>
		/// <param name="callBack">A <see cref="T:System.Threading.WaitCallback" /> representing the method to execute.</param>
		/// <param name="state">An object containing data to be used by the method.</param>
		/// <returns>
		///   <see langword="true" /> if the method is successfully queued; <see cref="T:System.NotSupportedException" /> is thrown if the work item could not be queued.</returns>
		/// <exception cref="T:System.NotSupportedException">The common language runtime (CLR) is hosted, and the host does not support this action.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="callBack" /> is <see langword="null" />.</exception>
		// Token: 0x06003CE4 RID: 15588 RVA: 0x000E2F20 File Offset: 0x000E1120
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool QueueUserWorkItem(WaitCallback callBack, object state)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return ThreadPool.QueueUserWorkItemHelper(callBack, state, ref stackCrawlMark, true);
		}

		/// <summary>Queues a method for execution. The method executes when a thread pool thread becomes available.</summary>
		/// <param name="callBack">A <see cref="T:System.Threading.WaitCallback" /> that represents the method to be executed.</param>
		/// <returns>
		///   <see langword="true" /> if the method is successfully queued; <see cref="T:System.NotSupportedException" /> is thrown if the work item could not be queued.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="callBack" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The common language runtime (CLR) is hosted, and the host does not support this action.</exception>
		// Token: 0x06003CE5 RID: 15589 RVA: 0x000E2F3C File Offset: 0x000E113C
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool QueueUserWorkItem(WaitCallback callBack)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return ThreadPool.QueueUserWorkItemHelper(callBack, null, ref stackCrawlMark, true);
		}

		/// <summary>Queues the specified delegate to the thread pool, but does not propagate the calling stack to the worker thread.</summary>
		/// <param name="callBack">A <see cref="T:System.Threading.WaitCallback" /> that represents the delegate to invoke when a thread in the thread pool picks up the work item.</param>
		/// <param name="state">The object that is passed to the delegate when serviced from the thread pool.</param>
		/// <returns>
		///   <see langword="true" /> if the method succeeds; <see cref="T:System.OutOfMemoryException" /> is thrown if the work item could not be queued.</returns>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		/// <exception cref="T:System.ApplicationException">An out-of-memory condition was encountered.</exception>
		/// <exception cref="T:System.OutOfMemoryException">The work item could not be queued.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="callBack" /> is <see langword="null" />.</exception>
		// Token: 0x06003CE6 RID: 15590 RVA: 0x000E2F58 File Offset: 0x000E1158
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool UnsafeQueueUserWorkItem(WaitCallback callBack, object state)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return ThreadPool.QueueUserWorkItemHelper(callBack, state, ref stackCrawlMark, false);
		}

		// Token: 0x06003CE7 RID: 15591 RVA: 0x000E2F74 File Offset: 0x000E1174
		[SecurityCritical]
		private static bool QueueUserWorkItemHelper(WaitCallback callBack, object state, ref StackCrawlMark stackMark, bool compressStack)
		{
			bool result = true;
			if (callBack != null)
			{
				ThreadPool.EnsureVMInitialized();
				try
				{
					return result;
				}
				finally
				{
					QueueUserWorkItemCallback callback = new QueueUserWorkItemCallback(callBack, state, compressStack, ref stackMark);
					ThreadPoolGlobals.workQueue.Enqueue(callback, true);
					result = true;
				}
			}
			throw new ArgumentNullException("WaitCallback");
		}

		// Token: 0x06003CE8 RID: 15592 RVA: 0x000E2FC4 File Offset: 0x000E11C4
		[SecurityCritical]
		internal static void UnsafeQueueCustomWorkItem(IThreadPoolWorkItem workItem, bool forceGlobal)
		{
			ThreadPool.EnsureVMInitialized();
			try
			{
			}
			finally
			{
				ThreadPoolGlobals.workQueue.Enqueue(workItem, forceGlobal);
			}
		}

		// Token: 0x06003CE9 RID: 15593 RVA: 0x000E2FF8 File Offset: 0x000E11F8
		[SecurityCritical]
		internal static bool TryPopCustomWorkItem(IThreadPoolWorkItem workItem)
		{
			return ThreadPoolGlobals.vmTpInitialized && ThreadPoolGlobals.workQueue.LocalFindAndPop(workItem);
		}

		// Token: 0x06003CEA RID: 15594 RVA: 0x000E3010 File Offset: 0x000E1210
		[SecurityCritical]
		internal static IEnumerable<IThreadPoolWorkItem> GetQueuedWorkItems()
		{
			return ThreadPool.EnumerateQueuedWorkItems(ThreadPoolWorkQueue.allThreadQueues.Current, ThreadPoolGlobals.workQueue.queueTail);
		}

		// Token: 0x06003CEB RID: 15595 RVA: 0x000E302D File Offset: 0x000E122D
		internal static IEnumerable<IThreadPoolWorkItem> EnumerateQueuedWorkItems(ThreadPoolWorkQueue.WorkStealingQueue[] wsQueues, ThreadPoolWorkQueue.QueueSegment globalQueueTail)
		{
			if (wsQueues != null)
			{
				foreach (ThreadPoolWorkQueue.WorkStealingQueue workStealingQueue in wsQueues)
				{
					if (workStealingQueue != null && workStealingQueue.m_array != null)
					{
						IThreadPoolWorkItem[] items = workStealingQueue.m_array;
						int num;
						for (int i = 0; i < items.Length; i = num + 1)
						{
							IThreadPoolWorkItem threadPoolWorkItem = items[i];
							if (threadPoolWorkItem != null)
							{
								yield return threadPoolWorkItem;
							}
							num = i;
						}
						items = null;
					}
				}
				ThreadPoolWorkQueue.WorkStealingQueue[] array = null;
			}
			if (globalQueueTail != null)
			{
				ThreadPoolWorkQueue.QueueSegment segment;
				for (segment = globalQueueTail; segment != null; segment = segment.Next)
				{
					IThreadPoolWorkItem[] items2 = segment.nodes;
					int num;
					for (int j = 0; j < items2.Length; j = num + 1)
					{
						IThreadPoolWorkItem threadPoolWorkItem2 = items2[j];
						if (threadPoolWorkItem2 != null)
						{
							yield return threadPoolWorkItem2;
						}
						num = j;
					}
					items2 = null;
				}
				segment = null;
			}
			yield break;
		}

		// Token: 0x06003CEC RID: 15596 RVA: 0x000E3044 File Offset: 0x000E1244
		[SecurityCritical]
		internal static IEnumerable<IThreadPoolWorkItem> GetLocallyQueuedWorkItems()
		{
			return ThreadPool.EnumerateQueuedWorkItems(new ThreadPoolWorkQueue.WorkStealingQueue[]
			{
				ThreadPoolWorkQueueThreadLocals.threadLocals.workStealingQueue
			}, null);
		}

		// Token: 0x06003CED RID: 15597 RVA: 0x000E305F File Offset: 0x000E125F
		[SecurityCritical]
		internal static IEnumerable<IThreadPoolWorkItem> GetGloballyQueuedWorkItems()
		{
			return ThreadPool.EnumerateQueuedWorkItems(null, ThreadPoolGlobals.workQueue.queueTail);
		}

		// Token: 0x06003CEE RID: 15598 RVA: 0x000E3074 File Offset: 0x000E1274
		private static object[] ToObjectArray(IEnumerable<IThreadPoolWorkItem> workitems)
		{
			int num = 0;
			foreach (IThreadPoolWorkItem threadPoolWorkItem in workitems)
			{
				num++;
			}
			object[] array = new object[num];
			num = 0;
			foreach (IThreadPoolWorkItem threadPoolWorkItem2 in workitems)
			{
				if (num < array.Length)
				{
					array[num] = threadPoolWorkItem2;
				}
				num++;
			}
			return array;
		}

		// Token: 0x06003CEF RID: 15599 RVA: 0x000E310C File Offset: 0x000E130C
		[SecurityCritical]
		internal static object[] GetQueuedWorkItemsForDebugger()
		{
			return ThreadPool.ToObjectArray(ThreadPool.GetQueuedWorkItems());
		}

		// Token: 0x06003CF0 RID: 15600 RVA: 0x000E3118 File Offset: 0x000E1318
		[SecurityCritical]
		internal static object[] GetGloballyQueuedWorkItemsForDebugger()
		{
			return ThreadPool.ToObjectArray(ThreadPool.GetGloballyQueuedWorkItems());
		}

		// Token: 0x06003CF1 RID: 15601 RVA: 0x000E3124 File Offset: 0x000E1324
		[SecurityCritical]
		internal static object[] GetLocallyQueuedWorkItemsForDebugger()
		{
			return ThreadPool.ToObjectArray(ThreadPool.GetLocallyQueuedWorkItems());
		}

		// Token: 0x06003CF2 RID: 15602
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern bool RequestWorkerThread();

		// Token: 0x06003CF3 RID: 15603
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern bool PostQueuedCompletionStatus(NativeOverlapped* overlapped);

		/// <summary>Queues an overlapped I/O operation for execution.</summary>
		/// <param name="overlapped">The <see cref="T:System.Threading.NativeOverlapped" /> structure to queue.</param>
		/// <returns>
		///   <see langword="true" /> if the operation was successfully queued to an I/O completion port; otherwise, <see langword="false" />.</returns>
		// Token: 0x06003CF4 RID: 15604 RVA: 0x000E3130 File Offset: 0x000E1330
		[SecurityCritical]
		[CLSCompliant(false)]
		public unsafe static bool UnsafeQueueNativeOverlapped(NativeOverlapped* overlapped)
		{
			return ThreadPool.PostQueuedCompletionStatus(overlapped);
		}

		// Token: 0x06003CF5 RID: 15605 RVA: 0x000E3138 File Offset: 0x000E1338
		[SecurityCritical]
		private static void EnsureVMInitialized()
		{
			if (!ThreadPoolGlobals.vmTpInitialized)
			{
				ThreadPool.InitializeVMTp(ref ThreadPoolGlobals.enableWorkerTracking);
				ThreadPoolGlobals.vmTpInitialized = true;
			}
		}

		// Token: 0x06003CF6 RID: 15606
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetMinThreadsNative(int workerThreads, int completionPortThreads);

		// Token: 0x06003CF7 RID: 15607
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetMaxThreadsNative(int workerThreads, int completionPortThreads);

		// Token: 0x06003CF8 RID: 15608
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetMinThreadsNative(out int workerThreads, out int completionPortThreads);

		// Token: 0x06003CF9 RID: 15609
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetMaxThreadsNative(out int workerThreads, out int completionPortThreads);

		// Token: 0x06003CFA RID: 15610
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetAvailableThreadsNative(out int workerThreads, out int completionPortThreads);

		// Token: 0x06003CFB RID: 15611
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool NotifyWorkItemComplete();

		// Token: 0x06003CFC RID: 15612
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ReportThreadStatus(bool isWorking);

		// Token: 0x06003CFD RID: 15613 RVA: 0x000E3155 File Offset: 0x000E1355
		[SecuritySafeCritical]
		internal static void NotifyWorkItemProgress()
		{
			if (!ThreadPoolGlobals.vmTpInitialized)
			{
				ThreadPool.InitializeVMTp(ref ThreadPoolGlobals.enableWorkerTracking);
			}
			ThreadPool.NotifyWorkItemProgressNative();
		}

		// Token: 0x06003CFE RID: 15614
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void NotifyWorkItemProgressNative();

		// Token: 0x06003CFF RID: 15615
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool IsThreadPoolHosted();

		// Token: 0x06003D00 RID: 15616
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void InitializeVMTp(ref bool enableWorkerTracking);

		// Token: 0x06003D01 RID: 15617
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr RegisterWaitForSingleObjectNative(WaitHandle waitHandle, object state, uint timeOutInterval, bool executeOnlyOnce, RegisteredWaitHandle registeredWaitHandle, ref StackCrawlMark stackMark, bool compressStack);

		/// <summary>Binds an operating system handle to the <see cref="T:System.Threading.ThreadPool" />.</summary>
		/// <param name="osHandle">An <see cref="T:System.IntPtr" /> that holds the handle. The handle must have been opened for overlapped I/O on the unmanaged side.</param>
		/// <returns>
		///   <see langword="true" /> if the handle is bound; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x06003D02 RID: 15618 RVA: 0x000E316F File Offset: 0x000E136F
		[SecuritySafeCritical]
		[Obsolete("ThreadPool.BindHandle(IntPtr) has been deprecated.  Please use ThreadPool.BindHandle(SafeHandle) instead.", false)]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public static bool BindHandle(IntPtr osHandle)
		{
			return ThreadPool.BindIOCompletionCallbackNative(osHandle);
		}

		/// <summary>Binds an operating system handle to the <see cref="T:System.Threading.ThreadPool" />.</summary>
		/// <param name="osHandle">A <see cref="T:System.Runtime.InteropServices.SafeHandle" /> that holds the operating system handle. The handle must have been opened for overlapped I/O on the unmanaged side.</param>
		/// <returns>
		///   <see langword="true" /> if the handle is bound; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="osHandle" /> is <see langword="null" />.</exception>
		// Token: 0x06003D03 RID: 15619 RVA: 0x000E3178 File Offset: 0x000E1378
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public static bool BindHandle(SafeHandle osHandle)
		{
			if (osHandle == null)
			{
				throw new ArgumentNullException("osHandle");
			}
			bool result = false;
			bool flag = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				osHandle.DangerousAddRef(ref flag);
				result = ThreadPool.BindIOCompletionCallbackNative(osHandle.DangerousGetHandle());
			}
			finally
			{
				if (flag)
				{
					osHandle.DangerousRelease();
				}
			}
			return result;
		}

		// Token: 0x06003D04 RID: 15620
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool BindIOCompletionCallbackNative(IntPtr fileHandle);
	}
}
