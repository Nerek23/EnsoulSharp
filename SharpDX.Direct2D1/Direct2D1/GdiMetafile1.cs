using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000307 RID: 775
	[Guid("2e69f9e8-dd3f-4bf9-95ba-c04f49d788df")]
	public class GdiMetafile1 : GdiMetafile
	{
		// Token: 0x06000DA8 RID: 3496 RVA: 0x00025D83 File Offset: 0x00023F83
		public GdiMetafile1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x00025D8C File Offset: 0x00023F8C
		public new static explicit operator GdiMetafile1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new GdiMetafile1(nativePtr);
			}
			return null;
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000DAA RID: 3498 RVA: 0x00025DA4 File Offset: 0x00023FA4
		public RawRectangleF SourceBounds
		{
			get
			{
				RawRectangleF result;
				this.GetSourceBounds(out result);
				return result;
			}
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x00025DBC File Offset: 0x00023FBC
		public unsafe void GetDpi(out float dpiX, out float dpiY)
		{
			Result result;
			fixed (float* ptr = &dpiY)
			{
				void* ptr2 = (void*)ptr;
				fixed (float* ptr3 = &dpiX)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x00025E08 File Offset: 0x00024008
		internal unsafe void GetSourceBounds(out RawRectangleF bounds)
		{
			bounds = default(RawRectangleF);
			Result result;
			fixed (RawRectangleF* ptr = &bounds)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
