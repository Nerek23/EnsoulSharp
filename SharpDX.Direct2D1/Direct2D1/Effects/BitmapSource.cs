using System;
using SharpDX.Mathematics.Interop;
using SharpDX.WIC;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x0200033E RID: 830
	public class BitmapSource : Effect
	{
		// Token: 0x06000E1F RID: 3615 RVA: 0x00026D17 File Offset: 0x00024F17
		public BitmapSource(DeviceContext context) : base(context, Effect.BitmapSource)
		{
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000E20 RID: 3616 RVA: 0x00026D25 File Offset: 0x00024F25
		// (set) Token: 0x06000E21 RID: 3617 RVA: 0x00026D42 File Offset: 0x00024F42
		public BitmapSource WicBitmapSource
		{
			get
			{
				if (this.wicBitmapSource == null)
				{
					this.wicBitmapSource = base.GetComObjectValue<BitmapSource>(0);
				}
				return this.wicBitmapSource;
			}
			set
			{
				this.wicBitmapSource = value;
				base.SetValue<BitmapSource>(0, this.wicBitmapSource);
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000E22 RID: 3618 RVA: 0x00026D58 File Offset: 0x00024F58
		// (set) Token: 0x06000E23 RID: 3619 RVA: 0x00026D61 File Offset: 0x00024F61
		public RawVector2 ScaleSource
		{
			get
			{
				return base.GetVector2Value(1);
			}
			set
			{
				base.SetValue(1, value);
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000E24 RID: 3620 RVA: 0x00026D6B File Offset: 0x00024F6B
		// (set) Token: 0x06000E25 RID: 3621 RVA: 0x00026D74 File Offset: 0x00024F74
		public InterpolationMode InterpolationMode
		{
			get
			{
				return base.GetEnumValue<InterpolationMode>(2);
			}
			set
			{
				base.SetEnumValue<InterpolationMode>(2, value);
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000E26 RID: 3622 RVA: 0x00026D7E File Offset: 0x00024F7E
		// (set) Token: 0x06000E27 RID: 3623 RVA: 0x00026D87 File Offset: 0x00024F87
		public bool EnableDpiCorrection
		{
			get
			{
				return base.GetBoolValue(3);
			}
			set
			{
				base.SetValue(3, value);
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000E28 RID: 3624 RVA: 0x00026D91 File Offset: 0x00024F91
		// (set) Token: 0x06000E29 RID: 3625 RVA: 0x00026D9A File Offset: 0x00024F9A
		public AlphaMode AlphaMode
		{
			get
			{
				return base.GetEnumValue<AlphaMode>(4);
			}
			set
			{
				base.SetEnumValue<AlphaMode>(4, value);
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000E2A RID: 3626 RVA: 0x00026DA4 File Offset: 0x00024FA4
		// (set) Token: 0x06000E2B RID: 3627 RVA: 0x00026DAD File Offset: 0x00024FAD
		public BitmapSourceOrientation Orientation
		{
			get
			{
				return base.GetEnumValue<BitmapSourceOrientation>(5);
			}
			set
			{
				base.SetEnumValue<BitmapSourceOrientation>(5, value);
			}
		}

		// Token: 0x04000B34 RID: 2868
		private BitmapSource wicBitmapSource;
	}
}
