using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000346 RID: 838
	public class Crop : Effect
	{
		// Token: 0x06000E65 RID: 3685 RVA: 0x000270DA File Offset: 0x000252DA
		public Crop(DeviceContext context) : base(context, Effect.Crop)
		{
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000E66 RID: 3686 RVA: 0x00026CD0 File Offset: 0x00024ED0
		// (set) Token: 0x06000E67 RID: 3687 RVA: 0x00026CD9 File Offset: 0x00024ED9
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
