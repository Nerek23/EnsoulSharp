using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SharpDX.Win32
{
	// Token: 0x02000065 RID: 101
	[Guid("0000000c-0000-0000-C000-000000000046")]
	public class ComStream : ComStreamBase, IStream, IStreamBase, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x0600026E RID: 622 RVA: 0x000076E2 File Offset: 0x000058E2
		public ComStream(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600026F RID: 623 RVA: 0x000076EB File Offset: 0x000058EB
		public new static explicit operator ComStream(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ComStream(nativePtr);
			}
			return null;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00007704 File Offset: 0x00005904
		public unsafe long Seek(long dlibMove, SeekOrigin dwOrigin)
		{
			long result;
			calli(System.Int32(System.Void*,System.Int64,System.UInt32,System.Void*), this._nativePointer, dlibMove, dwOrigin, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00007744 File Offset: 0x00005944
		public unsafe void SetSize(long libNewSize)
		{
			calli(System.Int32(System.Void*,System.Int64), this._nativePointer, libNewSize, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000777C File Offset: 0x0000597C
		public unsafe long CopyTo(IStream stmRef, long cb, out long cbWrittenRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IStream>(stmRef);
			long result2;
			Result result;
			fixed (long* ptr = &cbWrittenRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Int64,System.Void*,System.Void*), this._nativePointer, (void*)value, cb, &result2, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x000077D8 File Offset: 0x000059D8
		public unsafe void Commit(CommitFlags grfCommitFlags)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, grfCommitFlags, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00007810 File Offset: 0x00005A10
		public unsafe void Revert()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00007848 File Offset: 0x00005A48
		public unsafe void LockRegion(long libOffset, long cb, LockType dwLockType)
		{
			calli(System.Int32(System.Void*,System.Int64,System.Int64,System.Int32), this._nativePointer, libOffset, cb, dwLockType, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00007884 File Offset: 0x00005A84
		public unsafe void UnlockRegion(long libOffset, long cb, LockType dwLockType)
		{
			calli(System.Int32(System.Void*,System.Int64,System.Int64,System.Int32), this._nativePointer, libOffset, cb, dwLockType, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000277 RID: 631 RVA: 0x000078C0 File Offset: 0x00005AC0
		public unsafe StorageStatistics GetStatistics(StorageStatisticsFlags grfStatFlag)
		{
			StorageStatistics.__Native _Native = default(StorageStatistics.__Native);
			StorageStatistics result = default(StorageStatistics);
			Result result2 = calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, &_Native, grfStatFlag, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			result.__MarshalFrom(ref _Native);
			result2.CheckError();
			return result;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00007918 File Offset: 0x00005B18
		public unsafe IStream Clone()
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			IStream result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new ComStream(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}
	}
}
