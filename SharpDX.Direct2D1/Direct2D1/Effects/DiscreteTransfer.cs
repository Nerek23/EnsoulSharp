using System;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000348 RID: 840
	public class DiscreteTransfer : Effect
	{
		// Token: 0x06000E71 RID: 3697 RVA: 0x0002712F File Offset: 0x0002532F
		public DiscreteTransfer(DeviceContext context) : base(context, Effect.DiscreteTransfer)
		{
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000E72 RID: 3698 RVA: 0x0002713D File Offset: 0x0002533D
		// (set) Token: 0x06000E73 RID: 3699 RVA: 0x0002713D File Offset: 0x0002533D
		public float[] RedTable
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000E74 RID: 3700 RVA: 0x00026CE3 File Offset: 0x00024EE3
		// (set) Token: 0x06000E75 RID: 3701 RVA: 0x00026CEC File Offset: 0x00024EEC
		public bool RedDisable
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

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000E76 RID: 3702 RVA: 0x0002713D File Offset: 0x0002533D
		// (set) Token: 0x06000E77 RID: 3703 RVA: 0x0002713D File Offset: 0x0002533D
		public float[] GreenTable
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000E78 RID: 3704 RVA: 0x00026D7E File Offset: 0x00024F7E
		// (set) Token: 0x06000E79 RID: 3705 RVA: 0x00026D87 File Offset: 0x00024F87
		public bool GreenDisable
		{
			get
			{
				return base.GetBoolValue(3);
			}
			set
			{
				base.SetValue(3, value);
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000E7A RID: 3706 RVA: 0x0002713D File Offset: 0x0002533D
		// (set) Token: 0x06000E7B RID: 3707 RVA: 0x0002713D File Offset: 0x0002533D
		public float[] BlueTable
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000E7C RID: 3708 RVA: 0x00027144 File Offset: 0x00025344
		// (set) Token: 0x06000E7D RID: 3709 RVA: 0x0002714D File Offset: 0x0002534D
		public bool BlueDisable
		{
			get
			{
				return base.GetBoolValue(5);
			}
			set
			{
				base.SetValue(5, value);
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000E7E RID: 3710 RVA: 0x0002713D File Offset: 0x0002533D
		// (set) Token: 0x06000E7F RID: 3711 RVA: 0x0002713D File Offset: 0x0002533D
		public float[] AlphaTable
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000E80 RID: 3712 RVA: 0x00027157 File Offset: 0x00025357
		// (set) Token: 0x06000E81 RID: 3713 RVA: 0x00027160 File Offset: 0x00025360
		public bool AlphaDisable
		{
			get
			{
				return base.GetBoolValue(7);
			}
			set
			{
				base.SetValue(7, value);
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000E82 RID: 3714 RVA: 0x000270B2 File Offset: 0x000252B2
		// (set) Token: 0x06000E83 RID: 3715 RVA: 0x000270BB File Offset: 0x000252BB
		public bool ClampOutput
		{
			get
			{
				return base.GetBoolValue(8);
			}
			set
			{
				base.SetValue(8, value);
			}
		}
	}
}
