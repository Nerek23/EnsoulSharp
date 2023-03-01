using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200012A RID: 298
	[Guid("29748ED6-8C9C-4A6A-BE0B-D912E8538944")]
	public class Font3 : Font2
	{
		// Token: 0x06000538 RID: 1336 RVA: 0x00010E51 File Offset: 0x0000F051
		public Font3(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x00010E5A File Offset: 0x0000F05A
		public new static explicit operator Font3(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Font3(nativePtr);
			}
			return null;
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x00010E74 File Offset: 0x0000F074
		public FontFaceReference FontFaceReference
		{
			get
			{
				FontFaceReference result;
				this.GetFontFaceReference(out result);
				return result;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600053B RID: 1339 RVA: 0x00010E8A File Offset: 0x0000F08A
		public Locality Locality
		{
			get
			{
				return this.GetLocality();
			}
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x00010E94 File Offset: 0x0000F094
		public unsafe void CreateFontFace(out FontFace3 fontFace)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontFace = new FontFace3(zero);
			}
			else
			{
				fontFace = null;
			}
			result.CheckError();
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00010EF0 File Offset: 0x0000F0F0
		public unsafe RawBool Equals(Font font)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Font>(font);
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x00010F30 File Offset: 0x0000F130
		internal unsafe void GetFontFaceReference(out FontFaceReference fontFaceReference)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
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

		// Token: 0x0600053F RID: 1343 RVA: 0x00010F8B File Offset: 0x0000F18B
		public new unsafe RawBool HasCharacter(int unicodeValue)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Int32), this._nativePointer, unicodeValue, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x00010FAC File Offset: 0x0000F1AC
		internal unsafe Locality GetLocality()
		{
			return calli(SharpDX.DirectWrite.Locality(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
		}
	}
}
