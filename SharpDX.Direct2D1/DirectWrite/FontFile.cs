using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000090 RID: 144
	[Guid("739d886a-cef5-47dc-8769-1a8b41bebbb0")]
	public class FontFile : ComObject
	{
		// Token: 0x060002F0 RID: 752 RVA: 0x0000BAD0 File Offset: 0x00009CD0
		public FontFile(Factory factory, string filePath) : this(factory, filePath, null)
		{
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0000BAEE File Offset: 0x00009CEE
		public FontFile(Factory factory, string filePath, long? lastWriteTime)
		{
			factory.CreateFontFileReference(filePath, lastWriteTime, this);
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x0000BAFF File Offset: 0x00009CFF
		public FontFile(Factory factory, IntPtr fontFileReferenceKey, int fontFileReferenceKeySize, FontFileLoader fontFileLoader)
		{
			factory.CreateCustomFontFileReference(fontFileReferenceKey, fontFileReferenceKeySize, fontFileLoader, this);
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x0000BB14 File Offset: 0x00009D14
		public FontFileLoader Loader
		{
			get
			{
				if (this.fontLoaderShadow != null)
				{
					return (FontFileLoader)this.fontLoaderShadow.Callback;
				}
				FontFileLoader result;
				this.GetLoader(out result);
				return result;
			}
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000BB44 File Offset: 0x00009D44
		public unsafe DataPointer GetReferenceKey()
		{
			IntPtr pointer;
			int size;
			this.GetReferenceKey(new IntPtr((void*)(&pointer)), out size);
			return new DataPointer(pointer, size);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00002A7F File Offset: 0x00000C7F
		public FontFile(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0000BB68 File Offset: 0x00009D68
		public new static explicit operator FontFile(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontFile(nativePtr);
			}
			return null;
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000BB80 File Offset: 0x00009D80
		internal unsafe void GetReferenceKey(IntPtr fontFileReferenceKey, out int fontFileReferenceKeySize)
		{
			Result result;
			fixed (int* ptr = &fontFileReferenceKeySize)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)fontFileReferenceKey, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0000BBC8 File Offset: 0x00009DC8
		internal unsafe void GetLoader(out FontFileLoader fontFileLoader)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				fontFileLoader = new FontFileLoaderNative(zero);
			}
			else
			{
				fontFileLoader = null;
			}
			result.CheckError();
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0000BC24 File Offset: 0x00009E24
		public unsafe void Analyze(out RawBool isSupportedFontType, out FontFileType fontFileType, out FontFaceType fontFaceType, out int numberOfFaces)
		{
			isSupportedFontType = default(RawBool);
			Result result;
			fixed (int* ptr = &numberOfFaces)
			{
				void* ptr2 = (void*)ptr;
				fixed (FontFaceType* ptr3 = &fontFaceType)
				{
					void* ptr4 = (void*)ptr3;
					fixed (FontFileType* ptr5 = &fontFileType)
					{
						void* ptr6 = (void*)ptr5;
						fixed (RawBool* ptr7 = &isSupportedFontType)
						{
							void* ptr8 = (void*)ptr7;
							result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr8, ptr6, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
						}
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x04000213 RID: 531
		private FontFileLoaderShadow fontLoaderShadow;
	}
}
