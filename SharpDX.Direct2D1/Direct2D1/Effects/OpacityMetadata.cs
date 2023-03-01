using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000356 RID: 854
	public class OpacityMetadata : Effect
	{
		// Token: 0x06000F0C RID: 3852 RVA: 0x00027482 File Offset: 0x00025682
		public OpacityMetadata(DeviceContext deviceContext) : base(deviceContext, Effect.OpacityMetadata)
		{
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000F0D RID: 3853 RVA: 0x00026CD0 File Offset: 0x00024ED0
		// (set) Token: 0x06000F0E RID: 3854 RVA: 0x00026CD9 File Offset: 0x00024ED9
		public RawVector4 OpaqueRectangle
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
