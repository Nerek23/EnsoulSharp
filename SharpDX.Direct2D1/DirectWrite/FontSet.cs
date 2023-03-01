using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000139 RID: 313
	[Guid("53585141-D9F8-4095-8321-D73CF6BD116B")]
	public class FontSet : ComObject
	{
		// Token: 0x060005C1 RID: 1473 RVA: 0x00002A7F File Offset: 0x00000C7F
		public FontSet(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x0001285B File Offset: 0x00010A5B
		public new static explicit operator FontSet(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontSet(nativePtr);
			}
			return null;
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060005C3 RID: 1475 RVA: 0x00012872 File Offset: 0x00010A72
		public int FontCount
		{
			get
			{
				return this.GetFontCount();
			}
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0000B227 File Offset: 0x00009427
		internal unsafe int GetFontCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x0001287C File Offset: 0x00010A7C
		public unsafe void GetFontFaceReference(int listIndex, out FontFaceReference fontFaceReference)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, listIndex, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
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

		// Token: 0x060005C6 RID: 1478 RVA: 0x000128D8 File Offset: 0x00010AD8
		public unsafe void FindFontFaceReference(FontFaceReference fontFaceReference, out int listIndex, out RawBool exists)
		{
			IntPtr value = IntPtr.Zero;
			exists = default(RawBool);
			value = CppObject.ToCallbackPtr<FontFaceReference>(fontFaceReference);
			Result result;
			fixed (RawBool* ptr = &exists)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &listIndex)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x00012940 File Offset: 0x00010B40
		public unsafe void FindFontFace(FontFace fontFace, out int listIndex, out RawBool exists)
		{
			IntPtr value = IntPtr.Zero;
			exists = default(RawBool);
			value = CppObject.ToCallbackPtr<FontFace>(fontFace);
			Result result;
			fixed (RawBool* ptr = &exists)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &listIndex)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x000129A8 File Offset: 0x00010BA8
		public unsafe void GetPropertyValues(FontPropertyId propertyID, out StringList values)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, propertyID, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				values = new StringList(zero);
			}
			else
			{
				values = null;
			}
			result.CheckError();
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00012A04 File Offset: 0x00010C04
		public unsafe void GetPropertyValues(FontPropertyId propertyID, string referredLocaleNamesRef, out StringList values)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (string text = referredLocaleNamesRef)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, propertyID, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				values = new StringList(zero);
			}
			else
			{
				values = null;
			}
			result.CheckError();
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x00012A74 File Offset: 0x00010C74
		public unsafe void GetPropertyValues(int listIndex, FontPropertyId propertyId, out RawBool exists, out LocalizedStrings values)
		{
			exists = default(RawBool);
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (RawBool* ptr = &exists)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, listIndex, propertyId, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				values = new LocalizedStrings(zero);
			}
			else
			{
				values = null;
			}
			result.CheckError();
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x00012AE4 File Offset: 0x00010CE4
		public unsafe void GetPropertyOccurrenceCount(ref FontProperty ropertyRef, out int ropertyOccurrenceCountRef)
		{
			FontProperty.__Native _Native = default(FontProperty.__Native);
			ropertyRef.__MarshalTo(ref _Native);
			Result result;
			fixed (int* ptr = &ropertyOccurrenceCountRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &_Native, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			ropertyRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00012B40 File Offset: 0x00010D40
		public unsafe void GetMatchingFonts(string familyName, FontWeight fontWeight, FontStretch fontStretch, FontStyle fontStyle, out FontSet filteredSet)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (string text = familyName)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, ptr, fontWeight, fontStretch, fontStyle, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
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

		// Token: 0x060005CD RID: 1485 RVA: 0x00012BB4 File Offset: 0x00010DB4
		public unsafe void GetMatchingFonts(FontProperty[] ropertiesRef, int propertyCount, out FontSet filteredSet)
		{
			FontProperty.__Native[] array = new FontProperty.__Native[ropertiesRef.Length];
			IntPtr zero = IntPtr.Zero;
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
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr, propertyCount, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			array2 = null;
			if (zero != IntPtr.Zero)
			{
				filteredSet = new FontSet(zero);
			}
			else
			{
				filteredSet = null;
			}
			for (int j = 0; j < ropertiesRef.Length; j++)
			{
				ropertiesRef[j].__MarshalFree(ref array[j]);
			}
			result.CheckError();
		}
	}
}
