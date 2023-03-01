using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x02000025 RID: 37
	[Guid("4AE63092-6327-4c1b-80AE-BFE12EA32B86")]
	public class Surface1 : Surface
	{
		// Token: 0x060000F8 RID: 248 RVA: 0x00004D24 File Offset: 0x00002F24
		public void ReleaseDC()
		{
			this.ReleaseDC_(null);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00004D40 File Offset: 0x00002F40
		public void ReleaseDC(RawRectangle dirtyRect)
		{
			this.ReleaseDC_(new RawRectangle?(dirtyRect));
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00004D4E File Offset: 0x00002F4E
		public Surface1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00004D57 File Offset: 0x00002F57
		public new static explicit operator Surface1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Surface1(nativePtr);
			}
			return null;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00004D70 File Offset: 0x00002F70
		public unsafe IntPtr GetDC(RawBool discard)
		{
			IntPtr result;
			calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawBool,System.Void*), this._nativePointer, discard, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00004DB0 File Offset: 0x00002FB0
		internal unsafe void ReleaseDC_(RawRectangle? dirtyRectRef)
		{
			RawRectangle value;
			if (dirtyRectRef != null)
			{
				value = dirtyRectRef.Value;
			}
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (dirtyRectRef == null) ? null : (&value), *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
