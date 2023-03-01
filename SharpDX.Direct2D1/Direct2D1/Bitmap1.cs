using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;
using SharpDX.WIC;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000176 RID: 374
	[Guid("a898a84c-3873-4588-b08b-ebbf978df041")]
	public class Bitmap1 : Bitmap
	{
		// Token: 0x060006BE RID: 1726 RVA: 0x00015730 File Offset: 0x00013930
		public Bitmap1(DeviceContext deviceContext, Size2 size) : this(deviceContext, size, null, 0, new BitmapProperties1(new PixelFormat(Format.Unknown, AlphaMode.Unknown)))
		{
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00015748 File Offset: 0x00013948
		public Bitmap1(DeviceContext deviceContext, Size2 size, BitmapProperties1 bitmapProperties) : this(deviceContext, size, null, 0, bitmapProperties)
		{
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x00015755 File Offset: 0x00013955
		public Bitmap1(DeviceContext deviceContext, Size2 size, DataStream dataStream, int pitch) : this(deviceContext, size, dataStream, pitch, new BitmapProperties1(new PixelFormat(Format.Unknown, AlphaMode.Unknown)))
		{
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x0001576E File Offset: 0x0001396E
		public Bitmap1(DeviceContext deviceContext, Size2 size, DataStream dataStream, int pitch, BitmapProperties1 bitmapProperties) : base(IntPtr.Zero)
		{
			deviceContext.CreateBitmap(size, (dataStream == null) ? IntPtr.Zero : dataStream.PositionPointer, pitch, bitmapProperties, this);
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00015797 File Offset: 0x00013997
		public Bitmap1(DeviceContext deviceContext, Surface surface) : base(IntPtr.Zero)
		{
			deviceContext.CreateBitmapFromDxgiSurface(surface, null, this);
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x000157AD File Offset: 0x000139AD
		public Bitmap1(DeviceContext deviceContext, Surface surface, BitmapProperties1 bitmapProperties) : base(IntPtr.Zero)
		{
			deviceContext.CreateBitmapFromDxgiSurface(surface, bitmapProperties, this);
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x000157C4 File Offset: 0x000139C4
		public static Bitmap1 FromWicBitmap(DeviceContext deviceContext, BitmapSource wicBitmapSource)
		{
			Bitmap1 result;
			deviceContext.CreateBitmapFromWicBitmap(wicBitmapSource, null, out result);
			return result;
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x000157DC File Offset: 0x000139DC
		public static Bitmap1 FromWicBitmap(DeviceContext deviceContext, BitmapSource wicBitmap, BitmapProperties1 bitmapProperties)
		{
			Bitmap1 result;
			deviceContext.CreateBitmapFromWicBitmap(wicBitmap, bitmapProperties, out result);
			return result;
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x000157F4 File Offset: 0x000139F4
		public DataRectangle Map(MapOptions options)
		{
			MappedRectangle mappedRectangle;
			this.Map(options, out mappedRectangle);
			return new DataRectangle(mappedRectangle.Bits, mappedRectangle.Pitch);
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x0001581B File Offset: 0x00013A1B
		public Bitmap1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x00015824 File Offset: 0x00013A24
		public new static explicit operator Bitmap1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Bitmap1(nativePtr);
			}
			return null;
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060006C9 RID: 1737 RVA: 0x0001583C File Offset: 0x00013A3C
		public ColorContext ColorContext
		{
			get
			{
				ColorContext result;
				this.GetColorContext(out result);
				return result;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060006CA RID: 1738 RVA: 0x00015852 File Offset: 0x00013A52
		public BitmapOptions Options
		{
			get
			{
				return this.GetOptions();
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060006CB RID: 1739 RVA: 0x0001585C File Offset: 0x00013A5C
		public Surface Surface
		{
			get
			{
				Surface result;
				this.GetSurface(out result);
				return result;
			}
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x00015874 File Offset: 0x00013A74
		internal unsafe void GetColorContext(out ColorContext colorContext)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				colorContext = new ColorContext(zero);
				return;
			}
			colorContext = null;
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x000158C1 File Offset: 0x00013AC1
		internal unsafe BitmapOptions GetOptions()
		{
			return calli(SharpDX.Direct2D1.BitmapOptions(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x000158E4 File Offset: 0x00013AE4
		internal unsafe void GetSurface(out Surface dxgiSurface)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				dxgiSurface = new Surface(zero);
			}
			else
			{
				dxgiSurface = null;
			}
			result.CheckError();
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x00015940 File Offset: 0x00013B40
		internal unsafe void Map(MapOptions options, out MappedRectangle mappedRect)
		{
			mappedRect = default(MappedRectangle);
			Result result;
			fixed (MappedRectangle* ptr = &mappedRect)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, options, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x0001598C File Offset: 0x00013B8C
		public unsafe void Unmap()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
