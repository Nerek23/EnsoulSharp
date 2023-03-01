using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000306 RID: 774
	[Guid("2f543dc3-cfc1-4211-864f-cfd91c6f3395")]
	public class GdiMetafile : Resource
	{
		// Token: 0x06000DA3 RID: 3491 RVA: 0x00016258 File Offset: 0x00014458
		public GdiMetafile(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000DA4 RID: 3492 RVA: 0x00025CBF File Offset: 0x00023EBF
		public new static explicit operator GdiMetafile(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new GdiMetafile(nativePtr);
			}
			return null;
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06000DA5 RID: 3493 RVA: 0x00025CD8 File Offset: 0x00023ED8
		public RawRectangleF Bounds
		{
			get
			{
				RawRectangleF result;
				this.GetBounds(out result);
				return result;
			}
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x00025CF0 File Offset: 0x00023EF0
		public unsafe void Stream(GdiMetafileSink sink)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<GdiMetafileSink>(sink);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000DA7 RID: 3495 RVA: 0x00025D3C File Offset: 0x00023F3C
		internal unsafe void GetBounds(out RawRectangleF bounds)
		{
			bounds = default(RawRectangleF);
			Result result;
			fixed (RawRectangleF* ptr = &bounds)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
