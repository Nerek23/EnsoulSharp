using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200013F RID: 319
	[Guid("4DB3757A-2C72-4ED9-B2B6-1ABABE1AFF9C")]
	public class RemoteFontFileStream : FontFileStreamNative
	{
		// Token: 0x060005E7 RID: 1511 RVA: 0x00013274 File Offset: 0x00011474
		public RemoteFontFileStream(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x0001327D File Offset: 0x0001147D
		public new static explicit operator RemoteFontFileStream(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RemoteFontFileStream(nativePtr);
			}
			return null;
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060005E9 RID: 1513 RVA: 0x00013294 File Offset: 0x00011494
		public long LocalFileSize
		{
			get
			{
				long result;
				this.GetLocalFileSize(out result);
				return result;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060005EA RID: 1514 RVA: 0x000132AA File Offset: 0x000114AA
		public Locality Locality
		{
			get
			{
				return this.GetLocality();
			}
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x000132B4 File Offset: 0x000114B4
		internal unsafe void GetLocalFileSize(out long localFileSize)
		{
			Result result;
			fixed (long* ptr = &localFileSize)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x000132F4 File Offset: 0x000114F4
		public unsafe void GetFileFragmentLocality(long fileOffset, long fragmentSize, out RawBool isLocal, long artialSizeRef)
		{
			isLocal = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &isLocal)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int64,System.Int64,System.Void*,System.Void*), this._nativePointer, fileOffset, fragmentSize, ptr2, &artialSizeRef, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x00013340 File Offset: 0x00011540
		internal unsafe Locality GetLocality()
		{
			return calli(SharpDX.DirectWrite.Locality(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x00013360 File Offset: 0x00011560
		public unsafe AsyncResult BeginDownload(Guid downloadOperationID, FileFragment[] fileFragments, int fragmentCount)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (FileFragment[] array = fileFragments)
			{
				void* ptr;
				if (fileFragments == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, &downloadOperationID, ptr, fragmentCount, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			AsyncResult result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new AsyncResult(zero);
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
