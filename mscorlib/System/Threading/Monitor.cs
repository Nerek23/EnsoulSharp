using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Threading
{
	/// <summary>Provides a mechanism that synchronizes access to objects.</summary>
	// Token: 0x020004D4 RID: 1236
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public static class Monitor
	{
		/// <summary>Acquires an exclusive lock on the specified object.</summary>
		/// <param name="obj">The object on which to acquire the monitor lock.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06003B41 RID: 15169
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Enter(object obj);

		/// <summary>Acquires an exclusive lock on the specified object, and atomically sets a value that indicates whether the lock was taken.</summary>
		/// <param name="obj">The object on which to wait.</param>
		/// <param name="lockTaken">The result of the attempt to acquire the lock, passed by reference. The input must be <see langword="false" />. The output is <see langword="true" /> if the lock is acquired; otherwise, the output is <see langword="false" />. The output is set even if an exception occurs during the attempt to acquire the lock.  
		///  Note   If no exception occurs, the output of this method is always <see langword="true" />.</param>
		/// <exception cref="T:System.ArgumentException">The input to <paramref name="lockTaken" /> is <see langword="true" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06003B42 RID: 15170 RVA: 0x000DF8D8 File Offset: 0x000DDAD8
		[__DynamicallyInvokable]
		public static void Enter(object obj, ref bool lockTaken)
		{
			if (lockTaken)
			{
				Monitor.ThrowLockTakenException();
			}
			Monitor.ReliableEnter(obj, ref lockTaken);
		}

		// Token: 0x06003B43 RID: 15171 RVA: 0x000DF8EA File Offset: 0x000DDAEA
		private static void ThrowLockTakenException()
		{
			throw new ArgumentException(Environment.GetResourceString("Argument_MustBeFalse"), "lockTaken");
		}

		// Token: 0x06003B44 RID: 15172
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ReliableEnter(object obj, ref bool lockTaken);

		/// <summary>Releases an exclusive lock on the specified object.</summary>
		/// <param name="obj">The object on which to release the lock.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Threading.SynchronizationLockException">The current thread does not own the lock for the specified object.</exception>
		// Token: 0x06003B45 RID: 15173
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Exit(object obj);

		/// <summary>Attempts to acquire an exclusive lock on the specified object.</summary>
		/// <param name="obj">The object on which to acquire the lock.</param>
		/// <returns>
		///   <see langword="true" /> if the current thread acquires the lock; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06003B46 RID: 15174 RVA: 0x000DF900 File Offset: 0x000DDB00
		[__DynamicallyInvokable]
		public static bool TryEnter(object obj)
		{
			bool result = false;
			Monitor.TryEnter(obj, 0, ref result);
			return result;
		}

		/// <summary>Attempts to acquire an exclusive lock on the specified object, and atomically sets a value that indicates whether the lock was taken.</summary>
		/// <param name="obj">The object on which to acquire the lock.</param>
		/// <param name="lockTaken">The result of the attempt to acquire the lock, passed by reference. The input must be <see langword="false" />. The output is <see langword="true" /> if the lock is acquired; otherwise, the output is <see langword="false" />. The output is set even if an exception occurs during the attempt to acquire the lock.</param>
		/// <exception cref="T:System.ArgumentException">The input to <paramref name="lockTaken" /> is <see langword="true" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06003B47 RID: 15175 RVA: 0x000DF919 File Offset: 0x000DDB19
		[__DynamicallyInvokable]
		public static void TryEnter(object obj, ref bool lockTaken)
		{
			if (lockTaken)
			{
				Monitor.ThrowLockTakenException();
			}
			Monitor.ReliableEnterTimeout(obj, 0, ref lockTaken);
		}

		/// <summary>Attempts, for the specified number of milliseconds, to acquire an exclusive lock on the specified object.</summary>
		/// <param name="obj">The object on which to acquire the lock.</param>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait for the lock.</param>
		/// <returns>
		///   <see langword="true" /> if the current thread acquires the lock; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="millisecondsTimeout" /> is negative, and not equal to <see cref="F:System.Threading.Timeout.Infinite" />.</exception>
		// Token: 0x06003B48 RID: 15176 RVA: 0x000DF92C File Offset: 0x000DDB2C
		[__DynamicallyInvokable]
		public static bool TryEnter(object obj, int millisecondsTimeout)
		{
			bool result = false;
			Monitor.TryEnter(obj, millisecondsTimeout, ref result);
			return result;
		}

		// Token: 0x06003B49 RID: 15177 RVA: 0x000DF948 File Offset: 0x000DDB48
		private static int MillisecondsTimeoutFromTimeSpan(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			return (int)num;
		}

		/// <summary>Attempts, for the specified amount of time, to acquire an exclusive lock on the specified object.</summary>
		/// <param name="obj">The object on which to acquire the lock.</param>
		/// <param name="timeout">A <see cref="T:System.TimeSpan" /> representing the amount of time to wait for the lock. A value of -1 millisecond specifies an infinite wait.</param>
		/// <returns>
		///   <see langword="true" /> if the current thread acquires the lock; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of <paramref name="timeout" /> in milliseconds is negative and is not equal to <see cref="F:System.Threading.Timeout.Infinite" /> (-1 millisecond), or is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		// Token: 0x06003B4A RID: 15178 RVA: 0x000DF983 File Offset: 0x000DDB83
		[__DynamicallyInvokable]
		public static bool TryEnter(object obj, TimeSpan timeout)
		{
			return Monitor.TryEnter(obj, Monitor.MillisecondsTimeoutFromTimeSpan(timeout));
		}

		/// <summary>Attempts, for the specified number of milliseconds, to acquire an exclusive lock on the specified object, and atomically sets a value that indicates whether the lock was taken.</summary>
		/// <param name="obj">The object on which to acquire the lock.</param>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait for the lock.</param>
		/// <param name="lockTaken">The result of the attempt to acquire the lock, passed by reference. The input must be <see langword="false" />. The output is <see langword="true" /> if the lock is acquired; otherwise, the output is <see langword="false" />. The output is set even if an exception occurs during the attempt to acquire the lock.</param>
		/// <exception cref="T:System.ArgumentException">The input to <paramref name="lockTaken" /> is <see langword="true" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="millisecondsTimeout" /> is negative, and not equal to <see cref="F:System.Threading.Timeout.Infinite" />.</exception>
		// Token: 0x06003B4B RID: 15179 RVA: 0x000DF991 File Offset: 0x000DDB91
		[__DynamicallyInvokable]
		public static void TryEnter(object obj, int millisecondsTimeout, ref bool lockTaken)
		{
			if (lockTaken)
			{
				Monitor.ThrowLockTakenException();
			}
			Monitor.ReliableEnterTimeout(obj, millisecondsTimeout, ref lockTaken);
		}

		/// <summary>Attempts, for the specified amount of time, to acquire an exclusive lock on the specified object, and atomically sets a value that indicates whether the lock was taken.</summary>
		/// <param name="obj">The object on which to acquire the lock.</param>
		/// <param name="timeout">The amount of time to wait for the lock. A value of -1 millisecond specifies an infinite wait.</param>
		/// <param name="lockTaken">The result of the attempt to acquire the lock, passed by reference. The input must be <see langword="false" />. The output is <see langword="true" /> if the lock is acquired; otherwise, the output is <see langword="false" />. The output is set even if an exception occurs during the attempt to acquire the lock.</param>
		/// <exception cref="T:System.ArgumentException">The input to <paramref name="lockTaken" /> is <see langword="true" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of <paramref name="timeout" /> in milliseconds is negative and is not equal to <see cref="F:System.Threading.Timeout.Infinite" /> (-1 millisecond), or is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		// Token: 0x06003B4C RID: 15180 RVA: 0x000DF9A4 File Offset: 0x000DDBA4
		[__DynamicallyInvokable]
		public static void TryEnter(object obj, TimeSpan timeout, ref bool lockTaken)
		{
			if (lockTaken)
			{
				Monitor.ThrowLockTakenException();
			}
			Monitor.ReliableEnterTimeout(obj, Monitor.MillisecondsTimeoutFromTimeSpan(timeout), ref lockTaken);
		}

		// Token: 0x06003B4D RID: 15181
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ReliableEnterTimeout(object obj, int timeout, ref bool lockTaken);

		/// <summary>Determines whether the current thread holds the lock on the specified object.</summary>
		/// <param name="obj">The object to test.</param>
		/// <returns>
		///   <see langword="true" /> if the current thread holds the lock on <paramref name="obj" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="obj" /> is <see langword="null" />.</exception>
		// Token: 0x06003B4E RID: 15182 RVA: 0x000DF9BC File Offset: 0x000DDBBC
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static bool IsEntered(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			return Monitor.IsEnteredNative(obj);
		}

		// Token: 0x06003B4F RID: 15183
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsEnteredNative(object obj);

		// Token: 0x06003B50 RID: 15184
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool ObjWait(bool exitContext, int millisecondsTimeout, object obj);

		/// <summary>Releases the lock on an object and blocks the current thread until it reacquires the lock. If the specified time-out interval elapses, the thread enters the ready queue. This method also specifies whether the synchronization domain for the context (if in a synchronized context) is exited before the wait and reacquired afterward.</summary>
		/// <param name="obj">The object on which to wait.</param>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait before the thread enters the ready queue.</param>
		/// <param name="exitContext">
		///   <see langword="true" /> to exit and reacquire the synchronization domain for the context (if in a synchronized context) before the wait; otherwise, <see langword="false" />.</param>
		/// <returns>
		///   <see langword="true" /> if the lock was reacquired before the specified time elapsed; <see langword="false" /> if the lock was reacquired after the specified time elapsed. The method does not return until the lock is reacquired.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Threading.SynchronizationLockException">
		///   <see langword="Wait" /> is not invoked from within a synchronized block of code.</exception>
		/// <exception cref="T:System.Threading.ThreadInterruptedException">The thread that invokes <see langword="Wait" /> is later interrupted from the waiting state. This happens when another thread calls this thread's <see cref="M:System.Threading.Thread.Interrupt" /> method.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <paramref name="millisecondsTimeout" /> parameter is negative, and is not equal to <see cref="F:System.Threading.Timeout.Infinite" />.</exception>
		// Token: 0x06003B51 RID: 15185 RVA: 0x000DF9D2 File Offset: 0x000DDBD2
		[SecuritySafeCritical]
		public static bool Wait(object obj, int millisecondsTimeout, bool exitContext)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			return Monitor.ObjWait(exitContext, millisecondsTimeout, obj);
		}

		/// <summary>Releases the lock on an object and blocks the current thread until it reacquires the lock. If the specified time-out interval elapses, the thread enters the ready queue. Optionally exits the synchronization domain for the synchronized context before the wait and reacquires the domain afterward.</summary>
		/// <param name="obj">The object on which to wait.</param>
		/// <param name="timeout">A <see cref="T:System.TimeSpan" /> representing the amount of time to wait before the thread enters the ready queue.</param>
		/// <param name="exitContext">
		///   <see langword="true" /> to exit and reacquire the synchronization domain for the context (if in a synchronized context) before the wait; otherwise, <see langword="false" />.</param>
		/// <returns>
		///   <see langword="true" /> if the lock was reacquired before the specified time elapsed; <see langword="false" /> if the lock was reacquired after the specified time elapsed. The method does not return until the lock is reacquired.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Threading.SynchronizationLockException">
		///   <see langword="Wait" /> is not invoked from within a synchronized block of code.</exception>
		/// <exception cref="T:System.Threading.ThreadInterruptedException">The thread that invokes Wait is later interrupted from the waiting state. This happens when another thread calls this thread's <see cref="M:System.Threading.Thread.Interrupt" /> method.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="timeout" /> parameter is negative and does not represent <see cref="F:System.Threading.Timeout.Infinite" /> (-1 millisecond), or is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		// Token: 0x06003B52 RID: 15186 RVA: 0x000DF9EA File Offset: 0x000DDBEA
		public static bool Wait(object obj, TimeSpan timeout, bool exitContext)
		{
			return Monitor.Wait(obj, Monitor.MillisecondsTimeoutFromTimeSpan(timeout), exitContext);
		}

		/// <summary>Releases the lock on an object and blocks the current thread until it reacquires the lock. If the specified time-out interval elapses, the thread enters the ready queue.</summary>
		/// <param name="obj">The object on which to wait.</param>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait before the thread enters the ready queue.</param>
		/// <returns>
		///   <see langword="true" /> if the lock was reacquired before the specified time elapsed; <see langword="false" /> if the lock was reacquired after the specified time elapsed. The method does not return until the lock is reacquired.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Threading.SynchronizationLockException">The calling thread does not own the lock for the specified object.</exception>
		/// <exception cref="T:System.Threading.ThreadInterruptedException">The thread that invokes <see langword="Wait" /> is later interrupted from the waiting state. This happens when another thread calls this thread's <see cref="M:System.Threading.Thread.Interrupt" /> method.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <paramref name="millisecondsTimeout" /> parameter is negative, and is not equal to <see cref="F:System.Threading.Timeout.Infinite" />.</exception>
		// Token: 0x06003B53 RID: 15187 RVA: 0x000DF9F9 File Offset: 0x000DDBF9
		[__DynamicallyInvokable]
		public static bool Wait(object obj, int millisecondsTimeout)
		{
			return Monitor.Wait(obj, millisecondsTimeout, false);
		}

		/// <summary>Releases the lock on an object and blocks the current thread until it reacquires the lock. If the specified time-out interval elapses, the thread enters the ready queue.</summary>
		/// <param name="obj">The object on which to wait.</param>
		/// <param name="timeout">A <see cref="T:System.TimeSpan" /> representing the amount of time to wait before the thread enters the ready queue.</param>
		/// <returns>
		///   <see langword="true" /> if the lock was reacquired before the specified time elapsed; <see langword="false" /> if the lock was reacquired after the specified time elapsed. The method does not return until the lock is reacquired.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Threading.SynchronizationLockException">The calling thread does not own the lock for the specified object.</exception>
		/// <exception cref="T:System.Threading.ThreadInterruptedException">The thread that invokes <see langword="Wait" /> is later interrupted from the waiting state. This happens when another thread calls this thread's <see cref="M:System.Threading.Thread.Interrupt" /> method.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <paramref name="timeout" /> parameter in milliseconds is negative and does not represent <see cref="F:System.Threading.Timeout.Infinite" /> (-1 millisecond), or is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		// Token: 0x06003B54 RID: 15188 RVA: 0x000DFA03 File Offset: 0x000DDC03
		[__DynamicallyInvokable]
		public static bool Wait(object obj, TimeSpan timeout)
		{
			return Monitor.Wait(obj, Monitor.MillisecondsTimeoutFromTimeSpan(timeout), false);
		}

		/// <summary>Releases the lock on an object and blocks the current thread until it reacquires the lock.</summary>
		/// <param name="obj">The object on which to wait.</param>
		/// <returns>
		///   <see langword="true" /> if the call returned because the caller reacquired the lock for the specified object. This method does not return if the lock is not reacquired.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Threading.SynchronizationLockException">The calling thread does not own the lock for the specified object.</exception>
		/// <exception cref="T:System.Threading.ThreadInterruptedException">The thread that invokes <see langword="Wait" /> is later interrupted from the waiting state. This happens when another thread calls this thread's <see cref="M:System.Threading.Thread.Interrupt" /> method.</exception>
		// Token: 0x06003B55 RID: 15189 RVA: 0x000DFA12 File Offset: 0x000DDC12
		[__DynamicallyInvokable]
		public static bool Wait(object obj)
		{
			return Monitor.Wait(obj, -1, false);
		}

		// Token: 0x06003B56 RID: 15190
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ObjPulse(object obj);

		/// <summary>Notifies a thread in the waiting queue of a change in the locked object's state.</summary>
		/// <param name="obj">The object a thread is waiting for.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Threading.SynchronizationLockException">The calling thread does not own the lock for the specified object.</exception>
		// Token: 0x06003B57 RID: 15191 RVA: 0x000DFA1C File Offset: 0x000DDC1C
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static void Pulse(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			Monitor.ObjPulse(obj);
		}

		// Token: 0x06003B58 RID: 15192
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ObjPulseAll(object obj);

		/// <summary>Notifies all waiting threads of a change in the object's state.</summary>
		/// <param name="obj">The object that sends the pulse.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="obj" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Threading.SynchronizationLockException">The calling thread does not own the lock for the specified object.</exception>
		// Token: 0x06003B59 RID: 15193 RVA: 0x000DFA32 File Offset: 0x000DDC32
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static void PulseAll(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			Monitor.ObjPulseAll(obj);
		}
	}
}
