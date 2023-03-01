using System;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x0200033F RID: 831
	public class Blend : Effect
	{
		// Token: 0x06000E2C RID: 3628 RVA: 0x00026DB7 File Offset: 0x00024FB7
		public Blend(DeviceContext context) : base(context, Effect.Blend)
		{
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000E2D RID: 3629 RVA: 0x00026DC5 File Offset: 0x00024FC5
		// (set) Token: 0x06000E2E RID: 3630 RVA: 0x00026DCE File Offset: 0x00024FCE
		public BlendMode Mode
		{
			get
			{
				return base.GetEnumValue<BlendMode>(0);
			}
			set
			{
				base.SetEnumValue<BlendMode>(0, value);
			}
		}
	}
}
