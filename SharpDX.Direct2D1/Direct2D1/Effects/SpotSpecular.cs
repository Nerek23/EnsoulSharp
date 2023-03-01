using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x0200035F RID: 863
	public class SpotSpecular : Effect
	{
		// Token: 0x06000F65 RID: 3941 RVA: 0x000275F7 File Offset: 0x000257F7
		public SpotSpecular(DeviceContext context) : base(context, Effect.SpotSpecular)
		{
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000F66 RID: 3942 RVA: 0x000274F8 File Offset: 0x000256F8
		// (set) Token: 0x06000F67 RID: 3943 RVA: 0x00027501 File Offset: 0x00025701
		public RawVector3 LightPosition
		{
			get
			{
				return base.GetVector3Value(0);
			}
			set
			{
				base.SetValue(0, value);
			}
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000F68 RID: 3944 RVA: 0x000275D1 File Offset: 0x000257D1
		// (set) Token: 0x06000F69 RID: 3945 RVA: 0x000275DA File Offset: 0x000257DA
		public RawVector3 PointsAt
		{
			get
			{
				return base.GetVector3Value(1);
			}
			set
			{
				base.SetValue(1, value);
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000F6A RID: 3946 RVA: 0x000271AC File Offset: 0x000253AC
		// (set) Token: 0x06000F6B RID: 3947 RVA: 0x000271B5 File Offset: 0x000253B5
		public float Focus
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

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000F6C RID: 3948 RVA: 0x00026CAF File Offset: 0x00024EAF
		// (set) Token: 0x06000F6D RID: 3949 RVA: 0x00026CB8 File Offset: 0x00024EB8
		public float LimitingConeAngle
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

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000F6E RID: 3950 RVA: 0x00027206 File Offset: 0x00025406
		// (set) Token: 0x06000F6F RID: 3951 RVA: 0x0002720F File Offset: 0x0002540F
		public float SpecularExponent
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

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000F70 RID: 3952 RVA: 0x00027079 File Offset: 0x00025279
		// (set) Token: 0x06000F71 RID: 3953 RVA: 0x00027082 File Offset: 0x00025282
		public float SpecularConstant
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

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000F72 RID: 3954 RVA: 0x0002708C File Offset: 0x0002528C
		// (set) Token: 0x06000F73 RID: 3955 RVA: 0x00027095 File Offset: 0x00025295
		public float SurfaceScale
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

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06000F74 RID: 3956 RVA: 0x000274D7 File Offset: 0x000256D7
		// (set) Token: 0x06000F75 RID: 3957 RVA: 0x000274E0 File Offset: 0x000256E0
		public RawVector3 Color
		{
			get
			{
				return base.GetVector3Value(7);
			}
			set
			{
				base.SetValue(7, value);
			}
		}

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000F76 RID: 3958 RVA: 0x00027605 File Offset: 0x00025805
		// (set) Token: 0x06000F77 RID: 3959 RVA: 0x0002760E File Offset: 0x0002580E
		public RawVector2 KernelUnitLength
		{
			get
			{
				return base.GetVector2Value(8);
			}
			set
			{
				base.SetValue(8, value);
			}
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000F78 RID: 3960 RVA: 0x00027618 File Offset: 0x00025818
		// (set) Token: 0x06000F79 RID: 3961 RVA: 0x00027622 File Offset: 0x00025822
		public SpotSpecularScaleMode ScaleMode
		{
			get
			{
				return base.GetEnumValue<SpotSpecularScaleMode>(9);
			}
			set
			{
				base.SetEnumValue<SpotSpecularScaleMode>(9, value);
			}
		}
	}
}
