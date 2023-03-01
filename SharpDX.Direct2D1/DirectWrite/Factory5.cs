using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000126 RID: 294
	[Guid("958DB99A-BE2A-4F09-AF7D-65189803D1D3")]
	public class Factory5 : Factory4
	{
		// Token: 0x0600050F RID: 1295 RVA: 0x000107DE File Offset: 0x0000E9DE
		public Factory5(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x000107E7 File Offset: 0x0000E9E7
		public new static explicit operator Factory5(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory5(nativePtr);
			}
			return null;
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x00010800 File Offset: 0x0000EA00
		public unsafe void CreateFontSetBuilder(out FontSetBuilder1 fontSetBuilder)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)43 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontSetBuilder = new FontSetBuilder1(zero);
			}
			else
			{
				fontSetBuilder = null;
			}
			result.CheckError();
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0001085C File Offset: 0x0000EA5C
		public unsafe void CreateInMemoryFontFileLoader(out InMemoryFontFileLoader newLoader)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)44 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				newLoader = new InMemoryFontFileLoader(zero);
			}
			else
			{
				newLoader = null;
			}
			result.CheckError();
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x000108B8 File Offset: 0x0000EAB8
		public unsafe void CreateHttpFontFileLoader(string referrerUrl, string extraHeaders, out RemoteFontFileLoader newLoader)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (string text = extraHeaders)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				fixed (string text2 = referrerUrl)
				{
					char* ptr2 = text2;
					if (ptr2 != null)
					{
						ptr2 += RuntimeHelpers.OffsetToStringData / 2;
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)45 * (IntPtr)sizeof(void*)));
				}
			}
			if (zero != IntPtr.Zero)
			{
				newLoader = new RemoteFontFileLoader(zero);
			}
			else
			{
				newLoader = null;
			}
			result.CheckError();
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00010941 File Offset: 0x0000EB41
		public unsafe ContainerType AnalyzeContainerType(IntPtr fileData, int fileDataSize)
		{
			return calli(SharpDX.DirectWrite.ContainerType(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)fileData, fileDataSize, *(*(IntPtr*)this._nativePointer + (IntPtr)46 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x00010968 File Offset: 0x0000EB68
		public unsafe void UnpackFontFile(ContainerType containerType, IntPtr fileData, int fileDataSize, out FontFileStream unpackedFontStream)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, containerType, (void*)fileData, fileDataSize, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)47 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				unpackedFontStream = new FontFileStreamNative(zero);
			}
			else
			{
				unpackedFontStream = null;
			}
			result.CheckError();
		}
	}
}
