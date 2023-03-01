using System;
using SharpDX.Win32;

namespace SharpDX.WIC
{
	// Token: 0x02000008 RID: 8
	public class BitmapEncoderOptions : PropertyBag
	{
		// Token: 0x06000077 RID: 119 RVA: 0x000036A2 File Offset: 0x000018A2
		public BitmapEncoderOptions(IntPtr propertyBagPointer) : base(propertyBagPointer)
		{
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000078 RID: 120 RVA: 0x000036AB File Offset: 0x000018AB
		// (set) Token: 0x06000079 RID: 121 RVA: 0x000036B8 File Offset: 0x000018B8
		public float ImageQuality
		{
			get
			{
				return base.Get<float, float>(BitmapEncoderOptions.ImageQualityKey);
			}
			set
			{
				base.Set<float, float>(BitmapEncoderOptions.ImageQualityKey, value);
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600007A RID: 122 RVA: 0x000036C6 File Offset: 0x000018C6
		// (set) Token: 0x0600007B RID: 123 RVA: 0x000036D3 File Offset: 0x000018D3
		public float CompressionQuality
		{
			get
			{
				return base.Get<float, float>(BitmapEncoderOptions.CompressionQualityKey);
			}
			set
			{
				base.Set<float, float>(BitmapEncoderOptions.CompressionQualityKey, value);
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600007C RID: 124 RVA: 0x000036E1 File Offset: 0x000018E1
		// (set) Token: 0x0600007D RID: 125 RVA: 0x000036EE File Offset: 0x000018EE
		public bool LossLess
		{
			get
			{
				return base.Get<bool, bool>(BitmapEncoderOptions.LosslessKey);
			}
			set
			{
				base.Set<bool, bool>(BitmapEncoderOptions.LosslessKey, value);
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600007E RID: 126 RVA: 0x000036FC File Offset: 0x000018FC
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00003709 File Offset: 0x00001909
		public BitmapTransformOptions BitmapTransform
		{
			get
			{
				return base.Get<BitmapTransformOptions, byte>(BitmapEncoderOptions.BitmapTransformKey);
			}
			set
			{
				base.Set<BitmapTransformOptions, byte>(BitmapEncoderOptions.BitmapTransformKey, value);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00003717 File Offset: 0x00001917
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00003724 File Offset: 0x00001924
		public bool InterlaceOption
		{
			get
			{
				return base.Get<bool, bool>(BitmapEncoderOptions.InterlaceOptionKey);
			}
			set
			{
				base.Set<bool, bool>(BitmapEncoderOptions.InterlaceOptionKey, value);
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00003732 File Offset: 0x00001932
		// (set) Token: 0x06000083 RID: 131 RVA: 0x0000373F File Offset: 0x0000193F
		public PngFilterOption FilterOption
		{
			get
			{
				return base.Get<PngFilterOption, byte>(BitmapEncoderOptions.FilterOptionKey);
			}
			set
			{
				base.Set<PngFilterOption, byte>(BitmapEncoderOptions.FilterOptionKey, value);
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000084 RID: 132 RVA: 0x0000374D File Offset: 0x0000194D
		// (set) Token: 0x06000085 RID: 133 RVA: 0x0000375A File Offset: 0x0000195A
		public TiffCompressionOption TiffCompressionMethod
		{
			get
			{
				return base.Get<TiffCompressionOption, bool>(BitmapEncoderOptions.TiffCompressionMethodKey);
			}
			set
			{
				base.Set<TiffCompressionOption, bool>(BitmapEncoderOptions.TiffCompressionMethodKey, value);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00003768 File Offset: 0x00001968
		// (set) Token: 0x06000087 RID: 135 RVA: 0x00003775 File Offset: 0x00001975
		public uint[] Luminance
		{
			get
			{
				return base.Get<uint[], uint[]>(BitmapEncoderOptions.LuminanceKey);
			}
			set
			{
				base.Set<uint[], uint[]>(BitmapEncoderOptions.LuminanceKey, value);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00003783 File Offset: 0x00001983
		// (set) Token: 0x06000089 RID: 137 RVA: 0x00003790 File Offset: 0x00001990
		public uint[] Chrominance
		{
			get
			{
				return base.Get<uint[], uint[]>(BitmapEncoderOptions.ChrominanceKey);
			}
			set
			{
				base.Set<uint[], uint[]>(BitmapEncoderOptions.ChrominanceKey, value);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600008A RID: 138 RVA: 0x0000379E File Offset: 0x0000199E
		// (set) Token: 0x0600008B RID: 139 RVA: 0x000037AB File Offset: 0x000019AB
		public JpegYCrCbSubsamplingOption JpegYCrCbSubsampling
		{
			get
			{
				return base.Get<JpegYCrCbSubsamplingOption, byte>(BitmapEncoderOptions.JpegYCrCbSubsamplingKey);
			}
			set
			{
				base.Set<JpegYCrCbSubsamplingOption, byte>(BitmapEncoderOptions.JpegYCrCbSubsamplingKey, value);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600008C RID: 140 RVA: 0x000037B9 File Offset: 0x000019B9
		// (set) Token: 0x0600008D RID: 141 RVA: 0x000037C6 File Offset: 0x000019C6
		public bool SuppressApp0
		{
			get
			{
				return base.Get<bool, bool>(BitmapEncoderOptions.SuppressApp0Key);
			}
			set
			{
				base.Set<bool, bool>(BitmapEncoderOptions.SuppressApp0Key, value);
			}
		}

		// Token: 0x04000004 RID: 4
		private static readonly PropertyBagKey<float, float> ImageQualityKey = new PropertyBagKey<float, float>("ImageQuality");

		// Token: 0x04000005 RID: 5
		private static readonly PropertyBagKey<float, float> CompressionQualityKey = new PropertyBagKey<float, float>("CompressionQuality");

		// Token: 0x04000006 RID: 6
		private static readonly PropertyBagKey<bool, bool> LosslessKey = new PropertyBagKey<bool, bool>("Lossless");

		// Token: 0x04000007 RID: 7
		private static readonly PropertyBagKey<BitmapTransformOptions, byte> BitmapTransformKey = new PropertyBagKey<BitmapTransformOptions, byte>("BitmapTransform");

		// Token: 0x04000008 RID: 8
		private static readonly PropertyBagKey<bool, bool> InterlaceOptionKey = new PropertyBagKey<bool, bool>("InterlaceOption");

		// Token: 0x04000009 RID: 9
		private static readonly PropertyBagKey<PngFilterOption, byte> FilterOptionKey = new PropertyBagKey<PngFilterOption, byte>("FilterOption");

		// Token: 0x0400000A RID: 10
		private static readonly PropertyBagKey<TiffCompressionOption, bool> TiffCompressionMethodKey = new PropertyBagKey<TiffCompressionOption, bool>("TiffCompressionMethod");

		// Token: 0x0400000B RID: 11
		private static readonly PropertyBagKey<uint[], uint[]> LuminanceKey = new PropertyBagKey<uint[], uint[]>("Luminance");

		// Token: 0x0400000C RID: 12
		private static readonly PropertyBagKey<uint[], uint[]> ChrominanceKey = new PropertyBagKey<uint[], uint[]>("Chrominance");

		// Token: 0x0400000D RID: 13
		private static readonly PropertyBagKey<JpegYCrCbSubsamplingOption, byte> JpegYCrCbSubsamplingKey = new PropertyBagKey<JpegYCrCbSubsamplingOption, byte>("JpegYCrCbSubsampling");

		// Token: 0x0400000E RID: 14
		private static readonly PropertyBagKey<bool, bool> SuppressApp0Key = new PropertyBagKey<bool, bool>("SuppressApp0");
	}
}
