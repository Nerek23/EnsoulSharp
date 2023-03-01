using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000089 RID: 137
	public struct JpegDeviceContextHuffmanTable
	{
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000216 RID: 534 RVA: 0x00008600 File Offset: 0x00006800
		// (set) Token: 0x06000217 RID: 535 RVA: 0x00008627 File Offset: 0x00006827
		public byte[] CodeCounts
		{
			get
			{
				byte[] result;
				if ((result = this._CodeCounts) == null)
				{
					result = (this._CodeCounts = new byte[12]);
				}
				return result;
			}
			private set
			{
				this._CodeCounts = value;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000218 RID: 536 RVA: 0x00008630 File Offset: 0x00006830
		// (set) Token: 0x06000219 RID: 537 RVA: 0x00008657 File Offset: 0x00006857
		public byte[] CodeValues
		{
			get
			{
				byte[] result;
				if ((result = this._CodeValues) == null)
				{
					result = (this._CodeValues = new byte[12]);
				}
				return result;
			}
			private set
			{
				this._CodeValues = value;
			}
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00004A73 File Offset: 0x00002C73
		internal void __MarshalFree(ref JpegDeviceContextHuffmanTable.__Native @ref)
		{
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00008660 File Offset: 0x00006860
		internal unsafe void __MarshalFrom(ref JpegDeviceContextHuffmanTable.__Native @ref)
		{
			fixed (byte* ptr = &this.CodeCounts[0])
			{
				void* value = (void*)ptr;
				fixed (byte* ptr2 = &@ref.CodeCounts)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 12);
					ptr = null;
				}
				fixed (byte* ptr2 = &this.CodeValues[0])
				{
					void* value3 = (void*)ptr2;
					fixed (byte* ptr = &@ref.CodeValues)
					{
						void* value4 = (void*)ptr;
						Utilities.CopyMemory((IntPtr)value3, (IntPtr)value4, 12);
						ptr2 = null;
					}
				}
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x000086D8 File Offset: 0x000068D8
		internal unsafe void __MarshalTo(ref JpegDeviceContextHuffmanTable.__Native @ref)
		{
			fixed (byte* ptr = &this.CodeCounts[0])
			{
				void* value = (void*)ptr;
				fixed (byte* ptr2 = &@ref.CodeCounts)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value2, (IntPtr)value, 12);
					ptr = null;
				}
				fixed (byte* ptr2 = &this.CodeValues[0])
				{
					void* value3 = (void*)ptr2;
					fixed (byte* ptr = &@ref.CodeValues)
					{
						void* value4 = (void*)ptr;
						Utilities.CopyMemory((IntPtr)value4, (IntPtr)value3, 12);
						ptr2 = null;
					}
				}
			}
		}

		// Token: 0x04000CF9 RID: 3321
		internal byte[] _CodeCounts;

		// Token: 0x04000CFA RID: 3322
		internal byte[] _CodeValues;

		// Token: 0x0200008A RID: 138
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000CFB RID: 3323
			public byte CodeCounts;

			// Token: 0x04000CFC RID: 3324
			public byte __CodeCounts1;

			// Token: 0x04000CFD RID: 3325
			public byte __CodeCounts2;

			// Token: 0x04000CFE RID: 3326
			public byte __CodeCounts3;

			// Token: 0x04000CFF RID: 3327
			public byte __CodeCounts4;

			// Token: 0x04000D00 RID: 3328
			public byte __CodeCounts5;

			// Token: 0x04000D01 RID: 3329
			public byte __CodeCounts6;

			// Token: 0x04000D02 RID: 3330
			public byte __CodeCounts7;

			// Token: 0x04000D03 RID: 3331
			public byte __CodeCounts8;

			// Token: 0x04000D04 RID: 3332
			public byte __CodeCounts9;

			// Token: 0x04000D05 RID: 3333
			public byte __CodeCounts10;

			// Token: 0x04000D06 RID: 3334
			public byte __CodeCounts11;

			// Token: 0x04000D07 RID: 3335
			public byte CodeValues;

			// Token: 0x04000D08 RID: 3336
			public byte __CodeValues1;

			// Token: 0x04000D09 RID: 3337
			public byte __CodeValues2;

			// Token: 0x04000D0A RID: 3338
			public byte __CodeValues3;

			// Token: 0x04000D0B RID: 3339
			public byte __CodeValues4;

			// Token: 0x04000D0C RID: 3340
			public byte __CodeValues5;

			// Token: 0x04000D0D RID: 3341
			public byte __CodeValues6;

			// Token: 0x04000D0E RID: 3342
			public byte __CodeValues7;

			// Token: 0x04000D0F RID: 3343
			public byte __CodeValues8;

			// Token: 0x04000D10 RID: 3344
			public byte __CodeValues9;

			// Token: 0x04000D11 RID: 3345
			public byte __CodeValues10;

			// Token: 0x04000D12 RID: 3346
			public byte __CodeValues11;
		}
	}
}
