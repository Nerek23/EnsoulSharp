using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x0200033B RID: 827
	public class AffineTransform2D : Effect
	{
		// Token: 0x06000E0C RID: 3596 RVA: 0x00026C68 File Offset: 0x00024E68
		public AffineTransform2D(DeviceContext context) : base(context, Effect.AffineTransform2D)
		{
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000E0D RID: 3597 RVA: 0x00026C76 File Offset: 0x00024E76
		// (set) Token: 0x06000E0E RID: 3598 RVA: 0x00026C7F File Offset: 0x00024E7F
		public InterpolationMode InterpolationMode
		{
			get
			{
				return base.GetEnumValue<InterpolationMode>(0);
			}
			set
			{
				base.SetEnumValue<InterpolationMode>(0, value);
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000E0F RID: 3599 RVA: 0x00026C89 File Offset: 0x00024E89
		// (set) Token: 0x06000E10 RID: 3600 RVA: 0x00026C92 File Offset: 0x00024E92
		public BorderMode BorderMode
		{
			get
			{
				return base.GetEnumValue<BorderMode>(1);
			}
			set
			{
				base.SetEnumValue<BorderMode>(1, value);
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000E11 RID: 3601 RVA: 0x00026C9C File Offset: 0x00024E9C
		// (set) Token: 0x06000E12 RID: 3602 RVA: 0x00026CA5 File Offset: 0x00024EA5
		public RawMatrix3x2 TransformMatrix
		{
			get
			{
				return base.GetMatrix3x2Value(2);
			}
			set
			{
				base.SetValue(2, value);
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000E13 RID: 3603 RVA: 0x00026CAF File Offset: 0x00024EAF
		// (set) Token: 0x06000E14 RID: 3604 RVA: 0x00026CB8 File Offset: 0x00024EB8
		public float Sharpness
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
	}
}
