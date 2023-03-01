using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace SharpDX.Multimedia
{
	// Token: 0x02000070 RID: 112
	public class WaveFormat
	{
		// Token: 0x060002C9 RID: 713 RVA: 0x000084E8 File Offset: 0x000066E8
		internal void __MarshalFree(ref WaveFormat.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x060002CA RID: 714 RVA: 0x000084F0 File Offset: 0x000066F0
		internal void __MarshalFrom(ref WaveFormat.__Native @ref)
		{
			this.waveFormatTag = @ref.pcmWaveFormat.waveFormatTag;
			this.channels = @ref.pcmWaveFormat.channels;
			this.sampleRate = @ref.pcmWaveFormat.sampleRate;
			this.averageBytesPerSecond = @ref.pcmWaveFormat.averageBytesPerSecond;
			this.blockAlign = @ref.pcmWaveFormat.blockAlign;
			this.bitsPerSample = @ref.pcmWaveFormat.bitsPerSample;
			this.extraSize = @ref.extraSize;
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00008570 File Offset: 0x00006770
		internal void __MarshalTo(ref WaveFormat.__Native @ref)
		{
			@ref.pcmWaveFormat.waveFormatTag = this.waveFormatTag;
			@ref.pcmWaveFormat.channels = this.channels;
			@ref.pcmWaveFormat.sampleRate = this.sampleRate;
			@ref.pcmWaveFormat.averageBytesPerSecond = this.averageBytesPerSecond;
			@ref.pcmWaveFormat.blockAlign = this.blockAlign;
			@ref.pcmWaveFormat.bitsPerSample = this.bitsPerSample;
			@ref.extraSize = this.extraSize;
		}

		// Token: 0x060002CC RID: 716 RVA: 0x000085EF File Offset: 0x000067EF
		internal void __MarshalFree(ref WaveFormat.__PcmNative @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x060002CD RID: 717 RVA: 0x000085F8 File Offset: 0x000067F8
		internal void __MarshalFrom(ref WaveFormat.__PcmNative @ref)
		{
			this.waveFormatTag = @ref.waveFormatTag;
			this.channels = @ref.channels;
			this.sampleRate = @ref.sampleRate;
			this.averageBytesPerSecond = @ref.averageBytesPerSecond;
			this.blockAlign = @ref.blockAlign;
			this.bitsPerSample = @ref.bitsPerSample;
			this.extraSize = 0;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00008654 File Offset: 0x00006854
		internal void __MarshalTo(ref WaveFormat.__PcmNative @ref)
		{
			@ref.waveFormatTag = this.waveFormatTag;
			@ref.channels = this.channels;
			@ref.sampleRate = this.sampleRate;
			@ref.averageBytesPerSecond = this.averageBytesPerSecond;
			@ref.blockAlign = this.blockAlign;
			@ref.bitsPerSample = this.bitsPerSample;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x000086A9 File Offset: 0x000068A9
		public WaveFormat() : this(44100, 16, 2)
		{
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x000086B9 File Offset: 0x000068B9
		public WaveFormat(int sampleRate, int channels) : this(sampleRate, 16, channels)
		{
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x000086C8 File Offset: 0x000068C8
		public int ConvertLatencyToByteSize(int milliseconds)
		{
			int num = (int)((double)this.AverageBytesPerSecond / 1000.0 * (double)milliseconds);
			if (num % this.BlockAlign != 0)
			{
				num = num + this.BlockAlign - num % this.BlockAlign;
			}
			return num;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00008708 File Offset: 0x00006908
		public static WaveFormat CreateCustomFormat(WaveFormatEncoding tag, int sampleRate, int channels, int averageBytesPerSecond, int blockAlign, int bitsPerSample)
		{
			return new WaveFormat
			{
				waveFormatTag = tag,
				channels = (short)channels,
				sampleRate = sampleRate,
				averageBytesPerSecond = averageBytesPerSecond,
				blockAlign = (short)blockAlign,
				bitsPerSample = (short)bitsPerSample,
				extraSize = 0
			};
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00008745 File Offset: 0x00006945
		public static WaveFormat CreateALawFormat(int sampleRate, int channels)
		{
			return WaveFormat.CreateCustomFormat(WaveFormatEncoding.Alaw, sampleRate, channels, sampleRate * channels, 1, 8);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00008754 File Offset: 0x00006954
		public static WaveFormat CreateMuLawFormat(int sampleRate, int channels)
		{
			return WaveFormat.CreateCustomFormat(WaveFormatEncoding.Mulaw, sampleRate, channels, sampleRate * channels, 1, 8);
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x00008764 File Offset: 0x00006964
		public WaveFormat(int rate, int bits, int channels)
		{
			if (channels < 1)
			{
				throw new ArgumentOutOfRangeException("channels", "Channels must be 1 or greater");
			}
			this.waveFormatTag = ((bits < 32) ? WaveFormatEncoding.Pcm : WaveFormatEncoding.IeeeFloat);
			this.channels = (short)channels;
			this.sampleRate = rate;
			this.bitsPerSample = (short)bits;
			this.extraSize = 0;
			this.blockAlign = (short)(channels * (bits / 8));
			this.averageBytesPerSecond = this.sampleRate * (int)this.blockAlign;
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x000087D8 File Offset: 0x000069D8
		public static WaveFormat CreateIeeeFloatWaveFormat(int sampleRate, int channels)
		{
			WaveFormat waveFormat = new WaveFormat
			{
				waveFormatTag = WaveFormatEncoding.IeeeFloat,
				channels = (short)channels,
				bitsPerSample = 32,
				sampleRate = sampleRate,
				blockAlign = (short)(4 * channels)
			};
			waveFormat.averageBytesPerSecond = sampleRate * (int)waveFormat.blockAlign;
			waveFormat.extraSize = 0;
			return waveFormat;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000882C File Offset: 0x00006A2C
		public unsafe static WaveFormat MarshalFrom(byte[] rawdata)
		{
			void* value;
			if (rawdata == null || rawdata.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&rawdata[0]);
			}
			return WaveFormat.MarshalFrom((IntPtr)value);
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0000885C File Offset: 0x00006A5C
		public unsafe static WaveFormat MarshalFrom(IntPtr pointer)
		{
			if (pointer == IntPtr.Zero)
			{
				return null;
			}
			WaveFormat.__PcmNative _PcmNative = *(WaveFormat.__PcmNative*)((void*)pointer);
			WaveFormatEncoding waveFormatEncoding = _PcmNative.waveFormatTag;
			if (_PcmNative.channels <= 2 && (waveFormatEncoding == WaveFormatEncoding.Pcm || waveFormatEncoding == WaveFormatEncoding.IeeeFloat || waveFormatEncoding == WaveFormatEncoding.Wmaudio2 || waveFormatEncoding == WaveFormatEncoding.Wmaudio3))
			{
				WaveFormat waveFormat = new WaveFormat();
				waveFormat.__MarshalFrom(ref _PcmNative);
				return waveFormat;
			}
			if (waveFormatEncoding == WaveFormatEncoding.Extensible)
			{
				WaveFormatExtensible waveFormatExtensible = new WaveFormatExtensible();
				waveFormatExtensible.__MarshalFrom(ref *(WaveFormatExtensible.__Native*)((void*)pointer));
				return waveFormatExtensible;
			}
			if (waveFormatEncoding == WaveFormatEncoding.Adpcm)
			{
				WaveFormatAdpcm waveFormatAdpcm = new WaveFormatAdpcm();
				waveFormatAdpcm.__MarshalFrom(ref *(WaveFormatAdpcm.__Native*)((void*)pointer));
				return waveFormatAdpcm;
			}
			throw new InvalidOperationException(string.Format("Unsupported WaveFormat [{0}]", waveFormatEncoding));
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x000088FC File Offset: 0x00006AFC
		protected unsafe virtual IntPtr MarshalToPtr()
		{
			IntPtr intPtr = Marshal.AllocHGlobal(Utilities.SizeOf<WaveFormat.__Native>());
			this.__MarshalTo(ref *(WaveFormat.__Native*)((void*)intPtr));
			return intPtr;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00008921 File Offset: 0x00006B21
		public static IntPtr MarshalToPtr(WaveFormat format)
		{
			if (format == null)
			{
				return IntPtr.Zero;
			}
			return format.MarshalToPtr();
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00008934 File Offset: 0x00006B34
		public WaveFormat(BinaryReader br)
		{
			int num = br.ReadInt32();
			if (num < 16)
			{
				throw new SharpDXException("Invalid WaveFormat Structure", new object[0]);
			}
			this.waveFormatTag = (WaveFormatEncoding)br.ReadUInt16();
			this.channels = br.ReadInt16();
			this.sampleRate = br.ReadInt32();
			this.averageBytesPerSecond = br.ReadInt32();
			this.blockAlign = br.ReadInt16();
			this.bitsPerSample = br.ReadInt16();
			this.extraSize = 0;
			if (num > 16)
			{
				this.extraSize = br.ReadInt16();
				if ((int)this.extraSize > num - 18)
				{
					this.extraSize = (short)(num - 18);
				}
			}
		}

		// Token: 0x060002DC RID: 732 RVA: 0x000089DC File Offset: 0x00006BDC
		public override string ToString()
		{
			WaveFormatEncoding waveFormatEncoding = this.waveFormatTag;
			if (waveFormatEncoding == WaveFormatEncoding.Extensible || waveFormatEncoding == WaveFormatEncoding.Pcm)
			{
				return string.Format(CultureInfo.InvariantCulture, "{0} bit PCM: {1}kHz {2} channels", new object[]
				{
					this.bitsPerSample,
					this.sampleRate / 1000,
					this.channels
				});
			}
			return this.waveFormatTag.ToString();
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00008A50 File Offset: 0x00006C50
		public override bool Equals(object obj)
		{
			if (!(obj is WaveFormat))
			{
				return false;
			}
			WaveFormat waveFormat = (WaveFormat)obj;
			return this.waveFormatTag == waveFormat.waveFormatTag && this.channels == waveFormat.channels && this.sampleRate == waveFormat.sampleRate && this.averageBytesPerSecond == waveFormat.averageBytesPerSecond && this.blockAlign == waveFormat.blockAlign && this.bitsPerSample == waveFormat.bitsPerSample;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00008AC4 File Offset: 0x00006CC4
		public override int GetHashCode()
		{
			return (int)(this.waveFormatTag ^ (WaveFormatEncoding)this.channels) ^ this.sampleRate ^ this.averageBytesPerSecond ^ (int)this.blockAlign ^ (int)this.bitsPerSample;
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060002DF RID: 735 RVA: 0x00008AEF File Offset: 0x00006CEF
		public WaveFormatEncoding Encoding
		{
			get
			{
				return this.waveFormatTag;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00008AF7 File Offset: 0x00006CF7
		public int Channels
		{
			get
			{
				return (int)this.channels;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060002E1 RID: 737 RVA: 0x00008AFF File Offset: 0x00006CFF
		public int SampleRate
		{
			get
			{
				return this.sampleRate;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x00008B07 File Offset: 0x00006D07
		public int AverageBytesPerSecond
		{
			get
			{
				return this.averageBytesPerSecond;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x00008B0F File Offset: 0x00006D0F
		public int BlockAlign
		{
			get
			{
				return (int)this.blockAlign;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x00008B17 File Offset: 0x00006D17
		public int BitsPerSample
		{
			get
			{
				return (int)this.bitsPerSample;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x00008B1F File Offset: 0x00006D1F
		public int ExtraSize
		{
			get
			{
				return (int)this.extraSize;
			}
		}

		// Token: 0x04000D8D RID: 3469
		protected WaveFormatEncoding waveFormatTag;

		// Token: 0x04000D8E RID: 3470
		protected short channels;

		// Token: 0x04000D8F RID: 3471
		protected int sampleRate;

		// Token: 0x04000D90 RID: 3472
		protected int averageBytesPerSecond;

		// Token: 0x04000D91 RID: 3473
		protected short blockAlign;

		// Token: 0x04000D92 RID: 3474
		protected short bitsPerSample;

		// Token: 0x04000D93 RID: 3475
		protected short extraSize;

		// Token: 0x02000071 RID: 113
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		internal struct __Native
		{
			// Token: 0x060002E6 RID: 742 RVA: 0x000022F0 File Offset: 0x000004F0
			internal void __MarshalFree()
			{
			}

			// Token: 0x04000D94 RID: 3476
			public WaveFormat.__PcmNative pcmWaveFormat;

			// Token: 0x04000D95 RID: 3477
			public short extraSize;
		}

		// Token: 0x02000072 RID: 114
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		internal struct __PcmNative
		{
			// Token: 0x060002E7 RID: 743 RVA: 0x000022F0 File Offset: 0x000004F0
			internal void __MarshalFree()
			{
			}

			// Token: 0x04000D96 RID: 3478
			public WaveFormatEncoding waveFormatTag;

			// Token: 0x04000D97 RID: 3479
			public short channels;

			// Token: 0x04000D98 RID: 3480
			public int sampleRate;

			// Token: 0x04000D99 RID: 3481
			public int averageBytesPerSecond;

			// Token: 0x04000D9A RID: 3482
			public short blockAlign;

			// Token: 0x04000D9B RID: 3483
			public short bitsPerSample;
		}
	}
}
