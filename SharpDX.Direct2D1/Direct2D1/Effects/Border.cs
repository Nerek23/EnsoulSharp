using System;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000340 RID: 832
	public class Border : Effect
	{
		// Token: 0x06000E2F RID: 3631 RVA: 0x00026DD8 File Offset: 0x00024FD8
		public Border(DeviceContext context) : base(context, Effect.Border)
		{
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000E30 RID: 3632 RVA: 0x00026DE6 File Offset: 0x00024FE6
		// (set) Token: 0x06000E31 RID: 3633 RVA: 0x00026DEF File Offset: 0x00024FEF
		public BorderEdgeMode EdgeModeX
		{
			get
			{
				return base.GetEnumValue<BorderEdgeMode>(0);
			}
			set
			{
				base.SetEnumValue<BorderEdgeMode>(0, value);
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000E32 RID: 3634 RVA: 0x00026DF9 File Offset: 0x00024FF9
		// (set) Token: 0x06000E33 RID: 3635 RVA: 0x00026E02 File Offset: 0x00025002
		public BorderEdgeMode EdgeModeY
		{
			get
			{
				return base.GetEnumValue<BorderEdgeMode>(1);
			}
			set
			{
				base.SetEnumValue<BorderEdgeMode>(1, value);
			}
		}
	}
}
