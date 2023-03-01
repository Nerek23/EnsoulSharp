using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000128 RID: 296
	public struct KeyExchangeHwProtectionInputData
	{
		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600047F RID: 1151 RVA: 0x00011270 File Offset: 0x0000F470
		// (set) Token: 0x06000480 RID: 1152 RVA: 0x00011296 File Offset: 0x0000F496
		public byte[] PbInput
		{
			get
			{
				byte[] result;
				if ((result = this._PbInput) == null)
				{
					result = (this._PbInput = new byte[4]);
				}
				return result;
			}
			private set
			{
				this._PbInput = value;
			}
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x000022D3 File Offset: 0x000004D3
		internal void __MarshalFree(ref KeyExchangeHwProtectionInputData.__Native @ref)
		{
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x000112A0 File Offset: 0x0000F4A0
		internal unsafe void __MarshalFrom(ref KeyExchangeHwProtectionInputData.__Native @ref)
		{
			this.PrivateDataSize = @ref.PrivateDataSize;
			this.HWProtectionDataSize = @ref.HWProtectionDataSize;
			fixed (byte* ptr = &this.PbInput[0])
			{
				void* value = (void*)ptr;
				fixed (byte* ptr2 = &@ref.PbInput)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 4);
					ptr = null;
				}
			}
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x000112F8 File Offset: 0x0000F4F8
		internal unsafe void __MarshalTo(ref KeyExchangeHwProtectionInputData.__Native @ref)
		{
			@ref.PrivateDataSize = this.PrivateDataSize;
			@ref.HWProtectionDataSize = this.HWProtectionDataSize;
			fixed (byte* ptr = &this.PbInput[0])
			{
				void* value = (void*)ptr;
				fixed (byte* ptr2 = &@ref.PbInput)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value2, (IntPtr)value, 4);
					ptr = null;
				}
			}
		}

		// Token: 0x040009BC RID: 2492
		public int PrivateDataSize;

		// Token: 0x040009BD RID: 2493
		public int HWProtectionDataSize;

		// Token: 0x040009BE RID: 2494
		internal byte[] _PbInput;

		// Token: 0x02000129 RID: 297
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040009BF RID: 2495
			public int PrivateDataSize;

			// Token: 0x040009C0 RID: 2496
			public int HWProtectionDataSize;

			// Token: 0x040009C1 RID: 2497
			public byte PbInput;

			// Token: 0x040009C2 RID: 2498
			public byte __PbInput1;

			// Token: 0x040009C3 RID: 2499
			public byte __PbInput2;

			// Token: 0x040009C4 RID: 2500
			public byte __PbInput3;
		}
	}
}
