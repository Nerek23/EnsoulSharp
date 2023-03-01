using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000206 RID: 518
	[Guid("3fe6adea-7643-4f53-bd14-a0ce63f24042")]
	public class OffsetTransform : TransformNodeNative
	{
		// Token: 0x06000B0A RID: 2826 RVA: 0x0001F8E6 File Offset: 0x0001DAE6
		public OffsetTransform(EffectContext context, RawPoint offset) : base(IntPtr.Zero)
		{
			context.CreateOffsetTransform(offset, this);
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x0001614D File Offset: 0x0001434D
		public OffsetTransform(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x0001F8FB File Offset: 0x0001DAFB
		public new static explicit operator OffsetTransform(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new OffsetTransform(nativePtr);
			}
			return null;
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000B0D RID: 2829 RVA: 0x0001F912 File Offset: 0x0001DB12
		// (set) Token: 0x06000B0E RID: 2830 RVA: 0x0001F91A File Offset: 0x0001DB1A
		public RawPoint Offset
		{
			get
			{
				return this.GetOffset();
			}
			set
			{
				this.SetOffset(value);
			}
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x0001F923 File Offset: 0x0001DB23
		internal unsafe void SetOffset(RawPoint offset)
		{
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawPoint), this._nativePointer, offset, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x0001F944 File Offset: 0x0001DB44
		internal unsafe RawPoint GetOffset()
		{
			RawPoint result;
			object obj = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			return result;
		}
	}
}
