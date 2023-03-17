using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Threading
{
	/// <summary>Represents an I/O handle that is bound to the system thread pool and enables low-level components to receive notifications for asynchronous I/O operations.</summary>
	// Token: 0x020004DC RID: 1244
	public sealed class ThreadPoolBoundHandle : IDisposable
	{
		// Token: 0x06003B99 RID: 15257 RVA: 0x000E04F1 File Offset: 0x000DE6F1
		[SecurityCritical]
		private ThreadPoolBoundHandle(SafeHandle handle)
		{
			this._handle = handle;
		}

		/// <summary>Gets the bound operating system handle.</summary>
		/// <returns>An object that holds the bound operating system handle.</returns>
		// Token: 0x1700090B RID: 2315
		// (get) Token: 0x06003B9A RID: 15258 RVA: 0x000E0500 File Offset: 0x000DE700
		public SafeHandle Handle
		{
			[SecurityCritical]
			get
			{
				return this._handle;
			}
		}

		/// <summary>Returns a <see cref="T:System.Threading.ThreadPoolBoundHandle" /> for the specified handle, which is bound to the system thread pool.</summary>
		/// <param name="handle">An object that holds the operating system handle. The handle must have been opened for overlapped I/O in unmanaged code.</param>
		/// <returns>A <see cref="T:System.Threading.ThreadPoolBoundHandle" /> for <paramref name="handle" />, which is bound to the system thread pool.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="handle" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="handle" /> has been disposed.  
		/// -or-  
		/// <paramref name="handle" /> does not refer to a valid I/O handle.  
		/// -or-  
		/// <paramref name="handle" /> refers to a handle that has not been opened for overlapped I/O.  
		/// -or-  
		/// <paramref name="handle" /> refers to a handle that has already been bound.</exception>
		// Token: 0x06003B9B RID: 15259 RVA: 0x000E0508 File Offset: 0x000DE708
		[SecurityCritical]
		public static ThreadPoolBoundHandle BindHandle(SafeHandle handle)
		{
			if (handle == null)
			{
				throw new ArgumentNullException("handle");
			}
			if (handle.IsClosed || handle.IsInvalid)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidHandle"), "handle");
			}
			try
			{
				bool flag = ThreadPool.BindHandle(handle);
			}
			catch (Exception ex)
			{
				if (ex.HResult == -2147024890)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidHandle"), "handle");
				}
				if (ex.HResult == -2147024809)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_AlreadyBoundOrSyncHandle"), "handle");
				}
				throw;
			}
			return new ThreadPoolBoundHandle(handle);
		}

		/// <summary>Returns an unmanaged pointer to a <see cref="T:System.Threading.NativeOverlapped" /> structure, specifying a delegate that is invoked when the asynchronous I/O operation is complete, a user-provided object that supplies context, and managed objects that serve as buffers.</summary>
		/// <param name="callback">A delegate that represents the callback method to invoke when the asynchronous I/O operation completes.</param>
		/// <param name="state">A user-provided object that distinguishes this <see cref="T:System.Threading.NativeOverlapped" /> instance from other <see cref="T:System.Threading.NativeOverlapped" /> instances.</param>
		/// <param name="pinData">An object or array of objects that represent the input or output buffer for the operation, or <see langword="null" />. Each object represents a buffer, such an array of bytes.</param>
		/// <returns>An unmanaged pointer to a <see cref="T:System.Threading.NativeOverlapped" /> structure.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="callback" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ObjectDisposedException">This method was called after the <see cref="T:System.Threading.ThreadPoolBoundHandle" /> object was disposed.</exception>
		// Token: 0x06003B9C RID: 15260 RVA: 0x000E05B0 File Offset: 0x000DE7B0
		[CLSCompliant(false)]
		[SecurityCritical]
		public unsafe NativeOverlapped* AllocateNativeOverlapped(IOCompletionCallback callback, object state, object pinData)
		{
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			this.EnsureNotDisposed();
			return new ThreadPoolBoundHandleOverlapped(callback, state, pinData, null)
			{
				_boundHandle = this
			}._nativeOverlapped;
		}

		/// <summary>Returns an unmanaged pointer to a <see cref="T:System.Threading.NativeOverlapped" /> structure using the callback state and buffers associated with the specified <see cref="T:System.Threading.PreAllocatedOverlapped" /> object.</summary>
		/// <param name="preAllocated">An object from which to create the <see cref="T:System.Threading.NativeOverlapped" /> pointer.</param>
		/// <returns>An unmanaged pointer to a <see cref="T:System.Threading.NativeOverlapped" /> structure.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="preAllocated" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="preAllocated" /> is currently in use for another I/O operation.</exception>
		/// <exception cref="T:System.ObjectDisposedException">This method was called after the <see cref="T:System.Threading.ThreadPoolBoundHandle" /> was disposed.  
		///  -or-  
		///  This method was called after <paramref name="preAllocated" /> was disposed.</exception>
		// Token: 0x06003B9D RID: 15261 RVA: 0x000E05E8 File Offset: 0x000DE7E8
		[CLSCompliant(false)]
		[SecurityCritical]
		public unsafe NativeOverlapped* AllocateNativeOverlapped(PreAllocatedOverlapped preAllocated)
		{
			if (preAllocated == null)
			{
				throw new ArgumentNullException("preAllocated");
			}
			this.EnsureNotDisposed();
			preAllocated.AddRef();
			NativeOverlapped* nativeOverlapped;
			try
			{
				ThreadPoolBoundHandleOverlapped overlapped = preAllocated._overlapped;
				if (overlapped._boundHandle != null)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_PreAllocatedAlreadyAllocated"), "preAllocated");
				}
				overlapped._boundHandle = this;
				nativeOverlapped = overlapped._nativeOverlapped;
			}
			catch
			{
				preAllocated.Release();
				throw;
			}
			return nativeOverlapped;
		}

		/// <summary>Frees the memory associated with a <see cref="T:System.Threading.NativeOverlapped" /> structure allocated by the <see cref="Overload:System.Threading.ThreadPoolBoundHandle.AllocateNativeOverlapped" /> method.</summary>
		/// <param name="overlapped">An unmanaged pointer to the <see cref="T:System.Threading.NativeOverlapped" /> structure structure to be freed.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="overlapped" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ObjectDisposedException">This method was called after the <see cref="T:System.Threading.ThreadPoolBoundHandle" /> object was disposed.</exception>
		// Token: 0x06003B9E RID: 15262 RVA: 0x000E0660 File Offset: 0x000DE860
		[CLSCompliant(false)]
		[SecurityCritical]
		public unsafe void FreeNativeOverlapped(NativeOverlapped* overlapped)
		{
			if (overlapped == null)
			{
				throw new ArgumentNullException("overlapped");
			}
			ThreadPoolBoundHandleOverlapped overlappedWrapper = ThreadPoolBoundHandle.GetOverlappedWrapper(overlapped, this);
			if (overlappedWrapper._boundHandle != this)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NativeOverlappedWrongBoundHandle"), "overlapped");
			}
			if (overlappedWrapper._preAllocated != null)
			{
				overlappedWrapper._preAllocated.Release();
				return;
			}
			Overlapped.Free(overlapped);
		}

		/// <summary>Returns the user-provided object that was specified when the <see cref="T:System.Threading.NativeOverlapped" /> instance was allocated by calling the <see cref="M:System.Threading.ThreadPoolBoundHandle.AllocateNativeOverlapped(System.Threading.IOCompletionCallback,System.Object,System.Object)" /> method.</summary>
		/// <param name="overlapped">An unmanaged pointer to the <see cref="T:System.Threading.NativeOverlapped" /> structure from which to return the associated user-provided object.</param>
		/// <returns>A user-provided object that distinguishes this <see cref="T:System.Threading.NativeOverlapped" /> instance from other <see cref="T:System.Threading.NativeOverlapped" /> instances, or <see langword="null" /> if one was not specified when the intstance was allocated by calling the <see cref="Overload:System.Threading.ThreadPoolBoundHandle.AllocateNativeOverlapped" /> method.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="overlapped" /> is <see langword="null" />.</exception>
		// Token: 0x06003B9F RID: 15263 RVA: 0x000E06C0 File Offset: 0x000DE8C0
		[CLSCompliant(false)]
		[SecurityCritical]
		public unsafe static object GetNativeOverlappedState(NativeOverlapped* overlapped)
		{
			if (overlapped == null)
			{
				throw new ArgumentNullException("overlapped");
			}
			ThreadPoolBoundHandleOverlapped overlappedWrapper = ThreadPoolBoundHandle.GetOverlappedWrapper(overlapped, null);
			return overlappedWrapper._userState;
		}

		// Token: 0x06003BA0 RID: 15264 RVA: 0x000E06EC File Offset: 0x000DE8EC
		[SecurityCritical]
		private unsafe static ThreadPoolBoundHandleOverlapped GetOverlappedWrapper(NativeOverlapped* overlapped, ThreadPoolBoundHandle expectedBoundHandle)
		{
			ThreadPoolBoundHandleOverlapped result;
			try
			{
				result = (ThreadPoolBoundHandleOverlapped)Overlapped.Unpack(overlapped);
			}
			catch (NullReferenceException innerException)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NativeOverlappedAlreadyFree"), "overlapped", innerException);
			}
			return result;
		}

		/// <summary>Releases all unmanaged resources used by the <see cref="T:System.Threading.ThreadPoolBoundHandle" /> instance.</summary>
		// Token: 0x06003BA1 RID: 15265 RVA: 0x000E0730 File Offset: 0x000DE930
		public void Dispose()
		{
			this._isDisposed = true;
		}

		// Token: 0x06003BA2 RID: 15266 RVA: 0x000E0739 File Offset: 0x000DE939
		private void EnsureNotDisposed()
		{
			if (this._isDisposed)
			{
				throw new ObjectDisposedException(base.GetType().ToString());
			}
		}

		// Token: 0x0400190A RID: 6410
		private const int E_HANDLE = -2147024890;

		// Token: 0x0400190B RID: 6411
		private const int E_INVALIDARG = -2147024809;

		// Token: 0x0400190C RID: 6412
		[SecurityCritical]
		private readonly SafeHandle _handle;

		// Token: 0x0400190D RID: 6413
		private bool _isDisposed;
	}
}
