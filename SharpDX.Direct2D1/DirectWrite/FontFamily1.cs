using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000136 RID: 310
	[Guid("DA20D8EF-812A-4C43-9802-62EC4ABD7ADF")]
	public class FontFamily1 : FontFamily
	{
		// Token: 0x060005B0 RID: 1456 RVA: 0x00012580 File Offset: 0x00010780
		public FontFamily1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00012589 File Offset: 0x00010789
		public new static explicit operator FontFamily1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontFamily1(nativePtr);
			}
			return null;
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x000125A0 File Offset: 0x000107A0
		public unsafe Locality GetFontLocality(int listIndex)
		{
			return calli(SharpDX.DirectWrite.Locality(System.Void*,System.Int32), this._nativePointer, listIndex, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x000125C4 File Offset: 0x000107C4
		public unsafe void GetFont(int listIndex, out Font3 font)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, listIndex, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				font = new Font3(zero);
			}
			else
			{
				font = null;
			}
			result.CheckError();
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x00012620 File Offset: 0x00010820
		public unsafe void GetFontFaceReference(int listIndex, out FontFaceReference fontFaceReference)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, listIndex, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontFaceReference = new FontFaceReference(zero);
			}
			else
			{
				fontFaceReference = null;
			}
			result.CheckError();
		}
	}
}
