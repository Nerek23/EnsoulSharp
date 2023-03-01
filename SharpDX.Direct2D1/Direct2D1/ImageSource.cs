using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001F5 RID: 501
	[Guid("c9b664e5-74a1-4378-9ac2-eefc37a3f4d8")]
	public class ImageSource : Image
	{
		// Token: 0x06000AAE RID: 2734 RVA: 0x0001EAF3 File Offset: 0x0001CCF3
		public ImageSource(DeviceContext2 context2, Surface[] surfaces, int surfaceCount, ColorSpaceType colorSpace, ImageSourceFromDxgiOptions options) : this(IntPtr.Zero)
		{
			context2.CreateImageSourceFromDxgi(surfaces, surfaceCount, colorSpace, options, this);
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x000154AE File Offset: 0x000136AE
		public ImageSource(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x0001EB0D File Offset: 0x0001CD0D
		public new static explicit operator ImageSource(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ImageSource(nativePtr);
			}
			return null;
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x0001EB24 File Offset: 0x0001CD24
		public unsafe void OfferResources()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x0001EB5C File Offset: 0x0001CD5C
		public unsafe void TryReclaimResources(out RawBool resourcesDiscarded)
		{
			resourcesDiscarded = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &resourcesDiscarded)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
