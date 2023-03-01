using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000343 RID: 835
	public class ColorMatrix : Effect
	{
		// Token: 0x06000E44 RID: 3652 RVA: 0x00026EDA File Offset: 0x000250DA
		public ColorMatrix(DeviceContext context) : base(context, Effect.ColorMatrix)
		{
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000E45 RID: 3653 RVA: 0x00026EE8 File Offset: 0x000250E8
		// (set) Token: 0x06000E46 RID: 3654 RVA: 0x00026EF1 File Offset: 0x000250F1
		public RawMatrix5x4 Matrix
		{
			get
			{
				return base.GetMatrix5x4Value(0);
			}
			set
			{
				base.SetValue(0, value);
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000E47 RID: 3655 RVA: 0x00026EFB File Offset: 0x000250FB
		// (set) Token: 0x06000E48 RID: 3656 RVA: 0x00026F04 File Offset: 0x00025104
		public AlphaMode AlphaMode
		{
			get
			{
				return base.GetEnumValue<AlphaMode>(1);
			}
			set
			{
				base.SetEnumValue<AlphaMode>(1, value);
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000E49 RID: 3657 RVA: 0x00026F0E File Offset: 0x0002510E
		// (set) Token: 0x06000E4A RID: 3658 RVA: 0x00026F17 File Offset: 0x00025117
		public bool ClampOutput
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
	}
}
