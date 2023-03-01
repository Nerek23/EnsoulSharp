using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000361 RID: 865
	public class Tile : Effect
	{
		// Token: 0x06000F8D RID: 3981 RVA: 0x0002781C File Offset: 0x00025A1C
		public Tile(DeviceContext context) : base(context, Effect.Tile)
		{
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000F8E RID: 3982 RVA: 0x00026CD0 File Offset: 0x00024ED0
		// (set) Token: 0x06000F8F RID: 3983 RVA: 0x00026CD9 File Offset: 0x00024ED9
		public RawVector4 Rectangle
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
	}
}
