using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Threading
{
	/// <summary>Represents a handle that has been registered when calling <see cref="M:System.Threading.ThreadPool.RegisterWaitForSingleObject(System.Threading.WaitHandle,System.Threading.WaitOrTimerCallback,System.Object,System.UInt32,System.Boolean)" />. This class cannot be inherited.</summary>
	// Token: 0x020004F1 RID: 1265
	[ComVisible(true)]
	public sealed class RegisteredWaitHandle : MarshalByRefObject
	{
		// Token: 0x06003CB7 RID: 15543 RVA: 0x000E2A90 File Offset: 0x000E0C90
		internal RegisteredWaitHandle()
		{
			this.internalRegisteredWait = new RegisteredWaitHandleSafe();
		}

		// Token: 0x06003CB8 RID: 15544 RVA: 0x000E2AA3 File Offset: 0x000E0CA3
		internal void SetHandle(IntPtr handle)
		{
			this.internalRegisteredWait.SetHandle(handle);
		}

		// Token: 0x06003CB9 RID: 15545 RVA: 0x000E2AB1 File Offset: 0x000E0CB1
		[SecurityCritical]
		internal void SetWaitObject(WaitHandle waitObject)
		{
			this.internalRegisteredWait.SetWaitObject(waitObject);
		}

		/// <summary>Cancels a registered wait operation issued by the <see cref="M:System.Threading.ThreadPool.RegisterWaitForSingleObject(System.Threading.WaitHandle,System.Threading.WaitOrTimerCallback,System.Object,System.UInt32,System.Boolean)" /> method.</summary>
		/// <param name="waitObject">The <see cref="T:System.Threading.WaitHandle" /> to be signaled.</param>
		/// <returns>
		///   <see langword="true" /> if the function succeeds; otherwise, <see langword="false" />.</returns>
		// Token: 0x06003CBA RID: 15546 RVA: 0x000E2ABF File Offset: 0x000E0CBF
		[SecuritySafeCritical]
		[ComVisible(true)]
		public bool Unregister(WaitHandle waitObject)
		{
			return this.internalRegisteredWait.Unregister(waitObject);
		}

		// Token: 0x04001958 RID: 6488
		private RegisteredWaitHandleSafe internalRegisteredWait;
	}
}
