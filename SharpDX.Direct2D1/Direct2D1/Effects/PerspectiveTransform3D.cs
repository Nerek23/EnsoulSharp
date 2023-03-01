using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000357 RID: 855
	public class PerspectiveTransform3D : Effect
	{
		// Token: 0x06000F0F RID: 3855 RVA: 0x00027490 File Offset: 0x00025690
		public PerspectiveTransform3D(DeviceContext deviceContext) : base(deviceContext, Effect.PerspectiveTransform3D)
		{
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000F10 RID: 3856 RVA: 0x0002749E File Offset: 0x0002569E
		// (set) Token: 0x06000F11 RID: 3857 RVA: 0x000274A7 File Offset: 0x000256A7
		public PerspectiveTransform3DInteroplationMode InterpolationMode
		{
			get
			{
				return base.GetEnumValue<PerspectiveTransform3DInteroplationMode>(0);
			}
			set
			{
				base.SetEnumValue<PerspectiveTransform3DInteroplationMode>(0, value);
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000F12 RID: 3858 RVA: 0x00026C89 File Offset: 0x00024E89
		// (set) Token: 0x06000F13 RID: 3859 RVA: 0x00026C92 File Offset: 0x00024E92
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

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000F14 RID: 3860 RVA: 0x000271AC File Offset: 0x000253AC
		// (set) Token: 0x06000F15 RID: 3861 RVA: 0x000271B5 File Offset: 0x000253B5
		public float Depth
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

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000F16 RID: 3862 RVA: 0x000274B1 File Offset: 0x000256B1
		// (set) Token: 0x06000F17 RID: 3863 RVA: 0x000274BA File Offset: 0x000256BA
		public RawVector2 PerspectiveOrigin
		{
			get
			{
				return base.GetVector2Value(3);
			}
			set
			{
				base.SetValue(3, value);
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000F18 RID: 3864 RVA: 0x000271BF File Offset: 0x000253BF
		// (set) Token: 0x06000F19 RID: 3865 RVA: 0x000271C8 File Offset: 0x000253C8
		public RawVector3 LocalOffset
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

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000F1A RID: 3866 RVA: 0x00027219 File Offset: 0x00025419
		// (set) Token: 0x06000F1B RID: 3867 RVA: 0x00027222 File Offset: 0x00025422
		public RawVector3 GlobalOffset
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

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000F1C RID: 3868 RVA: 0x000274C4 File Offset: 0x000256C4
		// (set) Token: 0x06000F1D RID: 3869 RVA: 0x000274CD File Offset: 0x000256CD
		public RawVector3 RotationOrigin
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

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000F1E RID: 3870 RVA: 0x000274D7 File Offset: 0x000256D7
		// (set) Token: 0x06000F1F RID: 3871 RVA: 0x000274E0 File Offset: 0x000256E0
		public RawVector3 Rotation
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
	}
}
