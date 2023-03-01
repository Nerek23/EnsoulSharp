using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200012C RID: 300
	public struct MessageAuthenticationCode
	{
		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x00011478 File Offset: 0x0000F678
		// (set) Token: 0x0600048A RID: 1162 RVA: 0x0001149F File Offset: 0x0000F69F
		public byte[] Buffer
		{
			get
			{
				byte[] result;
				if ((result = this._Buffer) == null)
				{
					result = (this._Buffer = new byte[16]);
				}
				return result;
			}
			private set
			{
				this._Buffer = value;
			}
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x000022D3 File Offset: 0x000004D3
		internal void __MarshalFree(ref MessageAuthenticationCode.__Native @ref)
		{
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x000114A8 File Offset: 0x0000F6A8
		internal unsafe void __MarshalFrom(ref MessageAuthenticationCode.__Native @ref)
		{
			fixed (byte* ptr = &this.Buffer[0])
			{
				void* value = (void*)ptr;
				fixed (byte* ptr2 = &@ref.Buffer)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 16);
					ptr = null;
				}
			}
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x000114E8 File Offset: 0x0000F6E8
		internal unsafe void __MarshalTo(ref MessageAuthenticationCode.__Native @ref)
		{
			fixed (byte* ptr = &this.Buffer[0])
			{
				void* value = (void*)ptr;
				fixed (byte* ptr2 = &@ref.Buffer)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value2, (IntPtr)value, 16);
					ptr = null;
				}
			}
		}

		// Token: 0x040009D4 RID: 2516
		internal byte[] _Buffer;

		// Token: 0x0200012D RID: 301
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040009D5 RID: 2517
			public byte Buffer;

			// Token: 0x040009D6 RID: 2518
			public byte __Buffer1;

			// Token: 0x040009D7 RID: 2519
			public byte __Buffer2;

			// Token: 0x040009D8 RID: 2520
			public byte __Buffer3;

			// Token: 0x040009D9 RID: 2521
			public byte __Buffer4;

			// Token: 0x040009DA RID: 2522
			public byte __Buffer5;

			// Token: 0x040009DB RID: 2523
			public byte __Buffer6;

			// Token: 0x040009DC RID: 2524
			public byte __Buffer7;

			// Token: 0x040009DD RID: 2525
			public byte __Buffer8;

			// Token: 0x040009DE RID: 2526
			public byte __Buffer9;

			// Token: 0x040009DF RID: 2527
			public byte __Buffer10;

			// Token: 0x040009E0 RID: 2528
			public byte __Buffer11;

			// Token: 0x040009E1 RID: 2529
			public byte __Buffer12;

			// Token: 0x040009E2 RID: 2530
			public byte __Buffer13;

			// Token: 0x040009E3 RID: 2531
			public byte __Buffer14;

			// Token: 0x040009E4 RID: 2532
			public byte __Buffer15;
		}
	}
}
