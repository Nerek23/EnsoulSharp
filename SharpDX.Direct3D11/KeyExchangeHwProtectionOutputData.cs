using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200012A RID: 298
	public struct KeyExchangeHwProtectionOutputData
	{
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x00011350 File Offset: 0x0000F550
		// (set) Token: 0x06000485 RID: 1157 RVA: 0x00011376 File Offset: 0x0000F576
		public byte[] PbOutput
		{
			get
			{
				byte[] result;
				if ((result = this._PbOutput) == null)
				{
					result = (this._PbOutput = new byte[4]);
				}
				return result;
			}
			private set
			{
				this._PbOutput = value;
			}
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x000022D3 File Offset: 0x000004D3
		internal void __MarshalFree(ref KeyExchangeHwProtectionOutputData.__Native @ref)
		{
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00011380 File Offset: 0x0000F580
		internal unsafe void __MarshalFrom(ref KeyExchangeHwProtectionOutputData.__Native @ref)
		{
			this.PrivateDataSize = @ref.PrivateDataSize;
			this.MaxHWProtectionDataSize = @ref.MaxHWProtectionDataSize;
			this.HWProtectionDataSize = @ref.HWProtectionDataSize;
			this.TransportTime = @ref.TransportTime;
			this.ExecutionTime = @ref.ExecutionTime;
			fixed (byte* ptr = &this.PbOutput[0])
			{
				void* value = (void*)ptr;
				fixed (byte* ptr2 = &@ref.PbOutput)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 4);
					ptr = null;
				}
			}
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x000113FC File Offset: 0x0000F5FC
		internal unsafe void __MarshalTo(ref KeyExchangeHwProtectionOutputData.__Native @ref)
		{
			@ref.PrivateDataSize = this.PrivateDataSize;
			@ref.MaxHWProtectionDataSize = this.MaxHWProtectionDataSize;
			@ref.HWProtectionDataSize = this.HWProtectionDataSize;
			@ref.TransportTime = this.TransportTime;
			@ref.ExecutionTime = this.ExecutionTime;
			fixed (byte* ptr = &this.PbOutput[0])
			{
				void* value = (void*)ptr;
				fixed (byte* ptr2 = &@ref.PbOutput)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value2, (IntPtr)value, 4);
					ptr = null;
				}
			}
		}

		// Token: 0x040009C5 RID: 2501
		public int PrivateDataSize;

		// Token: 0x040009C6 RID: 2502
		public int MaxHWProtectionDataSize;

		// Token: 0x040009C7 RID: 2503
		public int HWProtectionDataSize;

		// Token: 0x040009C8 RID: 2504
		public long TransportTime;

		// Token: 0x040009C9 RID: 2505
		public long ExecutionTime;

		// Token: 0x040009CA RID: 2506
		internal byte[] _PbOutput;

		// Token: 0x0200012B RID: 299
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040009CB RID: 2507
			public int PrivateDataSize;

			// Token: 0x040009CC RID: 2508
			public int MaxHWProtectionDataSize;

			// Token: 0x040009CD RID: 2509
			public int HWProtectionDataSize;

			// Token: 0x040009CE RID: 2510
			public long TransportTime;

			// Token: 0x040009CF RID: 2511
			public long ExecutionTime;

			// Token: 0x040009D0 RID: 2512
			public byte PbOutput;

			// Token: 0x040009D1 RID: 2513
			public byte __PbOutput1;

			// Token: 0x040009D2 RID: 2514
			public byte __PbOutput2;

			// Token: 0x040009D3 RID: 2515
			public byte __PbOutput3;
		}
	}
}
