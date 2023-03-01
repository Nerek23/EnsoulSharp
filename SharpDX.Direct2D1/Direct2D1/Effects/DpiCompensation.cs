using System;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x0200034C RID: 844
	public class DpiCompensation : Effect
	{
		// Token: 0x06000EAB RID: 3755 RVA: 0x00027252 File Offset: 0x00025452
		public DpiCompensation(DeviceContext context) : base(context, Effect.DpiCompensation)
		{
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000EAC RID: 3756 RVA: 0x00027260 File Offset: 0x00025460
		// (set) Token: 0x06000EAD RID: 3757 RVA: 0x00027269 File Offset: 0x00025469
		public DpiCompensationInterpolationMode InterpolationMode
		{
			get
			{
				return base.GetEnumValue<DpiCompensationInterpolationMode>(0);
			}
			set
			{
				base.SetEnumValue<DpiCompensationInterpolationMode>(0, value);
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000EAE RID: 3758 RVA: 0x00026C89 File Offset: 0x00024E89
		// (set) Token: 0x06000EAF RID: 3759 RVA: 0x00026C92 File Offset: 0x00024E92
		public BorderMode BorderMode
		{
			get
			{
				return base.GetEnumValue<BorderMode>(1);
			}
			set
			{
				base.SetEnumValue<BorderMode>(1, value);
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000EB0 RID: 3760 RVA: 0x000271AC File Offset: 0x000253AC
		// (set) Token: 0x06000EB1 RID: 3761 RVA: 0x000271B5 File Offset: 0x000253B5
		public float InputDpi
		{
			get
			{
				return base.GetFloatValue(2);
			}
			set
			{
				base.SetValue(2, value);
			}
		}
	}
}
