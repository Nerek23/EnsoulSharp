using System;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000349 RID: 841
	public class DisplacementMap : Effect
	{
		// Token: 0x06000E84 RID: 3716 RVA: 0x0002716A File Offset: 0x0002536A
		public DisplacementMap(DeviceContext context) : base(context, Effect.DisplacementMap)
		{
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000E85 RID: 3717 RVA: 0x00026F50 File Offset: 0x00025150
		// (set) Token: 0x06000E86 RID: 3718 RVA: 0x00026F59 File Offset: 0x00025159
		public new float Scale
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

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000E87 RID: 3719 RVA: 0x00027178 File Offset: 0x00025378
		// (set) Token: 0x06000E88 RID: 3720 RVA: 0x00027181 File Offset: 0x00025381
		public ChannelSelector XChannelSelect
		{
			get
			{
				return base.GetEnumValue<ChannelSelector>(1);
			}
			set
			{
				base.SetEnumValue<ChannelSelector>(1, value);
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000E89 RID: 3721 RVA: 0x0002718B File Offset: 0x0002538B
		// (set) Token: 0x06000E8A RID: 3722 RVA: 0x00027194 File Offset: 0x00025394
		public ChannelSelector YChannelSelect
		{
			get
			{
				return base.GetEnumValue<ChannelSelector>(2);
			}
			set
			{
				base.SetEnumValue<ChannelSelector>(2, value);
			}
		}
	}
}
