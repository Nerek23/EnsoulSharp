using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Threading
{
	/// <summary>Provides a managed representation of a Win32 OVERLAPPED structure, including methods to transfer information from an <see cref="T:System.Threading.Overlapped" /> instance to a <see cref="T:System.Threading.NativeOverlapped" /> structure.</summary>
	// Token: 0x020004D9 RID: 1241
	[ComVisible(true)]
	public class Overlapped
	{
		/// <summary>Initializes a new, empty instance of the <see cref="T:System.Threading.Overlapped" /> class.</summary>
		// Token: 0x06003B7A RID: 15226 RVA: 0x000E0104 File Offset: 0x000DE304
		public Overlapped()
		{
			this.m_overlappedData = (OverlappedData)Overlapped.s_overlappedDataCache.Allocate();
			this.m_overlappedData.m_overlapped = this;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Overlapped" /> class with the specified file position, the handle to an event that is signaled when the I/O operation is complete, and an interface through which to return the results of the operation.</summary>
		/// <param name="offsetLo">The low word of the file position at which to start the transfer.</param>
		/// <param name="offsetHi">The high word of the file position at which to start the transfer.</param>
		/// <param name="hEvent">The handle to an event that is signaled when the I/O operation is complete.</param>
		/// <param name="ar">An object that implements the <see cref="T:System.IAsyncResult" /> interface and provides status information on the I/O operation.</param>
		// Token: 0x06003B7B RID: 15227 RVA: 0x000E0130 File Offset: 0x000DE330
		public Overlapped(int offsetLo, int offsetHi, IntPtr hEvent, IAsyncResult ar)
		{
			this.m_overlappedData = (OverlappedData)Overlapped.s_overlappedDataCache.Allocate();
			this.m_overlappedData.m_overlapped = this;
			this.m_overlappedData.m_nativeOverlapped.OffsetLow = offsetLo;
			this.m_overlappedData.m_nativeOverlapped.OffsetHigh = offsetHi;
			this.m_overlappedData.UserHandle = hEvent;
			this.m_overlappedData.m_asyncResult = ar;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Overlapped" /> class with the specified file position, the 32-bit integer handle to an event that is signaled when the I/O operation is complete, and an interface through which to return the results of the operation.</summary>
		/// <param name="offsetLo">The low word of the file position at which to start the transfer.</param>
		/// <param name="offsetHi">The high word of the file position at which to start the transfer.</param>
		/// <param name="hEvent">The handle to an event that is signaled when the I/O operation is complete.</param>
		/// <param name="ar">An object that implements the <see cref="T:System.IAsyncResult" /> interface and provides status information on the I/O operation.</param>
		// Token: 0x06003B7C RID: 15228 RVA: 0x000E019F File Offset: 0x000DE39F
		[Obsolete("This constructor is not 64-bit compatible.  Use the constructor that takes an IntPtr for the event handle.  http://go.microsoft.com/fwlink/?linkid=14202")]
		public Overlapped(int offsetLo, int offsetHi, int hEvent, IAsyncResult ar) : this(offsetLo, offsetHi, new IntPtr(hEvent), ar)
		{
		}

		/// <summary>Gets or sets the object that provides status information on the I/O operation.</summary>
		/// <returns>An object that implements the <see cref="T:System.IAsyncResult" /> interface.</returns>
		// Token: 0x17000904 RID: 2308
		// (get) Token: 0x06003B7D RID: 15229 RVA: 0x000E01B1 File Offset: 0x000DE3B1
		// (set) Token: 0x06003B7E RID: 15230 RVA: 0x000E01BE File Offset: 0x000DE3BE
		public IAsyncResult AsyncResult
		{
			get
			{
				return this.m_overlappedData.m_asyncResult;
			}
			set
			{
				this.m_overlappedData.m_asyncResult = value;
			}
		}

		/// <summary>Gets or sets the low-order word of the file position at which to start the transfer. The file position is a byte offset from the start of the file.</summary>
		/// <returns>An <see cref="T:System.Int32" /> value representing the low word of the file position.</returns>
		// Token: 0x17000905 RID: 2309
		// (get) Token: 0x06003B7F RID: 15231 RVA: 0x000E01CC File Offset: 0x000DE3CC
		// (set) Token: 0x06003B80 RID: 15232 RVA: 0x000E01DE File Offset: 0x000DE3DE
		public int OffsetLow
		{
			get
			{
				return this.m_overlappedData.m_nativeOverlapped.OffsetLow;
			}
			set
			{
				this.m_overlappedData.m_nativeOverlapped.OffsetLow = value;
			}
		}

		/// <summary>Gets or sets the high-order word of the file position at which to start the transfer. The file position is a byte offset from the start of the file.</summary>
		/// <returns>An <see cref="T:System.Int32" /> value representing the high word of the file position.</returns>
		// Token: 0x17000906 RID: 2310
		// (get) Token: 0x06003B81 RID: 15233 RVA: 0x000E01F1 File Offset: 0x000DE3F1
		// (set) Token: 0x06003B82 RID: 15234 RVA: 0x000E0203 File Offset: 0x000DE403
		public int OffsetHigh
		{
			get
			{
				return this.m_overlappedData.m_nativeOverlapped.OffsetHigh;
			}
			set
			{
				this.m_overlappedData.m_nativeOverlapped.OffsetHigh = value;
			}
		}

		/// <summary>Gets or sets the 32-bit integer handle to a synchronization event that is signaled when the I/O operation is complete.</summary>
		/// <returns>An <see cref="T:System.Int32" /> value representing the handle of the synchronization event.</returns>
		// Token: 0x17000907 RID: 2311
		// (get) Token: 0x06003B83 RID: 15235 RVA: 0x000E0218 File Offset: 0x000DE418
		// (set) Token: 0x06003B84 RID: 15236 RVA: 0x000E0238 File Offset: 0x000DE438
		[Obsolete("This property is not 64-bit compatible.  Use EventHandleIntPtr instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
		public int EventHandle
		{
			get
			{
				return this.m_overlappedData.UserHandle.ToInt32();
			}
			set
			{
				this.m_overlappedData.UserHandle = new IntPtr(value);
			}
		}

		/// <summary>Gets or sets the handle to the synchronization event that is signaled when the I/O operation is complete.</summary>
		/// <returns>An <see cref="T:System.IntPtr" /> representing the handle of the event.</returns>
		// Token: 0x17000908 RID: 2312
		// (get) Token: 0x06003B85 RID: 15237 RVA: 0x000E024B File Offset: 0x000DE44B
		// (set) Token: 0x06003B86 RID: 15238 RVA: 0x000E0258 File Offset: 0x000DE458
		[ComVisible(false)]
		public IntPtr EventHandleIntPtr
		{
			get
			{
				return this.m_overlappedData.UserHandle;
			}
			set
			{
				this.m_overlappedData.UserHandle = value;
			}
		}

		// Token: 0x17000909 RID: 2313
		// (get) Token: 0x06003B87 RID: 15239 RVA: 0x000E0266 File Offset: 0x000DE466
		internal _IOCompletionCallback iocbHelper
		{
			get
			{
				return this.m_overlappedData.m_iocbHelper;
			}
		}

		// Token: 0x1700090A RID: 2314
		// (get) Token: 0x06003B88 RID: 15240 RVA: 0x000E0273 File Offset: 0x000DE473
		internal IOCompletionCallback UserCallback
		{
			[SecurityCritical]
			get
			{
				return this.m_overlappedData.m_iocb;
			}
		}

		/// <summary>Packs the current instance into a <see cref="T:System.Threading.NativeOverlapped" /> structure, specifying the delegate to be invoked when the asynchronous I/O operation is complete.</summary>
		/// <param name="iocb">An <see cref="T:System.Threading.IOCompletionCallback" /> delegate that represents the callback method invoked when the asynchronous I/O operation completes.</param>
		/// <returns>An unmanaged pointer to a <see cref="T:System.Threading.NativeOverlapped" /> structure.</returns>
		/// <exception cref="T:System.InvalidOperationException">The current <see cref="T:System.Threading.Overlapped" /> has already been packed.</exception>
		// Token: 0x06003B89 RID: 15241 RVA: 0x000E0280 File Offset: 0x000DE480
		[SecurityCritical]
		[Obsolete("This method is not safe.  Use Pack (iocb, userData) instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
		[CLSCompliant(false)]
		public unsafe NativeOverlapped* Pack(IOCompletionCallback iocb)
		{
			return this.Pack(iocb, null);
		}

		/// <summary>Packs the current instance into a <see cref="T:System.Threading.NativeOverlapped" /> structure, specifying a delegate that is invoked when the asynchronous I/O operation is complete and a managed object that serves as a buffer.</summary>
		/// <param name="iocb">An <see cref="T:System.Threading.IOCompletionCallback" /> delegate that represents the callback method invoked when the asynchronous I/O operation completes.</param>
		/// <param name="userData">An object or array of objects representing the input or output buffer for the operation. Each object represents a buffer, for example an array of bytes.</param>
		/// <returns>An unmanaged pointer to a <see cref="T:System.Threading.NativeOverlapped" /> structure.</returns>
		/// <exception cref="T:System.InvalidOperationException">The current <see cref="T:System.Threading.Overlapped" /> has already been packed.</exception>
		// Token: 0x06003B8A RID: 15242 RVA: 0x000E028A File Offset: 0x000DE48A
		[SecurityCritical]
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe NativeOverlapped* Pack(IOCompletionCallback iocb, object userData)
		{
			return this.m_overlappedData.Pack(iocb, userData);
		}

		/// <summary>Packs the current instance into a <see cref="T:System.Threading.NativeOverlapped" /> structure specifying the delegate to invoke when the asynchronous I/O operation is complete. Does not propagate the calling stack.</summary>
		/// <param name="iocb">An <see cref="T:System.Threading.IOCompletionCallback" /> delegate that represents the callback method invoked when the asynchronous I/O operation completes.</param>
		/// <returns>An unmanaged pointer to a <see cref="T:System.Threading.NativeOverlapped" /> structure.</returns>
		/// <exception cref="T:System.InvalidOperationException">The current <see cref="T:System.Threading.Overlapped" /> has already been packed.</exception>
		// Token: 0x06003B8B RID: 15243 RVA: 0x000E0299 File Offset: 0x000DE499
		[SecurityCritical]
		[Obsolete("This method is not safe.  Use UnsafePack (iocb, userData) instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
		[CLSCompliant(false)]
		public unsafe NativeOverlapped* UnsafePack(IOCompletionCallback iocb)
		{
			return this.UnsafePack(iocb, null);
		}

		/// <summary>Packs the current instance into a <see cref="T:System.Threading.NativeOverlapped" /> structure, specifying the delegate to invoke when the asynchronous I/O operation is complete and the managed object that serves as a buffer. Does not propagate the calling stack.</summary>
		/// <param name="iocb">An <see cref="T:System.Threading.IOCompletionCallback" /> delegate that represents the callback method invoked when the asynchronous I/O operation completes.</param>
		/// <param name="userData">An object or array of objects representing the input or output buffer for the operation. Each object represents a buffer, for example an array of bytes.</param>
		/// <returns>An unmanaged pointer to a <see cref="T:System.Threading.NativeOverlapped" /> structure.</returns>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		/// <exception cref="T:System.InvalidOperationException">The current <see cref="T:System.Threading.Overlapped" /> is already packed.</exception>
		// Token: 0x06003B8C RID: 15244 RVA: 0x000E02A3 File Offset: 0x000DE4A3
		[SecurityCritical]
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe NativeOverlapped* UnsafePack(IOCompletionCallback iocb, object userData)
		{
			return this.m_overlappedData.UnsafePack(iocb, userData);
		}

		/// <summary>Unpacks the specified unmanaged <see cref="T:System.Threading.NativeOverlapped" /> structure into a managed <see cref="T:System.Threading.Overlapped" /> object.</summary>
		/// <param name="nativeOverlappedPtr">An unmanaged pointer to a <see cref="T:System.Threading.NativeOverlapped" /> structure.</param>
		/// <returns>An <see cref="T:System.Threading.Overlapped" /> object containing the information unpacked from the native structure.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="nativeOverlappedPtr" /> is <see langword="null" />.</exception>
		// Token: 0x06003B8D RID: 15245 RVA: 0x000E02B4 File Offset: 0x000DE4B4
		[SecurityCritical]
		[CLSCompliant(false)]
		public unsafe static Overlapped Unpack(NativeOverlapped* nativeOverlappedPtr)
		{
			if (nativeOverlappedPtr == null)
			{
				throw new ArgumentNullException("nativeOverlappedPtr");
			}
			return OverlappedData.GetOverlappedFromNative(nativeOverlappedPtr).m_overlapped;
		}

		/// <summary>Frees the unmanaged memory associated with a native overlapped structure allocated by the <see cref="Overload:System.Threading.Overlapped.Pack" /> method.</summary>
		/// <param name="nativeOverlappedPtr">A pointer to the <see cref="T:System.Threading.NativeOverlapped" /> structure to be freed.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="nativeOverlappedPtr" /> is <see langword="null" />.</exception>
		// Token: 0x06003B8E RID: 15246 RVA: 0x000E02E0 File Offset: 0x000DE4E0
		[SecurityCritical]
		[CLSCompliant(false)]
		public unsafe static void Free(NativeOverlapped* nativeOverlappedPtr)
		{
			if (nativeOverlappedPtr == null)
			{
				throw new ArgumentNullException("nativeOverlappedPtr");
			}
			Overlapped overlapped = OverlappedData.GetOverlappedFromNative(nativeOverlappedPtr).m_overlapped;
			OverlappedData.FreeNativeOverlapped(nativeOverlappedPtr);
			OverlappedData overlappedData = overlapped.m_overlappedData;
			overlapped.m_overlappedData = null;
			overlappedData.ReInitialize();
			Overlapped.s_overlappedDataCache.Free(overlappedData);
		}

		// Token: 0x040018FF RID: 6399
		private OverlappedData m_overlappedData;

		// Token: 0x04001900 RID: 6400
		private static PinnableBufferCache s_overlappedDataCache = new PinnableBufferCache("System.Threading.OverlappedData", () => new OverlappedData());
	}
}
