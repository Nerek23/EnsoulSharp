using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200013C RID: 316
	[Guid("4556BE70-3ABD-4F70-90BE-421780A6F515")]
	public class GdiInterop1 : GdiInterop
	{
		// Token: 0x060005D7 RID: 1495 RVA: 0x00012EBA File Offset: 0x000110BA
		public GdiInterop1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x00012EC3 File Offset: 0x000110C3
		public new static explicit operator GdiInterop1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new GdiInterop1(nativePtr);
			}
			return null;
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x00012EDC File Offset: 0x000110DC
		internal unsafe Font CreateFontFromLOGFONT(IntPtr logFont, FontCollection fontCollection)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontCollection>(fontCollection);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)logFont, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
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

		// Token: 0x060005DA RID: 1498 RVA: 0x00012F50 File Offset: 0x00011150
		public unsafe GdiInterop.FontSignature GetFontSignature(FontFace fontFace)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFace>(fontFace);
			GdiInterop.FontSignature result;
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x00012FA0 File Offset: 0x000111A0
		public unsafe GdiInterop.FontSignature GetFontSignature(Font font)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Font>(font);
			GdiInterop.FontSignature result;
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x00012FF0 File Offset: 0x000111F0
		internal unsafe void GetMatchingFontsByLOGFONT(IntPtr logFont, FontSet fontSet, out FontSet filteredSet)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontSet>(fontSet);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)logFont, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				filteredSet = new FontSet(zero);
			}
			else
			{
				filteredSet = null;
			}
			result.CheckError();
		}
	}
}
