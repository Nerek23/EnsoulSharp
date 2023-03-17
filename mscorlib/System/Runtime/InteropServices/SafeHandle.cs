using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.InteropServices
{
	/// <summary>Represents a wrapper class for operating system handles. This class must be inherited.</summary>
	// Token: 0x0200092A RID: 2346
	[SecurityCritical]
	[__DynamicallyInvokable]
	[SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
	public abstract class SafeHandle : CriticalFinalizerObject, IDisposable
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.SafeHandle" /> class with the specified invalid handle value.</summary>
		/// <param name="invalidHandleValue">The value of an invalid handle (usually 0 or -1).  Your implementation of <see cref="P:System.Runtime.InteropServices.SafeHandle.IsInvalid" /> should return <see langword="true" /> for this value.</param>
		/// <param name="ownsHandle">
		///   <see langword="true" /> to reliably let <see cref="T:System.Runtime.InteropServices.SafeHandle" /> release the handle during the finalization phase; otherwise, <see langword="false" /> (not recommended).</param>
		/// <exception cref="T:System.TypeLoadException">The derived class resides in an assembly without unmanaged code access permission.</exception>
		// Token: 0x060060B9 RID: 24761 RVA: 0x0014A12F File Offset: 0x0014832F
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		protected SafeHandle(IntPtr invalidHandleValue, bool ownsHandle)
		{
			this.handle = invalidHandleValue;
			this._state = 4;
			this._ownsHandle = ownsHandle;
			if (!ownsHandle)
			{
				GC.SuppressFinalize(this);
			}
			this._fullyInitialized = true;
		}

		/// <summary>Frees all resources associated with the handle.</summary>
		// Token: 0x060060BA RID: 24762 RVA: 0x0014A15C File Offset: 0x0014835C
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		~SafeHandle()
		{
			this.Dispose(false);
		}

		// Token: 0x060060BB RID: 24763
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void InternalFinalize();

		/// <summary>Sets the handle to the specified pre-existing handle.</summary>
		/// <param name="handle">The pre-existing handle to use.</param>
		// Token: 0x060060BC RID: 24764 RVA: 0x0014A18C File Offset: 0x0014838C
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		protected void SetHandle(IntPtr handle)
		{
			this.handle = handle;
		}

		/// <summary>Returns the value of the <see cref="F:System.Runtime.InteropServices.SafeHandle.handle" /> field.</summary>
		/// <returns>An <see langword="IntPtr" /> representing the value of the <see cref="F:System.Runtime.InteropServices.SafeHandle.handle" /> field. If the handle has been marked invalid with <see cref="M:System.Runtime.InteropServices.SafeHandle.SetHandleAsInvalid" />, this method still returns the original handle value, which can be a stale value.</returns>
		// Token: 0x060060BD RID: 24765 RVA: 0x0014A195 File Offset: 0x00148395
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public IntPtr DangerousGetHandle()
		{
			return this.handle;
		}

		/// <summary>Gets a value indicating whether the handle is closed.</summary>
		/// <returns>
		///   <see langword="true" /> if the handle is closed; otherwise, <see langword="false" />.</returns>
		// Token: 0x170010EE RID: 4334
		// (get) Token: 0x060060BE RID: 24766 RVA: 0x0014A19D File Offset: 0x0014839D
		[__DynamicallyInvokable]
		public bool IsClosed
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			[__DynamicallyInvokable]
			get
			{
				return (this._state & 1) == 1;
			}
		}

		/// <summary>When overridden in a derived class, gets a value indicating whether the handle value is invalid.</summary>
		/// <returns>
		///   <see langword="true" /> if the handle value is invalid; otherwise, <see langword="false" />.</returns>
		// Token: 0x170010EF RID: 4335
		// (get) Token: 0x060060BF RID: 24767
		[__DynamicallyInvokable]
		public abstract bool IsInvalid { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] [__DynamicallyInvokable] get; }

		/// <summary>Marks the handle for releasing and freeing resources.</summary>
		// Token: 0x060060C0 RID: 24768 RVA: 0x0014A1AA File Offset: 0x001483AA
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void Close()
		{
			this.Dispose(true);
		}

		/// <summary>Releases all resources used by the <see cref="T:System.Runtime.InteropServices.SafeHandle" /> class.</summary>
		// Token: 0x060060C1 RID: 24769 RVA: 0x0014A1B3 File Offset: 0x001483B3
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public void Dispose()
		{
			this.Dispose(true);
		}

		/// <summary>Releases the unmanaged resources used by the <see cref="T:System.Runtime.InteropServices.SafeHandle" /> class specifying whether to perform a normal dispose operation.</summary>
		/// <param name="disposing">
		///   <see langword="true" /> for a normal dispose operation; <see langword="false" /> to finalize the handle.</param>
		// Token: 0x060060C2 RID: 24770 RVA: 0x0014A1BC File Offset: 0x001483BC
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.InternalDispose();
				return;
			}
			this.InternalFinalize();
		}

		// Token: 0x060060C3 RID: 24771
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void InternalDispose();

		/// <summary>Marks a handle as no longer used.</summary>
		// Token: 0x060060C4 RID: 24772
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetHandleAsInvalid();

		/// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
		/// <returns>
		///   <see langword="true" /> if the handle is released successfully; otherwise, in the event of a catastrophic failure, <see langword="false" />. In this case, it generates a releaseHandleFailed Managed Debugging Assistant.</returns>
		// Token: 0x060060C5 RID: 24773
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		protected abstract bool ReleaseHandle();

		/// <summary>Manually increments the reference counter on <see cref="T:System.Runtime.InteropServices.SafeHandle" /> instances.</summary>
		/// <param name="success">
		///   <see langword="true" /> if the reference counter was successfully incremented; otherwise, <see langword="false" />.</param>
		// Token: 0x060060C6 RID: 24774
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void DangerousAddRef(ref bool success);

		/// <summary>Manually decrements the reference counter on a <see cref="T:System.Runtime.InteropServices.SafeHandle" /> instance.</summary>
		// Token: 0x060060C7 RID: 24775
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void DangerousRelease();

		/// <summary>Specifies the handle to be wrapped.</summary>
		// Token: 0x04002AC4 RID: 10948
		protected IntPtr handle;

		// Token: 0x04002AC5 RID: 10949
		private int _state;

		// Token: 0x04002AC6 RID: 10950
		private bool _ownsHandle;

		// Token: 0x04002AC7 RID: 10951
		private bool _fullyInitialized;
	}
}
