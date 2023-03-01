using System;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000350 RID: 848
	public class Histogram : Effect
	{
		// Token: 0x06000EDF RID: 3807 RVA: 0x00027391 File Offset: 0x00025591
		public Histogram(DeviceContext context) : base(context, Effect.Histogram)
		{
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000EE0 RID: 3808 RVA: 0x0002739F File Offset: 0x0002559F
		// (set) Token: 0x06000EE1 RID: 3809 RVA: 0x000273A8 File Offset: 0x000255A8
		public int NumBins
		{
			get
			{
				return (int)base.GetUIntValue(0);
			}
			set
			{
				base.SetValue(0, (uint)value);
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000EE2 RID: 3810 RVA: 0x00027178 File Offset: 0x00025378
		// (set) Token: 0x06000EE3 RID: 3811 RVA: 0x00027181 File Offset: 0x00025381
		public ChannelSelector ChannelSelect
		{
			get
			{
				return base.GetEnumValue<ChannelSelector>(1);
			}
			set
			{
				base.SetEnumValue<ChannelSelector>(1, value);
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000EE4 RID: 3812 RVA: 0x000273B4 File Offset: 0x000255B4
		public unsafe float[] HistogramOutput
		{
			get
			{
				float[] array = new float[this.NumBins];
				float[] array2;
				void* value;
				if ((array2 = array) == null || array2.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array2[0]);
				}
				base.GetValue(2, PropertyType.Blob, (IntPtr)value, 4 * array.Length);
				array2 = null;
				return array;
			}
		}
	}
}
