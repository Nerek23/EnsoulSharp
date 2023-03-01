using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000123 RID: 291
	[Guid("791e8298-3ef3-4230-9880-c9bdecc42064")]
	public class BitmapRenderTarget1 : BitmapRenderTarget
	{
		// Token: 0x060004F7 RID: 1271 RVA: 0x00010111 File Offset: 0x0000E311
		public BitmapRenderTarget1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x0001011A File Offset: 0x0000E31A
		public new static explicit operator BitmapRenderTarget1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapRenderTarget1(nativePtr);
			}
			return null;
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060004F9 RID: 1273 RVA: 0x00010131 File Offset: 0x0000E331
		// (set) Token: 0x060004FA RID: 1274 RVA: 0x00010139 File Offset: 0x0000E339
		public TextAntialiasMode TextAntialiasMode
		{
			get
			{
				return this.GetTextAntialiasMode();
			}
			set
			{
				this.SetTextAntialiasMode(value);
			}
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00010142 File Offset: 0x0000E342
		internal unsafe TextAntialiasMode GetTextAntialiasMode()
		{
			return calli(SharpDX.DirectWrite.TextAntialiasMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00010164 File Offset: 0x0000E364
		internal unsafe void SetTextAntialiasMode(TextAntialiasMode antialiasMode)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, antialiasMode, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
