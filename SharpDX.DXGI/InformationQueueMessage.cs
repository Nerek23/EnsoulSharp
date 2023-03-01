using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000085 RID: 133
	public struct InformationQueueMessage
	{
		// Token: 0x0600020C RID: 524 RVA: 0x000083D5 File Offset: 0x000065D5
		internal void __MarshalFree(ref InformationQueueMessage.__Native @ref)
		{
			Marshal.FreeHGlobal(@ref.PDescription);
		}

		// Token: 0x0600020D RID: 525 RVA: 0x000083E4 File Offset: 0x000065E4
		internal void __MarshalFrom(ref InformationQueueMessage.__Native @ref)
		{
			this.Producer = @ref.Producer;
			this.Category = @ref.Category;
			this.Severity = @ref.Severity;
			this.Id = @ref.Id;
			this.PDescription = Marshal.PtrToStringAnsi(@ref.PDescription);
			this.DescriptionByteLength = @ref.DescriptionByteLength;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00008444 File Offset: 0x00006644
		internal void __MarshalTo(ref InformationQueueMessage.__Native @ref)
		{
			@ref.Producer = this.Producer;
			@ref.Category = this.Category;
			@ref.Severity = this.Severity;
			@ref.Id = this.Id;
			@ref.PDescription = Marshal.StringToHGlobalAnsi(this.PDescription);
			@ref.DescriptionByteLength = this.DescriptionByteLength;
		}

		// Token: 0x04000C39 RID: 3129
		public Guid Producer;

		// Token: 0x04000C3A RID: 3130
		public InformationQueueMessageCategory Category;

		// Token: 0x04000C3B RID: 3131
		public InformationQueueMessageSeverity Severity;

		// Token: 0x04000C3C RID: 3132
		public int Id;

		// Token: 0x04000C3D RID: 3133
		public string PDescription;

		// Token: 0x04000C3E RID: 3134
		public PointerSize DescriptionByteLength;

		// Token: 0x02000086 RID: 134
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000C3F RID: 3135
			public Guid Producer;

			// Token: 0x04000C40 RID: 3136
			public InformationQueueMessageCategory Category;

			// Token: 0x04000C41 RID: 3137
			public InformationQueueMessageSeverity Severity;

			// Token: 0x04000C42 RID: 3138
			public int Id;

			// Token: 0x04000C43 RID: 3139
			public IntPtr PDescription;

			// Token: 0x04000C44 RID: 3140
			public IntPtr DescriptionByteLength;
		}
	}
}
