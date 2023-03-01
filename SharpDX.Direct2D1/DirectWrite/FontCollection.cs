using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000089 RID: 137
	[Guid("a84cee02-3eea-4eee-a827-87c1a02a0fcc")]
	public class FontCollection : ComObject
	{
		// Token: 0x060002BD RID: 701 RVA: 0x0000B1EC File Offset: 0x000093EC
		public FontCollection(Factory factory, FontCollectionLoader collectionLoader, DataPointer collectionKey)
		{
			factory.CreateCustomFontCollection(collectionLoader, collectionKey.Pointer, collectionKey.Size, this);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00002A7F File Offset: 0x00000C7F
		public FontCollection(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000B208 File Offset: 0x00009408
		public new static explicit operator FontCollection(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontCollection(nativePtr);
			}
			return null;
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x0000B21F File Offset: 0x0000941F
		public int FontFamilyCount
		{
			get
			{
				return this.GetFontFamilyCount();
			}
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000B227 File Offset: 0x00009427
		internal unsafe int GetFontFamilyCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000B248 File Offset: 0x00009448
		public unsafe FontFamily GetFontFamily(int index)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			FontFamily result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new FontFamily(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000B2A4 File Offset: 0x000094A4
		public unsafe RawBool FindFamilyName(string familyName, out int index)
		{
			RawBool result2;
			Result result;
			fixed (int* ptr = &index)
			{
				void* ptr2 = (void*)ptr;
				fixed (string text = familyName)
				{
					char* ptr3 = text;
					if (ptr3 != null)
					{
						ptr3 += RuntimeHelpers.OffsetToStringData / 2;
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr3, ptr2, &result2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000B304 File Offset: 0x00009504
		public unsafe Font GetFontFromFontFace(FontFace fontFace)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFace>(fontFace);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
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
