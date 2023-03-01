using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000F1 RID: 241
	public struct AuthenticatedQueryOutput
	{
		// Token: 0x06000466 RID: 1126 RVA: 0x00010EA9 File Offset: 0x0000F0A9
		internal void __MarshalFree(ref AuthenticatedQueryOutput.__Native @ref)
		{
			this.Omac.__MarshalFree(ref @ref.Omac);
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00010EBC File Offset: 0x0000F0BC
		internal void __MarshalFrom(ref AuthenticatedQueryOutput.__Native @ref)
		{
			this.Omac.__MarshalFrom(ref @ref.Omac);
			this.QueryType = @ref.QueryType;
			this.HChannel = @ref.HChannel;
			this.SequenceNumber = @ref.SequenceNumber;
			this.ReturnCode = @ref.ReturnCode;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00010F0C File Offset: 0x0000F10C
		internal void __MarshalTo(ref AuthenticatedQueryOutput.__Native @ref)
		{
			this.Omac.__MarshalTo(ref @ref.Omac);
			@ref.QueryType = this.QueryType;
			@ref.HChannel = this.HChannel;
			@ref.SequenceNumber = this.SequenceNumber;
			@ref.ReturnCode = this.ReturnCode;
		}

		// Token: 0x04000914 RID: 2324
		public MessageAuthenticationCode Omac;

		// Token: 0x04000915 RID: 2325
		public Guid QueryType;

		// Token: 0x04000916 RID: 2326
		public IntPtr HChannel;

		// Token: 0x04000917 RID: 2327
		public int SequenceNumber;

		// Token: 0x04000918 RID: 2328
		public Result ReturnCode;

		// Token: 0x020000F2 RID: 242
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000919 RID: 2329
			public MessageAuthenticationCode.__Native Omac;

			// Token: 0x0400091A RID: 2330
			public Guid QueryType;

			// Token: 0x0400091B RID: 2331
			public IntPtr HChannel;

			// Token: 0x0400091C RID: 2332
			public int SequenceNumber;

			// Token: 0x0400091D RID: 2333
			public Result ReturnCode;
		}
	}
}
