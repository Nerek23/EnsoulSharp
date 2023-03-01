using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000127 RID: 295
	[Guid("acd16696-8c14-4f5d-877e-fe3fc1d32737")]
	public class Font : ComObject
	{
		// Token: 0x06000516 RID: 1302 RVA: 0x00002A7F File Offset: 0x00000C7F
		public Font(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x000109CD File Offset: 0x0000EBCD
		public new static explicit operator Font(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Font(nativePtr);
			}
			return null;
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x000109E4 File Offset: 0x0000EBE4
		public FontFamily FontFamily
		{
			get
			{
				FontFamily result;
				this.GetFontFamily(out result);
				return result;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000519 RID: 1305 RVA: 0x000109FA File Offset: 0x0000EBFA
		public FontWeight Weight
		{
			get
			{
				return this.GetWeight();
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600051A RID: 1306 RVA: 0x00010A02 File Offset: 0x0000EC02
		public FontStretch Stretch
		{
			get
			{
				return this.GetStretch();
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x00010A0A File Offset: 0x0000EC0A
		public FontStyle Style
		{
			get
			{
				return this.GetStyle();
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x00010A12 File Offset: 0x0000EC12
		public RawBool IsSymbolFont
		{
			get
			{
				return this.IsSymbolFont_();
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x00010A1C File Offset: 0x0000EC1C
		public LocalizedStrings FaceNames
		{
			get
			{
				LocalizedStrings result;
				this.GetFaceNames(out result);
				return result;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600051E RID: 1310 RVA: 0x00010A32 File Offset: 0x0000EC32
		public FontSimulations Simulations
		{
			get
			{
				return this.GetSimulations();
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600051F RID: 1311 RVA: 0x00010A3C File Offset: 0x0000EC3C
		public FontMetrics Metrics
		{
			get
			{
				FontMetrics result;
				this.GetMetrics(out result);
				return result;
			}
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x00010A54 File Offset: 0x0000EC54
		internal unsafe void GetFontFamily(out FontFamily fontFamily)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontFamily = new FontFamily(zero);
			}
			else
			{
				fontFamily = null;
			}
			result.CheckError();
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00010AAE File Offset: 0x0000ECAE
		internal unsafe FontWeight GetWeight()
		{
			return calli(SharpDX.DirectWrite.FontWeight(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x00010ACD File Offset: 0x0000ECCD
		internal unsafe FontStretch GetStretch()
		{
			return calli(SharpDX.DirectWrite.FontStretch(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x00010AEC File Offset: 0x0000ECEC
		internal unsafe FontStyle GetStyle()
		{
			return calli(SharpDX.DirectWrite.FontStyle(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0000B6BA File Offset: 0x000098BA
		internal unsafe RawBool IsSymbolFont_()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x00010B0C File Offset: 0x0000ED0C
		internal unsafe void GetFaceNames(out LocalizedStrings names)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				names = new LocalizedStrings(zero);
			}
			else
			{
				names = null;
			}
			result.CheckError();
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x00010B68 File Offset: 0x0000ED68
		public unsafe RawBool GetInformationalStrings(InformationalStringId informationalStringID, out LocalizedStrings informationalStrings)
		{
			IntPtr zero = IntPtr.Zero;
			RawBool result2;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, informationalStringID, &zero, &result2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				informationalStrings = new LocalizedStrings(zero);
			}
			else
			{
				informationalStrings = null;
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x00010BC8 File Offset: 0x0000EDC8
		internal unsafe FontSimulations GetSimulations()
		{
			return calli(SharpDX.DirectWrite.FontSimulations(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x00010BE8 File Offset: 0x0000EDE8
		internal unsafe void GetMetrics(out FontMetrics fontMetrics)
		{
			fontMetrics = default(FontMetrics);
			fixed (FontMetrics* ptr = &fontMetrics)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x00010C24 File Offset: 0x0000EE24
		public unsafe RawBool HasCharacter(int unicodeValue)
		{
			RawBool result;
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, unicodeValue, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x00010C64 File Offset: 0x0000EE64
		internal unsafe void CreateFontFace(FontFace fontFace)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			fontFace.NativePointer = zero;
			result.CheckError();
		}
	}
}
