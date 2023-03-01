using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x0200033C RID: 828
	public class ArithmeticComposite : Effect
	{
		// Token: 0x06000E15 RID: 3605 RVA: 0x00026CC2 File Offset: 0x00024EC2
		public ArithmeticComposite(DeviceContext context) : base(context, Effect.ArithmeticComposite)
		{
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000E16 RID: 3606 RVA: 0x00026CD0 File Offset: 0x00024ED0
		// (set) Token: 0x06000E17 RID: 3607 RVA: 0x00026CD9 File Offset: 0x00024ED9
		public RawVector4 Coefficients
		{
			get
			{
				return base.GetVector4Value(0);
			}
			set
			{
				base.SetValue(0, value);
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000E18 RID: 3608 RVA: 0x00026CE3 File Offset: 0x00024EE3
		// (set) Token: 0x06000E19 RID: 3609 RVA: 0x00026CEC File Offset: 0x00024EEC
		public bool ClampOutput
		{
			get
			{
				return base.GetBoolValue(1);
			}
			set
			{
				base.SetValue(1, value);
			}
		}
	}
}
