using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000363 RID: 867
	public class Turbulence : Effect
	{
		// Token: 0x06000F97 RID: 3991 RVA: 0x0002784B File Offset: 0x00025A4B
		public Turbulence(DeviceContext context) : base(context, Effect.Turbulence)
		{
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06000F98 RID: 3992 RVA: 0x00026E1A File Offset: 0x0002501A
		// (set) Token: 0x06000F99 RID: 3993 RVA: 0x00026E23 File Offset: 0x00025023
		public RawVector2 Offset
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

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06000F9A RID: 3994 RVA: 0x00027859 File Offset: 0x00025A59
		// (set) Token: 0x06000F9B RID: 3995 RVA: 0x00027862 File Offset: 0x00025A62
		public RawVector2 BaseFrequency
		{
			get
			{
				return base.GetVector2Value(2);
			}
			set
			{
				base.SetValue(2, value);
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06000F9C RID: 3996 RVA: 0x00026F89 File Offset: 0x00025189
		// (set) Token: 0x06000F9D RID: 3997 RVA: 0x00026F92 File Offset: 0x00025192
		public int OctaveCount
		{
			get
			{
				return (int)base.GetUIntValue(3);
			}
			set
			{
				base.SetValue(3, (uint)value);
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000F9E RID: 3998 RVA: 0x0002786C File Offset: 0x00025A6C
		// (set) Token: 0x06000F9F RID: 3999 RVA: 0x00027875 File Offset: 0x00025A75
		public int Seed
		{
			get
			{
				return (int)base.GetUIntValue(4);
			}
			set
			{
				base.SetValue(4, (uint)value);
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000FA0 RID: 4000 RVA: 0x0002787F File Offset: 0x00025A7F
		// (set) Token: 0x06000FA1 RID: 4001 RVA: 0x00027888 File Offset: 0x00025A88
		public TurbulenceNoise Noise
		{
			get
			{
				return base.GetEnumValue<TurbulenceNoise>(5);
			}
			set
			{
				base.SetEnumValue<TurbulenceNoise>(5, value);
			}
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000FA2 RID: 4002 RVA: 0x00027892 File Offset: 0x00025A92
		// (set) Token: 0x06000FA3 RID: 4003 RVA: 0x0002789B File Offset: 0x00025A9B
		public bool Stitchable
		{
			get
			{
				return base.GetBoolValue(6);
			}
			set
			{
				base.SetValue(6, value);
			}
		}
	}
}
