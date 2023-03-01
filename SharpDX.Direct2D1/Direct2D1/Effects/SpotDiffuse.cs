using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x0200035E RID: 862
	public class SpotDiffuse : Effect
	{
		// Token: 0x06000F52 RID: 3922 RVA: 0x000275C3 File Offset: 0x000257C3
		public SpotDiffuse(DeviceContext context) : base(context, Effect.SpotDiffuse)
		{
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06000F53 RID: 3923 RVA: 0x000274F8 File Offset: 0x000256F8
		// (set) Token: 0x06000F54 RID: 3924 RVA: 0x00027501 File Offset: 0x00025701
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

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000F55 RID: 3925 RVA: 0x000275D1 File Offset: 0x000257D1
		// (set) Token: 0x06000F56 RID: 3926 RVA: 0x000275DA File Offset: 0x000257DA
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

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000F57 RID: 3927 RVA: 0x000271AC File Offset: 0x000253AC
		// (set) Token: 0x06000F58 RID: 3928 RVA: 0x000271B5 File Offset: 0x000253B5
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

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000F59 RID: 3929 RVA: 0x00026CAF File Offset: 0x00024EAF
		// (set) Token: 0x06000F5A RID: 3930 RVA: 0x00026CB8 File Offset: 0x00024EB8
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

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000F5B RID: 3931 RVA: 0x00027206 File Offset: 0x00025406
		// (set) Token: 0x06000F5C RID: 3932 RVA: 0x0002720F File Offset: 0x0002540F
		public float DiffuseConstant
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

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000F5D RID: 3933 RVA: 0x00027079 File Offset: 0x00025279
		// (set) Token: 0x06000F5E RID: 3934 RVA: 0x00027082 File Offset: 0x00025282
		public float SurfaceScale
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

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000F5F RID: 3935 RVA: 0x000274C4 File Offset: 0x000256C4
		// (set) Token: 0x06000F60 RID: 3936 RVA: 0x000274CD File Offset: 0x000256CD
		public RawVector3 Color
		{
			get
			{
				return base.GetVector3Value(6);
			}
			set
			{
				base.SetValue(6, value);
			}
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000F61 RID: 3937 RVA: 0x0002709F File Offset: 0x0002529F
		// (set) Token: 0x06000F62 RID: 3938 RVA: 0x000270A8 File Offset: 0x000252A8
		public RawVector2 KernelUnitLength
		{
			get
			{
				return base.GetVector2Value(7);
			}
			set
			{
				base.SetValue(7, value);
			}
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000F63 RID: 3939 RVA: 0x000275E4 File Offset: 0x000257E4
		// (set) Token: 0x06000F64 RID: 3940 RVA: 0x000275ED File Offset: 0x000257ED
		public SpotDiffuseScaleMode ScaleMode
		{
			get
			{
				return base.GetEnumValue<SpotDiffuseScaleMode>(8);
			}
			set
			{
				base.SetEnumValue<SpotDiffuseScaleMode>(8, value);
			}
		}
	}
}
