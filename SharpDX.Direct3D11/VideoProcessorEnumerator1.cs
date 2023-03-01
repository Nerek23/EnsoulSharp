using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000CC RID: 204
	[Guid("465217F2-5568-43CF-B5B9-F61D54531CA1")]
	public class VideoProcessorEnumerator1 : VideoProcessorEnumerator
	{
		// Token: 0x0600042B RID: 1067 RVA: 0x000106F1 File Offset: 0x0000E8F1
		public VideoProcessorEnumerator1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x000106FA File Offset: 0x0000E8FA
		public new static explicit operator VideoProcessorEnumerator1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new VideoProcessorEnumerator1(nativePtr);
			}
			return null;
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x00010714 File Offset: 0x0000E914
		public unsafe void CheckVideoProcessorFormatConversion(Format inputFormat, ColorSpaceType inputColorSpace, Format outputFormat, ColorSpaceType outputColorSpace, out RawBool supportedRef)
		{
			supportedRef = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &supportedRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, inputFormat, inputColorSpace, outputFormat, outputColorSpace, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
