using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.WIC
{
	// Token: 0x02000017 RID: 23
	[Guid("3d4c0c61-18a4-41e4-bd80-481a4fc9f464")]
	public class DdsFrameDecode : ComObject
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000119 RID: 281 RVA: 0x0000500C File Offset: 0x0000320C
		public Size2 SizeInBlocks
		{
			get
			{
				int width;
				int height;
				this.GetSizeInBlocks(out width, out height);
				return new Size2(width, height);
			}
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000502A File Offset: 0x0000322A
		public void CopyBlocks(RawBox? boundsInBlocks, int stride, DataStream destination)
		{
			this.CopyBlocks(boundsInBlocks, stride, (int)(destination.Length - destination.Position), destination.PositionPointer);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00002A7F File Offset: 0x00000C7F
		public DdsFrameDecode(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00005048 File Offset: 0x00003248
		public new static explicit operator DdsFrameDecode(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DdsFrameDecode(nativePtr);
			}
			return null;
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00005060 File Offset: 0x00003260
		public DdsFormatInfo FormatInfo
		{
			get
			{
				DdsFormatInfo result;
				this.GetFormatInfo(out result);
				return result;
			}
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00005078 File Offset: 0x00003278
		internal unsafe void GetSizeInBlocks(out int widthInBlocksRef, out int heightInBlocksRef)
		{
			Result result;
			fixed (int* ptr = &heightInBlocksRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &widthInBlocksRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000050C4 File Offset: 0x000032C4
		internal unsafe void GetFormatInfo(out DdsFormatInfo formatInfoRef)
		{
			formatInfoRef = default(DdsFormatInfo);
			Result result;
			fixed (DdsFormatInfo* ptr = &formatInfoRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000510C File Offset: 0x0000330C
		internal unsafe void CopyBlocks(RawBox? rcBoundsInBlocksRef, int stride, int bufferSize, IntPtr bufferRef)
		{
			RawBox value;
			if (rcBoundsInBlocksRef != null)
			{
				value = rcBoundsInBlocksRef.Value;
			}
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, (rcBoundsInBlocksRef == null) ? null : (&value), stride, bufferSize, (void*)bufferRef, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
