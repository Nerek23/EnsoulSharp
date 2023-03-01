using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000137 RID: 311
	[Guid("1a0d8438-1d97-4ec1-aef9-a2fb86ed6acb")]
	public class FontList : ComObject
	{
		// Token: 0x060005B5 RID: 1461 RVA: 0x00002A7F File Offset: 0x00000C7F
		public FontList(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0001267C File Offset: 0x0001087C
		public new static explicit operator FontList(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontList(nativePtr);
			}
			return null;
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060005B7 RID: 1463 RVA: 0x00012694 File Offset: 0x00010894
		public FontCollection FontCollection
		{
			get
			{
				FontCollection result;
				this.GetFontCollection(out result);
				return result;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x000126AA File Offset: 0x000108AA
		public int FontCount
		{
			get
			{
				return this.GetFontCount();
			}
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x000126B4 File Offset: 0x000108B4
		internal unsafe void GetFontCollection(out FontCollection fontCollection)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontCollection = new FontCollection(zero);
			}
			else
			{
				fontCollection = null;
			}
			result.CheckError();
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x00010018 File Offset: 0x0000E218
		internal unsafe int GetFontCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x00012710 File Offset: 0x00010910
		public unsafe Font GetFont(int index)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			Font result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new Font(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}
	}
}
