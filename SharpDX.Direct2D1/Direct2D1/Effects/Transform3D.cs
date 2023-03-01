using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000362 RID: 866
	public class Transform3D : Effect
	{
		// Token: 0x06000F90 RID: 3984 RVA: 0x0002782A File Offset: 0x00025A2A
		public Transform3D(DeviceContext context) : base(context, Effect.Transform3D)
		{
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000F91 RID: 3985 RVA: 0x00026C76 File Offset: 0x00024E76
		// (set) Token: 0x06000F92 RID: 3986 RVA: 0x00026C7F File Offset: 0x00024E7F
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

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06000F93 RID: 3987 RVA: 0x00026C89 File Offset: 0x00024E89
		// (set) Token: 0x06000F94 RID: 3988 RVA: 0x00026C92 File Offset: 0x00024E92
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

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06000F95 RID: 3989 RVA: 0x00027838 File Offset: 0x00025A38
		// (set) Token: 0x06000F96 RID: 3990 RVA: 0x00027841 File Offset: 0x00025A41
		public RawMatrix TransformMatrix
		{
			get
			{
				return base.GetMatrixValue(2);
			}
			set
			{
				base.SetValue(2, value);
			}
		}
	}
}
