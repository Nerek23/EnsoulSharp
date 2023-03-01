using System;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x0200034E RID: 846
	public class GammaTransfer : Effect
	{
		// Token: 0x06000EB5 RID: 3765 RVA: 0x00027294 File Offset: 0x00025494
		public GammaTransfer(DeviceContext context) : base(context, Effect.GammaTransfer)
		{
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000EB6 RID: 3766 RVA: 0x00026F50 File Offset: 0x00025150
		// (set) Token: 0x06000EB7 RID: 3767 RVA: 0x00026F59 File Offset: 0x00025159
		public float RedAmplitude
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

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000EB8 RID: 3768 RVA: 0x000270F6 File Offset: 0x000252F6
		// (set) Token: 0x06000EB9 RID: 3769 RVA: 0x000270FF File Offset: 0x000252FF
		public float RedExponent
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

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000EBA RID: 3770 RVA: 0x000271AC File Offset: 0x000253AC
		// (set) Token: 0x06000EBB RID: 3771 RVA: 0x000271B5 File Offset: 0x000253B5
		public float RedOffset
		{
			get
			{
				return base.GetFloatValue(2);
			}
			set
			{
				base.SetValue(2, value);
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000EBC RID: 3772 RVA: 0x00026D7E File Offset: 0x00024F7E
		// (set) Token: 0x06000EBD RID: 3773 RVA: 0x00026D87 File Offset: 0x00024F87
		public bool RedDisable
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

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000EBE RID: 3774 RVA: 0x00027206 File Offset: 0x00025406
		// (set) Token: 0x06000EBF RID: 3775 RVA: 0x0002720F File Offset: 0x0002540F
		public float GreenAmplitude
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

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000EC0 RID: 3776 RVA: 0x00027079 File Offset: 0x00025279
		// (set) Token: 0x06000EC1 RID: 3777 RVA: 0x00027082 File Offset: 0x00025282
		public float GreenExponent
		{
			get
			{
				return base.GetFloatValue(5);
			}
			set
			{
				base.SetValue(5, value);
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000EC2 RID: 3778 RVA: 0x0002708C File Offset: 0x0002528C
		// (set) Token: 0x06000EC3 RID: 3779 RVA: 0x00027095 File Offset: 0x00025295
		public float GreenOffset
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

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000EC4 RID: 3780 RVA: 0x00027157 File Offset: 0x00025357
		// (set) Token: 0x06000EC5 RID: 3781 RVA: 0x00027160 File Offset: 0x00025360
		public bool GreenDisable
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

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000EC6 RID: 3782 RVA: 0x000272A2 File Offset: 0x000254A2
		// (set) Token: 0x06000EC7 RID: 3783 RVA: 0x000272AB File Offset: 0x000254AB
		public float BlueAmplitude
		{
			get
			{
				return base.GetFloatValue(8);
			}
			set
			{
				base.SetValue(8, value);
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000EC8 RID: 3784 RVA: 0x000272B5 File Offset: 0x000254B5
		// (set) Token: 0x06000EC9 RID: 3785 RVA: 0x000272BF File Offset: 0x000254BF
		public float BlueExponent
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

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000ECA RID: 3786 RVA: 0x000272CA File Offset: 0x000254CA
		// (set) Token: 0x06000ECB RID: 3787 RVA: 0x000272D4 File Offset: 0x000254D4
		public float BlueOffset
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

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000ECC RID: 3788 RVA: 0x000272DF File Offset: 0x000254DF
		// (set) Token: 0x06000ECD RID: 3789 RVA: 0x000272E9 File Offset: 0x000254E9
		public bool BlueDisable
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

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000ECE RID: 3790 RVA: 0x000272F4 File Offset: 0x000254F4
		// (set) Token: 0x06000ECF RID: 3791 RVA: 0x000272FE File Offset: 0x000254FE
		public float AlphaAmplitude
		{
			get
			{
				return base.GetFloatValue(12);
			}
			set
			{
				base.SetValue(12, value);
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000ED0 RID: 3792 RVA: 0x00027309 File Offset: 0x00025509
		// (set) Token: 0x06000ED1 RID: 3793 RVA: 0x00027313 File Offset: 0x00025513
		public float AlphaExponent
		{
			get
			{
				return base.GetFloatValue(13);
			}
			set
			{
				base.SetValue(13, value);
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000ED2 RID: 3794 RVA: 0x0002731E File Offset: 0x0002551E
		// (set) Token: 0x06000ED3 RID: 3795 RVA: 0x00027328 File Offset: 0x00025528
		public float AlphaOffset
		{
			get
			{
				return base.GetFloatValue(14);
			}
			set
			{
				base.SetValue(14, value);
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000ED4 RID: 3796 RVA: 0x00027333 File Offset: 0x00025533
		// (set) Token: 0x06000ED5 RID: 3797 RVA: 0x0002733D File Offset: 0x0002553D
		public bool AlphaDisable
		{
			get
			{
				return base.GetBoolValue(15);
			}
			set
			{
				base.SetValue(15, value);
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000ED6 RID: 3798 RVA: 0x00027348 File Offset: 0x00025548
		// (set) Token: 0x06000ED7 RID: 3799 RVA: 0x00027352 File Offset: 0x00025552
		public bool ClampOutput
		{
			get
			{
				return base.GetBoolValue(16);
			}
			set
			{
				base.SetValue(16, value);
			}
		}
	}
}
