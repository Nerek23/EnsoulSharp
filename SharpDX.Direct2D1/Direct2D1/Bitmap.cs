using System;
using System.IO;
using System.Runtime.InteropServices;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using SharpDX.WIC;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000175 RID: 373
	[Guid("a2296057-ea42-4099-983b-539fb6505426")]
	public class Bitmap : Image
	{
		// Token: 0x06000696 RID: 1686 RVA: 0x00015096 File Offset: 0x00013296
		public Bitmap(RenderTarget renderTarget, Size2 size) : this(renderTarget, size, DataPointer.Zero, 0, new BitmapProperties(new PixelFormat(Format.Unknown, AlphaMode.Unknown)))
		{
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x000150B2 File Offset: 0x000132B2
		public Bitmap(RenderTarget renderTarget, Size2 size, BitmapProperties bitmapProperties) : this(renderTarget, size, DataPointer.Zero, 0, bitmapProperties)
		{
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x000150C3 File Offset: 0x000132C3
		public Bitmap(RenderTarget renderTarget, Size2 size, DataPointer dataPointer, int pitch) : this(renderTarget, size, dataPointer, pitch, new BitmapProperties(new PixelFormat(Format.Unknown, AlphaMode.Unknown)))
		{
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x000150DC File Offset: 0x000132DC
		public Bitmap(RenderTarget renderTarget, Size2 size, DataPointer dataPointer, int pitch, BitmapProperties bitmapProperties) : base(IntPtr.Zero)
		{
			renderTarget.CreateBitmap(size, (dataPointer == DataPointer.Zero) ? IntPtr.Zero : dataPointer.Pointer, pitch, bitmapProperties, this);
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x00015110 File Offset: 0x00013310
		public Bitmap(RenderTarget renderTarget, Bitmap bitmap) : this(renderTarget, bitmap, null)
		{
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x0001512E File Offset: 0x0001332E
		public Bitmap(RenderTarget renderTarget, Bitmap bitmap, BitmapProperties? bitmapProperties) : base(IntPtr.Zero)
		{
			renderTarget.CreateSharedBitmap(Utilities.GetGuidFromType(typeof(Bitmap)), bitmap.NativePointer, bitmapProperties, this);
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00015158 File Offset: 0x00013358
		public Bitmap(RenderTarget renderTarget, Surface surface) : this(renderTarget, surface, null)
		{
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x00015176 File Offset: 0x00013376
		public Bitmap(RenderTarget renderTarget, Surface surface, BitmapProperties? bitmapProperties) : base(IntPtr.Zero)
		{
			renderTarget.CreateSharedBitmap(Utilities.GetGuidFromType(typeof(Surface)), surface.NativePointer, bitmapProperties, this);
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x000151A0 File Offset: 0x000133A0
		public Bitmap(RenderTarget renderTarget, BitmapLock bitmapLock) : this(renderTarget, bitmapLock, null)
		{
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x000151BE File Offset: 0x000133BE
		public Bitmap(RenderTarget renderTarget, BitmapLock bitmapLock, BitmapProperties? bitmapProperties) : base(IntPtr.Zero)
		{
			renderTarget.CreateSharedBitmap(Utilities.GetGuidFromType(typeof(BitmapLock)), bitmapLock.NativePointer, bitmapProperties, this);
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x000151E8 File Offset: 0x000133E8
		public unsafe static Bitmap New<T>(RenderTarget renderTarget, Size2 size, T[] pixelDatas, BitmapProperties bitmapProperties) where T : struct
		{
			int num = pixelDatas.Length * Utilities.SizeOf<T>();
			int num2 = size.Width * size.Height * bitmapProperties.PixelFormat.Format.SizeOfInBytes();
			if (num != num2)
			{
				throw new ArgumentException("Invalid size of pixelDatas. Must be equal to sizeof(T) == sizeof(PixelFormat.Format) and  Width * Height elements");
			}
			fixed (T* value = &pixelDatas[0])
			{
				return new Bitmap(renderTarget, size, new DataPointer((IntPtr)((void*)value), num), size.Width * bitmapProperties.PixelFormat.Format.SizeOfInBytes(), bitmapProperties);
			}
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x00015260 File Offset: 0x00013460
		public static Bitmap FromWicBitmap(RenderTarget renderTarget, BitmapSource wicBitmapSource)
		{
			Bitmap result;
			renderTarget.CreateBitmapFromWicBitmap(wicBitmapSource, null, out result);
			return result;
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x00015280 File Offset: 0x00013480
		public static Bitmap FromWicBitmap(RenderTarget renderTarget, BitmapSource wicBitmap, BitmapProperties bitmapProperties)
		{
			Bitmap result;
			renderTarget.CreateBitmapFromWicBitmap(wicBitmap, new BitmapProperties?(bitmapProperties), out result);
			return result;
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x000152A0 File Offset: 0x000134A0
		public void CopyFromBitmap(Bitmap sourceBitmap)
		{
			this.CopyFromBitmap(null, sourceBitmap, null);
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x000152C8 File Offset: 0x000134C8
		public void CopyFromBitmap(Bitmap sourceBitmap, RawPoint destinationPoint)
		{
			this.CopyFromBitmap(new RawPoint?(destinationPoint), sourceBitmap, null);
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x000152EB File Offset: 0x000134EB
		public void CopyFromBitmap(Bitmap sourceBitmap, RawPoint destinationPoint, RawRectangle sourceArea)
		{
			this.CopyFromBitmap(new RawPoint?(destinationPoint), sourceBitmap, new RawRectangle?(sourceArea));
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00015300 File Offset: 0x00013500
		public void CopyFromMemory(IntPtr pointer, int pitch)
		{
			this.CopyFromMemory(null, pointer, pitch);
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00015320 File Offset: 0x00013520
		public unsafe void CopyFromMemory(byte[] memory, int pitch)
		{
			fixed (byte* ptr = &memory[0])
			{
				void* value = (void*)ptr;
				this.CopyFromMemory(null, new IntPtr(value), pitch);
			}
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x00015354 File Offset: 0x00013554
		public unsafe void CopyFromMemory<T>(T[] memory, int pitch = 0) where T : struct
		{
			if (pitch == 0)
			{
				pitch = (int)(this.Size.Width * (float)Utilities.SizeOf<T>() / this.DotsPerInch.Width);
			}
			RawRectangle? dstRect = null;
			fixed (T* value = &memory[0])
			{
				this.CopyFromMemory(dstRect, (IntPtr)((void*)value), pitch);
			}
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x000153A3 File Offset: 0x000135A3
		public void CopyFromMemory(IntPtr pointer, int pitch, RawRectangle destinationArea)
		{
			this.CopyFromMemory(new RawRectangle?(destinationArea), pointer, pitch);
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x000153B4 File Offset: 0x000135B4
		public unsafe void CopyFromMemory(byte[] memory, int pitch, RawRectangle destinationArea)
		{
			fixed (byte* ptr = &memory[0])
			{
				void* value = (void*)ptr;
				this.CopyFromMemory(new RawRectangle?(destinationArea), new IntPtr(value), pitch);
			}
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x000153E4 File Offset: 0x000135E4
		public unsafe void CopyFromMemory<T>(T[] memory, int pitch, RawRectangle destinationArea) where T : struct
		{
			RawRectangle? dstRect = new RawRectangle?(destinationArea);
			fixed (T* value = &memory[0])
			{
				this.CopyFromMemory(dstRect, (IntPtr)((void*)value), pitch);
			}
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x0001540C File Offset: 0x0001360C
		public void CopyFromRenderTarget(RenderTarget renderTarget)
		{
			this.CopyFromRenderTarget(null, renderTarget, null);
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x00015434 File Offset: 0x00013634
		public void CopyFromRenderTarget(RenderTarget renderTarget, RawPoint destinationPoint)
		{
			this.CopyFromRenderTarget(new RawPoint?(destinationPoint), renderTarget, null);
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x00015457 File Offset: 0x00013657
		public void CopyFromRenderTarget(RenderTarget renderTarget, RawPoint destinationPoint, RawRectangle sourceArea)
		{
			this.CopyFromRenderTarget(new RawPoint?(destinationPoint), renderTarget, new RawRectangle?(sourceArea));
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x0001546C File Offset: 0x0001366C
		public void CopyFromStream(Stream stream, int pitch, int length)
		{
			this.CopyFromMemory(Utilities.ReadStream(stream, ref length), pitch);
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x0001547D File Offset: 0x0001367D
		public void CopyFromStream(Stream stream, int pitch, int length, RawRectangle destinationArea)
		{
			this.CopyFromMemory(Utilities.ReadStream(stream, ref length), pitch, destinationArea);
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060006B1 RID: 1713 RVA: 0x00015490 File Offset: 0x00013690
		public Size2F DotsPerInch
		{
			get
			{
				float width;
				float height;
				this.GetDpi(out width, out height);
				return new Size2F(width, height);
			}
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x000154AE File Offset: 0x000136AE
		public Bitmap(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x000154B7 File Offset: 0x000136B7
		public new static explicit operator Bitmap(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Bitmap(nativePtr);
			}
			return null;
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060006B4 RID: 1716 RVA: 0x000154CE File Offset: 0x000136CE
		public Size2F Size
		{
			get
			{
				return this.GetSize();
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060006B5 RID: 1717 RVA: 0x000154D6 File Offset: 0x000136D6
		public Size2 PixelSize
		{
			get
			{
				return this.GetPixelSize();
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060006B6 RID: 1718 RVA: 0x000154DE File Offset: 0x000136DE
		public PixelFormat PixelFormat
		{
			get
			{
				return this.GetPixelFormat();
			}
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x000154E8 File Offset: 0x000136E8
		internal unsafe Size2F GetSize()
		{
			Size2F result;
			object obj = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			return result;
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x00015518 File Offset: 0x00013718
		internal unsafe Size2 GetPixelSize()
		{
			Size2 result;
			object obj = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			return result;
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00015548 File Offset: 0x00013748
		internal unsafe PixelFormat GetPixelFormat()
		{
			PixelFormat result;
			object obj = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			return result;
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x00015578 File Offset: 0x00013778
		internal unsafe void GetDpi(out float dpiX, out float dpiY)
		{
			fixed (float* ptr = &dpiY)
			{
				void* ptr2 = (void*)ptr;
				fixed (float* ptr3 = &dpiX)
				{
					void* ptr4 = (void*)ptr3;
					calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x000155B4 File Offset: 0x000137B4
		internal unsafe void CopyFromBitmap(RawPoint? destPoint, Bitmap bitmap, RawRectangle? srcRect)
		{
			IntPtr value = IntPtr.Zero;
			RawPoint value2;
			if (destPoint != null)
			{
				value2 = destPoint.Value;
			}
			value = CppObject.ToCallbackPtr<Bitmap>(bitmap);
			RawRectangle value3;
			if (srcRect != null)
			{
				value3 = srcRect.Value;
			}
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (destPoint == null) ? null : (&value2), (void*)value, (srcRect == null) ? null : (&value3), *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x00015640 File Offset: 0x00013840
		internal unsafe void CopyFromRenderTarget(RawPoint? destPoint, RenderTarget renderTarget, RawRectangle? srcRect)
		{
			IntPtr value = IntPtr.Zero;
			RawPoint value2;
			if (destPoint != null)
			{
				value2 = destPoint.Value;
			}
			value = CppObject.ToCallbackPtr<RenderTarget>(renderTarget);
			RawRectangle value3;
			if (srcRect != null)
			{
				value3 = srcRect.Value;
			}
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (destPoint == null) ? null : (&value2), (void*)value, (srcRect == null) ? null : (&value3), *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x000156D0 File Offset: 0x000138D0
		internal unsafe void CopyFromMemory(RawRectangle? dstRect, IntPtr srcData, int pitch)
		{
			RawRectangle value;
			if (dstRect != null)
			{
				value = dstRect.Value;
			}
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (dstRect == null) ? null : (&value), (void*)srcData, pitch, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
