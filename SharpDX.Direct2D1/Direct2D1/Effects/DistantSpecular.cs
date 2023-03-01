using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x0200034B RID: 843
	public class DistantSpecular : Effect
	{
		// Token: 0x06000E9A RID: 3738 RVA: 0x000271F8 File Offset: 0x000253F8
		public DistantSpecular(DeviceContext context) : base(context, Effect.DistantSpecular)
		{
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000E9B RID: 3739 RVA: 0x00026F50 File Offset: 0x00025150
		// (set) Token: 0x06000E9C RID: 3740 RVA: 0x00026F59 File Offset: 0x00025159
		public float Azimuth
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

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000E9D RID: 3741 RVA: 0x000270F6 File Offset: 0x000252F6
		// (set) Token: 0x06000E9E RID: 3742 RVA: 0x000270FF File Offset: 0x000252FF
		public float Elevation
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

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000E9F RID: 3743 RVA: 0x000271AC File Offset: 0x000253AC
		// (set) Token: 0x06000EA0 RID: 3744 RVA: 0x000271B5 File Offset: 0x000253B5
		public float SpecularExponent
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

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000EA1 RID: 3745 RVA: 0x00026CAF File Offset: 0x00024EAF
		// (set) Token: 0x06000EA2 RID: 3746 RVA: 0x00026CB8 File Offset: 0x00024EB8
		public float SpecularConstant
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

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000EA3 RID: 3747 RVA: 0x00027206 File Offset: 0x00025406
		// (set) Token: 0x06000EA4 RID: 3748 RVA: 0x0002720F File Offset: 0x0002540F
		public float SurfaceScale
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

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000EA5 RID: 3749 RVA: 0x00027219 File Offset: 0x00025419
		// (set) Token: 0x06000EA6 RID: 3750 RVA: 0x00027222 File Offset: 0x00025422
		public RawVector3 Color
		{
			get
			{
				return base.GetVector3Value(5);
			}
			set
			{
				base.SetValue(5, value);
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000EA7 RID: 3751 RVA: 0x0002722C File Offset: 0x0002542C
		// (set) Token: 0x06000EA8 RID: 3752 RVA: 0x00027235 File Offset: 0x00025435
		public RawVector2 KernelUnitLength
		{
			get
			{
				return base.GetVector2Value(6);
			}
			set
			{
				base.SetValue(6, value);
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000EA9 RID: 3753 RVA: 0x0002723F File Offset: 0x0002543F
		// (set) Token: 0x06000EAA RID: 3754 RVA: 0x00027248 File Offset: 0x00025448
		public DistantSpecularScaleMode ScaleMode
		{
			get
			{
				return base.GetEnumValue<DistantSpecularScaleMode>(7);
			}
			set
			{
				base.SetEnumValue<DistantSpecularScaleMode>(7, value);
			}
		}
	}
}
