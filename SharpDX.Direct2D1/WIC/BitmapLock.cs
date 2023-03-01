using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x0200000C RID: 12
	[Guid("00000123-a8f2-4877-ba0a-fd2b6645fb94")]
	public class BitmapLock : ComObject
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000BC RID: 188 RVA: 0x0000402C File Offset: 0x0000222C
		public Size2 Size
		{
			get
			{
				int width;
				int height;
				this.GetSize(out width, out height);
				return new Size2(width, height);
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000BD RID: 189 RVA: 0x0000404C File Offset: 0x0000224C
		public DataRectangle Data
		{
			get
			{
				int num;
				return new DataRectangle(this.GetDataPointer(out num), this.Stride);
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00002A7F File Offset: 0x00000C7F
		public BitmapLock(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000406C File Offset: 0x0000226C
		public new static explicit operator BitmapLock(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapLock(nativePtr);
			}
			return null;
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00004084 File Offset: 0x00002284
		public int Stride
		{
			get
			{
				int result;
				this.GetStride(out result);
				return result;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x0000409C File Offset: 0x0000229C
		public Guid PixelFormat
		{
			get
			{
				Guid result;
				this.GetPixelFormat(out result);
				return result;
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000040B4 File Offset: 0x000022B4
		internal unsafe void GetSize(out int widthRef, out int heightRef)
		{
			Result result;
			fixed (int* ptr = &heightRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &widthRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00004100 File Offset: 0x00002300
		internal unsafe void GetStride(out int strideRef)
		{
			Result result;
			fixed (int* ptr = &strideRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00004140 File Offset: 0x00002340
		internal unsafe IntPtr GetDataPointer(out int bufferSizeRef)
		{
			IntPtr result2;
			Result result;
			fixed (int* ptr = &bufferSizeRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, &result2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00004184 File Offset: 0x00002384
		internal unsafe void GetPixelFormat(out Guid pixelFormatRef)
		{
			pixelFormatRef = default(Guid);
			Result result;
			fixed (Guid* ptr = &pixelFormatRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
