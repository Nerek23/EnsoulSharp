using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000359 RID: 857
	public class PointSpecular : Effect
	{
		// Token: 0x06000F2D RID: 3885 RVA: 0x00027544 File Offset: 0x00025744
		public PointSpecular(DeviceContext context) : base(context, Effect.PointSpecular)
		{
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000F2E RID: 3886 RVA: 0x000274F8 File Offset: 0x000256F8
		// (set) Token: 0x06000F2F RID: 3887 RVA: 0x00027501 File Offset: 0x00025701
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

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000F30 RID: 3888 RVA: 0x000270F6 File Offset: 0x000252F6
		// (set) Token: 0x06000F31 RID: 3889 RVA: 0x000270FF File Offset: 0x000252FF
		public float SpecularExponent
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

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000F32 RID: 3890 RVA: 0x000271AC File Offset: 0x000253AC
		// (set) Token: 0x06000F33 RID: 3891 RVA: 0x000271B5 File Offset: 0x000253B5
		public float SpecularConstant
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

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000F34 RID: 3892 RVA: 0x00026CAF File Offset: 0x00024EAF
		// (set) Token: 0x06000F35 RID: 3893 RVA: 0x00026CB8 File Offset: 0x00024EB8
		public float SurfaceScale
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

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000F36 RID: 3894 RVA: 0x000271BF File Offset: 0x000253BF
		// (set) Token: 0x06000F37 RID: 3895 RVA: 0x000271C8 File Offset: 0x000253C8
		public RawVector3 Color
		{
			get
			{
				return base.GetVector3Value(4);
			}
			set
			{
				base.SetValue(4, value);
			}
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000F38 RID: 3896 RVA: 0x000271D2 File Offset: 0x000253D2
		// (set) Token: 0x06000F39 RID: 3897 RVA: 0x000271DB File Offset: 0x000253DB
		public RawVector2 KernelUnitLength
		{
			get
			{
				return base.GetVector2Value(5);
			}
			set
			{
				base.SetValue(5, value);
			}
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000F3A RID: 3898 RVA: 0x00027552 File Offset: 0x00025752
		// (set) Token: 0x06000F3B RID: 3899 RVA: 0x0002755B File Offset: 0x0002575B
		public PointSpecularScaleMode ScaleMode
		{
			get
			{
				return base.GetEnumValue<PointSpecularScaleMode>(6);
			}
			set
			{
				base.SetEnumValue<PointSpecularScaleMode>(6, value);
			}
		}
	}
}
