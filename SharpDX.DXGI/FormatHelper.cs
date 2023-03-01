using System;
using System.Collections.Generic;

namespace SharpDX.DXGI
{
	// Token: 0x02000010 RID: 16
	public static class FormatHelper
	{
		// Token: 0x06000063 RID: 99 RVA: 0x00003268 File Offset: 0x00001468
		public static int SizeOfInBytes(this Format format)
		{
			return format.SizeOfInBits() >> 3;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003272 File Offset: 0x00001472
		public static int SizeOfInBits(this Format format)
		{
			return FormatHelper.sizeOfInBits[(int)format];
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000327B File Offset: 0x0000147B
		public static bool IsValid(this Format format)
		{
			return format >= Format.R32G32B32A32_Typeless && format <= Format.B4G4R4A4_UNorm;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000328B File Offset: 0x0000148B
		public static bool IsCompressed(this Format format)
		{
			return FormatHelper.compressedFormats[(int)format];
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003294 File Offset: 0x00001494
		public static bool IsPacked(this Format format)
		{
			return format == Format.R8G8_B8G8_UNorm || format == Format.G8R8_G8B8_UNorm;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000032A4 File Offset: 0x000014A4
		public static bool IsVideo(this Format format)
		{
			switch (format)
			{
			case Format.AYUV:
			case Format.Y410:
			case Format.Y416:
			case Format.NV12:
			case Format.P010:
			case Format.P016:
			case Format.YUY2:
			case Format.Y210:
			case Format.Y216:
			case Format.NV11:
				return true;
			case Format.Opaque420:
			case Format.AI44:
			case Format.IA44:
			case Format.P8:
			case Format.A8P8:
				return true;
			default:
				return false;
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000032FD File Offset: 0x000014FD
		public static bool IsSRgb(this Format format)
		{
			return FormatHelper.srgbFormats[(int)format];
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003306 File Offset: 0x00001506
		public static bool IsTypeless(this Format format)
		{
			return FormatHelper.typelessFormats[(int)format];
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000330F File Offset: 0x0000150F
		public static int ComputeScanlineCount(this Format format, int height)
		{
			if (format - Format.BC1_Typeless <= 14 || format - Format.BC6H_Typeless <= 5)
			{
				return Math.Max(1, (height + 3) / 4);
			}
			return height;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003330 File Offset: 0x00001530
		static FormatHelper()
		{
			FormatHelper.InitFormat(new Format[]
			{
				Format.R1_UNorm
			}, 1);
			FormatHelper.InitFormat(new Format[]
			{
				Format.A8_UNorm,
				Format.R8_SInt,
				Format.R8_SNorm,
				Format.R8_Typeless,
				Format.R8_UInt,
				Format.R8_UNorm
			}, 8);
			FormatHelper.InitFormat(new Format[]
			{
				Format.B5G5R5A1_UNorm,
				Format.B5G6R5_UNorm,
				Format.D16_UNorm,
				Format.R16_Float,
				Format.R16_SInt,
				Format.R16_SNorm,
				Format.R16_Typeless,
				Format.R16_UInt,
				Format.R16_UNorm,
				Format.R8G8_SInt,
				Format.R8G8_SNorm,
				Format.R8G8_Typeless,
				Format.R8G8_UInt,
				Format.R8G8_UNorm,
				Format.B4G4R4A4_UNorm
			}, 16);
			FormatHelper.InitFormat(new Format[]
			{
				Format.B8G8R8X8_Typeless,
				Format.B8G8R8X8_UNorm,
				Format.B8G8R8X8_UNorm_SRgb,
				Format.D24_UNorm_S8_UInt,
				Format.D32_Float,
				Format.D32_Float_S8X24_UInt,
				Format.G8R8_G8B8_UNorm,
				Format.R10G10B10_Xr_Bias_A2_UNorm,
				Format.R10G10B10A2_Typeless,
				Format.R10G10B10A2_UInt,
				Format.R10G10B10A2_UNorm,
				Format.R11G11B10_Float,
				Format.R16G16_Float,
				Format.R16G16_SInt,
				Format.R16G16_SNorm,
				Format.R16G16_Typeless,
				Format.R16G16_UInt,
				Format.R16G16_UNorm,
				Format.R24_UNorm_X8_Typeless,
				Format.R24G8_Typeless,
				Format.R32_Float,
				Format.R32_Float_X8X24_Typeless,
				Format.R32_SInt,
				Format.R32_Typeless,
				Format.R32_UInt,
				Format.R8G8_B8G8_UNorm,
				Format.R8G8B8A8_SInt,
				Format.R8G8B8A8_SNorm,
				Format.R8G8B8A8_Typeless,
				Format.R8G8B8A8_UInt,
				Format.R8G8B8A8_UNorm,
				Format.R8G8B8A8_UNorm_SRgb,
				Format.B8G8R8A8_Typeless,
				Format.B8G8R8A8_UNorm,
				Format.B8G8R8A8_UNorm_SRgb,
				Format.R9G9B9E5_Sharedexp,
				Format.X24_Typeless_G8_UInt,
				Format.X32_Typeless_G8X24_UInt
			}, 32);
			FormatHelper.InitFormat(new Format[]
			{
				Format.R16G16B16A16_Float,
				Format.R16G16B16A16_SInt,
				Format.R16G16B16A16_SNorm,
				Format.R16G16B16A16_Typeless,
				Format.R16G16B16A16_UInt,
				Format.R16G16B16A16_UNorm,
				Format.R32G32_Float,
				Format.R32G32_SInt,
				Format.R32G32_Typeless,
				Format.R32G32_UInt,
				Format.R32G8X24_Typeless
			}, 64);
			FormatHelper.InitFormat(new Format[]
			{
				Format.R32G32B32_Float,
				Format.R32G32B32_SInt,
				Format.R32G32B32_Typeless,
				Format.R32G32B32_UInt
			}, 96);
			FormatHelper.InitFormat(new Format[]
			{
				Format.R32G32B32A32_Float,
				Format.R32G32B32A32_SInt,
				Format.R32G32B32A32_Typeless,
				Format.R32G32B32A32_UInt
			}, 128);
			FormatHelper.InitFormat(new Format[]
			{
				Format.BC1_Typeless,
				Format.BC1_UNorm,
				Format.BC1_UNorm_SRgb,
				Format.BC4_SNorm,
				Format.BC4_Typeless,
				Format.BC4_UNorm
			}, 4);
			FormatHelper.InitFormat(new Format[]
			{
				Format.BC2_Typeless,
				Format.BC2_UNorm,
				Format.BC2_UNorm_SRgb,
				Format.BC3_Typeless,
				Format.BC3_UNorm,
				Format.BC3_UNorm_SRgb,
				Format.BC5_SNorm,
				Format.BC5_Typeless,
				Format.BC5_UNorm,
				Format.BC6H_Sf16,
				Format.BC6H_Typeless,
				Format.BC6H_Uf16,
				Format.BC7_Typeless,
				Format.BC7_UNorm,
				Format.BC7_UNorm_SRgb
			}, 8);
			FormatHelper.InitDefaults(new Format[]
			{
				Format.BC1_Typeless,
				Format.BC1_UNorm,
				Format.BC1_UNorm_SRgb,
				Format.BC2_Typeless,
				Format.BC2_UNorm,
				Format.BC2_UNorm_SRgb,
				Format.BC3_Typeless,
				Format.BC3_UNorm,
				Format.BC3_UNorm_SRgb,
				Format.BC4_Typeless,
				Format.BC4_UNorm,
				Format.BC4_SNorm,
				Format.BC5_Typeless,
				Format.BC5_UNorm,
				Format.BC5_SNorm,
				Format.BC6H_Typeless,
				Format.BC6H_Uf16,
				Format.BC6H_Sf16,
				Format.BC7_Typeless,
				Format.BC7_UNorm,
				Format.BC7_UNorm_SRgb
			}, FormatHelper.compressedFormats);
			FormatHelper.InitDefaults(new Format[]
			{
				Format.R8G8B8A8_UNorm_SRgb,
				Format.BC1_UNorm_SRgb,
				Format.BC2_UNorm_SRgb,
				Format.BC3_UNorm_SRgb,
				Format.B8G8R8A8_UNorm_SRgb,
				Format.B8G8R8X8_UNorm_SRgb,
				Format.BC7_UNorm_SRgb
			}, FormatHelper.srgbFormats);
			FormatHelper.InitDefaults(new Format[]
			{
				Format.R32G32B32A32_Typeless,
				Format.R32G32B32_Typeless,
				Format.R16G16B16A16_Typeless,
				Format.R32G32_Typeless,
				Format.R32G8X24_Typeless,
				Format.R10G10B10A2_Typeless,
				Format.R8G8B8A8_Typeless,
				Format.R16G16_Typeless,
				Format.R32_Typeless,
				Format.R24G8_Typeless,
				Format.R8G8_Typeless,
				Format.R16_Typeless,
				Format.R8_Typeless,
				Format.BC1_Typeless,
				Format.BC2_Typeless,
				Format.BC3_Typeless,
				Format.BC4_Typeless,
				Format.BC5_Typeless,
				Format.B8G8R8A8_Typeless,
				Format.B8G8R8X8_Typeless,
				Format.BC6H_Typeless,
				Format.BC7_Typeless
			}, FormatHelper.typelessFormats);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000034A4 File Offset: 0x000016A4
		private static void InitFormat(IEnumerable<Format> formats, int bitCount)
		{
			foreach (Format format in formats)
			{
				FormatHelper.sizeOfInBits[(int)format] = bitCount;
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000034F0 File Offset: 0x000016F0
		private static void InitDefaults(IEnumerable<Format> formats, bool[] outputArray)
		{
			foreach (Format format in formats)
			{
				outputArray[(int)format] = true;
			}
		}

		// Token: 0x04000006 RID: 6
		private static readonly int[] sizeOfInBits = new int[256];

		// Token: 0x04000007 RID: 7
		private static readonly bool[] compressedFormats = new bool[256];

		// Token: 0x04000008 RID: 8
		private static readonly bool[] srgbFormats = new bool[256];

		// Token: 0x04000009 RID: 9
		private static readonly bool[] typelessFormats = new bool[256];
	}
}
