using System;
using System.Runtime.InteropServices;

namespace SharpDX.Multimedia
{
	// Token: 0x02000073 RID: 115
	public class WaveFormatAdpcm : WaveFormat
	{
		// Token: 0x060002E8 RID: 744 RVA: 0x00008B27 File Offset: 0x00006D27
		internal WaveFormatAdpcm()
		{
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00008B30 File Offset: 0x00006D30
		public WaveFormatAdpcm(int rate, int channels, int blockAlign = 0) : base(rate, 4, channels)
		{
			if (blockAlign == 0)
			{
				if (rate <= 11025)
				{
					blockAlign = 256;
				}
				else if (rate <= 22050)
				{
					blockAlign = 512;
				}
				else
				{
					blockAlign = 1024;
				}
			}
			if (rate <= 0)
			{
				throw new ArgumentOutOfRangeException("rate", "Must be > 0");
			}
			if (channels <= 0)
			{
				throw new ArgumentOutOfRangeException("channels", "Must be > 0");
			}
			if (blockAlign <= 0)
			{
				throw new ArgumentOutOfRangeException("blockAlign", "Must be > 0");
			}
			if (blockAlign > 32767)
			{
				throw new ArgumentOutOfRangeException("blockAlign", "Must be < 32767");
			}
			this.waveFormatTag = WaveFormatEncoding.Adpcm;
			this.blockAlign = (short)blockAlign;
			this.SamplesPerBlock = (ushort)(blockAlign * 2 / channels - 12);
			this.averageBytesPerSecond = base.SampleRate * blockAlign / (int)this.SamplesPerBlock;
			this.Coefficients1 = new short[]
			{
				256,
				512,
				0,
				192,
				240,
				460,
				392
			};
			this.Coefficients2 = new short[]
			{
				0,
				-256,
				0,
				64,
				0,
				-208,
				-232
			};
			this.extraSize = 32;
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00008C2F File Offset: 0x00006E2F
		// (set) Token: 0x060002EB RID: 747 RVA: 0x00008C37 File Offset: 0x00006E37
		public ushort SamplesPerBlock { get; private set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00008C40 File Offset: 0x00006E40
		// (set) Token: 0x060002ED RID: 749 RVA: 0x00008C48 File Offset: 0x00006E48
		public short[] Coefficients1 { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060002EE RID: 750 RVA: 0x00008C51 File Offset: 0x00006E51
		// (set) Token: 0x060002EF RID: 751 RVA: 0x00008C59 File Offset: 0x00006E59
		public short[] Coefficients2 { get; set; }

		// Token: 0x060002F0 RID: 752 RVA: 0x00008C64 File Offset: 0x00006E64
		protected unsafe override IntPtr MarshalToPtr()
		{
			IntPtr intPtr = Marshal.AllocHGlobal(Utilities.SizeOf<WaveFormat.__Native>() + 4 + 4 * this.Coefficients1.Length);
			this.__MarshalTo(ref *(WaveFormatAdpcm.__Native*)((void*)intPtr));
			return intPtr;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00008C98 File Offset: 0x00006E98
		internal unsafe void __MarshalFrom(ref WaveFormatAdpcm.__Native @ref)
		{
			base.__MarshalFrom(ref @ref.waveFormat);
			this.SamplesPerBlock = @ref.samplesPerBlock;
			this.Coefficients1 = new short[(int)@ref.numberOfCoefficients];
			this.Coefficients2 = new short[(int)@ref.numberOfCoefficients];
			if (@ref.numberOfCoefficients > 7)
			{
				throw new InvalidOperationException("Unable to read Adpcm format. Too may coefficients (max 7)");
			}
			fixed (short* ptr = &@ref.coefficients)
			{
				short* ptr2 = ptr;
				for (int i = 0; i < (int)@ref.numberOfCoefficients; i++)
				{
					this.Coefficients1[i] = ptr2[i * 2];
					this.Coefficients2[i] = ptr2[i * 2 + 1];
				}
			}
			this.extraSize = (short)(4 + 4 * @ref.numberOfCoefficients);
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00008D48 File Offset: 0x00006F48
		private unsafe void __MarshalTo(ref WaveFormatAdpcm.__Native @ref)
		{
			if (this.Coefficients1.Length > 7)
			{
				throw new InvalidOperationException("Unable to encode Adpcm format. Too may coefficients (max 7)");
			}
			this.extraSize = (short)(4 + 4 * this.Coefficients1.Length);
			base.__MarshalTo(ref @ref.waveFormat);
			@ref.samplesPerBlock = this.SamplesPerBlock;
			@ref.numberOfCoefficients = (ushort)this.Coefficients1.Length;
			fixed (short* ptr = &@ref.coefficients)
			{
				short* ptr2 = ptr;
				for (int i = 0; i < (int)@ref.numberOfCoefficients; i++)
				{
					ptr2[i * 2] = this.Coefficients1[i];
					ptr2[i * 2 + 1] = this.Coefficients2[i];
				}
			}
		}

		// Token: 0x02000074 RID: 116
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		internal new struct __Native
		{
			// Token: 0x060002F3 RID: 755 RVA: 0x00008DE7 File Offset: 0x00006FE7
			internal void __MarshalFree()
			{
				this.waveFormat.__MarshalFree();
			}

			// Token: 0x04000D9F RID: 3487
			public WaveFormat.__Native waveFormat;

			// Token: 0x04000DA0 RID: 3488
			public ushort samplesPerBlock;

			// Token: 0x04000DA1 RID: 3489
			public ushort numberOfCoefficients;

			// Token: 0x04000DA2 RID: 3490
			public short coefficients;
		}
	}
}
