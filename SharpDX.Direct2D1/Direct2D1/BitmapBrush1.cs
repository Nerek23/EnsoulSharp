using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000178 RID: 376
	[Guid("41343a53-e41a-49a2-91cd-21793bbb62e5")]
	public class BitmapBrush1 : BitmapBrush
	{
		// Token: 0x060006E7 RID: 1767 RVA: 0x00015C14 File Offset: 0x00013E14
		public BitmapBrush1(DeviceContext deviceContext, Bitmap1 bitmap) : this(deviceContext, bitmap, null, null)
		{
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00015C3C File Offset: 0x00013E3C
		public BitmapBrush1(DeviceContext deviceContext, Bitmap1 bitmap, BitmapBrushProperties1 bitmapBrushProperties) : this(deviceContext, bitmap, new BitmapBrushProperties1?(bitmapBrushProperties), null)
		{
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x00015C60 File Offset: 0x00013E60
		public BitmapBrush1(DeviceContext deviceContext, Bitmap1 bitmap, BrushProperties brushProperties) : this(deviceContext, bitmap, null, new BrushProperties?(brushProperties))
		{
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x00015C84 File Offset: 0x00013E84
		public BitmapBrush1(DeviceContext deviceContext, Bitmap1 bitmap, BitmapBrushProperties1? bitmapBrushProperties, BrushProperties? brushProperties) : base(IntPtr.Zero)
		{
			deviceContext.CreateBitmapBrush(bitmap, bitmapBrushProperties, brushProperties, this);
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x00015C9C File Offset: 0x00013E9C
		public BitmapBrush1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00015CA5 File Offset: 0x00013EA5
		public new static explicit operator BitmapBrush1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapBrush1(nativePtr);
			}
			return null;
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060006ED RID: 1773 RVA: 0x00015CBC File Offset: 0x00013EBC
		// (set) Token: 0x060006EE RID: 1774 RVA: 0x00015CC4 File Offset: 0x00013EC4
		public InterpolationMode InterpolationMode1
		{
			get
			{
				return this.GetInterpolationMode1();
			}
			set
			{
				this.SetInterpolationMode1(value);
			}
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x00015CCD File Offset: 0x00013ECD
		internal unsafe void SetInterpolationMode1(InterpolationMode interpolationMode)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, interpolationMode, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x00015CEE File Offset: 0x00013EEE
		internal unsafe InterpolationMode GetInterpolationMode1()
		{
			return calli(SharpDX.Direct2D1.InterpolationMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
		}
	}
}
