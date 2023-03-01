using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200013A RID: 314
	[Guid("2F642AFE-9C68-4F40-B8BE-457401AFCB3D")]
	public class FontSetBuilder : ComObject
	{
		// Token: 0x060005CE RID: 1486 RVA: 0x00002A7F File Offset: 0x00000C7F
		public FontSetBuilder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x00012C83 File Offset: 0x00010E83
		public new static explicit operator FontSetBuilder(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontSetBuilder(nativePtr);
			}
			return null;
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x00012C9C File Offset: 0x00010E9C
		public unsafe void AddFontFaceReference(FontFaceReference fontFaceReference, FontProperty[] ropertiesRef, int propertyCount)
		{
			IntPtr value = IntPtr.Zero;
			FontProperty.__Native[] array = new FontProperty.__Native[ropertiesRef.Length];
			value = CppObject.ToCallbackPtr<FontFaceReference>(fontFaceReference);
			for (int i = 0; i < ropertiesRef.Length; i++)
			{
				ropertiesRef[i].__MarshalTo(ref array[i]);
			}
			FontProperty.__Native[] array2;
			void* ptr;
			if ((array2 = array) == null || array2.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = (void*)(&array2[0]);
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, ptr, propertyCount, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			array2 = null;
			for (int j = 0; j < ropertiesRef.Length; j++)
			{
				ropertiesRef[j].__MarshalFree(ref array[j]);
			}
			result.CheckError();
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x00012D5C File Offset: 0x00010F5C
		public unsafe void AddFontFaceReference(FontFaceReference fontFaceReference)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFaceReference>(fontFaceReference);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x00012DA8 File Offset: 0x00010FA8
		public unsafe void AddFontSet(FontSet fontSet)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontSet>(fontSet);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x00012DF4 File Offset: 0x00010FF4
		public unsafe void CreateFontSet(out FontSet fontSet)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
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
	}
}
