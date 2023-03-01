using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000A3 RID: 163
	[Guid("1edd9491-9853-4299-898f-6432983b6f3a")]
	public class GdiInterop : ComObject
	{
		// Token: 0x06000343 RID: 835 RVA: 0x0000C200 File Offset: 0x0000A400
		public unsafe Font FromLogFont(object logFont)
		{
			int num = Marshal.SizeOf(logFont);
			byte* value = stackalloc byte[(UIntPtr)num];
			Marshal.StructureToPtr(logFont, new IntPtr((void*)value), false);
			Font result;
			this.CreateFontFromLOGFONT(new IntPtr((void*)value), out result);
			return result;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0000C238 File Offset: 0x0000A438
		public unsafe bool ToLogFont(Font font, object logFont)
		{
			int num = Marshal.SizeOf(logFont);
			byte* value = stackalloc byte[(UIntPtr)num];
			RawBool booleanValue;
			this.ConvertFontToLOGFONT(font, new IntPtr((void*)value), out booleanValue);
			Marshal.PtrToStructure(new IntPtr((void*)value), logFont);
			return booleanValue;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00002A7F File Offset: 0x00000C7F
		public GdiInterop(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000C272 File Offset: 0x0000A472
		public new static explicit operator GdiInterop(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new GdiInterop(nativePtr);
			}
			return null;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0000C28C File Offset: 0x0000A48C
		internal unsafe void CreateFontFromLOGFONT(IntPtr logFont, out Font font)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)logFont, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				font = new Font(zero);
			}
			else
			{
				font = null;
			}
			result.CheckError();
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0000C2EC File Offset: 0x0000A4EC
		internal unsafe void ConvertFontToLOGFONT(Font font, IntPtr logFont, out RawBool isSystemFont)
		{
			IntPtr value = IntPtr.Zero;
			isSystemFont = default(RawBool);
			value = CppObject.ToCallbackPtr<Font>(font);
			Result result;
			fixed (RawBool* ptr = &isSystemFont)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)logFont, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000C34C File Offset: 0x0000A54C
		internal unsafe void ConvertFontFaceToLOGFONT(FontFace font, IntPtr logFont)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFace>(font);
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)logFont, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000C39C File Offset: 0x0000A59C
		public unsafe FontFace CreateFontFaceFromHdc(IntPtr hdc)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)hdc, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			FontFace result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new FontFace(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000C3FC File Offset: 0x0000A5FC
		public unsafe BitmapRenderTarget CreateBitmapRenderTarget(IntPtr hdc, int width, int height)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)hdc, width, height, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			BitmapRenderTarget result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new BitmapRenderTarget(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x020000A4 RID: 164
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public class LogFont
		{
			// Token: 0x04000217 RID: 535
			public int lfHeight;

			// Token: 0x04000218 RID: 536
			public int lfWidth;

			// Token: 0x04000219 RID: 537
			public int lfEscapement;

			// Token: 0x0400021A RID: 538
			public int lfOrientation;

			// Token: 0x0400021B RID: 539
			public int lfWeight;

			// Token: 0x0400021C RID: 540
			public byte lfItalic;

			// Token: 0x0400021D RID: 541
			public byte lfUnderline;

			// Token: 0x0400021E RID: 542
			public byte lfStrikeOut;

			// Token: 0x0400021F RID: 543
			public byte lfCharSet;

			// Token: 0x04000220 RID: 544
			public byte lfOutPrecision;

			// Token: 0x04000221 RID: 545
			public byte lfClipPrecision;

			// Token: 0x04000222 RID: 546
			public byte lfQuality;

			// Token: 0x04000223 RID: 547
			public byte lfPitchAndFamily;

			// Token: 0x04000224 RID: 548
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string lfFaceName;
		}

		// Token: 0x020000A5 RID: 165
		public struct FontSignature
		{
			// Token: 0x04000225 RID: 549
			public int fsUsb1;

			// Token: 0x04000226 RID: 550
			public int fsUsb2;

			// Token: 0x04000227 RID: 551
			public int fsUsb3;

			// Token: 0x04000228 RID: 552
			public int fsUsb4;

			// Token: 0x04000229 RID: 553
			public int fsCsb1;

			// Token: 0x0400022A RID: 554
			public int fsCsb2;
		}
	}
}
