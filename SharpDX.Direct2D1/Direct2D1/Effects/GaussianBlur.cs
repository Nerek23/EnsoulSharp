using System;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x0200034F RID: 847
	public class GaussianBlur : Effect
	{
		// Token: 0x06000ED8 RID: 3800 RVA: 0x0002735D File Offset: 0x0002555D
		public GaussianBlur(DeviceContext context) : base(context, Effect.GaussianBlur)
		{
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000ED9 RID: 3801 RVA: 0x00026F50 File Offset: 0x00025150
		// (set) Token: 0x06000EDA RID: 3802 RVA: 0x00026F59 File Offset: 0x00025159
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

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000EDB RID: 3803 RVA: 0x0002736B File Offset: 0x0002556B
		// (set) Token: 0x06000EDC RID: 3804 RVA: 0x00027374 File Offset: 0x00025574
		public GaussianBlurOptimization Optimization
		{
			get
			{
				return base.GetEnumValue<GaussianBlurOptimization>(1);
			}
			set
			{
				base.SetEnumValue<GaussianBlurOptimization>(1, value);
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000EDD RID: 3805 RVA: 0x0002737E File Offset: 0x0002557E
		// (set) Token: 0x06000EDE RID: 3806 RVA: 0x00027387 File Offset: 0x00025587
		public BorderMode BorderMode
		{
			get
			{
				return base.GetEnumValue<BorderMode>(2);
			}
			set
			{
				base.SetEnumValue<BorderMode>(2, value);
			}
		}
	}
}
