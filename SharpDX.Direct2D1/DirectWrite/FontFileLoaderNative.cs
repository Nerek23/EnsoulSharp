using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000097 RID: 151
	[Guid("727cad4e-d6af-4c9e-8a08-d695b11caa49")]
	public class FontFileLoaderNative : ComObject, FontFileLoader, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x0600030C RID: 780 RVA: 0x0000BD9C File Offset: 0x00009F9C
		public FontFileStream CreateStreamFromKey(DataPointer fontFileReferenceKey)
		{
			FontFileStream result;
			this.CreateStreamFromKey_(fontFileReferenceKey.Pointer, fontFileReferenceKey.Size, out result);
			return result;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00002A7F File Offset: 0x00000C7F
		public FontFileLoaderNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0000BDBE File Offset: 0x00009FBE
		public new static explicit operator FontFileLoaderNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontFileLoaderNative(nativePtr);
			}
			return null;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0000BDD8 File Offset: 0x00009FD8
		internal unsafe void CreateStreamFromKey_(IntPtr fontFileReferenceKey, int fontFileReferenceKeySize, out FontFileStream fontFileStream)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)fontFileReferenceKey, fontFileReferenceKeySize, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontFileStream = new FontFileStreamNative(zero);
			}
			else
			{
				fontFileStream = null;
			}
			result.CheckError();
		}
	}
}
