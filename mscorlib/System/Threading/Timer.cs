using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading.NetCore;

namespace System.Threading
{
	/// <summary>Provides a mechanism for executing a method on a thread pool thread at specified intervals. This class cannot be inherited.</summary>
	// Token: 0x02000504 RID: 1284
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public sealed class Timer : MarshalByRefObject, IDisposable
	{
		/// <summary>Initializes a new instance of the <see langword="Timer" /> class, using a 32-bit signed integer to specify the time interval.</summary>
		/// <param name="callback">A <see cref="T:System.Threading.TimerCallback" /> delegate representing a method to be executed.</param>
		/// <param name="state">An object containing information to be used by the callback method, or <see langword="null" />.</param>
		/// <param name="dueTime">The amount of time to delay before <paramref name="callback" /> is invoked, in milliseconds. Specify <see cref="F:System.Threading.Timeout.Infinite" /> to prevent the timer from starting. Specify zero (0) to start the timer immediately.</param>
		/// <param name="period">The time interval between invocations of <paramref name="callback" />, in milliseconds. Specify <see cref="F:System.Threading.Timeout.Infinite" /> to disable periodic signaling.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="dueTime" /> or <paramref name="period" /> parameter is negative and is not equal to <see cref="F:System.Threading.Timeout.Infinite" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="callback" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06003D34 RID: 15668 RVA: 0x000E3C2C File Offset: 0x000E1E2C
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Timer(TimerCallback callback, object state, int dueTime, int period)
		{
			if (dueTime < -1)
			{
				throw new ArgumentOutOfRangeException("dueTime", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (period < -1)
			{
				throw new ArgumentOutOfRangeException("period", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.TimerSetup(callback, state, (uint)dueTime, (uint)period, ref stackCrawlMark);
		}

		/// <summary>Initializes a new instance of the <see langword="Timer" /> class, using <see cref="T:System.TimeSpan" /> values to measure time intervals.</summary>
		/// <param name="callback">A delegate representing a method to be executed.</param>
		/// <param name="state">An object containing information to be used by the callback method, or <see langword="null" />.</param>
		/// <param name="dueTime">The amount of time to delay before the <paramref name="callback" /> parameter invokes its methods. Specify negative one (-1) milliseconds to prevent the timer from starting. Specify zero (0) to start the timer immediately.</param>
		/// <param name="period">The time interval between invocations of the methods referenced by <paramref name="callback" />. Specify negative one (-1) milliseconds to disable periodic signaling.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The number of milliseconds in the value of <paramref name="dueTime" /> or <paramref name="period" /> is negative and not equal to <see cref="F:System.Threading.Timeout.Infinite" />, or is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="callback" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06003D35 RID: 15669 RVA: 0x000E3C84 File Offset: 0x000E1E84
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Timer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period)
		{
			long num = (long)dueTime.TotalMilliseconds;
			if (num < -1L)
			{
				throw new ArgumentOutOfRangeException("dueTm", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (num > (long)((ulong)-2))
			{
				throw new ArgumentOutOfRangeException("dueTm", Environment.GetResourceString("ArgumentOutOfRange_TimeoutTooLarge"));
			}
			long num2 = (long)period.TotalMilliseconds;
			if (num2 < -1L)
			{
				throw new ArgumentOutOfRangeException("periodTm", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (num2 > (long)((ulong)-2))
			{
				throw new ArgumentOutOfRangeException("periodTm", Environment.GetResourceString("ArgumentOutOfRange_PeriodTooLarge"));
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.TimerSetup(callback, state, (uint)num, (uint)num2, ref stackCrawlMark);
		}

		/// <summary>Initializes a new instance of the <see langword="Timer" /> class, using 32-bit unsigned integers to measure time intervals.</summary>
		/// <param name="callback">A delegate representing a method to be executed.</param>
		/// <param name="state">An object containing information to be used by the callback method, or <see langword="null" />.</param>
		/// <param name="dueTime">The amount of time to delay before <paramref name="callback" /> is invoked, in milliseconds. Specify <see cref="F:System.Threading.Timeout.Infinite" /> to prevent the timer from starting. Specify zero (0) to start the timer immediately.</param>
		/// <param name="period">The time interval between invocations of <paramref name="callback" />, in milliseconds. Specify <see cref="F:System.Threading.Timeout.Infinite" /> to disable periodic signaling.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="dueTime" /> or <paramref name="period" /> parameter is negative and is not equal to <see cref="F:System.Threading.Timeout.Infinite" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="callback" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06003D36 RID: 15670 RVA: 0x000E3D24 File Offset: 0x000E1F24
		[CLSCompliant(false)]
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Timer(TimerCallback callback, object state, uint dueTime, uint period)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.TimerSetup(callback, state, dueTime, period, ref stackCrawlMark);
		}

		/// <summary>Initializes a new instance of the <see langword="Timer" /> class, using 64-bit signed integers to measure time intervals.</summary>
		/// <param name="callback">A <see cref="T:System.Threading.TimerCallback" /> delegate representing a method to be executed.</param>
		/// <param name="state">An object containing information to be used by the callback method, or <see langword="null" />.</param>
		/// <param name="dueTime">The amount of time to delay before <paramref name="callback" /> is invoked, in milliseconds. Specify <see cref="F:System.Threading.Timeout.Infinite" /> to prevent the timer from starting. Specify zero (0) to start the timer immediately.</param>
		/// <param name="period">The time interval between invocations of <paramref name="callback" />, in milliseconds. Specify <see cref="F:System.Threading.Timeout.Infinite" /> to disable periodic signaling.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="dueTime" /> or <paramref name="period" /> parameter is negative and is not equal to <see cref="F:System.Threading.Timeout.Infinite" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The <paramref name="dueTime" /> or <paramref name="period" /> parameter is greater than 4294967294.</exception>
		// Token: 0x06003D37 RID: 15671 RVA: 0x000E3D48 File Offset: 0x000E1F48
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Timer(TimerCallback callback, object state, long dueTime, long period)
		{
			if (dueTime < -1L)
			{
				throw new ArgumentOutOfRangeException("dueTime", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (period < -1L)
			{
				throw new ArgumentOutOfRangeException("period", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (dueTime > (long)((ulong)-2))
			{
				throw new ArgumentOutOfRangeException("dueTime", Environment.GetResourceString("ArgumentOutOfRange_TimeoutTooLarge"));
			}
			if (period > (long)((ulong)-2))
			{
				throw new ArgumentOutOfRangeException("period", Environment.GetResourceString("ArgumentOutOfRange_PeriodTooLarge"));
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.TimerSetup(callback, state, (uint)dueTime, (uint)period, ref stackCrawlMark);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Timer" /> class with an infinite period and an infinite due time, using the newly created <see cref="T:System.Threading.Timer" /> object as the state object.</summary>
		/// <param name="callback">A <see cref="T:System.Threading.TimerCallback" /> delegate representing a method to be executed.</param>
		// Token: 0x06003D38 RID: 15672 RVA: 0x000E3DD8 File Offset: 0x000E1FD8
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Timer(TimerCallback callback)
		{
			int dueTime = -1;
			int period = -1;
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.TimerSetup(callback, this, (uint)dueTime, (uint)period, ref stackCrawlMark);
		}

		// Token: 0x06003D39 RID: 15673 RVA: 0x000E3E00 File Offset: 0x000E2000
		[SecurityCritical]
		private void TimerSetup(TimerCallback callback, object state, uint dueTime, uint period, ref StackCrawlMark stackMark)
		{
			if (callback == null)
			{
				throw new ArgumentNullException("TimerCallback");
			}
			object timer;
			if (Timer.UseNetCoreTimer)
			{
				timer = new TimerQueueTimer(callback, state, dueTime, period, true, ref stackMark);
			}
			else
			{
				timer = new TimerQueueTimer(callback, state, dueTime, period, ref stackMark);
			}
			this.m_timer = new TimerHolder(timer);
		}

		// Token: 0x06003D3A RID: 15674 RVA: 0x000E3E4B File Offset: 0x000E204B
		[SecurityCritical]
		internal static void Pause()
		{
			if (Timer.UseNetCoreTimer)
			{
				TimerQueue.PauseAll();
				return;
			}
			TimerQueue.Instance.Pause();
		}

		// Token: 0x06003D3B RID: 15675 RVA: 0x000E3E64 File Offset: 0x000E2064
		[SecurityCritical]
		internal static void Resume()
		{
			if (Timer.UseNetCoreTimer)
			{
				TimerQueue.ResumeAll();
				return;
			}
			TimerQueue.Instance.Resume();
		}

		/// <summary>Changes the start time and the interval between method invocations for a timer, using 32-bit signed integers to measure time intervals.</summary>
		/// <param name="dueTime">The amount of time to delay before the invoking the callback method specified when the <see cref="T:System.Threading.Timer" /> was constructed, in milliseconds. Specify <see cref="F:System.Threading.Timeout.Infinite" /> to prevent the timer from restarting. Specify zero (0) to restart the timer immediately.</param>
		/// <param name="period">The time interval between invocations of the callback method specified when the <see cref="T:System.Threading.Timer" /> was constructed, in milliseconds. Specify <see cref="F:System.Threading.Timeout.Infinite" /> to disable periodic signaling.</param>
		/// <returns>
		///   <see langword="true" /> if the timer was successfully updated; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.Timer" /> has already been disposed.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="dueTime" /> or <paramref name="period" /> parameter is negative and is not equal to <see cref="F:System.Threading.Timeout.Infinite" />.</exception>
		// Token: 0x06003D3C RID: 15676 RVA: 0x000E3E80 File Offset: 0x000E2080
		[__DynamicallyInvokable]
		public bool Change(int dueTime, int period)
		{
			if (dueTime < -1)
			{
				throw new ArgumentOutOfRangeException("dueTime", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (period < -1)
			{
				throw new ArgumentOutOfRangeException("period", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			return this.m_timer.Change((uint)dueTime, (uint)period);
		}

		/// <summary>Changes the start time and the interval between method invocations for a timer, using <see cref="T:System.TimeSpan" /> values to measure time intervals.</summary>
		/// <param name="dueTime">A <see cref="T:System.TimeSpan" /> representing the amount of time to delay before invoking the callback method specified when the <see cref="T:System.Threading.Timer" /> was constructed. Specify negative one (-1) milliseconds to prevent the timer from restarting. Specify zero (0) to restart the timer immediately.</param>
		/// <param name="period">The time interval between invocations of the callback method specified when the <see cref="T:System.Threading.Timer" /> was constructed. Specify negative one (-1) milliseconds to disable periodic signaling.</param>
		/// <returns>
		///   <see langword="true" /> if the timer was successfully updated; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.Timer" /> has already been disposed.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="dueTime" /> or <paramref name="period" /> parameter, in milliseconds, is less than -1.</exception>
		/// <exception cref="T:System.NotSupportedException">The <paramref name="dueTime" /> or <paramref name="period" /> parameter, in milliseconds, is greater than 4294967294.</exception>
		// Token: 0x06003D3D RID: 15677 RVA: 0x000E3ECC File Offset: 0x000E20CC
		[__DynamicallyInvokable]
		public bool Change(TimeSpan dueTime, TimeSpan period)
		{
			return this.Change((long)dueTime.TotalMilliseconds, (long)period.TotalMilliseconds);
		}

		/// <summary>Changes the start time and the interval between method invocations for a timer, using 32-bit unsigned integers to measure time intervals.</summary>
		/// <param name="dueTime">The amount of time to delay before the invoking the callback method specified when the <see cref="T:System.Threading.Timer" /> was constructed, in milliseconds. Specify <see cref="F:System.Threading.Timeout.Infinite" /> to prevent the timer from restarting. Specify zero (0) to restart the timer immediately.</param>
		/// <param name="period">The time interval between invocations of the callback method specified when the <see cref="T:System.Threading.Timer" /> was constructed, in milliseconds. Specify <see cref="F:System.Threading.Timeout.Infinite" /> to disable periodic signaling.</param>
		/// <returns>
		///   <see langword="true" /> if the timer was successfully updated; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.Timer" /> has already been disposed.</exception>
		// Token: 0x06003D3E RID: 15678 RVA: 0x000E3EE4 File Offset: 0x000E20E4
		[CLSCompliant(false)]
		public bool Change(uint dueTime, uint period)
		{
			return this.m_timer.Change(dueTime, period);
		}

		/// <summary>Changes the start time and the interval between method invocations for a timer, using 64-bit signed integers to measure time intervals.</summary>
		/// <param name="dueTime">The amount of time to delay before the invoking the callback method specified when the <see cref="T:System.Threading.Timer" /> was constructed, in milliseconds. Specify <see cref="F:System.Threading.Timeout.Infinite" /> to prevent the timer from restarting. Specify zero (0) to restart the timer immediately.</param>
		/// <param name="period">The time interval between invocations of the callback method specified when the <see cref="T:System.Threading.Timer" /> was constructed, in milliseconds. Specify <see cref="F:System.Threading.Timeout.Infinite" /> to disable periodic signaling.</param>
		/// <returns>
		///   <see langword="true" /> if the timer was successfully updated; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.Threading.Timer" /> has already been disposed.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="dueTime" /> or <paramref name="period" /> parameter is less than -1.</exception>
		/// <exception cref="T:System.NotSupportedException">The <paramref name="dueTime" /> or <paramref name="period" /> parameter is greater than 4294967294.</exception>
		// Token: 0x06003D3F RID: 15679 RVA: 0x000E3EF4 File Offset: 0x000E20F4
		public bool Change(long dueTime, long period)
		{
			if (dueTime < -1L)
			{
				throw new ArgumentOutOfRangeException("dueTime", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (period < -1L)
			{
				throw new ArgumentOutOfRangeException("period", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (dueTime > (long)((ulong)-2))
			{
				throw new ArgumentOutOfRangeException("dueTime", Environment.GetResourceString("ArgumentOutOfRange_TimeoutTooLarge"));
			}
			if (period > (long)((ulong)-2))
			{
				throw new ArgumentOutOfRangeException("period", Environment.GetResourceString("ArgumentOutOfRange_PeriodTooLarge"));
			}
			return this.m_timer.Change((uint)dueTime, (uint)period);
		}

		/// <summary>Releases all resources used by the current instance of <see cref="T:System.Threading.Timer" /> and signals when the timer has been disposed of.</summary>
		/// <param name="notifyObject">The <see cref="T:System.Threading.WaitHandle" /> to be signaled when the <see langword="Timer" /> has been disposed of.</param>
		/// <returns>
		///   <see langword="true" /> if the function succeeds; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="notifyObject" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06003D40 RID: 15680 RVA: 0x000E3F7A File Offset: 0x000E217A
		public bool Dispose(WaitHandle notifyObject)
		{
			if (notifyObject == null)
			{
				throw new ArgumentNullException("notifyObject");
			}
			return this.m_timer.Close(notifyObject);
		}

		/// <summary>Releases all resources used by the current instance of <see cref="T:System.Threading.Timer" />.</summary>
		// Token: 0x06003D41 RID: 15681 RVA: 0x000E3F96 File Offset: 0x000E2196
		[__DynamicallyInvokable]
		public void Dispose()
		{
			this.m_timer.Close();
		}

		// Token: 0x06003D42 RID: 15682 RVA: 0x000E3FA3 File Offset: 0x000E21A3
		internal void KeepRootedWhileScheduled()
		{
			GC.SuppressFinalize(this.m_timer);
		}

		// Token: 0x0400198B RID: 6539
		internal static readonly bool UseNetCoreTimer = AppContextSwitches.UseNetCoreTimer;

		// Token: 0x0400198C RID: 6540
		private const uint MAX_SUPPORTED_TIMEOUT = 4294967294U;

		// Token: 0x0400198D RID: 6541
		private TimerHolder m_timer;
	}
}
