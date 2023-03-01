using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x0200000A RID: 10
	[Guid("3B16811B-6A43-4ec9-A813-3D930C13B940")]
	public class BitmapFrameDecode : BitmapSource
	{
		// Token: 0x06000093 RID: 147 RVA: 0x000038FF File Offset: 0x00001AFF
		public Result TryGetColorContexts(ImagingFactory imagingFactory, out ColorContext[] colorContexts)
		{
			return ColorContextsHelper.TryGetColorContexts(new ColorContextsProvider(this.GetColorContexts), imagingFactory, out colorContexts);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003914 File Offset: 0x00001B14
		public ColorContext[] TryGetColorContexts(ImagingFactory imagingFactory)
		{
			return ColorContextsHelper.TryGetColorContexts(new ColorContextsProvider(this.GetColorContexts), imagingFactory);
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00002A77 File Offset: 0x00000C77
		[Obsolete("Use TryGetColorContexts instead")]
		public ColorContext[] ColorContexts
		{
			get
			{
				return new ColorContext[0];
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00002145 File Offset: 0x00000345
		public BitmapFrameDecode(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003928 File Offset: 0x00001B28
		public new static explicit operator BitmapFrameDecode(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapFrameDecode(nativePtr);
			}
			return null;
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00003940 File Offset: 0x00001B40
		public MetadataQueryReader MetadataQueryReader
		{
			get
			{
				MetadataQueryReader result;
				this.GetMetadataQueryReader(out result);
				return result;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00003958 File Offset: 0x00001B58
		public BitmapSource Thumbnail
		{
			get
			{
				BitmapSource result;
				this.GetThumbnail(out result);
				return result;
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003970 File Offset: 0x00001B70
		internal unsafe void GetMetadataQueryReader(out MetadataQueryReader metadataQueryReaderOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				metadataQueryReaderOut = new MetadataQueryReader(zero);
			}
			else
			{
				metadataQueryReaderOut = null;
			}
			result.CheckError();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000039CC File Offset: 0x00001BCC
		internal unsafe Result GetColorContexts(int count, ColorContext[] colorContextsOut, out int actualCountRef)
		{
			IntPtr* ptr = null;
			if (colorContextsOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)colorContextsOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			if (colorContextsOut != null)
			{
				for (int i = 0; i < colorContextsOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<ColorContext>(colorContextsOut[i]);
				}
			}
			Result result;
			fixed (int* ptr2 = &actualCountRef)
			{
				void* ptr3 = (void*)ptr2;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, count, ptr, ptr3, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			return result;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003A40 File Offset: 0x00001C40
		internal unsafe void GetThumbnail(out BitmapSource thumbnailOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				thumbnailOut = new BitmapSource(zero);
			}
			else
			{
				thumbnailOut = null;
			}
			result.CheckError();
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00003A9C File Offset: 0x00001C9C
		internal unsafe Result GetColorContexts(int count, ComArray<ColorContext> colorContextsOut, out int actualCountRef)
		{
			Result result;
			fixed (int* ptr = &actualCountRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, count, (void*)((colorContextsOut != null) ? colorContextsOut.NativePointer : IntPtr.Zero), ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			return result;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003AEB File Offset: 0x00001CEB
		private unsafe Result GetColorContexts(int count, IntPtr colorContextsOut, IntPtr actualCountRef)
		{
			return calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, count, (void*)colorContextsOut, (void*)actualCountRef, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}
	}
}
