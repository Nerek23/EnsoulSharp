using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000341 RID: 833
	public class Brightness : Effect
	{
		// Token: 0x06000E34 RID: 3636 RVA: 0x00026E0C File Offset: 0x0002500C
		public Brightness(DeviceContext context) : base(context, Effect.Brightness)
		{
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000E35 RID: 3637 RVA: 0x00026E1A File Offset: 0x0002501A
		// (set) Token: 0x06000E36 RID: 3638 RVA: 0x00026E23 File Offset: 0x00025023
		public RawVector2 WhitePoint
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

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000E37 RID: 3639 RVA: 0x00026D58 File Offset: 0x00024F58
		// (set) Token: 0x06000E38 RID: 3640 RVA: 0x00026D61 File Offset: 0x00024F61
		public RawVector2 BlackPoint
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
	}
}
