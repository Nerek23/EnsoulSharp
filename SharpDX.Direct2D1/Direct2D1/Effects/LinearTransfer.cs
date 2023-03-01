using System;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000352 RID: 850
	public class LinearTransfer : Effect
	{
		// Token: 0x06000EE8 RID: 3816 RVA: 0x0002740A File Offset: 0x0002560A
		public LinearTransfer(DeviceContext context) : base(context, Effect.LinearTransfer)
		{
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000EE9 RID: 3817 RVA: 0x00026F50 File Offset: 0x00025150
		// (set) Token: 0x06000EEA RID: 3818 RVA: 0x00026F59 File Offset: 0x00025159
		public float RedYIntercept
		{
			get
			{
				return base.GetFloatValue(0);
			}
			set
			{
				base.SetValue(0, value);
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000EEB RID: 3819 RVA: 0x000270F6 File Offset: 0x000252F6
		// (set) Token: 0x06000EEC RID: 3820 RVA: 0x000270FF File Offset: 0x000252FF
		public float RedSlope
		{
			get
			{
				return base.GetFloatValue(1);
			}
			set
			{
				base.SetValue(1, value);
			}
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000EED RID: 3821 RVA: 0x00026F0E File Offset: 0x0002510E
		// (set) Token: 0x06000EEE RID: 3822 RVA: 0x00026F17 File Offset: 0x00025117
		public bool RedDisable
		{
			get
			{
				return base.GetBoolValue(2);
			}
			set
			{
				base.SetValue(2, value);
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000EEF RID: 3823 RVA: 0x00026CAF File Offset: 0x00024EAF
		// (set) Token: 0x06000EF0 RID: 3824 RVA: 0x00026CB8 File Offset: 0x00024EB8
		public float GreenYIntercept
		{
			get
			{
				return base.GetFloatValue(3);
			}
			set
			{
				base.SetValue(3, value);
			}
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000EF1 RID: 3825 RVA: 0x00027206 File Offset: 0x00025406
		// (set) Token: 0x06000EF2 RID: 3826 RVA: 0x0002720F File Offset: 0x0002540F
		public float GreenSlope
		{
			get
			{
				return base.GetFloatValue(4);
			}
			set
			{
				base.SetValue(4, value);
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000EF3 RID: 3827 RVA: 0x00027144 File Offset: 0x00025344
		// (set) Token: 0x06000EF4 RID: 3828 RVA: 0x0002714D File Offset: 0x0002534D
		public bool GreenDisable
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

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000EF5 RID: 3829 RVA: 0x0002708C File Offset: 0x0002528C
		// (set) Token: 0x06000EF6 RID: 3830 RVA: 0x00027095 File Offset: 0x00025295
		public float BlueYIntercept
		{
			get
			{
				return base.GetFloatValue(6);
			}
			set
			{
				base.SetValue(6, value);
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000EF7 RID: 3831 RVA: 0x00027418 File Offset: 0x00025618
		// (set) Token: 0x06000EF8 RID: 3832 RVA: 0x00027421 File Offset: 0x00025621
		public float BlueSlope
		{
			get
			{
				return base.GetFloatValue(7);
			}
			set
			{
				base.SetValue(7, value);
			}
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000EF9 RID: 3833 RVA: 0x000270B2 File Offset: 0x000252B2
		// (set) Token: 0x06000EFA RID: 3834 RVA: 0x000270BB File Offset: 0x000252BB
		public bool BlueDisable
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

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000EFB RID: 3835 RVA: 0x000272B5 File Offset: 0x000254B5
		// (set) Token: 0x06000EFC RID: 3836 RVA: 0x000272BF File Offset: 0x000254BF
		public float AlphaYIntercept
		{
			get
			{
				return base.GetFloatValue(9);
			}
			set
			{
				base.SetValue(9, value);
			}
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000EFD RID: 3837 RVA: 0x000272CA File Offset: 0x000254CA
		// (set) Token: 0x06000EFE RID: 3838 RVA: 0x000272D4 File Offset: 0x000254D4
		public float AlphaSlope
		{
			get
			{
				return base.GetFloatValue(10);
			}
			set
			{
				base.SetValue(10, value);
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000EFF RID: 3839 RVA: 0x000272DF File Offset: 0x000254DF
		// (set) Token: 0x06000F00 RID: 3840 RVA: 0x000272E9 File Offset: 0x000254E9
		public bool AlphaDisable
		{
			get
			{
				return base.GetBoolValue(11);
			}
			set
			{
				base.SetValue(11, value);
			}
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000F01 RID: 3841 RVA: 0x0002742B File Offset: 0x0002562B
		// (set) Token: 0x06000F02 RID: 3842 RVA: 0x00027435 File Offset: 0x00025635
		public bool ClampOutput
		{
			get
			{
				return base.GetBoolValue(12);
			}
			set
			{
				base.SetValue(12, value);
			}
		}
	}
}
