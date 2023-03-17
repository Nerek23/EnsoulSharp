using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.InteropServices
{
	/// <summary>Represents a wrapper class for handle resources.</summary>
	// Token: 0x02000918 RID: 2328
	[SecurityCritical]
	[__DynamicallyInvokable]
	[SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
	public abstract class CriticalHandle : CriticalFinalizerObject, IDisposable
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.CriticalHandle" /> class with the specified invalid handle value.</summary>
		/// <param name="invalidHandleValue">The value of an invalid handle (usually 0 or -1).</param>
		/// <exception cref="T:System.TypeLoadException">The derived class resides in an assembly without unmanaged code access permission.</exception>
		// Token: 0x06005F50 RID: 24400 RVA: 0x001475E6 File Offset: 0x001457E6
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		protected CriticalHandle(IntPtr invalidHandleValue)
		{
			this.handle = invalidHandleValue;
			this._isClosed = false;
		}

		/// <summary>Frees all resources associated with the handle.</summary>
		// Token: 0x06005F51 RID: 24401 RVA: 0x001475FC File Offset: 0x001457FC
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		~CriticalHandle()
		{
			this.Dispose(false);
		}

		// Token: 0x06005F52 RID: 24402 RVA: 0x0014762C File Offset: 0x0014582C
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		private void Cleanup()
		{
			if (this.IsClosed)
			{
				return;
			}
			this._isClosed = true;
			if (this.IsInvalid)
			{
				return;
			}
			int lastWin32Error = Marshal.GetLastWin32Error();
			if (!this.ReleaseHandle())
			{
				this.FireCustomerDebugProbe();
			}
			Marshal.SetLastWin32Error(lastWin32Error);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06005F53 RID: 24403
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void FireCustomerDebugProbe();

		/// <summary>Sets the handle to the specified pre-existing handle.</summary>
		/// <param name="handle">The pre-existing handle to use.</param>
		// Token: 0x06005F54 RID: 24404 RVA: 0x00147672 File Offset: 0x00145872
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		protected void SetHandle(IntPtr handle)
		{
			this.handle = handle;
		}

		/// <summary>Gets a value indicating whether the handle is closed.</summary>
		/// <returns>
		///   <see langword="true" /> if the handle is closed; otherwise, <see langword="false" />.</returns>
		// Token: 0x170010DF RID: 4319
		// (get) Token: 0x06005F55 RID: 24405 RVA: 0x0014767B File Offset: 0x0014587B
		[__DynamicallyInvokable]
		public bool IsClosed
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			[__DynamicallyInvokable]
			get
			{
				return this._isClosed;
			}
		}

		/// <summary>When overridden in a derived class, gets a value indicating whether the handle value is invalid.</summary>
		/// <returns>
		///   <see langword="true" /> if the handle is valid; otherwise, <see langword="false" />.</returns>
		// Token: 0x170010E0 RID: 4320
		// (get) Token: 0x06005F56 RID: 24406
		[__DynamicallyInvokable]
		public abstract bool IsInvalid { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] [__DynamicallyInvokable] get; }

		/// <summary>Marks the handle for releasing and freeing resources.</summary>
		// Token: 0x06005F57 RID: 24407 RVA: 0x00147683 File Offset: 0x00145883
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void Close()
		{
			this.Dispose(true);
		}

		/// <summary>Releases all resources used by the <see cref="T:System.Runtime.InteropServices.CriticalHandle" />.</summary>
		// Token: 0x06005F58 RID: 24408 RVA: 0x0014768C File Offset: 0x0014588C
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public void Dispose()
		{
			this.Dispose(true);
		}

		/// <summary>Releases the unmanaged resources used by the <see cref="T:System.Runtime.InteropServices.CriticalHandle" /> class specifying whether to perform a normal dispose operation.</summary>
		/// <param name="disposing">
		///   <see langword="true" /> for a normal dispose operation; <see langword="false" /> to finalize the handle.</param>
		// Token: 0x06005F59 RID: 24409 RVA: 0x00147695 File Offset: 0x00145895
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		protected virtual void Dispose(bool disposing)
		{
			this.Cleanup();
		}

		/// <summary>Marks a handle as invalid.</summary>
		// Token: 0x06005F5A RID: 24410 RVA: 0x0014769D File Offset: 0x0014589D
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public void SetHandleAsInvalid()
		{
			this._isClosed = true;
			GC.SuppressFinalize(this);
		}

		/// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
		/// <returns>
		///   <see langword="true" /> if the handle is released successfully; otherwise, in the event of a catastrophic failure, <see langword="false" />. In this case, it generates a releaseHandleFailed Managed Debugging Assistant.</returns>
		// Token: 0x06005F5B RID: 24411
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		protected abstract bool ReleaseHandle();

		/// <summary>Specifies the handle to be wrapped.</summary>
		// Token: 0x04002A83 RID: 10883
		protected IntPtr handle;

		// Token: 0x04002A84 RID: 10884
		private bool _isClosed;
	}
}
