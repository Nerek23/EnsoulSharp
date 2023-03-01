using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200012B RID: 299
	[Guid("53585141-D9F8-4095-8321-D73CF6BD116C")]
	public class FontCollection1 : FontCollection
	{
		// Token: 0x06000541 RID: 1345 RVA: 0x00010FCC File Offset: 0x0000F1CC
		public FontCollection1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00010FD5 File Offset: 0x0000F1D5
		public new static explicit operator FontCollection1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontCollection1(nativePtr);
			}
			return null;
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000543 RID: 1347 RVA: 0x00010FEC File Offset: 0x0000F1EC
		public FontSet FontSet
		{
			get
			{
				FontSet result;
				this.GetFontSet(out result);
				return result;
			}
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x00011004 File Offset: 0x0000F204
		internal unsafe void GetFontSet(out FontSet fontSet)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontSet = new FontSet(zero);
			}
			else
			{
				fontSet = null;
			}
			result.CheckError();
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x00011060 File Offset: 0x0000F260
		public unsafe void GetFontFamily(int index, out FontFamily1 fontFamily)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontFamily = new FontFamily1(zero);
			}
			else
			{
				fontFamily = null;
			}
			result.CheckError();
		}
	}
}
