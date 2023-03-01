using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Win32;

namespace SharpDX.WIC
{
	// Token: 0x02000025 RID: 37
	[Guid("A721791A-0DEF-4d06-BD91-2118BF1DB10B")]
	public class MetadataQueryWriter : MetadataQueryReader
	{
		// Token: 0x06000186 RID: 390 RVA: 0x0000663C File Offset: 0x0000483C
		public MetadataQueryWriter(ImagingFactory factory, Guid guidMetadataFormat) : base(IntPtr.Zero)
		{
			factory.CreateQueryWriter(guidMetadataFormat, null, this);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00006665 File Offset: 0x00004865
		public MetadataQueryWriter(ImagingFactory factory, Guid guidMetadataFormat, Guid guidVendorRef) : base(IntPtr.Zero)
		{
			factory.CreateQueryWriter(guidMetadataFormat, new Guid?(guidVendorRef), this);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00006680 File Offset: 0x00004880
		public MetadataQueryWriter(ImagingFactory factory, MetadataQueryReader metadataQueryReader) : base(IntPtr.Zero)
		{
			factory.CreateQueryWriterFromReader(metadataQueryReader, null, this);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000066A9 File Offset: 0x000048A9
		public MetadataQueryWriter(ImagingFactory factory, MetadataQueryReader metadataQueryReader, Guid guidVendorRef) : base(IntPtr.Zero)
		{
			factory.CreateQueryWriterFromReader(metadataQueryReader, new Guid?(guidVendorRef), this);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x000066C4 File Offset: 0x000048C4
		public unsafe void SetMetadataByName(string name, object value)
		{
			byte* ptr = stackalloc byte[(UIntPtr)512];
			Variant* ptr2 = (Variant*)ptr;
			ptr2->Value = value;
			this.SetMetadataByName(name, (IntPtr)((void*)ptr));
		}

		// Token: 0x0600018B RID: 395 RVA: 0x000066F0 File Offset: 0x000048F0
		public MetadataQueryWriter(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600018C RID: 396 RVA: 0x000066F9 File Offset: 0x000048F9
		public new static explicit operator MetadataQueryWriter(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new MetadataQueryWriter(nativePtr);
			}
			return null;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00006710 File Offset: 0x00004910
		internal unsafe void SetMetadataByName(string name, IntPtr varValueRef)
		{
			Result result;
			fixed (string text = name)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr, (void*)varValueRef, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00006760 File Offset: 0x00004960
		public unsafe void RemoveMetadataByName(string name)
		{
			Result result;
			fixed (string text = name)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
