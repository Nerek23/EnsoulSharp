using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000365 RID: 869
	public class YCbCr : Effect
	{
		// Token: 0x06000FA5 RID: 4005 RVA: 0x000278B3 File Offset: 0x00025AB3
		public YCbCr(DeviceContext context) : base(context, Effect.YCbCr)
		{
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06000FA6 RID: 4006 RVA: 0x000278C1 File Offset: 0x00025AC1
		// (set) Token: 0x06000FA7 RID: 4007 RVA: 0x000278CA File Offset: 0x00025ACA
		public YcbcrChromaSubSampling ChromaSubSampling
		{
			get
			{
				return base.GetEnumValue<YcbcrChromaSubSampling>(0);
			}
			set
			{
				base.SetEnumValue<YcbcrChromaSubSampling>(0, value);
			}
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x06000FA8 RID: 4008 RVA: 0x000278D4 File Offset: 0x00025AD4
		// (set) Token: 0x06000FA9 RID: 4009 RVA: 0x000278DD File Offset: 0x00025ADD
		public RawMatrix3x2 Transform
		{
			get
			{
				return base.GetMatrix3x2Value(1);
			}
			set
			{
				base.SetValue(1, value);
			}
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x06000FAA RID: 4010 RVA: 0x000278E7 File Offset: 0x00025AE7
		// (set) Token: 0x06000FAB RID: 4011 RVA: 0x000278F0 File Offset: 0x00025AF0
		public YcbcrInterpolationMode InterpolationMode
		{
			get
			{
				return base.GetEnumValue<YcbcrInterpolationMode>(2);
			}
			set
			{
				base.SetEnumValue<YcbcrInterpolationMode>(2, value);
			}
		}
	}
}
