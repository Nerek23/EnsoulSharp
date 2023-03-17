using System;
using System.Security;
using Microsoft.Win32.SafeHandles;

namespace System.Threading
{
	/// <summary>Provides convenience methods to for working with a safe handle for a wait handle.</summary>
	// Token: 0x02000507 RID: 1287
	[__DynamicallyInvokable]
	public static class WaitHandleExtensions
	{
		/// <summary>Gets the safe handle for a native operating system wait handle.</summary>
		/// <param name="waitHandle">A native operating system handle.</param>
		/// <returns>The safe wait handle that wraps the native operating system wait handle.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="waitHandle" /> is <see langword="null" />.</exception>
		// Token: 0x06003D86 RID: 15750 RVA: 0x000E4844 File Offset: 0x000E2A44
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static SafeWaitHandle GetSafeWaitHandle(this WaitHandle waitHandle)
		{
			if (waitHandle == null)
			{
				throw new ArgumentNullException("waitHandle");
			}
			return waitHandle.SafeWaitHandle;
		}

		/// <summary>Sets a safe handle for a native operating system wait handle.</summary>
		/// <param name="waitHandle">A wait handle that encapsulates an operating system-specific object that waits for exclusive access to a shared resource.</param>
		/// <param name="value">The safe handle to wrap the operating system handle.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="waitHandle" /> is <see langword="null" />.</exception>
		// Token: 0x06003D87 RID: 15751 RVA: 0x000E485A File Offset: 0x000E2A5A
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static void SetSafeWaitHandle(this WaitHandle waitHandle, SafeWaitHandle value)
		{
			if (waitHandle == null)
			{
				throw new ArgumentNullException("waitHandle");
			}
			waitHandle.SafeWaitHandle = value;
		}
	}
}
