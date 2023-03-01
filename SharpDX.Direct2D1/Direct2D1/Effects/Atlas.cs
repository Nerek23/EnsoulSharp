using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x0200033D RID: 829
	public class Atlas : Effect
	{
		// Token: 0x06000E1A RID: 3610 RVA: 0x00026CF6 File Offset: 0x00024EF6
		public Atlas(DeviceContext context) : base(context, Effect.Atlas)
		{
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000E1B RID: 3611 RVA: 0x00026CD0 File Offset: 0x00024ED0
		// (set) Token: 0x06000E1C RID: 3612 RVA: 0x00026CD9 File Offset: 0x00024ED9
		public RawVector4 InputRectangle
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

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000E1D RID: 3613 RVA: 0x00026D04 File Offset: 0x00024F04
		// (set) Token: 0x06000E1E RID: 3614 RVA: 0x00026D0D File Offset: 0x00024F0D
		public RawVector4 InputPaddingRectangle
		{
			get
			{
				return base.GetVector4Value(1);
			}
			set
			{
				base.SetValue(1, value);
			}
		}
	}
}
