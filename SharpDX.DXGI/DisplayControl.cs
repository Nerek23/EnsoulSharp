using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200005F RID: 95
	[Guid("ea9dbf1a-c88e-4486-854a-98aa0138f30c")]
	public class DisplayControl : ComObject
	{
		// Token: 0x06000190 RID: 400 RVA: 0x0000272E File Offset: 0x0000092E
		public DisplayControl(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00006AC9 File Offset: 0x00004CC9
		public new static explicit operator DisplayControl(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DisplayControl(nativePtr);
			}
			return null;
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000192 RID: 402 RVA: 0x00006AE0 File Offset: 0x00004CE0
		public RawBool IsStereoEnabled
		{
			get
			{
				return this.IsStereoEnabled_();
			}
		}

		// Token: 0x1700002D RID: 45
		// (set) Token: 0x06000193 RID: 403 RVA: 0x00006AE8 File Offset: 0x00004CE8
		public RawBool StereoEnabled
		{
			set
			{
				this.SetStereoEnabled(value);
			}
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00006AF1 File Offset: 0x00004CF1
		internal unsafe RawBool IsStereoEnabled_()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00006B10 File Offset: 0x00004D10
		internal unsafe void SetStereoEnabled(RawBool enabled)
		{
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, enabled, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}
	}
}
