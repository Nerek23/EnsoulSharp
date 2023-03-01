using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.WIC
{
	// Token: 0x0200000F RID: 15
	[Guid("3B16811B-6A43-4ec9-B713-3D5A0C13B940")]
	public class BitmapSourceTransform : ComObject
	{
		// Token: 0x060000DA RID: 218 RVA: 0x000045D8 File Offset: 0x000027D8
		public void CopyPixels(int width, int height, int stride, DataStream output)
		{
			this.CopyPixels(IntPtr.Zero, width, height, null, BitmapTransformOptions.Rotate0, stride, (int)(output.Length - output.Position), output.PositionPointer);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00004614 File Offset: 0x00002814
		public void CopyPixels(int width, int height, BitmapTransformOptions dstTransform, int stride, DataStream output)
		{
			this.CopyPixels(IntPtr.Zero, width, height, null, dstTransform, stride, (int)(output.Length - output.Position), output.PositionPointer);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00004654 File Offset: 0x00002854
		public void CopyPixels(int width, int height, Guid guidDstFormat, BitmapTransformOptions dstTransform, int stride, DataStream output)
		{
			this.CopyPixels(IntPtr.Zero, width, height, new Guid?(guidDstFormat), dstTransform, stride, (int)(output.Length - output.Position), output.PositionPointer);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00004690 File Offset: 0x00002890
		public unsafe void CopyPixels(RawBox rectangle, int width, int height, Guid guidDstFormat, BitmapTransformOptions dstTransform, int stride, DataStream output)
		{
			this.CopyPixels(new IntPtr((void*)(&rectangle)), width, height, new Guid?(guidDstFormat), dstTransform, stride, (int)(output.Length - output.Position), output.PositionPointer);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000046D0 File Offset: 0x000028D0
		public void GetClosestSize(ref Size2 size)
		{
			int width = size.Width;
			int height = size.Height;
			this.GetClosestSize(ref width, ref height);
			size.Width = width;
			size.Height = height;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00002A7F File Offset: 0x00000C7F
		public BitmapSourceTransform(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00004703 File Offset: 0x00002903
		public new static explicit operator BitmapSourceTransform(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapSourceTransform(nativePtr);
			}
			return null;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000471C File Offset: 0x0000291C
		internal unsafe void CopyPixels(IntPtr rectangleRef, int width, int height, Guid? guidDstFormatRef, BitmapTransformOptions dstTransform, int nStride, int bufferSize, IntPtr bufferRef)
		{
			Guid value;
			if (guidDstFormatRef != null)
			{
				value = guidDstFormatRef.Value;
			}
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)rectangleRef, width, height, (guidDstFormatRef == null) ? null : (&value), dstTransform, nStride, bufferSize, (void*)bufferRef, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000478C File Offset: 0x0000298C
		internal unsafe void GetClosestSize(ref int widthRef, ref int heightRef)
		{
			Result result;
			fixed (int* ptr = &heightRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &widthRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000047D8 File Offset: 0x000029D8
		public unsafe void GetClosestPixelFormat(ref Guid guidDstFormatRef)
		{
			Result result;
			fixed (Guid* ptr = &guidDstFormatRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00004818 File Offset: 0x00002A18
		public unsafe void IsSupportingTransform(BitmapTransformOptions dstTransform, out RawBool fIsSupportedRef)
		{
			fIsSupportedRef = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &fIsSupportedRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, dstTransform, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
