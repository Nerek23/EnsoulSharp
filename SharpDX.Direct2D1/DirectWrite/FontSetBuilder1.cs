using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200013B RID: 315
	[Guid("3FF7715F-3CDC-4DC6-9B72-EC5621DCCAFD")]
	public class FontSetBuilder1 : FontSetBuilder
	{
		// Token: 0x060005D4 RID: 1492 RVA: 0x00012E4E File Offset: 0x0001104E
		public FontSetBuilder1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x00012E57 File Offset: 0x00011057
		public new static explicit operator FontSetBuilder1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontSetBuilder1(nativePtr);
			}
			return null;
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x00012E70 File Offset: 0x00011070
		public unsafe void AddFontFile(FontFile fontFile)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFile>(fontFile);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
