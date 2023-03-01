using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x0200034D RID: 845
	public class Flood : Effect
	{
		// Token: 0x06000EB2 RID: 3762 RVA: 0x00027273 File Offset: 0x00025473
		public Flood(DeviceContext context) : base(context, Effect.Flood)
		{
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000EB3 RID: 3763 RVA: 0x00027281 File Offset: 0x00025481
		// (set) Token: 0x06000EB4 RID: 3764 RVA: 0x0002728A File Offset: 0x0002548A
		public RawColor4 Color
		{
			get
			{
				return base.GetColor4Value(0);
			}
			set
			{
				base.SetValue(0, value);
			}
		}
	}
}
