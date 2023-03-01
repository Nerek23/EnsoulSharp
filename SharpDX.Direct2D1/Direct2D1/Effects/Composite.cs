using System;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000344 RID: 836
	public class Composite : Effect
	{
		// Token: 0x06000E4B RID: 3659 RVA: 0x00026F21 File Offset: 0x00025121
		public Composite(DeviceContext context) : base(context, Effect.Composite)
		{
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000E4C RID: 3660 RVA: 0x00026F2F File Offset: 0x0002512F
		// (set) Token: 0x06000E4D RID: 3661 RVA: 0x00026F38 File Offset: 0x00025138
		public CompositeMode Mode
		{
			get
			{
				return base.GetEnumValue<CompositeMode>(0);
			}
			set
			{
				base.SetEnumValue<CompositeMode>(0, value);
			}
		}
	}
}
