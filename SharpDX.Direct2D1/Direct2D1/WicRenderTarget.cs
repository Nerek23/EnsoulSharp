using System;
using SharpDX.WIC;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200024C RID: 588
	public class WicRenderTarget : RenderTarget
	{
		// Token: 0x06000D77 RID: 3447 RVA: 0x00025004 File Offset: 0x00023204
		public WicRenderTarget(Factory factory, Bitmap wicBitmap, RenderTargetProperties renderTargetProperties) : base(IntPtr.Zero)
		{
			factory.CreateWicBitmapRenderTarget(wicBitmap, ref renderTargetProperties, this);
		}
	}
}
