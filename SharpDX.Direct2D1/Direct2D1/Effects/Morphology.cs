using System;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000354 RID: 852
	public class Morphology : Effect
	{
		// Token: 0x06000F04 RID: 3844 RVA: 0x0002744E File Offset: 0x0002564E
		public Morphology(DeviceContext context) : base(context, Effect.Morphology)
		{
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000F05 RID: 3845 RVA: 0x0002745C File Offset: 0x0002565C
		// (set) Token: 0x06000F06 RID: 3846 RVA: 0x00027465 File Offset: 0x00025665
		public MorphologyMode Mode
		{
			get
			{
				return base.GetEnumValue<MorphologyMode>(0);
			}
			set
			{
				base.SetEnumValue<MorphologyMode>(0, value);
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000F07 RID: 3847 RVA: 0x0002746F File Offset: 0x0002566F
		// (set) Token: 0x06000F08 RID: 3848 RVA: 0x00027478 File Offset: 0x00025678
		public int Width
		{
			get
			{
				return (int)base.GetUIntValue(1);
			}
			set
			{
				base.SetValue(1, (uint)value);
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000F09 RID: 3849 RVA: 0x00026F76 File Offset: 0x00025176
		// (set) Token: 0x06000F0A RID: 3850 RVA: 0x00026F7F File Offset: 0x0002517F
		public int Height
		{
			get
			{
				return (int)base.GetUIntValue(2);
			}
			set
			{
				base.SetValue(2, (uint)value);
			}
		}
	}
}
