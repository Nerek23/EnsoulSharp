using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200009C RID: 156
	[Guid("6d4865fe-0ab8-4d91-8f62-5dd6be34a3e0")]
	public class FontFileStreamNative : ComObject, FontFileStream, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x0600031E RID: 798 RVA: 0x0000BED8 File Offset: 0x0000A0D8
		public void ReadFileFragment(out IntPtr fragmentStart, long fileOffset, long fragmentSize, out IntPtr fragmentContext)
		{
			this.ReadFileFragment_(out fragmentStart, fileOffset, fragmentSize, out fragmentContext);
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000BEE5 File Offset: 0x0000A0E5
		public void ReleaseFileFragment(IntPtr fragmentContext)
		{
			this.ReleaseFileFragment_(fragmentContext);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0000BEF0 File Offset: 0x0000A0F0
		public long GetFileSize()
		{
			long result;
			this.GetFileSize_(out result);
			return result;
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0000BF08 File Offset: 0x0000A108
		public long GetLastWriteTime()
		{
			long result;
			this.GetLastWriteTime_(out result);
			return result;
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00002A7F File Offset: 0x00000C7F
		public FontFileStreamNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0000BF1E File Offset: 0x0000A11E
		public new static explicit operator FontFileStreamNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontFileStreamNative(nativePtr);
			}
			return null;
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000324 RID: 804 RVA: 0x0000BF38 File Offset: 0x0000A138
		public long FileSize_
		{
			get
			{
				long result;
				this.GetFileSize_(out result);
				return result;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000325 RID: 805 RVA: 0x0000BF50 File Offset: 0x0000A150
		public long LastWriteTime_
		{
			get
			{
				long result;
				this.GetLastWriteTime_(out result);
				return result;
			}
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0000BF68 File Offset: 0x0000A168
		internal unsafe void ReadFileFragment_(out IntPtr fragmentStart, long fileOffset, long fragmentSize, out IntPtr fragmentContext)
		{
			Result result;
			fixed (IntPtr* ptr = &fragmentContext)
			{
				void* ptr2 = (void*)ptr;
				fixed (IntPtr* ptr3 = &fragmentStart)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Int64,System.Int64,System.Void*), this._nativePointer, ptr4, fileOffset, fragmentSize, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0000BFB7 File Offset: 0x0000A1B7
		internal unsafe void ReleaseFileFragment_(IntPtr fragmentContext)
		{
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)fragmentContext, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0000BFDC File Offset: 0x0000A1DC
		internal unsafe void GetFileSize_(out long fileSize)
		{
			Result result;
			fixed (long* ptr = &fileSize)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0000C01C File Offset: 0x0000A21C
		internal unsafe void GetLastWriteTime_(out long lastWriteTime)
		{
			Result result;
			fixed (long* ptr = &lastWriteTime)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
