using System;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x0200035B RID: 859
	public class Saturation : Effect
	{
		// Token: 0x06000F3D RID: 3901 RVA: 0x00027573 File Offset: 0x00025773
		public Saturation(DeviceContext context) : base(context, Effect.Saturation)
		{
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06000F3E RID: 3902 RVA: 0x00026F50 File Offset: 0x00025150
		// (set) Token: 0x06000F3F RID: 3903 RVA: 0x00026F59 File Offset: 0x00025159
		public float Value
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
