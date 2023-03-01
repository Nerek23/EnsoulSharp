using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200002A RID: 42
	[Guid("9537ab04-3250-412e-8213-fcd2f8677933")]
	public class EffectPool : ComObject
	{
		// Token: 0x060002A6 RID: 678 RVA: 0x0000A96C File Offset: 0x00008B6C
		public EffectPool()
		{
			D3DX9.CreateEffectPool(this);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00002623 File Offset: 0x00000823
		public EffectPool(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000A97A File Offset: 0x00008B7A
		public new static explicit operator EffectPool(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new EffectPool(nativePointer);
			}
			return null;
		}
	}
}
