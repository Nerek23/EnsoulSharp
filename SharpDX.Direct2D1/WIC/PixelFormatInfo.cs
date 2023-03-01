using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x02000029 RID: 41
	[Guid("E8EDA601-3D48-431a-AB44-69059BE88BBE")]
	public class PixelFormatInfo : ComponentInfo
	{
		// Token: 0x060001A7 RID: 423 RVA: 0x0000754C File Offset: 0x0000574C
		public byte[] GetChannelMask(int channelIndex)
		{
			int num = 0;
			this.GetChannelMask(channelIndex, num, null, out num);
			if (num == 0)
			{
				return new byte[0];
			}
			byte[] array = new byte[num];
			this.GetChannelMask(channelIndex, num, array, out num);
			return array;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000245C File Offset: 0x0000065C
		public PixelFormatInfo(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00007583 File Offset: 0x00005783
		public new static explicit operator PixelFormatInfo(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new PixelFormatInfo(nativePtr);
			}
			return null;
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060001AA RID: 426 RVA: 0x0000759C File Offset: 0x0000579C
		public Guid FormatGUID
		{
			get
			{
				Guid result;
				this.GetFormatGUID(out result);
				return result;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060001AB RID: 427 RVA: 0x000075B4 File Offset: 0x000057B4
		public ColorContext ColorContext
		{
			get
			{
				ColorContext result;
				this.GetColorContext(out result);
				return result;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001AC RID: 428 RVA: 0x000075CC File Offset: 0x000057CC
		public int BitsPerPixel
		{
			get
			{
				int result;
				this.GetBitsPerPixel(out result);
				return result;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001AD RID: 429 RVA: 0x000075E4 File Offset: 0x000057E4
		public int ChannelCount
		{
			get
			{
				int result;
				this.GetChannelCount(out result);
				return result;
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x000075FC File Offset: 0x000057FC
		internal unsafe void GetFormatGUID(out Guid formatRef)
		{
			formatRef = default(Guid);
			Result result;
			fixed (Guid* ptr = &formatRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00007644 File Offset: 0x00005844
		internal unsafe void GetColorContext(out ColorContext colorContextOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				colorContextOut = new ColorContext(zero);
			}
			else
			{
				colorContextOut = null;
			}
			result.CheckError();
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x000076A0 File Offset: 0x000058A0
		internal unsafe void GetBitsPerPixel(out int bitsPerPixelRef)
		{
			Result result;
			fixed (int* ptr = &bitsPerPixelRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x000076E4 File Offset: 0x000058E4
		internal unsafe void GetChannelCount(out int channelCountRef)
		{
			Result result;
			fixed (int* ptr = &channelCountRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00007728 File Offset: 0x00005928
		internal unsafe void GetChannelMask(int channelIndex, int maskBuffer, byte[] maskBufferRef, out int actualRef)
		{
			Result result;
			fixed (int* ptr = &actualRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (byte[] array = maskBufferRef)
				{
					void* ptr3;
					if (maskBufferRef == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, channelIndex, maskBuffer, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}
	}
}
