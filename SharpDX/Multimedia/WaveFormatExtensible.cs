using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace SharpDX.Multimedia
{
	// Token: 0x02000075 RID: 117
	public class WaveFormatExtensible : WaveFormat
	{
		// Token: 0x060002F4 RID: 756 RVA: 0x00008B27 File Offset: 0x00006D27
		internal WaveFormatExtensible()
		{
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00008DF4 File Offset: 0x00006FF4
		public WaveFormatExtensible(int rate, int bits, int channels) : base(rate, bits, channels)
		{
			this.waveFormatTag = WaveFormatEncoding.Extensible;
			this.extraSize = 22;
			this.wValidBitsPerSample = (short)bits;
			int num = 0;
			for (int i = 0; i < channels; i++)
			{
				num |= 1 << i;
			}
			this.ChannelMask = (Speakers)num;
			this.GuidSubFormat = ((bits == 32) ? new Guid("00000003-0000-0010-8000-00aa00389b71") : new Guid("00000001-0000-0010-8000-00aa00389b71"));
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00008E64 File Offset: 0x00007064
		protected unsafe override IntPtr MarshalToPtr()
		{
			IntPtr intPtr = Marshal.AllocHGlobal(Utilities.SizeOf<WaveFormatExtensible.__Native>());
			this.__MarshalTo(ref *(WaveFormatExtensible.__Native*)((void*)intPtr));
			return intPtr;
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00008E89 File Offset: 0x00007089
		internal void __MarshalFrom(ref WaveFormatExtensible.__Native @ref)
		{
			base.__MarshalFrom(ref @ref.waveFormat);
			this.wValidBitsPerSample = @ref.wValidBitsPerSample;
			this.ChannelMask = @ref.dwChannelMask;
			this.GuidSubFormat = @ref.subFormat;
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00008EBB File Offset: 0x000070BB
		internal void __MarshalTo(ref WaveFormatExtensible.__Native @ref)
		{
			base.__MarshalTo(ref @ref.waveFormat);
			@ref.wValidBitsPerSample = this.wValidBitsPerSample;
			@ref.dwChannelMask = this.ChannelMask;
			@ref.subFormat = this.GuidSubFormat;
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00008EF0 File Offset: 0x000070F0
		internal static WaveFormatExtensible.__Native __NewNative()
		{
			WaveFormatExtensible.__Native result = default(WaveFormatExtensible.__Native);
			result.waveFormat.extraSize = 22;
			return result;
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00008F14 File Offset: 0x00007114
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0} wBitsPerSample:{1} ChannelMask:{2} SubFormat:{3} extraSize:{4}", new object[]
			{
				base.ToString(),
				this.wValidBitsPerSample,
				this.ChannelMask,
				this.GuidSubFormat,
				this.extraSize
			});
		}

		// Token: 0x04000DA3 RID: 3491
		private short wValidBitsPerSample;

		// Token: 0x04000DA4 RID: 3492
		public Guid GuidSubFormat;

		// Token: 0x04000DA5 RID: 3493
		public Speakers ChannelMask;

		// Token: 0x02000076 RID: 118
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		internal new struct __Native
		{
			// Token: 0x060002FB RID: 763 RVA: 0x00008F77 File Offset: 0x00007177
			internal void __MarshalFree()
			{
				this.waveFormat.__MarshalFree();
			}

			// Token: 0x04000DA6 RID: 3494
			public WaveFormat.__Native waveFormat;

			// Token: 0x04000DA7 RID: 3495
			public short wValidBitsPerSample;

			// Token: 0x04000DA8 RID: 3496
			public Speakers dwChannelMask;

			// Token: 0x04000DA9 RID: 3497
			public Guid subFormat;
		}
	}
}
