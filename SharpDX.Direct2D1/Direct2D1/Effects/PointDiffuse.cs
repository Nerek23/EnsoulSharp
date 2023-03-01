using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000358 RID: 856
	public class PointDiffuse : Effect
	{
		// Token: 0x06000F20 RID: 3872 RVA: 0x000274EA File Offset: 0x000256EA
		public PointDiffuse(DeviceContext context) : base(context, Effect.PointDiffuse)
		{
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000F21 RID: 3873 RVA: 0x000274F8 File Offset: 0x000256F8
		// (set) Token: 0x06000F22 RID: 3874 RVA: 0x00027501 File Offset: 0x00025701
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

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000F23 RID: 3875 RVA: 0x000270F6 File Offset: 0x000252F6
		// (set) Token: 0x06000F24 RID: 3876 RVA: 0x000270FF File Offset: 0x000252FF
		public float DiffuseConstant
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

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000F25 RID: 3877 RVA: 0x000271AC File Offset: 0x000253AC
		// (set) Token: 0x06000F26 RID: 3878 RVA: 0x000271B5 File Offset: 0x000253B5
		public float SurfaceScale
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

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000F27 RID: 3879 RVA: 0x0002750B File Offset: 0x0002570B
		// (set) Token: 0x06000F28 RID: 3880 RVA: 0x00027514 File Offset: 0x00025714
		public RawVector3 Color
		{
			get
			{
				return base.GetVector3Value(3);
			}
			set
			{
				base.SetValue(3, value);
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000F29 RID: 3881 RVA: 0x0002751E File Offset: 0x0002571E
		// (set) Token: 0x06000F2A RID: 3882 RVA: 0x00027527 File Offset: 0x00025727
		public RawVector2 KernelUnitLength
		{
			get
			{
				return base.GetVector2Value(4);
			}
			set
			{
				base.SetValue(4, value);
			}
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000F2B RID: 3883 RVA: 0x00027531 File Offset: 0x00025731
		// (set) Token: 0x06000F2C RID: 3884 RVA: 0x0002753A File Offset: 0x0002573A
		public PointDiffuseScaleMode ScaleMode
		{
			get
			{
				return base.GetEnumValue<PointDiffuseScaleMode>(5);
			}
			set
			{
				base.SetEnumValue<PointDiffuseScaleMode>(5, value);
			}
		}
	}
}
