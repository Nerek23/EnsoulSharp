using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200017C RID: 380
	[Guid("2cd90695-12e2-11dc-9fed-001143a055f9")]
	public class BitmapRenderTarget : RenderTarget
	{
		// Token: 0x060006FB RID: 1787 RVA: 0x00015E58 File Offset: 0x00014058
		public BitmapRenderTarget(RenderTarget renderTarget, CompatibleRenderTargetOptions options) : this(renderTarget, options, null, null, null)
		{
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x00015E88 File Offset: 0x00014088
		public BitmapRenderTarget(RenderTarget renderTarget, CompatibleRenderTargetOptions options, Size2F desiredSize) : this(renderTarget, options, new Size2F?(desiredSize), null, null)
		{
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x00015EB8 File Offset: 0x000140B8
		public BitmapRenderTarget(RenderTarget renderTarget, CompatibleRenderTargetOptions options, PixelFormat? desiredFormat) : this(renderTarget, options, null, null, desiredFormat)
		{
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x00015EE0 File Offset: 0x000140E0
		public BitmapRenderTarget(RenderTarget renderTarget, CompatibleRenderTargetOptions options, Size2F? desiredSize, Size2? desiredPixelSize, PixelFormat? desiredFormat) : base(IntPtr.Zero)
		{
			renderTarget.CreateCompatibleRenderTarget(desiredSize, desiredPixelSize, desiredFormat, options, this);
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x00015EFA File Offset: 0x000140FA
		public BitmapRenderTarget(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x00015F03 File Offset: 0x00014103
		public new static explicit operator BitmapRenderTarget(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapRenderTarget(nativePtr);
			}
			return null;
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000701 RID: 1793 RVA: 0x00015F1C File Offset: 0x0001411C
		public Bitmap Bitmap
		{
			get
			{
				Bitmap result;
				this.GetBitmap(out result);
				return result;
			}
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00015F34 File Offset: 0x00014134
		internal unsafe void GetBitmap(out Bitmap bitmap)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)57 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				bitmap = new Bitmap(zero);
			}
			else
			{
				bitmap = null;
			}
			result.CheckError();
		}
	}
}
