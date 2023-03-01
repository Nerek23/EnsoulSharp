using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x0200035C RID: 860
	public class Scale : Effect
	{
		// Token: 0x06000F40 RID: 3904 RVA: 0x00027581 File Offset: 0x00025781
		public Scale(DeviceContext context) : base(context, Effect.Scale)
		{
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06000F41 RID: 3905 RVA: 0x00026E1A File Offset: 0x0002501A
		// (set) Token: 0x06000F42 RID: 3906 RVA: 0x00026E23 File Offset: 0x00025023
		public RawVector2 ScaleAmount
		{
			get
			{
				return base.GetVector2Value(0);
			}
			set
			{
				base.SetValue(0, value);
			}
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000F43 RID: 3907 RVA: 0x00026D58 File Offset: 0x00024F58
		// (set) Token: 0x06000F44 RID: 3908 RVA: 0x00026D61 File Offset: 0x00024F61
		public RawVector2 CenterPoint
		{
			get
			{
				return base.GetVector2Value(1);
			}
			set
			{
				base.SetValue(1, value);
			}
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000F45 RID: 3909 RVA: 0x0002711C File Offset: 0x0002531C
		// (set) Token: 0x06000F46 RID: 3910 RVA: 0x00027125 File Offset: 0x00025325
		public BorderMode BorderMode
		{
			get
			{
				return base.GetEnumValue<BorderMode>(3);
			}
			set
			{
				base.SetEnumValue<BorderMode>(3, value);
			}
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000F47 RID: 3911 RVA: 0x00027206 File Offset: 0x00025406
		// (set) Token: 0x06000F48 RID: 3912 RVA: 0x0002720F File Offset: 0x0002540F
		public float Sharpness
		{
			get
			{
				return base.GetFloatValue(4);
			}
			set
			{
				base.SetValue(4, value);
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000F49 RID: 3913 RVA: 0x00026D6B File Offset: 0x00024F6B
		// (set) Token: 0x06000F4A RID: 3914 RVA: 0x00026D74 File Offset: 0x00024F74
		public InterpolationMode InterpolationMode
		{
			get
			{
				return base.GetEnumValue<InterpolationMode>(2);
			}
			set
			{
				base.SetEnumValue<InterpolationMode>(2, value);
			}
		}
	}
}
