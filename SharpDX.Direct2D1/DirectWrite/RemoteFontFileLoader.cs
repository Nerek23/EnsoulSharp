using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200013E RID: 318
	[Guid("68648C83-6EDE-46C0-AB46-20083A887FDE")]
	public class RemoteFontFileLoader : FontFileLoaderNative
	{
		// Token: 0x060005E2 RID: 1506 RVA: 0x0000D137 File Offset: 0x0000B337
		public RemoteFontFileLoader(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x0001310E File Offset: 0x0001130E
		public new static explicit operator RemoteFontFileLoader(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RemoteFontFileLoader(nativePtr);
			}
			return null;
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00013128 File Offset: 0x00011328
		public unsafe void CreateRemoteStreamFromKey(IntPtr fontFileReferenceKey, int fontFileReferenceKeySize, out RemoteFontFileStream fontFileStream)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)fontFileReferenceKey, fontFileReferenceKeySize, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontFileStream = new RemoteFontFileStream(zero);
			}
			else
			{
				fontFileStream = null;
			}
			result.CheckError();
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x0001318C File Offset: 0x0001138C
		public unsafe void GetLocalityFromKey(IntPtr fontFileReferenceKey, int fontFileReferenceKeySize, out Locality locality)
		{
			Result result;
			fixed (Locality* ptr = &locality)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)fontFileReferenceKey, fontFileReferenceKeySize, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x000131D4 File Offset: 0x000113D4
		public unsafe void CreateFontFileReferenceFromUrl(Factory factory, string baseUrl, string fontFileUrl, out FontFile fontFile)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Factory>(factory);
			Result result;
			fixed (string text = fontFileUrl)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				fixed (string text2 = baseUrl)
				{
					char* ptr2 = text2;
					if (ptr2 != null)
					{
						ptr2 += RuntimeHelpers.OffsetToStringData / 2;
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr2, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
				}
			}
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
	}
}
