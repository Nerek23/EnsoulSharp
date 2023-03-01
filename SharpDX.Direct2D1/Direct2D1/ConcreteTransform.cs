using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020002FF RID: 767
	[Guid("1a799d8a-69f7-4e4c-9fed-437ccc6684cc")]
	public class ConcreteTransform : TransformNodeNative
	{
		// Token: 0x06000D8B RID: 3467 RVA: 0x0001614D File Offset: 0x0001434D
		public ConcreteTransform(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000D8C RID: 3468 RVA: 0x000258B2 File Offset: 0x00023AB2
		public new static explicit operator ConcreteTransform(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ConcreteTransform(nativePtr);
			}
			return null;
		}

		// Token: 0x170001CD RID: 461
		// (set) Token: 0x06000D8D RID: 3469 RVA: 0x000258C9 File Offset: 0x00023AC9
		public RawBool Cached
		{
			set
			{
				this.SetCached(value);
			}
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x000258D4 File Offset: 0x00023AD4
		public unsafe void SetOutputBuffer(BufferPrecision bufferPrecision, ChannelDepth channelDepth)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, bufferPrecision, channelDepth, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x0002590D File Offset: 0x00023B0D
		internal unsafe void SetCached(RawBool isCached)
		{
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, isCached, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}
	}
}
