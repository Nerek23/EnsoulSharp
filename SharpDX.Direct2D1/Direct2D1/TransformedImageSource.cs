using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200023C RID: 572
	[Guid("7f1f79e5-2796-416c-8f55-700f911445e5")]
	public class TransformedImageSource : Image
	{
		// Token: 0x06000D37 RID: 3383 RVA: 0x000248A3 File Offset: 0x00022AA3
		public TransformedImageSource(DeviceContext2 context2, ImageSource imageSource, ref TransformedImageSourceProperties ropertiesRef) : this(IntPtr.Zero)
		{
			context2.CreateTransformedImageSource(imageSource, ref ropertiesRef, this);
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x000154AE File Offset: 0x000136AE
		public TransformedImageSource(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000D39 RID: 3385 RVA: 0x000248B9 File Offset: 0x00022AB9
		public new static explicit operator TransformedImageSource(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TransformedImageSource(nativePtr);
			}
			return null;
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000D3A RID: 3386 RVA: 0x000248D0 File Offset: 0x00022AD0
		public ImageSource Source
		{
			get
			{
				ImageSource result;
				this.GetSource(out result);
				return result;
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000D3B RID: 3387 RVA: 0x000248E8 File Offset: 0x00022AE8
		public TransformedImageSourceProperties Properties
		{
			get
			{
				TransformedImageSourceProperties result;
				this.GetProperties(out result);
				return result;
			}
		}

		// Token: 0x06000D3C RID: 3388 RVA: 0x00024900 File Offset: 0x00022B00
		internal unsafe void GetSource(out ImageSource imageSource)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				imageSource = new ImageSource(zero);
				return;
			}
			imageSource = null;
		}

		// Token: 0x06000D3D RID: 3389 RVA: 0x0002494C File Offset: 0x00022B4C
		internal unsafe void GetProperties(out TransformedImageSourceProperties ropertiesRef)
		{
			ropertiesRef = default(TransformedImageSourceProperties);
			fixed (TransformedImageSourceProperties* ptr = &ropertiesRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
