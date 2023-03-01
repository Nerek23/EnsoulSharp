using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200013D RID: 317
	[Guid("DC102F47-A12D-4B1C-822D-9E117E33043F")]
	public class InMemoryFontFileLoader : FontFileLoaderNative
	{
		// Token: 0x060005DD RID: 1501 RVA: 0x0000D137 File Offset: 0x0000B337
		public InMemoryFontFileLoader(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x00013064 File Offset: 0x00011264
		public new static explicit operator InMemoryFontFileLoader(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new InMemoryFontFileLoader(nativePtr);
			}
			return null;
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060005DF RID: 1503 RVA: 0x0001307B File Offset: 0x0001127B
		public int FileCount
		{
			get
			{
				return this.GetFileCount();
			}
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x00013084 File Offset: 0x00011284
		public unsafe void CreateInMemoryFontFileReference(Factory factory, IntPtr fontData, int fontDataSize, IUnknown ownerObject, out FontFile fontFile)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Factory>(factory);
			value2 = CppObject.ToCallbackPtr<IUnknown>(ownerObject);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)fontData, fontDataSize, (void*)value2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontFile = new FontFile(zero);
			}
			else
			{
				fontFile = null;
			}
			result.CheckError();
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0000B67C File Offset: 0x0000987C
		internal unsafe int GetFileCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}
	}
}
