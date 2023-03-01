using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000030 RID: 48
	[Guid("d79dbb70-5f21-4d36-bbc2-ff525c213cdc")]
	public class Font : ComObject
	{
		// Token: 0x060002BC RID: 700 RVA: 0x0000AB0C File Offset: 0x00008D0C
		public Font(Device device, FontDescription fontDescription) : base(IntPtr.Zero)
		{
			D3DX9.CreateFontIndirect(device, ref fontDescription, this);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000AB24 File Offset: 0x00008D24
		public Font(Device device, int height, int width, FontWeight weight, int mipLevels, bool isItalic, FontCharacterSet characterSet, FontPrecision precision, FontQuality quality, FontPitchAndFamily pitchAndFamily, string faceName)
		{
			D3DX9.CreateFont(device, height, width, (int)weight, mipLevels, isItalic, (int)characterSet, (int)precision, (int)quality, (int)pitchAndFamily, faceName, this);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000AB55 File Offset: 0x00008D55
		public void PreloadText(string stringRef)
		{
			this.PreloadText(stringRef, stringRef.Length);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000AB64 File Offset: 0x00008D64
		public unsafe int DrawText(Sprite sprite, string text, RawRectangle rect, FontDrawFlags drawFlags, RawColorBGRA color)
		{
			int num = this.DrawText(sprite, text, text.Length, new IntPtr((void*)(&rect)), (int)drawFlags, color);
			if (num == 0)
			{
				throw new SharpDXException("Draw failed", new object[0]);
			}
			return num;
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0000ABA1 File Offset: 0x00008DA1
		public int DrawText(Sprite sprite, string text, int x, int y, RawColorBGRA color)
		{
			return this.DrawText(sprite, text, new RawRectangle(x, y, 0, 0), FontDrawFlags.NoClip, color);
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000ABBC File Offset: 0x00008DBC
		public RawRectangle MeasureText(Sprite sprite, string text, FontDrawFlags drawFlags)
		{
			return this.MeasureText(sprite, text, default(RawRectangle), drawFlags);
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000ABDC File Offset: 0x00008DDC
		public unsafe RawRectangle MeasureText(Sprite sprite, string text, RawRectangle rect, FontDrawFlags drawFlags)
		{
			int num = -1;
			this.DrawText(sprite, text, text.Length, new IntPtr((void*)(&rect)), (int)(drawFlags | (FontDrawFlags)1024), *(RawColorBGRA*)(&num));
			return rect;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000AC14 File Offset: 0x00008E14
		public unsafe RawRectangle MeasureText(Sprite sprite, string text, RawRectangle rect, FontDrawFlags drawFlags, out int textHeight)
		{
			int num = -1;
			textHeight = this.DrawText(sprite, text, text.Length, new IntPtr((void*)(&rect)), (int)(drawFlags | (FontDrawFlags)1024), *(RawColorBGRA*)(&num));
			return rect;
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00002623 File Offset: 0x00000823
		public Font(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000AC4D File Offset: 0x00008E4D
		public new static explicit operator Font(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new Font(nativePointer);
			}
			return null;
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x0000AC64 File Offset: 0x00008E64
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x0000AC7C File Offset: 0x00008E7C
		public FontDescription Description
		{
			get
			{
				FontDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x0000AC92 File Offset: 0x00008E92
		public IntPtr DeviceContext
		{
			get
			{
				return this.GetDeviceContext();
			}
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0000AC9C File Offset: 0x00008E9C
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0000ACF4 File Offset: 0x00008EF4
		internal unsafe void GetDescription(out FontDescription descRef)
		{
			FontDescription.__Native _Native = default(FontDescription.__Native);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			descRef = default(FontDescription);
			descRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000AD48 File Offset: 0x00008F48
		internal unsafe RawBool GetTextMetrics(out Win32Native.TextMetric textMetricsRef)
		{
			textMetricsRef = default(Win32Native.TextMetric);
			RawBool result;
			fixed (Win32Native.TextMetric* ptr = &textMetricsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			return result;
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0000AD82 File Offset: 0x00008F82
		internal unsafe IntPtr GetDeviceContext()
		{
			return calli(System.IntPtr(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000ADA4 File Offset: 0x00008FA4
		public unsafe void GetGlyphData(int glyph, out Texture textureOut, out RawRectangle blackBoxRef, out RawPoint cellIncRef)
		{
			IntPtr zero = IntPtr.Zero;
			blackBoxRef = default(RawRectangle);
			cellIncRef = default(RawPoint);
			Result result;
			fixed (RawRectangle* ptr = &blackBoxRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawPoint* ptr3 = &cellIncRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, glyph, &zero, ptr2, ptr4, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
				}
			}
			textureOut = ((zero == IntPtr.Zero) ? null : new Texture(zero));
			result.CheckError();
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000AE28 File Offset: 0x00009028
		public unsafe void PreloadCharacters(int first, int last)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, first, last, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000AE64 File Offset: 0x00009064
		public unsafe void PreloadGlyphs(int first, int last)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, first, last, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000AEA0 File Offset: 0x000090A0
		internal unsafe void PreloadText(string stringRef, int count)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(stringRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)intPtr, count, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			result.CheckError();
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000AEEC File Offset: 0x000090EC
		public unsafe int DrawText(Sprite spriteRef, string stringRef, int count, IntPtr rectRef, int format, RawColorBGRA color)
		{
			IntPtr intPtr = Utilities.StringToHGlobalUni(stringRef);
			int result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawColorBGRA), this._nativePointer, (void*)((spriteRef == null) ? IntPtr.Zero : spriteRef.NativePointer), (void*)intPtr, count, (void*)rectRef, format, color, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000AF4C File Offset: 0x0000914C
		public unsafe void OnLostDevice()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000AF84 File Offset: 0x00009184
		public unsafe void OnResetDevice()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
