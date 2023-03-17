using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Security;
using System.Security.Permissions;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace System.Threading
{
	/// <summary>Encapsulates operating system-specific objects that wait for exclusive access to shared resources.</summary>
	// Token: 0x02000506 RID: 1286
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public abstract class WaitHandle : MarshalByRefObject, IDisposable
	{
		// Token: 0x06003D60 RID: 15712 RVA: 0x000E41A9 File Offset: 0x000E23A9
		[SecuritySafeCritical]
		private static IntPtr GetInvalidHandle()
		{
			return Win32Native.INVALID_HANDLE_VALUE;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.WaitHandle" /> class.</summary>
		// Token: 0x06003D61 RID: 15713 RVA: 0x000E41B0 File Offset: 0x000E23B0
		[__DynamicallyInvokable]
		protected WaitHandle()
		{
			this.Init();
		}

		// Token: 0x06003D62 RID: 15714 RVA: 0x000E41BE File Offset: 0x000E23BE
		[SecuritySafeCritical]
		private void Init()
		{
			this.safeWaitHandle = null;
			this.waitHandle = WaitHandle.InvalidHandle;
			this.hasThreadAffinity = false;
		}

		/// <summary>Gets or sets the native operating system handle.</summary>
		/// <returns>An <see langword="IntPtr" /> representing the native operating system handle. The default is the value of the <see cref="F:System.Threading.WaitHandle.InvalidHandle" /> field.</returns>
		// Token: 0x17000926 RID: 2342
		// (get) Token: 0x06003D63 RID: 15715 RVA: 0x000E41DB File Offset: 0x000E23DB
		// (set) Token: 0x06003D64 RID: 15716 RVA: 0x000E41FC File Offset: 0x000E23FC
		[Obsolete("Use the SafeWaitHandle property instead.")]
		public virtual IntPtr Handle
		{
			[SecuritySafeCritical]
			get
			{
				if (this.safeWaitHandle != null)
				{
					return this.safeWaitHandle.DangerousGetHandle();
				}
				return WaitHandle.InvalidHandle;
			}
			[SecurityCritical]
			[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
			set
			{
				if (value == WaitHandle.InvalidHandle)
				{
					if (this.safeWaitHandle != null)
					{
						this.safeWaitHandle.SetHandleAsInvalid();
						this.safeWaitHandle = null;
					}
				}
				else
				{
					this.safeWaitHandle = new SafeWaitHandle(value, true);
				}
				this.waitHandle = value;
			}
		}

		/// <summary>Gets or sets the native operating system handle.</summary>
		/// <returns>A <see cref="T:Microsoft.Win32.SafeHandles.SafeWaitHandle" /> representing the native operating system handle.</returns>
		// Token: 0x17000927 RID: 2343
		// (get) Token: 0x06003D65 RID: 15717 RVA: 0x000E424E File Offset: 0x000E244E
		// (set) Token: 0x06003D66 RID: 15718 RVA: 0x000E4278 File Offset: 0x000E2478
		public SafeWaitHandle SafeWaitHandle
		{
			[SecurityCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
			[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
			get
			{
				if (this.safeWaitHandle == null)
				{
					this.safeWaitHandle = new SafeWaitHandle(WaitHandle.InvalidHandle, false);
				}
				return this.safeWaitHandle;
			}
			[SecurityCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
			set
			{
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
				}
				finally
				{
					if (value == null)
					{
						this.safeWaitHandle = null;
						this.waitHandle = WaitHandle.InvalidHandle;
					}
					else
					{
						this.safeWaitHandle = value;
						this.waitHandle = this.safeWaitHandle.DangerousGetHandle();
					}
				}
			}
		}

		// Token: 0x06003D67 RID: 15719 RVA: 0x000E42D4 File Offset: 0x000E24D4
		[SecurityCritical]
		internal void SetHandleInternal(SafeWaitHandle handle)
		{
			this.safeWaitHandle = handle;
			this.waitHandle = handle.DangerousGetHandle();
		}

		/// <summary>Blocks the current thread until the current <see cref="T:System.Threading.WaitHandle" /> receives a signal, using a 32-bit signed integer to specify the time interval and specifying whether to exit the synchronization domain before the wait.</summary>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait, or <see cref="F:System.Threading.Timeout.Infinite" /> (-1) to wait indefinitely.</param>
		/// <param name="exitContext">
		///   <see langword="true" /> to exit the synchronization domain for the context before the wait (if in a synchronized context), and reacquire it afterward; otherwise, <see langword="false" />.</param>
		/// <returns>
		///   <see langword="true" /> if the current instance receives a signal; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The current instance has already been disposed.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="millisecondsTimeout" /> is a negative number other than -1, which represents an infinite time-out.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait completed because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.InvalidOperationException">The current instance is a transparent proxy for a <see cref="T:System.Threading.WaitHandle" /> in another application domain.</exception>
		// Token: 0x06003D68 RID: 15720 RVA: 0x000E42EB File Offset: 0x000E24EB
		public virtual bool WaitOne(int millisecondsTimeout, bool exitContext)
		{
			if (millisecondsTimeout < -1)
			{
				throw new ArgumentOutOfRangeException("millisecondsTimeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			return this.WaitOne((long)millisecondsTimeout, exitContext);
		}

		/// <summary>Blocks the current thread until the current instance receives a signal, using a <see cref="T:System.TimeSpan" /> to specify the time interval and specifying whether to exit the synchronization domain before the wait.</summary>
		/// <param name="timeout">A <see cref="T:System.TimeSpan" /> that represents the number of milliseconds to wait, or a <see cref="T:System.TimeSpan" /> that represents -1 milliseconds to wait indefinitely.</param>
		/// <param name="exitContext">
		///   <see langword="true" /> to exit the synchronization domain for the context before the wait (if in a synchronized context), and reacquire it afterward; otherwise, <see langword="false" />.</param>
		/// <returns>
		///   <see langword="true" /> if the current instance receives a signal; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The current instance has already been disposed.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="timeout" /> is a negative number other than -1 milliseconds, which represents an infinite time-out.  
		/// -or-  
		/// <paramref name="timeout" /> is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait completed because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.InvalidOperationException">The current instance is a transparent proxy for a <see cref="T:System.Threading.WaitHandle" /> in another application domain.</exception>
		// Token: 0x06003D69 RID: 15721 RVA: 0x000E4310 File Offset: 0x000E2510
		public virtual bool WaitOne(TimeSpan timeout, bool exitContext)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (-1L > num || 2147483647L < num)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			return this.WaitOne(num, exitContext);
		}

		/// <summary>Blocks the current thread until the current <see cref="T:System.Threading.WaitHandle" /> receives a signal.</summary>
		/// <returns>
		///   <see langword="true" /> if the current instance receives a signal. If the current instance is never signaled, <see cref="M:System.Threading.WaitHandle.WaitOne(System.Int32,System.Boolean)" /> never returns.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The current instance has already been disposed.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait completed because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.InvalidOperationException">The current instance is a transparent proxy for a <see cref="T:System.Threading.WaitHandle" /> in another application domain.</exception>
		// Token: 0x06003D6A RID: 15722 RVA: 0x000E4351 File Offset: 0x000E2551
		[__DynamicallyInvokable]
		public virtual bool WaitOne()
		{
			return this.WaitOne(-1, false);
		}

		/// <summary>Blocks the current thread until the current <see cref="T:System.Threading.WaitHandle" /> receives a signal, using a 32-bit signed integer to specify the time interval in milliseconds.</summary>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait, or <see cref="F:System.Threading.Timeout.Infinite" /> (-1) to wait indefinitely.</param>
		/// <returns>
		///   <see langword="true" /> if the current instance receives a signal; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The current instance has already been disposed.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="millisecondsTimeout" /> is a negative number other than -1, which represents an infinite time-out.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait completed because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.InvalidOperationException">The current instance is a transparent proxy for a <see cref="T:System.Threading.WaitHandle" /> in another application domain.</exception>
		// Token: 0x06003D6B RID: 15723 RVA: 0x000E435B File Offset: 0x000E255B
		[__DynamicallyInvokable]
		public virtual bool WaitOne(int millisecondsTimeout)
		{
			return this.WaitOne(millisecondsTimeout, false);
		}

		/// <summary>Blocks the current thread until the current instance receives a signal, using a <see cref="T:System.TimeSpan" /> to specify the time interval.</summary>
		/// <param name="timeout">A <see cref="T:System.TimeSpan" /> that represents the number of milliseconds to wait, or a <see cref="T:System.TimeSpan" /> that represents -1 milliseconds to wait indefinitely.</param>
		/// <returns>
		///   <see langword="true" /> if the current instance receives a signal; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The current instance has already been disposed.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="timeout" /> is a negative number other than -1 milliseconds, which represents an infinite time-out.  
		/// -or-  
		/// <paramref name="timeout" /> is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait completed because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.InvalidOperationException">The current instance is a transparent proxy for a <see cref="T:System.Threading.WaitHandle" /> in another application domain.</exception>
		// Token: 0x06003D6C RID: 15724 RVA: 0x000E4365 File Offset: 0x000E2565
		[__DynamicallyInvokable]
		public virtual bool WaitOne(TimeSpan timeout)
		{
			return this.WaitOne(timeout, false);
		}

		// Token: 0x06003D6D RID: 15725 RVA: 0x000E436F File Offset: 0x000E256F
		[SecuritySafeCritical]
		private bool WaitOne(long timeout, bool exitContext)
		{
			return WaitHandle.InternalWaitOne(this.safeWaitHandle, timeout, this.hasThreadAffinity, exitContext);
		}

		// Token: 0x06003D6E RID: 15726 RVA: 0x000E4388 File Offset: 0x000E2588
		[SecurityCritical]
		internal static bool InternalWaitOne(SafeHandle waitableSafeHandle, long millisecondsTimeout, bool hasThreadAffinity, bool exitContext)
		{
			if (waitableSafeHandle == null)
			{
				throw new ObjectDisposedException(null, Environment.GetResourceString("ObjectDisposed_Generic"));
			}
			int num = WaitHandle.WaitOneNative(waitableSafeHandle, (uint)millisecondsTimeout, hasThreadAffinity, exitContext);
			if (AppDomainPauseManager.IsPaused)
			{
				AppDomainPauseManager.ResumeEvent.WaitOneWithoutFAS();
			}
			if (num == 128)
			{
				WaitHandle.ThrowAbandonedMutexException();
			}
			return num != 258;
		}

		// Token: 0x06003D6F RID: 15727 RVA: 0x000E43E0 File Offset: 0x000E25E0
		[SecurityCritical]
		internal bool WaitOneWithoutFAS()
		{
			if (this.safeWaitHandle == null)
			{
				throw new ObjectDisposedException(null, Environment.GetResourceString("ObjectDisposed_Generic"));
			}
			long num = -1L;
			int num2 = WaitHandle.WaitOneNative(this.safeWaitHandle, (uint)num, this.hasThreadAffinity, false);
			if (num2 == 128)
			{
				WaitHandle.ThrowAbandonedMutexException();
			}
			return num2 != 258;
		}

		// Token: 0x06003D70 RID: 15728
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int WaitOneNative(SafeHandle waitableSafeHandle, uint millisecondsTimeout, bool hasThreadAffinity, bool exitContext);

		// Token: 0x06003D71 RID: 15729
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int WaitMultiple(WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext, bool WaitAll);

		/// <summary>Waits for all the elements in the specified array to receive a signal, using an <see cref="T:System.Int32" /> value to specify the time interval and specifying whether to exit the synchronization domain before the wait.</summary>
		/// <param name="waitHandles">A <see langword="WaitHandle" /> array containing the objects for which the current instance will wait. This array cannot contain multiple references to the same object (duplicates).</param>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait, or <see cref="F:System.Threading.Timeout.Infinite" /> (-1) to wait indefinitely.</param>
		/// <param name="exitContext">
		///   <see langword="true" /> to exit the synchronization domain for the context before the wait (if in a synchronized context), and reacquire it afterward; otherwise, <see langword="false" />.</param>
		/// <returns>
		///   <see langword="true" /> when every element in <paramref name="waitHandles" /> has received a signal; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="waitHandles" /> parameter is <see langword="null" />.  
		///  -or-  
		///  One or more of the objects in the <paramref name="waitHandles" /> array is <see langword="null" />.  
		///  -or-  
		///  <paramref name="waitHandles" /> is an array with no elements and the .NET Framework version is 2.0 or later.</exception>
		/// <exception cref="T:System.DuplicateWaitObjectException">The <paramref name="waitHandles" /> array contains elements that are duplicates.</exception>
		/// <exception cref="T:System.NotSupportedException">The number of objects in <paramref name="waitHandles" /> is greater than the system permits.  
		///  -or-  
		///  The <see cref="T:System.STAThreadAttribute" /> attribute is applied to the thread procedure for the current thread, and <paramref name="waitHandles" /> contains more than one element.</exception>
		/// <exception cref="T:System.ApplicationException">
		///   <paramref name="waitHandles" /> is an array with no elements and the .NET Framework version is 1.0 or 1.1.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="millisecondsTimeout" /> is a negative number other than -1, which represents an infinite time-out.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait completed because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.InvalidOperationException">The <paramref name="waitHandles" /> array contains a transparent proxy for a <see cref="T:System.Threading.WaitHandle" /> in another application domain.</exception>
		// Token: 0x06003D72 RID: 15730 RVA: 0x000E443C File Offset: 0x000E263C
		[SecuritySafeCritical]
		public static bool WaitAll(WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext)
		{
			if (waitHandles == null)
			{
				throw new ArgumentNullException(Environment.GetResourceString("ArgumentNull_Waithandles"));
			}
			if (waitHandles.Length == 0)
			{
				throw new ArgumentNullException(Environment.GetResourceString("Argument_EmptyWaithandleArray"));
			}
			if (waitHandles.Length > 64)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_MaxWaitHandles"));
			}
			if (-1 > millisecondsTimeout)
			{
				throw new ArgumentOutOfRangeException("millisecondsTimeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			WaitHandle[] array = new WaitHandle[waitHandles.Length];
			for (int i = 0; i < waitHandles.Length; i++)
			{
				WaitHandle waitHandle = waitHandles[i];
				if (waitHandle == null)
				{
					throw new ArgumentNullException(Environment.GetResourceString("ArgumentNull_ArrayElement"));
				}
				if (RemotingServices.IsTransparentProxy(waitHandle))
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_WaitOnTransparentProxy"));
				}
				array[i] = waitHandle;
			}
			int num = WaitHandle.WaitMultiple(array, millisecondsTimeout, exitContext, true);
			if (AppDomainPauseManager.IsPaused)
			{
				AppDomainPauseManager.ResumeEvent.WaitOneWithoutFAS();
			}
			if (128 <= num && 128 + array.Length > num)
			{
				WaitHandle.ThrowAbandonedMutexException();
			}
			GC.KeepAlive(array);
			return num != 258;
		}

		/// <summary>Waits for all the elements in the specified array to receive a signal, using a <see cref="T:System.TimeSpan" /> value to specify the time interval, and specifying whether to exit the synchronization domain before the wait.</summary>
		/// <param name="waitHandles">A <see langword="WaitHandle" /> array containing the objects for which the current instance will wait. This array cannot contain multiple references to the same object.</param>
		/// <param name="timeout">A <see cref="T:System.TimeSpan" /> that represents the number of milliseconds to wait, or a <see cref="T:System.TimeSpan" /> that represents -1 milliseconds, to wait indefinitely.</param>
		/// <param name="exitContext">
		///   <see langword="true" /> to exit the synchronization domain for the context before the wait (if in a synchronized context), and reacquire it afterward; otherwise, <see langword="false" />.</param>
		/// <returns>
		///   <see langword="true" /> when every element in <paramref name="waitHandles" /> has received a signal; otherwise <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="waitHandles" /> parameter is <see langword="null" />.  
		///  -or-  
		///  One or more of the objects in the <paramref name="waitHandles" /> array is <see langword="null" />.  
		///  -or-  
		///  <paramref name="waitHandles" /> is an array with no elements and the .NET Framework version is 2.0 or later.</exception>
		/// <exception cref="T:System.DuplicateWaitObjectException">The <paramref name="waitHandles" /> array contains elements that are duplicates.</exception>
		/// <exception cref="T:System.NotSupportedException">The number of objects in <paramref name="waitHandles" /> is greater than the system permits.  
		///  -or-  
		///  The <see cref="T:System.STAThreadAttribute" /> attribute is applied to the thread procedure for the current thread, and <paramref name="waitHandles" /> contains more than one element.</exception>
		/// <exception cref="T:System.ApplicationException">
		///   <paramref name="waitHandles" /> is an array with no elements and the .NET Framework version is 1.0 or 1.1.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="timeout" /> is a negative number other than -1 milliseconds, which represents an infinite time-out.  
		/// -or-  
		/// <paramref name="timeout" /> is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait terminated because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.InvalidOperationException">The <paramref name="waitHandles" /> array contains a transparent proxy for a <see cref="T:System.Threading.WaitHandle" /> in another application domain.</exception>
		// Token: 0x06003D73 RID: 15731 RVA: 0x000E4530 File Offset: 0x000E2730
		public static bool WaitAll(WaitHandle[] waitHandles, TimeSpan timeout, bool exitContext)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (-1L > num || 2147483647L < num)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			return WaitHandle.WaitAll(waitHandles, (int)num, exitContext);
		}

		/// <summary>Waits for all the elements in the specified array to receive a signal.</summary>
		/// <param name="waitHandles">A <see langword="WaitHandle" /> array containing the objects for which the current instance will wait. This array cannot contain multiple references to the same object.</param>
		/// <returns>
		///   <see langword="true" /> when every element in <paramref name="waitHandles" /> has received a signal; otherwise the method never returns.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="waitHandles" /> parameter is <see langword="null" />. -or-  
		///  One or more of the objects in the <paramref name="waitHandles" /> array are <see langword="null" />.  
		///  -or-  
		///  <paramref name="waitHandles" /> is an array with no elements and the .NET Framework version is 2.0 or later.</exception>
		/// <exception cref="T:System.DuplicateWaitObjectException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.ArgumentException" />, instead.  
		///
		///
		///
		///
		///  The <paramref name="waitHandles" /> array contains elements that are duplicates.</exception>
		/// <exception cref="T:System.NotSupportedException">The number of objects in <paramref name="waitHandles" /> is greater than the system permits.  
		///  -or-  
		///  The <see cref="T:System.STAThreadAttribute" /> attribute is applied to the thread procedure for the current thread, and <paramref name="waitHandles" /> contains more than one element.</exception>
		/// <exception cref="T:System.ApplicationException">
		///   <paramref name="waitHandles" /> is an array with no elements and the .NET Framework version is 1.0 or 1.1.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait terminated because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.InvalidOperationException">The <paramref name="waitHandles" /> array contains a transparent proxy for a <see cref="T:System.Threading.WaitHandle" /> in another application domain.</exception>
		// Token: 0x06003D74 RID: 15732 RVA: 0x000E4572 File Offset: 0x000E2772
		[__DynamicallyInvokable]
		public static bool WaitAll(WaitHandle[] waitHandles)
		{
			return WaitHandle.WaitAll(waitHandles, -1, true);
		}

		/// <summary>Waits for all the elements in the specified array to receive a signal, using an <see cref="T:System.Int32" /> value to specify the time interval.</summary>
		/// <param name="waitHandles">A <see langword="WaitHandle" /> array containing the objects for which the current instance will wait. This array cannot contain multiple references to the same object (duplicates).</param>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait, or <see cref="F:System.Threading.Timeout.Infinite" /> (-1) to wait indefinitely.</param>
		/// <returns>
		///   <see langword="true" /> when every element in <paramref name="waitHandles" /> has received a signal; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="waitHandles" /> parameter is <see langword="null" />.  
		///  -or-  
		///  One or more of the objects in the <paramref name="waitHandles" /> array is <see langword="null" />.  
		///  -or-  
		///  <paramref name="waitHandles" /> is an array with no elements.</exception>
		/// <exception cref="T:System.DuplicateWaitObjectException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.ArgumentException" />, instead.  
		///
		///
		///
		///
		///  The <paramref name="waitHandles" /> array contains elements that are duplicates.</exception>
		/// <exception cref="T:System.NotSupportedException">The number of objects in <paramref name="waitHandles" /> is greater than the system permits.  
		///  -or-  
		///  The <see cref="T:System.STAThreadAttribute" /> attribute is applied to the thread procedure for the current thread, and <paramref name="waitHandles" /> contains more than one element.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="millisecondsTimeout" /> is a negative number other than -1, which represents an infinite time-out.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait completed because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.InvalidOperationException">The <paramref name="waitHandles" /> array contains a transparent proxy for a <see cref="T:System.Threading.WaitHandle" /> in another application domain.</exception>
		// Token: 0x06003D75 RID: 15733 RVA: 0x000E457C File Offset: 0x000E277C
		[__DynamicallyInvokable]
		public static bool WaitAll(WaitHandle[] waitHandles, int millisecondsTimeout)
		{
			return WaitHandle.WaitAll(waitHandles, millisecondsTimeout, true);
		}

		/// <summary>Waits for all the elements in the specified array to receive a signal, using a <see cref="T:System.TimeSpan" /> value to specify the time interval.</summary>
		/// <param name="waitHandles">A <see langword="WaitHandle" /> array containing the objects for which the current instance will wait. This array cannot contain multiple references to the same object.</param>
		/// <param name="timeout">A <see cref="T:System.TimeSpan" /> that represents the number of milliseconds to wait, or a <see cref="T:System.TimeSpan" /> that represents -1 milliseconds, to wait indefinitely.</param>
		/// <returns>
		///   <see langword="true" /> when every element in <paramref name="waitHandles" /> has received a signal; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="waitHandles" /> parameter is <see langword="null" />.  
		///  -or-  
		///  One or more of the objects in the <paramref name="waitHandles" /> array is <see langword="null" />.  
		///  -or-  
		///  <paramref name="waitHandles" /> is an array with no elements.</exception>
		/// <exception cref="T:System.DuplicateWaitObjectException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.ArgumentException" />, instead.  
		///
		///
		///
		///
		///  The <paramref name="waitHandles" /> array contains elements that are duplicates.</exception>
		/// <exception cref="T:System.NotSupportedException">The number of objects in <paramref name="waitHandles" /> is greater than the system permits.  
		///  -or-  
		///  The <see cref="T:System.STAThreadAttribute" /> attribute is applied to the thread procedure for the current thread, and <paramref name="waitHandles" /> contains more than one element.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="timeout" /> is a negative number other than -1 milliseconds, which represents an infinite time-out.  
		/// -or-  
		/// <paramref name="timeout" /> is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait terminated because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.InvalidOperationException">The <paramref name="waitHandles" /> array contains a transparent proxy for a <see cref="T:System.Threading.WaitHandle" /> in another application domain.</exception>
		// Token: 0x06003D76 RID: 15734 RVA: 0x000E4586 File Offset: 0x000E2786
		[__DynamicallyInvokable]
		public static bool WaitAll(WaitHandle[] waitHandles, TimeSpan timeout)
		{
			return WaitHandle.WaitAll(waitHandles, timeout, true);
		}

		/// <summary>Waits for any of the elements in the specified array to receive a signal, using a 32-bit signed integer to specify the time interval, and specifying whether to exit the synchronization domain before the wait.</summary>
		/// <param name="waitHandles">A <see langword="WaitHandle" /> array containing the objects for which the current instance will wait.</param>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait, or <see cref="F:System.Threading.Timeout.Infinite" /> (-1) to wait indefinitely.</param>
		/// <param name="exitContext">
		///   <see langword="true" /> to exit the synchronization domain for the context before the wait (if in a synchronized context), and reacquire it afterward; otherwise, <see langword="false" />.</param>
		/// <returns>The array index of the object that satisfied the wait, or <see cref="F:System.Threading.WaitHandle.WaitTimeout" /> if no object satisfied the wait and a time interval equivalent to <paramref name="millisecondsTimeout" /> has passed.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="waitHandles" /> parameter is <see langword="null" />.  
		///  -or-  
		///  One or more of the objects in the <paramref name="waitHandles" /> array is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The number of objects in <paramref name="waitHandles" /> is greater than the system permits.</exception>
		/// <exception cref="T:System.ApplicationException">
		///   <paramref name="waitHandles" /> is an array with no elements, and the .NET Framework version is 1.0 or 1.1.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="millisecondsTimeout" /> is a negative number other than -1, which represents an infinite time-out.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait completed because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="waitHandles" /> is an array with no elements, and the .NET Framework version is 2.0 or later.</exception>
		/// <exception cref="T:System.InvalidOperationException">The <paramref name="waitHandles" /> array contains a transparent proxy for a <see cref="T:System.Threading.WaitHandle" /> in another application domain.</exception>
		// Token: 0x06003D77 RID: 15735 RVA: 0x000E4590 File Offset: 0x000E2790
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int WaitAny(WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext)
		{
			if (waitHandles == null)
			{
				throw new ArgumentNullException(Environment.GetResourceString("ArgumentNull_Waithandles"));
			}
			if (waitHandles.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyWaithandleArray"));
			}
			if (64 < waitHandles.Length)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_MaxWaitHandles"));
			}
			if (-1 > millisecondsTimeout)
			{
				throw new ArgumentOutOfRangeException("millisecondsTimeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			WaitHandle[] array = new WaitHandle[waitHandles.Length];
			for (int i = 0; i < waitHandles.Length; i++)
			{
				WaitHandle waitHandle = waitHandles[i];
				if (waitHandle == null)
				{
					throw new ArgumentNullException(Environment.GetResourceString("ArgumentNull_ArrayElement"));
				}
				if (RemotingServices.IsTransparentProxy(waitHandle))
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_WaitOnTransparentProxy"));
				}
				array[i] = waitHandle;
			}
			int num = WaitHandle.WaitMultiple(array, millisecondsTimeout, exitContext, false);
			if (AppDomainPauseManager.IsPaused)
			{
				AppDomainPauseManager.ResumeEvent.WaitOneWithoutFAS();
			}
			if (128 <= num && 128 + array.Length > num)
			{
				int num2 = num - 128;
				if (0 <= num2 && num2 < array.Length)
				{
					WaitHandle.ThrowAbandonedMutexException(num2, array[num2]);
				}
				else
				{
					WaitHandle.ThrowAbandonedMutexException();
				}
			}
			GC.KeepAlive(array);
			return num;
		}

		/// <summary>Waits for any of the elements in the specified array to receive a signal, using a <see cref="T:System.TimeSpan" /> to specify the time interval and specifying whether to exit the synchronization domain before the wait.</summary>
		/// <param name="waitHandles">A <see langword="WaitHandle" /> array containing the objects for which the current instance will wait.</param>
		/// <param name="timeout">A <see cref="T:System.TimeSpan" /> that represents the number of milliseconds to wait, or a <see cref="T:System.TimeSpan" /> that represents -1 milliseconds to wait indefinitely.</param>
		/// <param name="exitContext">
		///   <see langword="true" /> to exit the synchronization domain for the context before the wait (if in a synchronized context), and reacquire it afterward; otherwise, <see langword="false" />.</param>
		/// <returns>The array index of the object that satisfied the wait, or <see cref="F:System.Threading.WaitHandle.WaitTimeout" /> if no object satisfied the wait and a time interval equivalent to <paramref name="timeout" /> has passed.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="waitHandles" /> parameter is <see langword="null" />.  
		///  -or-  
		///  One or more of the objects in the <paramref name="waitHandles" /> array is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The number of objects in <paramref name="waitHandles" /> is greater than the system permits.</exception>
		/// <exception cref="T:System.ApplicationException">
		///   <paramref name="waitHandles" /> is an array with no elements, and the .NET Framework version is 1.0 or 1.1.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="timeout" /> is a negative number other than -1 milliseconds, which represents an infinite time-out.  
		/// -or-  
		/// <paramref name="timeout" /> is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait completed because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="waitHandles" /> is an array with no elements, and the .NET Framework version is 2.0 or later.</exception>
		/// <exception cref="T:System.InvalidOperationException">The <paramref name="waitHandles" /> array contains a transparent proxy for a <see cref="T:System.Threading.WaitHandle" /> in another application domain.</exception>
		// Token: 0x06003D78 RID: 15736 RVA: 0x000E469C File Offset: 0x000E289C
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int WaitAny(WaitHandle[] waitHandles, TimeSpan timeout, bool exitContext)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (-1L > num || 2147483647L < num)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			return WaitHandle.WaitAny(waitHandles, (int)num, exitContext);
		}

		/// <summary>Waits for any of the elements in the specified array to receive a signal, using a <see cref="T:System.TimeSpan" /> to specify the time interval.</summary>
		/// <param name="waitHandles">A <see langword="WaitHandle" /> array containing the objects for which the current instance will wait.</param>
		/// <param name="timeout">A <see cref="T:System.TimeSpan" /> that represents the number of milliseconds to wait, or a <see cref="T:System.TimeSpan" /> that represents -1 milliseconds to wait indefinitely.</param>
		/// <returns>The array index of the object that satisfied the wait, or <see cref="F:System.Threading.WaitHandle.WaitTimeout" /> if no object satisfied the wait and a time interval equivalent to <paramref name="timeout" /> has passed.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="waitHandles" /> parameter is <see langword="null" />.  
		///  -or-  
		///  One or more of the objects in the <paramref name="waitHandles" /> array is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The number of objects in <paramref name="waitHandles" /> is greater than the system permits.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="timeout" /> is a negative number other than -1 milliseconds, which represents an infinite time-out.  
		/// -or-  
		/// <paramref name="timeout" /> is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait completed because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="waitHandles" /> is an array with no elements.</exception>
		/// <exception cref="T:System.InvalidOperationException">The <paramref name="waitHandles" /> array contains a transparent proxy for a <see cref="T:System.Threading.WaitHandle" /> in another application domain.</exception>
		// Token: 0x06003D79 RID: 15737 RVA: 0x000E46DE File Offset: 0x000E28DE
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public static int WaitAny(WaitHandle[] waitHandles, TimeSpan timeout)
		{
			return WaitHandle.WaitAny(waitHandles, timeout, true);
		}

		/// <summary>Waits for any of the elements in the specified array to receive a signal.</summary>
		/// <param name="waitHandles">A <see langword="WaitHandle" /> array containing the objects for which the current instance will wait.</param>
		/// <returns>The array index of the object that satisfied the wait.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="waitHandles" /> parameter is <see langword="null" />.  
		///  -or-  
		///  One or more of the objects in the <paramref name="waitHandles" /> array is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The number of objects in <paramref name="waitHandles" /> is greater than the system permits.</exception>
		/// <exception cref="T:System.ApplicationException">
		///   <paramref name="waitHandles" /> is an array with no elements, and the .NET Framework version is 1.0 or 1.1.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait completed because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="waitHandles" /> is an array with no elements, and the .NET Framework version is 2.0 or later.</exception>
		/// <exception cref="T:System.InvalidOperationException">The <paramref name="waitHandles" /> array contains a transparent proxy for a <see cref="T:System.Threading.WaitHandle" /> in another application domain.</exception>
		// Token: 0x06003D7A RID: 15738 RVA: 0x000E46E8 File Offset: 0x000E28E8
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public static int WaitAny(WaitHandle[] waitHandles)
		{
			return WaitHandle.WaitAny(waitHandles, -1, true);
		}

		/// <summary>Waits for any of the elements in the specified array to receive a signal, using a 32-bit signed integer to specify the time interval.</summary>
		/// <param name="waitHandles">A <see langword="WaitHandle" /> array containing the objects for which the current instance will wait.</param>
		/// <param name="millisecondsTimeout">The number of milliseconds to wait, or <see cref="F:System.Threading.Timeout.Infinite" /> (-1) to wait indefinitely.</param>
		/// <returns>The array index of the object that satisfied the wait, or <see cref="F:System.Threading.WaitHandle.WaitTimeout" /> if no object satisfied the wait and a time interval equivalent to <paramref name="millisecondsTimeout" /> has passed.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="waitHandles" /> parameter is <see langword="null" />.  
		///  -or-  
		///  One or more of the objects in the <paramref name="waitHandles" /> array is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The number of objects in <paramref name="waitHandles" /> is greater than the system permits.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="millisecondsTimeout" /> is a negative number other than -1, which represents an infinite time-out.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait completed because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="waitHandles" /> is an array with no elements.</exception>
		/// <exception cref="T:System.InvalidOperationException">The <paramref name="waitHandles" /> array contains a transparent proxy for a <see cref="T:System.Threading.WaitHandle" /> in another application domain.</exception>
		// Token: 0x06003D7B RID: 15739 RVA: 0x000E46F2 File Offset: 0x000E28F2
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public static int WaitAny(WaitHandle[] waitHandles, int millisecondsTimeout)
		{
			return WaitHandle.WaitAny(waitHandles, millisecondsTimeout, true);
		}

		// Token: 0x06003D7C RID: 15740
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int SignalAndWaitOne(SafeWaitHandle waitHandleToSignal, SafeWaitHandle waitHandleToWaitOn, int millisecondsTimeout, bool hasThreadAffinity, bool exitContext);

		/// <summary>Signals one <see cref="T:System.Threading.WaitHandle" /> and waits on another.</summary>
		/// <param name="toSignal">The <see cref="T:System.Threading.WaitHandle" /> to signal.</param>
		/// <param name="toWaitOn">The <see cref="T:System.Threading.WaitHandle" /> to wait on.</param>
		/// <returns>
		///   <see langword="true" /> if both the signal and the wait complete successfully; if the wait does not complete, the method does not return.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="toSignal" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="toWaitOn" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The method was called on a thread that has <see cref="T:System.STAThreadAttribute" />.</exception>
		/// <exception cref="T:System.PlatformNotSupportedException">This method is not supported on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.InvalidOperationException">
		///   <paramref name="toSignal" /> is a semaphore, and it already has a full count.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait completed because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		// Token: 0x06003D7D RID: 15741 RVA: 0x000E46FC File Offset: 0x000E28FC
		public static bool SignalAndWait(WaitHandle toSignal, WaitHandle toWaitOn)
		{
			return WaitHandle.SignalAndWait(toSignal, toWaitOn, -1, false);
		}

		/// <summary>Signals one <see cref="T:System.Threading.WaitHandle" /> and waits on another, specifying the time-out interval as a <see cref="T:System.TimeSpan" /> and specifying whether to exit the synchronization domain for the context before entering the wait.</summary>
		/// <param name="toSignal">The <see cref="T:System.Threading.WaitHandle" /> to signal.</param>
		/// <param name="toWaitOn">The <see cref="T:System.Threading.WaitHandle" /> to wait on.</param>
		/// <param name="timeout">A <see cref="T:System.TimeSpan" /> that represents the interval to wait. If the value is -1, the wait is infinite.</param>
		/// <param name="exitContext">
		///   <see langword="true" /> to exit the synchronization domain for the context before the wait (if in a synchronized context), and reacquire it afterward; otherwise, <see langword="false" />.</param>
		/// <returns>
		///   <see langword="true" /> if both the signal and the wait completed successfully, or <see langword="false" /> if the signal completed but the wait timed out.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="toSignal" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="toWaitOn" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The method was called on a thread that has <see cref="T:System.STAThreadAttribute" />.</exception>
		/// <exception cref="T:System.PlatformNotSupportedException">This method is not supported on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.InvalidOperationException">
		///   <paramref name="toSignal" /> is a semaphore, and it already has a full count.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="timeout" /> evaluates to a negative number of milliseconds other than -1.  
		/// -or-  
		/// <paramref name="timeout" /> is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait completed because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		// Token: 0x06003D7E RID: 15742 RVA: 0x000E4708 File Offset: 0x000E2908
		public static bool SignalAndWait(WaitHandle toSignal, WaitHandle toWaitOn, TimeSpan timeout, bool exitContext)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (-1L > num || 2147483647L < num)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			return WaitHandle.SignalAndWait(toSignal, toWaitOn, (int)num, exitContext);
		}

		/// <summary>Signals one <see cref="T:System.Threading.WaitHandle" /> and waits on another, specifying a time-out interval as a 32-bit signed integer and specifying whether to exit the synchronization domain for the context before entering the wait.</summary>
		/// <param name="toSignal">The <see cref="T:System.Threading.WaitHandle" /> to signal.</param>
		/// <param name="toWaitOn">The <see cref="T:System.Threading.WaitHandle" /> to wait on.</param>
		/// <param name="millisecondsTimeout">An integer that represents the interval to wait. If the value is <see cref="F:System.Threading.Timeout.Infinite" />, that is, -1, the wait is infinite.</param>
		/// <param name="exitContext">
		///   <see langword="true" /> to exit the synchronization domain for the context before the wait (if in a synchronized context), and reacquire it afterward; otherwise, <see langword="false" />.</param>
		/// <returns>
		///   <see langword="true" /> if both the signal and the wait completed successfully, or <see langword="false" /> if the signal completed but the wait timed out.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="toSignal" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="toWaitOn" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The method is called on a thread that has <see cref="T:System.STAThreadAttribute" />.</exception>
		/// <exception cref="T:System.PlatformNotSupportedException">This method is not supported on Windows 98 or Windows Millennium Edition.</exception>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Threading.WaitHandle" /> cannot be signaled because it would exceed its maximum count.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="millisecondsTimeout" /> is a negative number other than -1, which represents an infinite time-out.</exception>
		/// <exception cref="T:System.Threading.AbandonedMutexException">The wait completed because a thread exited without releasing a mutex. This exception is not thrown on Windows 98 or Windows Millennium Edition.</exception>
		// Token: 0x06003D7F RID: 15743 RVA: 0x000E474C File Offset: 0x000E294C
		[SecuritySafeCritical]
		public static bool SignalAndWait(WaitHandle toSignal, WaitHandle toWaitOn, int millisecondsTimeout, bool exitContext)
		{
			if (toSignal == null)
			{
				throw new ArgumentNullException("toSignal");
			}
			if (toWaitOn == null)
			{
				throw new ArgumentNullException("toWaitOn");
			}
			if (-1 > millisecondsTimeout)
			{
				throw new ArgumentOutOfRangeException("millisecondsTimeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			int num = WaitHandle.SignalAndWaitOne(toSignal.safeWaitHandle, toWaitOn.safeWaitHandle, millisecondsTimeout, toWaitOn.hasThreadAffinity, exitContext);
			if (2147483647 != num && toSignal.hasThreadAffinity)
			{
				Thread.EndCriticalRegion();
				Thread.EndThreadAffinity();
			}
			if (128 == num)
			{
				WaitHandle.ThrowAbandonedMutexException();
			}
			if (298 == num)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Threading.WaitHandleTooManyPosts"));
			}
			return num == 0;
		}

		// Token: 0x06003D80 RID: 15744 RVA: 0x000E47F1 File Offset: 0x000E29F1
		private static void ThrowAbandonedMutexException()
		{
			throw new AbandonedMutexException();
		}

		// Token: 0x06003D81 RID: 15745 RVA: 0x000E47F8 File Offset: 0x000E29F8
		private static void ThrowAbandonedMutexException(int location, WaitHandle handle)
		{
			throw new AbandonedMutexException(location, handle);
		}

		/// <summary>Releases all resources held by the current <see cref="T:System.Threading.WaitHandle" />.</summary>
		// Token: 0x06003D82 RID: 15746 RVA: 0x000E4801 File Offset: 0x000E2A01
		public virtual void Close()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>When overridden in a derived class, releases the unmanaged resources used by the <see cref="T:System.Threading.WaitHandle" />, and optionally releases the managed resources.</summary>
		/// <param name="explicitDisposing">
		///   <see langword="true" /> to release both managed and unmanaged resources; <see langword="false" /> to release only unmanaged resources.</param>
		// Token: 0x06003D83 RID: 15747 RVA: 0x000E4810 File Offset: 0x000E2A10
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		protected virtual void Dispose(bool explicitDisposing)
		{
			if (this.safeWaitHandle != null)
			{
				this.safeWaitHandle.Close();
			}
		}

		/// <summary>Releases all resources used by the current instance of the <see cref="T:System.Threading.WaitHandle" /> class.</summary>
		// Token: 0x06003D84 RID: 15748 RVA: 0x000E4829 File Offset: 0x000E2A29
		[__DynamicallyInvokable]
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>Indicates that a <see cref="M:System.Threading.WaitHandle.WaitAny(System.Threading.WaitHandle[],System.Int32,System.Boolean)" /> operation timed out before any of the wait handles were signaled. This field is constant.</summary>
		// Token: 0x0400198E RID: 6542
		[__DynamicallyInvokable]
		public const int WaitTimeout = 258;

		// Token: 0x0400198F RID: 6543
		private const int MAX_WAITHANDLES = 64;

		// Token: 0x04001990 RID: 6544
		private IntPtr waitHandle;

		// Token: 0x04001991 RID: 6545
		[SecurityCritical]
		internal volatile SafeWaitHandle safeWaitHandle;

		// Token: 0x04001992 RID: 6546
		internal bool hasThreadAffinity;

		/// <summary>Represents an invalid native operating system handle. This field is read-only.</summary>
		// Token: 0x04001993 RID: 6547
		protected static readonly IntPtr InvalidHandle = WaitHandle.GetInvalidHandle();

		// Token: 0x04001994 RID: 6548
		private const int WAIT_OBJECT_0 = 0;

		// Token: 0x04001995 RID: 6549
		private const int WAIT_ABANDONED = 128;

		// Token: 0x04001996 RID: 6550
		private const int WAIT_FAILED = 2147483647;

		// Token: 0x04001997 RID: 6551
		private const int ERROR_TOO_MANY_POSTS = 298;

		// Token: 0x02000BC3 RID: 3011
		internal enum OpenExistingResult
		{
			// Token: 0x04003557 RID: 13655
			Success,
			// Token: 0x04003558 RID: 13656
			NameNotFound,
			// Token: 0x04003559 RID: 13657
			PathNotFound,
			// Token: 0x0400355A RID: 13658
			NameInvalid
		}
	}
}
