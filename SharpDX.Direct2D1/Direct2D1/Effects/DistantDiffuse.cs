using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x0200034A RID: 842
	public class DistantDiffuse : Effect
	{
		// Token: 0x06000E8B RID: 3723 RVA: 0x0002719E File Offset: 0x0002539E
		public DistantDiffuse(DeviceContext context) : base(context, Effect.DistantDiffuse)
		{
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000E8C RID: 3724 RVA: 0x00026F50 File Offset: 0x00025150
		// (set) Token: 0x06000E8D RID: 3725 RVA: 0x00026F59 File Offset: 0x00025159
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

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000E8E RID: 3726 RVA: 0x000270F6 File Offset: 0x000252F6
		// (set) Token: 0x06000E8F RID: 3727 RVA: 0x000270FF File Offset: 0x000252FF
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

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000E90 RID: 3728 RVA: 0x000271AC File Offset: 0x000253AC
		// (set) Token: 0x06000E91 RID: 3729 RVA: 0x000271B5 File Offset: 0x000253B5
		public float DiffuseConstant
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

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000E92 RID: 3730 RVA: 0x00026CAF File Offset: 0x00024EAF
		// (set) Token: 0x06000E93 RID: 3731 RVA: 0x00026CB8 File Offset: 0x00024EB8
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

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000E94 RID: 3732 RVA: 0x000271BF File Offset: 0x000253BF
		// (set) Token: 0x06000E95 RID: 3733 RVA: 0x000271C8 File Offset: 0x000253C8
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

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000E96 RID: 3734 RVA: 0x000271D2 File Offset: 0x000253D2
		// (set) Token: 0x06000E97 RID: 3735 RVA: 0x000271DB File Offset: 0x000253DB
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

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000E98 RID: 3736 RVA: 0x000271E5 File Offset: 0x000253E5
		// (set) Token: 0x06000E99 RID: 3737 RVA: 0x000271EE File Offset: 0x000253EE
		public DistantDiffuseScaleMode ScaleMode
		{
			get
			{
				return base.GetEnumValue<DistantDiffuseScaleMode>(6);
			}
			set
			{
				base.SetEnumValue<DistantDiffuseScaleMode>(6, value);
			}
		}
	}
}
