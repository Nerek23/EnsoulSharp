using System;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001DB RID: 475
	public class Effect<T> : Effect where T : CustomEffect
	{
		// Token: 0x060009A5 RID: 2469 RVA: 0x0001BEFA File Offset: 0x0001A0FA
		public Effect(DeviceContext deviceContext) : this(deviceContext, Utilities.GetGuidFromType(typeof(T)))
		{
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x0001BF12 File Offset: 0x0001A112
		public Effect(DeviceContext deviceContext, Guid effectId) : base(deviceContext, effectId)
		{
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x0001BF1C File Offset: 0x0001A11C
		public Effect(EffectContext effectContext) : base(effectContext, Utilities.GetGuidFromType(typeof(T)))
		{
		}
	}
}
