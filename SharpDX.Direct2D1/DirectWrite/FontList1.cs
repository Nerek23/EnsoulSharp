using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000138 RID: 312
	[Guid("DA20D8EF-812A-4C43-9802-62EC4ABD7ADE")]
	public class FontList1 : FontList
	{
		// Token: 0x060005BC RID: 1468 RVA: 0x00012432 File Offset: 0x00010632
		public FontList1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0001276A File Offset: 0x0001096A
		public new static explicit operator FontList1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontList1(nativePtr);
			}
			return null;
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x00012781 File Offset: 0x00010981
		public unsafe Locality GetFontLocality(int listIndex)
		{
			return calli(SharpDX.DirectWrite.Locality(System.Void*,System.Int32), this._nativePointer, listIndex, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x000127A4 File Offset: 0x000109A4
		public unsafe void GetFont(int listIndex, out Font3 font)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, listIndex, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
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

		// Token: 0x060005C0 RID: 1472 RVA: 0x00012800 File Offset: 0x00010A00
		public unsafe void GetFontFaceReference(int listIndex, out FontFaceReference fontFaceReference)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, listIndex, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
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
