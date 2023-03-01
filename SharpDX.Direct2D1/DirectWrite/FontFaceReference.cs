using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000132 RID: 306
	[Guid("5E7FA7CA-DDE3-424C-89F0-9FCD6FED58CD")]
	public class FontFaceReference : ComObject
	{
		// Token: 0x0600058B RID: 1419 RVA: 0x00002A7F File Offset: 0x00000C7F
		public FontFaceReference(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00011E20 File Offset: 0x00010020
		public new static explicit operator FontFaceReference(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontFaceReference(nativePtr);
			}
			return null;
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600058D RID: 1421 RVA: 0x00011E37 File Offset: 0x00010037
		public int FontFaceIndex
		{
			get
			{
				return this.GetFontFaceIndex();
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600058E RID: 1422 RVA: 0x00011E3F File Offset: 0x0001003F
		public FontSimulations Simulations
		{
			get
			{
				return this.GetSimulations();
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x00011E48 File Offset: 0x00010048
		public FontFile FontFile
		{
			get
			{
				FontFile result;
				this.GetFontFile(out result);
				return result;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x00011E5E File Offset: 0x0001005E
		public long LocalFileSize
		{
			get
			{
				return this.GetLocalFileSize();
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000591 RID: 1425 RVA: 0x00011E66 File Offset: 0x00010066
		public long FileSize
		{
			get
			{
				return this.GetFileSize();
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x00011E70 File Offset: 0x00010070
		public long FileTime
		{
			get
			{
				long result;
				this.GetFileTime(out result);
				return result;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x00011E86 File Offset: 0x00010086
		public Locality Locality
		{
			get
			{
				return this.GetLocality();
			}
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x00011E90 File Offset: 0x00010090
		public unsafe void CreateFontFace(out FontFace3 fontFace)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
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

		// Token: 0x06000595 RID: 1429 RVA: 0x00011EEC File Offset: 0x000100EC
		public unsafe void CreateFontFaceWithSimulations(FontSimulations fontFaceSimulationFlags, out FontFace3 fontFace)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, fontFaceSimulationFlags, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
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

		// Token: 0x06000596 RID: 1430 RVA: 0x00011F48 File Offset: 0x00010148
		public unsafe RawBool Equals(FontFaceReference fontFaceReference)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<FontFaceReference>(fontFaceReference);
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x00011F85 File Offset: 0x00010185
		internal unsafe int GetFontFaceIndex()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x00011FA4 File Offset: 0x000101A4
		internal unsafe FontSimulations GetSimulations()
		{
			return calli(SharpDX.DirectWrite.FontSimulations(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x00011FC4 File Offset: 0x000101C4
		internal unsafe void GetFontFile(out FontFile fontFile)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
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

		// Token: 0x0600059A RID: 1434 RVA: 0x0001201E File Offset: 0x0001021E
		internal unsafe long GetLocalFileSize()
		{
			return calli(System.Int64(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x0001203E File Offset: 0x0001023E
		internal unsafe long GetFileSize()
		{
			return calli(System.Int64(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x00012060 File Offset: 0x00010260
		internal unsafe void GetFileTime(out long lastWriteTime)
		{
			Result result;
			fixed (long* ptr = &lastWriteTime)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x000120A1 File Offset: 0x000102A1
		internal unsafe Locality GetLocality()
		{
			return calli(SharpDX.DirectWrite.Locality(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x000120C4 File Offset: 0x000102C4
		public unsafe void EnqueueFontDownloadRequest()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x000120FC File Offset: 0x000102FC
		public unsafe void EnqueueCharacterDownloadRequest(string characters, int characterCount)
		{
			Result result;
			fixed (string text = characters)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, characterCount, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x00012148 File Offset: 0x00010348
		public unsafe void EnqueueGlyphDownloadRequest(short[] glyphIndices, int glyphCount)
		{
			Result result;
			fixed (short[] array = glyphIndices)
			{
				void* ptr;
				if (glyphIndices == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, glyphCount, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x0001219C File Offset: 0x0001039C
		public unsafe void EnqueueFileFragmentDownloadRequest(long fileOffset, long fragmentSize)
		{
			calli(System.Int32(System.Void*,System.Int64,System.Int64), this._nativePointer, fileOffset, fragmentSize, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
