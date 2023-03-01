using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x0200001A RID: 26
	[Guid("9F34FB65-13F4-4f15-BC57-3726B5E53D9F")]
	public class FormatConverterInfo : ComponentInfo
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600012F RID: 303 RVA: 0x0000535C File Offset: 0x0000355C
		public Guid[] PixelFormats
		{
			get
			{
				int num = 0;
				this.GetPixelFormats(num, null, out num);
				if (num == 0)
				{
					return new Guid[0];
				}
				Guid[] array = new Guid[num];
				this.GetPixelFormats(num, array, out num);
				return array;
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0000245C File Offset: 0x0000065C
		public FormatConverterInfo(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00005391 File Offset: 0x00003591
		public new static explicit operator FormatConverterInfo(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FormatConverterInfo(nativePtr);
			}
			return null;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000053A8 File Offset: 0x000035A8
		internal unsafe void GetPixelFormats(int formats, Guid[] pixelFormatGUIDsRef, out int actualRef)
		{
			Result result;
			fixed (int* ptr = &actualRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (Guid[] array = pixelFormatGUIDsRef)
				{
					void* ptr3;
					if (pixelFormatGUIDsRef == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, formats, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000540C File Offset: 0x0000360C
		internal unsafe void CreateInstance(FormatConverter converterOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			converterOut.NativePointer = zero;
			result.CheckError();
		}
	}
}
