using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000B5 RID: 181
	[Guid("b2d9f3ec-c9fe-4a11-a2ec-d86208f7c0a2")]
	public class LocalFontFileLoader : FontFileLoaderNative
	{
		// Token: 0x0600039E RID: 926 RVA: 0x0000D088 File Offset: 0x0000B288
		public unsafe string GetFilePath(DataPointer referenceKey)
		{
			if (referenceKey.IsEmpty)
			{
				throw new ArgumentNullException("referenceKey", "DatePointer cannot be null");
			}
			int filePathLengthFromKey = this.GetFilePathLengthFromKey(referenceKey.Pointer, referenceKey.Size);
			char[] array2;
			char[] array = array2 = new char[filePathLengthFromKey + 1];
			void* value;
			if (array == null || array2.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&array2[0]);
			}
			this.GetFilePathFromKey(referenceKey.Pointer, referenceKey.Size, new IntPtr(value), filePathLengthFromKey + 1);
			array2 = null;
			return new string(array, 0, filePathLengthFromKey);
		}

		// Token: 0x0600039F RID: 927 RVA: 0x0000D105 File Offset: 0x0000B305
		public DateTime GetLastWriteTime(DataPointer referenceKey)
		{
			if (referenceKey.IsEmpty)
			{
				throw new ArgumentNullException("referenceKey", "DatePointer cannot be null");
			}
			return DateTime.FromFileTime(this.GetLastWriteTimeFromKey(referenceKey.Pointer, referenceKey.Size));
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x0000D137 File Offset: 0x0000B337
		public LocalFontFileLoader(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x0000D140 File Offset: 0x0000B340
		public new static explicit operator LocalFontFileLoader(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new LocalFontFileLoader(nativePtr);
			}
			return null;
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x0000D158 File Offset: 0x0000B358
		internal unsafe int GetFilePathLengthFromKey(IntPtr fontFileReferenceKey, int fontFileReferenceKeySize)
		{
			int result;
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)fontFileReferenceKey, fontFileReferenceKeySize, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x0000D19C File Offset: 0x0000B39C
		internal unsafe void GetFilePathFromKey(IntPtr fontFileReferenceKey, int fontFileReferenceKeySize, IntPtr filePath, int filePathSize)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, (void*)fontFileReferenceKey, fontFileReferenceKeySize, (void*)filePath, filePathSize, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x0000D1E4 File Offset: 0x0000B3E4
		internal unsafe long GetLastWriteTimeFromKey(IntPtr fontFileReferenceKey, int fontFileReferenceKeySize)
		{
			long result;
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)fontFileReferenceKey, fontFileReferenceKeySize, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}
	}
}
