using System;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000351 RID: 849
	public class HueRotation : Effect
	{
		// Token: 0x06000EE5 RID: 3813 RVA: 0x000273FC File Offset: 0x000255FC
		public HueRotation(DeviceContext context) : base(context, Effect.HueRotation)
		{
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000EE6 RID: 3814 RVA: 0x00026F50 File Offset: 0x00025150
		// (set) Token: 0x06000EE7 RID: 3815 RVA: 0x00026F59 File Offset: 0x00025159
		public float Angle
		{
			get
			{
				return base.GetFloatValue(0);
			}
			set
			{
				base.SetValue(0, value);
			}
		}
	}
}
