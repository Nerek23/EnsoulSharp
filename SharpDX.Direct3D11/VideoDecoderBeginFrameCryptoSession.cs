using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200016C RID: 364
	public struct VideoDecoderBeginFrameCryptoSession
	{
		// Token: 0x0600048E RID: 1166 RVA: 0x000022D3 File Offset: 0x000004D3
		internal void __MarshalFree(ref VideoDecoderBeginFrameCryptoSession.__Native @ref)
		{
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00011528 File Offset: 0x0000F728
		internal void __MarshalFrom(ref VideoDecoderBeginFrameCryptoSession.__Native @ref)
		{
			if (@ref.PCryptoSession != IntPtr.Zero)
			{
				this.PCryptoSession = new CryptoSession(@ref.PCryptoSession);
			}
			else
			{
				this.PCryptoSession = null;
			}
			this.BlobSize = @ref.BlobSize;
			this.PBlob = @ref.PBlob;
			this.PKeyInfoId = @ref.PKeyInfoId;
			this.PrivateDataSize = @ref.PrivateDataSize;
			this.PPrivateData = @ref.PPrivateData;
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x000115A0 File Offset: 0x0000F7A0
		internal void __MarshalTo(ref VideoDecoderBeginFrameCryptoSession.__Native @ref)
		{
			@ref.PCryptoSession = CppObject.ToCallbackPtr<CryptoSession>(this.PCryptoSession);
			@ref.BlobSize = this.BlobSize;
			@ref.PBlob = this.PBlob;
			@ref.PKeyInfoId = this.PKeyInfoId;
			@ref.PrivateDataSize = this.PrivateDataSize;
			@ref.PPrivateData = this.PPrivateData;
		}

		// Token: 0x04000AF8 RID: 2808
		public CryptoSession PCryptoSession;

		// Token: 0x04000AF9 RID: 2809
		public int BlobSize;

		// Token: 0x04000AFA RID: 2810
		public IntPtr PBlob;

		// Token: 0x04000AFB RID: 2811
		public IntPtr PKeyInfoId;

		// Token: 0x04000AFC RID: 2812
		public int PrivateDataSize;

		// Token: 0x04000AFD RID: 2813
		public IntPtr PPrivateData;

		// Token: 0x0200016D RID: 365
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000AFE RID: 2814
			public IntPtr PCryptoSession;

			// Token: 0x04000AFF RID: 2815
			public int BlobSize;

			// Token: 0x04000B00 RID: 2816
			public IntPtr PBlob;

			// Token: 0x04000B01 RID: 2817
			public IntPtr PKeyInfoId;

			// Token: 0x04000B02 RID: 2818
			public int PrivateDataSize;

			// Token: 0x04000B03 RID: 2819
			public IntPtr PPrivateData;
		}
	}
}
