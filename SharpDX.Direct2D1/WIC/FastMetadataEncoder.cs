using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x02000018 RID: 24
	[Guid("B84E2C09-78C9-4AC4-8BD3-524AE1663A2F")]
	public class FastMetadataEncoder : ComObject
	{
		// Token: 0x06000121 RID: 289 RVA: 0x0000516D File Offset: 0x0000336D
		public FastMetadataEncoder(ImagingFactory factory, BitmapDecoder decoder) : base(IntPtr.Zero)
		{
			factory.CreateFastMetadataEncoderFromDecoder(decoder, this);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00005182 File Offset: 0x00003382
		public FastMetadataEncoder(ImagingFactory factory, BitmapFrameDecode frameDecoder) : base(IntPtr.Zero)
		{
			factory.CreateFastMetadataEncoderFromFrameDecode(frameDecoder, this);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00002A7F File Offset: 0x00000C7F
		public FastMetadataEncoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00005197 File Offset: 0x00003397
		public new static explicit operator FastMetadataEncoder(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FastMetadataEncoder(nativePtr);
			}
			return null;
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000125 RID: 293 RVA: 0x000051B0 File Offset: 0x000033B0
		public MetadataQueryWriter MetadataQueryWriter
		{
			get
			{
				MetadataQueryWriter result;
				this.GetMetadataQueryWriter(out result);
				return result;
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x000051C8 File Offset: 0x000033C8
		public unsafe void Commit()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00005200 File Offset: 0x00003400
		internal unsafe void GetMetadataQueryWriter(out MetadataQueryWriter metadataQueryWriterOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				metadataQueryWriterOut = new MetadataQueryWriter(zero);
			}
			else
			{
				metadataQueryWriterOut = null;
			}
			result.CheckError();
		}
	}
}
