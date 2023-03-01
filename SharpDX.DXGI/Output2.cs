using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200001D RID: 29
	[Guid("595e39d1-2724-4663-99b1-da969de28364")]
	public class Output2 : Output1
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00004691 File Offset: 0x00002891
		public bool SupportsOverlays
		{
			get
			{
				return this.SupportsOverlays_();
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000469E File Offset: 0x0000289E
		public Output2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000046A7 File Offset: 0x000028A7
		public new static explicit operator Output2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Output2(nativePtr);
			}
			return null;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000046BE File Offset: 0x000028BE
		internal unsafe RawBool SupportsOverlays_()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
		}
	}
}
