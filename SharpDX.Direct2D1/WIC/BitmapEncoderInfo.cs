using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x02000069 RID: 105
	[Guid("94C9B4EE-A09F-4f92-8A1E-4A9BCE7E76FB")]
	public class BitmapEncoderInfo : BitmapCodecInfo
	{
		// Token: 0x060001E3 RID: 483 RVA: 0x00002FA5 File Offset: 0x000011A5
		public BitmapEncoderInfo(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000839C File Offset: 0x0000659C
		public new static explicit operator BitmapEncoderInfo(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapEncoderInfo(nativePtr);
			}
			return null;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x000083B4 File Offset: 0x000065B4
		public unsafe void CreateInstance(out BitmapEncoder bitmapEncoderOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				bitmapEncoderOut = new BitmapEncoder(zero);
			}
			else
			{
				bitmapEncoderOut = null;
			}
			result.CheckError();
		}
	}
}
