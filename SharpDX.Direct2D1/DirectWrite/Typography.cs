using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000E5 RID: 229
	[Guid("55f1112b-1dc2-4b3c-9541-f46894ed85b6")]
	public class Typography : ComObject
	{
		// Token: 0x060004E8 RID: 1256 RVA: 0x0000FFAF File Offset: 0x0000E1AF
		public Typography(Factory factory)
		{
			factory.CreateTypography(this);
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x00002A7F File Offset: 0x00000C7F
		public Typography(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x0000FFBE File Offset: 0x0000E1BE
		public new static explicit operator Typography(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Typography(nativePtr);
			}
			return null;
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x0000FFD5 File Offset: 0x0000E1D5
		public int FontFeatureCount
		{
			get
			{
				return this.GetFontFeatureCount();
			}
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x0000FFE0 File Offset: 0x0000E1E0
		public unsafe void AddFontFeature(FontFeature fontFeature)
		{
			calli(System.Int32(System.Void*,SharpDX.DirectWrite.FontFeature), this._nativePointer, fontFeature, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x00010018 File Offset: 0x0000E218
		internal unsafe int GetFontFeatureCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00010038 File Offset: 0x0000E238
		public unsafe FontFeature GetFontFeature(int fontFeatureIndex)
		{
			FontFeature result;
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, fontFeatureIndex, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}
	}
}
