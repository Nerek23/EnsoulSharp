using System;
using System.Collections.Generic;
using System.Globalization;

namespace SharpDX.WIC
{
	// Token: 0x02000028 RID: 40
	public sealed class PixelFormat
	{
		// Token: 0x060001A3 RID: 419 RVA: 0x00006BB4 File Offset: 0x00004DB4
		public static int GetBitsPerPixel(Guid guid)
		{
			int result;
			PixelFormat.mapGuidToSize.TryGetValue(guid, out result);
			return result;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00006BD0 File Offset: 0x00004DD0
		public static int GetStride(Guid guid, int width)
		{
			int bitsPerPixel = PixelFormat.GetBitsPerPixel(guid);
			if (bitsPerPixel == 0)
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid PixelFormat guid [{0}]. Unable to calculate stride", new object[]
				{
					guid
				}));
			}
			return (bitsPerPixel * width + 7) / 8;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00006C14 File Offset: 0x00004E14
		static PixelFormat()
		{
			PixelFormat.mapGuidToSize = new Dictionary<Guid, int>
			{
				{
					PixelFormat.Format72bpp8ChannelsAlpha,
					72
				},
				{
					PixelFormat.Format48bppBGRFixedPoint,
					48
				},
				{
					PixelFormat.Format64bppCMYK,
					64
				},
				{
					PixelFormat.Format40bpp5Channels,
					40
				},
				{
					PixelFormat.Format4bppIndexed,
					4
				},
				{
					PixelFormat.Format128bppRGBAFixedPoint,
					128
				},
				{
					PixelFormat.Format40bpp4ChannelsAlpha,
					40
				},
				{
					PixelFormat.Format32bppGrayFixedPoint,
					32
				},
				{
					PixelFormat.Format48bpp6Channels,
					48
				},
				{
					PixelFormat.Format16bppGray,
					16
				},
				{
					PixelFormat.Format1bppIndexed,
					1
				},
				{
					PixelFormat.Format32bpp3ChannelsAlpha,
					32
				},
				{
					PixelFormat.Format64bppRGBAFixedPoint,
					64
				},
				{
					PixelFormat.Format80bpp4ChannelsAlpha,
					80
				},
				{
					PixelFormat.Format64bpp8Channels,
					64
				},
				{
					PixelFormat.Format16bppBGR555,
					16
				},
				{
					PixelFormat.Format16bppBGR565,
					16
				},
				{
					PixelFormat.Format32bppRGBA1010102XR,
					32
				},
				{
					PixelFormat.Format24bppRGB,
					24
				},
				{
					PixelFormat.Format128bppRGBFloat,
					128
				},
				{
					PixelFormat.Format32bppBGR,
					32
				},
				{
					PixelFormat.Format64bppRGBA,
					64
				},
				{
					PixelFormat.FormatDontCare,
					0
				},
				{
					PixelFormat.Format40bppCMYKAlpha,
					40
				},
				{
					PixelFormat.Format32bppPRGBA,
					32
				},
				{
					PixelFormat.Format24bpp3Channels,
					24
				},
				{
					PixelFormat.Format32bppRGBE,
					32
				},
				{
					PixelFormat.Format24bppBGR,
					24
				},
				{
					PixelFormat.Format64bppRGBFixedPoint,
					64
				},
				{
					PixelFormat.Format96bppRGBFixedPoint,
					96
				},
				{
					PixelFormat.Format128bppRGBFixedPoint,
					128
				},
				{
					PixelFormat.Format144bpp8ChannelsAlpha,
					144
				},
				{
					PixelFormat.Format64bppBGRAFixedPoint,
					64
				},
				{
					PixelFormat.Format32bppCMYK,
					32
				},
				{
					PixelFormat.Format32bppGrayFloat,
					32
				},
				{
					PixelFormat.Format48bpp3Channels,
					48
				},
				{
					PixelFormat.Format32bppBGR101010,
					32
				},
				{
					PixelFormat.Format2bppGray,
					2
				},
				{
					PixelFormat.Format56bpp7Channels,
					56
				},
				{
					PixelFormat.Format16bppBGRA5551,
					16
				},
				{
					PixelFormat.Format48bppRGBFixedPoint,
					48
				},
				{
					PixelFormat.Format32bppRGBA1010102,
					32
				},
				{
					PixelFormat.Format64bppPBGRA,
					64
				},
				{
					PixelFormat.Format96bpp6Channels,
					96
				},
				{
					PixelFormat.Format32bppPBGRA,
					32
				},
				{
					PixelFormat.Format64bpp4Channels,
					64
				},
				{
					PixelFormat.Format96bpp5ChannelsAlpha,
					48
				},
				{
					PixelFormat.Format48bppRGBHalf,
					96
				},
				{
					PixelFormat.Format48bpp5ChannelsAlpha,
					48
				},
				{
					PixelFormat.Format8bppGray,
					8
				},
				{
					PixelFormat.Format128bpp7ChannelsAlpha,
					128
				},
				{
					PixelFormat.Format32bppRGBA,
					32
				},
				{
					PixelFormat.Format80bpp5Channels,
					80
				},
				{
					PixelFormat.Format64bppPRGBA,
					64
				},
				{
					PixelFormat.Format16bppGrayFixedPoint,
					16
				},
				{
					PixelFormat.Format112bpp7Channels,
					112
				},
				{
					PixelFormat.Format128bpp8Channels,
					128
				},
				{
					PixelFormat.Format80bppCMYKAlpha,
					80
				},
				{
					PixelFormat.Format8bppAlpha,
					8
				},
				{
					PixelFormat.Format4bppGray,
					4
				},
				{
					PixelFormat.FormatBlackWhite,
					0
				},
				{
					PixelFormat.Format32bppBGRA,
					32
				},
				{
					PixelFormat.Format128bppRGBAFloat,
					128
				},
				{
					PixelFormat.Format112bpp6ChannelsAlpha,
					112
				},
				{
					PixelFormat.Format64bppRGBAHalf,
					64
				},
				{
					PixelFormat.Format16bppGrayHalf,
					16
				},
				{
					PixelFormat.Format2bppIndexed,
					2
				},
				{
					PixelFormat.Format64bppBGRA,
					64
				},
				{
					PixelFormat.Format8bppIndexed,
					8
				},
				{
					PixelFormat.Format56bpp6ChannelsAlpha,
					56
				},
				{
					PixelFormat.Format48bppBGR,
					48
				},
				{
					PixelFormat.Format128bppPRGBAFloat,
					128
				},
				{
					PixelFormat.Format64bpp7ChannelsAlpha,
					64
				},
				{
					PixelFormat.Format64bpp3ChannelsAlpha,
					64
				},
				{
					PixelFormat.Format64bppRGBHalf,
					64
				},
				{
					PixelFormat.Format48bppRGB,
					48
				},
				{
					PixelFormat.Format32bpp4Channels,
					32
				}
			};
		}

		// Token: 0x0400001F RID: 31
		private static Dictionary<Guid, int> mapGuidToSize;

		// Token: 0x04000020 RID: 32
		public static readonly Guid FormatDontCare = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc900");

		// Token: 0x04000021 RID: 33
		public static readonly Guid Format1bppIndexed = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc901");

		// Token: 0x04000022 RID: 34
		public static readonly Guid Format2bppIndexed = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc902");

		// Token: 0x04000023 RID: 35
		public static readonly Guid Format4bppIndexed = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc903");

		// Token: 0x04000024 RID: 36
		public static readonly Guid Format8bppIndexed = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc904");

		// Token: 0x04000025 RID: 37
		public static readonly Guid FormatBlackWhite = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc905");

		// Token: 0x04000026 RID: 38
		public static readonly Guid Format2bppGray = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc906");

		// Token: 0x04000027 RID: 39
		public static readonly Guid Format4bppGray = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc907");

		// Token: 0x04000028 RID: 40
		public static readonly Guid Format8bppGray = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc908");

		// Token: 0x04000029 RID: 41
		public static readonly Guid Format8bppAlpha = new Guid("e6cd0116-eeba-4161-aa85-27dd9fb3a895");

		// Token: 0x0400002A RID: 42
		public static readonly Guid Format16bppBGR555 = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc909");

		// Token: 0x0400002B RID: 43
		public static readonly Guid Format16bppBGR565 = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc90a");

		// Token: 0x0400002C RID: 44
		public static readonly Guid Format16bppBGRA5551 = new Guid("05ec7c2b-f1e6-4961-ad46-e1cc810a87d2");

		// Token: 0x0400002D RID: 45
		public static readonly Guid Format16bppGray = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc90b");

		// Token: 0x0400002E RID: 46
		public static readonly Guid Format24bppBGR = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc90c");

		// Token: 0x0400002F RID: 47
		public static readonly Guid Format24bppRGB = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc90d");

		// Token: 0x04000030 RID: 48
		public static readonly Guid Format32bppBGR = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc90e");

		// Token: 0x04000031 RID: 49
		public static readonly Guid Format32bppBGRA = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc90f");

		// Token: 0x04000032 RID: 50
		public static readonly Guid Format32bppPBGRA = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc910");

		// Token: 0x04000033 RID: 51
		public static readonly Guid Format32bppGrayFloat = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc911");

		// Token: 0x04000034 RID: 52
		public static readonly Guid Format32bppRGB = new Guid("d98c6b95-3efe-47d6-bb25-eb1748ab0cf1");

		// Token: 0x04000035 RID: 53
		public static readonly Guid Format32bppRGBA = new Guid("f5c7ad2d-6a8d-43dd-a7a8-a29935261ae9");

		// Token: 0x04000036 RID: 54
		public static readonly Guid Format32bppPRGBA = new Guid("3cc4a650-a527-4d37-a916-3142c7ebedba");

		// Token: 0x04000037 RID: 55
		public static readonly Guid Format48bppRGB = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc915");

		// Token: 0x04000038 RID: 56
		public static readonly Guid Format48bppBGR = new Guid("e605a384-b468-46ce-bb2e-36f180e64313");

		// Token: 0x04000039 RID: 57
		public static readonly Guid Format64bppRGB = new Guid("a1182111-186d-4d42-bc6a-9c8303a8dff9");

		// Token: 0x0400003A RID: 58
		public static readonly Guid Format64bppRGBA = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc916");

		// Token: 0x0400003B RID: 59
		public static readonly Guid Format64bppBGRA = new Guid("1562ff7c-d352-46f9-979e-42976b792246");

		// Token: 0x0400003C RID: 60
		public static readonly Guid Format64bppPRGBA = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc917");

		// Token: 0x0400003D RID: 61
		public static readonly Guid Format64bppPBGRA = new Guid("8c518e8e-a4ec-468b-ae70-c9a35a9c5530");

		// Token: 0x0400003E RID: 62
		public static readonly Guid Format16bppGrayFixedPoint = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc913");

		// Token: 0x0400003F RID: 63
		public static readonly Guid Format32bppBGR101010 = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc914");

		// Token: 0x04000040 RID: 64
		public static readonly Guid Format48bppRGBFixedPoint = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc912");

		// Token: 0x04000041 RID: 65
		public static readonly Guid Format48bppBGRFixedPoint = new Guid("49ca140e-cab6-493b-9ddf-60187c37532a");

		// Token: 0x04000042 RID: 66
		public static readonly Guid Format96bppRGBFixedPoint = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc918");

		// Token: 0x04000043 RID: 67
		public static readonly Guid Format96bppRGBFloat = new Guid("e3fed78f-e8db-4acf-84c1-e97f6136b327");

		// Token: 0x04000044 RID: 68
		public static readonly Guid Format128bppRGBAFloat = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc919");

		// Token: 0x04000045 RID: 69
		public static readonly Guid Format128bppPRGBAFloat = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc91a");

		// Token: 0x04000046 RID: 70
		public static readonly Guid Format128bppRGBFloat = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc91b");

		// Token: 0x04000047 RID: 71
		public static readonly Guid Format32bppCMYK = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc91c");

		// Token: 0x04000048 RID: 72
		public static readonly Guid Format64bppRGBAFixedPoint = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc91d");

		// Token: 0x04000049 RID: 73
		public static readonly Guid Format64bppBGRAFixedPoint = new Guid("356de33c-54d2-4a23-bb04-9b7bf9b1d42d");

		// Token: 0x0400004A RID: 74
		public static readonly Guid Format64bppRGBFixedPoint = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc940");

		// Token: 0x0400004B RID: 75
		public static readonly Guid Format128bppRGBAFixedPoint = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc91e");

		// Token: 0x0400004C RID: 76
		public static readonly Guid Format128bppRGBFixedPoint = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc941");

		// Token: 0x0400004D RID: 77
		public static readonly Guid Format64bppRGBAHalf = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc93a");

		// Token: 0x0400004E RID: 78
		public static readonly Guid Format64bppPRGBAHalf = new Guid("58ad26c2-c623-4d9d-b320-387e49f8c442");

		// Token: 0x0400004F RID: 79
		public static readonly Guid Format64bppRGBHalf = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc942");

		// Token: 0x04000050 RID: 80
		public static readonly Guid Format48bppRGBHalf = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc93b");

		// Token: 0x04000051 RID: 81
		public static readonly Guid Format32bppRGBE = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc93d");

		// Token: 0x04000052 RID: 82
		public static readonly Guid Format16bppGrayHalf = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc93e");

		// Token: 0x04000053 RID: 83
		public static readonly Guid Format32bppGrayFixedPoint = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc93f");

		// Token: 0x04000054 RID: 84
		public static readonly Guid Format32bppRGBA1010102 = new Guid("25238d72-fcf9-4522-b514-5578e5ad55e0");

		// Token: 0x04000055 RID: 85
		public static readonly Guid Format32bppRGBA1010102XR = new Guid("00de6b9a-c101-434b-b502-d0165ee1122c");

		// Token: 0x04000056 RID: 86
		public static readonly Guid Format64bppCMYK = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc91f");

		// Token: 0x04000057 RID: 87
		public static readonly Guid Format24bpp3Channels = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc920");

		// Token: 0x04000058 RID: 88
		public static readonly Guid Format32bpp4Channels = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc921");

		// Token: 0x04000059 RID: 89
		public static readonly Guid Format40bpp5Channels = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc922");

		// Token: 0x0400005A RID: 90
		public static readonly Guid Format48bpp6Channels = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc923");

		// Token: 0x0400005B RID: 91
		public static readonly Guid Format56bpp7Channels = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc924");

		// Token: 0x0400005C RID: 92
		public static readonly Guid Format64bpp8Channels = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc925");

		// Token: 0x0400005D RID: 93
		public static readonly Guid Format48bpp3Channels = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc926");

		// Token: 0x0400005E RID: 94
		public static readonly Guid Format64bpp4Channels = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc927");

		// Token: 0x0400005F RID: 95
		public static readonly Guid Format80bpp5Channels = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc928");

		// Token: 0x04000060 RID: 96
		public static readonly Guid Format96bpp6Channels = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc929");

		// Token: 0x04000061 RID: 97
		public static readonly Guid Format112bpp7Channels = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc92a");

		// Token: 0x04000062 RID: 98
		public static readonly Guid Format128bpp8Channels = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc92b");

		// Token: 0x04000063 RID: 99
		public static readonly Guid Format40bppCMYKAlpha = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc92c");

		// Token: 0x04000064 RID: 100
		public static readonly Guid Format80bppCMYKAlpha = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc92d");

		// Token: 0x04000065 RID: 101
		public static readonly Guid Format32bpp3ChannelsAlpha = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc92e");

		// Token: 0x04000066 RID: 102
		public static readonly Guid Format40bpp4ChannelsAlpha = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc92f");

		// Token: 0x04000067 RID: 103
		public static readonly Guid Format48bpp5ChannelsAlpha = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc930");

		// Token: 0x04000068 RID: 104
		public static readonly Guid Format56bpp6ChannelsAlpha = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc931");

		// Token: 0x04000069 RID: 105
		public static readonly Guid Format64bpp7ChannelsAlpha = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc932");

		// Token: 0x0400006A RID: 106
		public static readonly Guid Format72bpp8ChannelsAlpha = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc933");

		// Token: 0x0400006B RID: 107
		public static readonly Guid Format64bpp3ChannelsAlpha = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc934");

		// Token: 0x0400006C RID: 108
		public static readonly Guid Format80bpp4ChannelsAlpha = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc935");

		// Token: 0x0400006D RID: 109
		public static readonly Guid Format96bpp5ChannelsAlpha = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc936");

		// Token: 0x0400006E RID: 110
		public static readonly Guid Format112bpp6ChannelsAlpha = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc937");

		// Token: 0x0400006F RID: 111
		public static readonly Guid Format128bpp7ChannelsAlpha = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc938");

		// Token: 0x04000070 RID: 112
		public static readonly Guid Format144bpp8ChannelsAlpha = new Guid("6fddc324-4e03-4bfe-b185-3d77768dc939");

		// Token: 0x04000071 RID: 113
		public static readonly Guid Format8bppY = new Guid("91b4db54-2df9-42f0-b449-2909bb3df88e");

		// Token: 0x04000072 RID: 114
		public static readonly Guid Format8bppCb = new Guid("1339f224-6bfe-4c3e-9302-e4f3a6d0ca2a");

		// Token: 0x04000073 RID: 115
		public static readonly Guid Format8bppCr = new Guid("b8145053-2116-49f0-8835-ed844b205c51");

		// Token: 0x04000074 RID: 116
		public static readonly Guid Format16bppCbCr = new Guid("ff95ba6e-11e0-4263-bb45-01721f3460a4");

		// Token: 0x04000075 RID: 117
		public static readonly Guid Format16bppYQuantizedDctCoefficients = new Guid("a355f433-48e8-4a42-84d8-e2aa26ca80a4");

		// Token: 0x04000076 RID: 118
		public static readonly Guid Format16bppCbQuantizedDctCoefficients = new Guid("d2c4ff61-56a5-49c2-8b5c-4c1925964837");

		// Token: 0x04000077 RID: 119
		public static readonly Guid Format16bppCrQuantizedDctCoefficients = new Guid("2fe354f0-1680-42d8-9231-e73c0565bfc1");
	}
}
