using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x0200035D RID: 861
	public class Shadow : Effect
	{
		// Token: 0x06000F4B RID: 3915 RVA: 0x0002758F File Offset: 0x0002578F
		public Shadow(DeviceContext context) : base(context, Effect.Shadow)
		{
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000F4C RID: 3916 RVA: 0x00026F50 File Offset: 0x00025150
		// (set) Token: 0x06000F4D RID: 3917 RVA: 0x00026F59 File Offset: 0x00025159
		public float BlurStandardDeviation
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

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000F4E RID: 3918 RVA: 0x0002759D File Offset: 0x0002579D
		// (set) Token: 0x06000F4F RID: 3919 RVA: 0x000275A6 File Offset: 0x000257A6
		public RawColor4 Color
		{
			get
			{
				return base.GetColor4Value(1);
			}
			set
			{
				base.SetValue(1, value);
			}
		}

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06000F50 RID: 3920 RVA: 0x000275B0 File Offset: 0x000257B0
		// (set) Token: 0x06000F51 RID: 3921 RVA: 0x000275B9 File Offset: 0x000257B9
		public ShadowOptimization Optimization
		{
			get
			{
				return base.GetEnumValue<ShadowOptimization>(2);
			}
			set
			{
				base.SetEnumValue<ShadowOptimization>(2, value);
			}
		}
	}
}
