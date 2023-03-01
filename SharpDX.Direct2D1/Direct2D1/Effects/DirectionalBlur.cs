using System;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000347 RID: 839
	public class DirectionalBlur : Effect
	{
		// Token: 0x06000E68 RID: 3688 RVA: 0x000270E8 File Offset: 0x000252E8
		public DirectionalBlur(DeviceContext context) : base(context, Effect.DirectionalBlur)
		{
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000E69 RID: 3689 RVA: 0x00026F50 File Offset: 0x00025150
		// (set) Token: 0x06000E6A RID: 3690 RVA: 0x00026F59 File Offset: 0x00025159
		public float StandardDeviation
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

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000E6B RID: 3691 RVA: 0x000270F6 File Offset: 0x000252F6
		// (set) Token: 0x06000E6C RID: 3692 RVA: 0x000270FF File Offset: 0x000252FF
		public float Angle
		{
			get
			{
				return base.GetFloatValue(1);
			}
			set
			{
				base.SetValue(1, value);
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000E6D RID: 3693 RVA: 0x00027109 File Offset: 0x00025309
		// (set) Token: 0x06000E6E RID: 3694 RVA: 0x00027112 File Offset: 0x00025312
		public DirectionalBlurOptimization Optimization
		{
			get
			{
				return base.GetEnumValue<DirectionalBlurOptimization>(2);
			}
			set
			{
				base.SetEnumValue<DirectionalBlurOptimization>(2, value);
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000E6F RID: 3695 RVA: 0x0002711C File Offset: 0x0002531C
		// (set) Token: 0x06000E70 RID: 3696 RVA: 0x00027125 File Offset: 0x00025325
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
	}
}
