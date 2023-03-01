using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200002F RID: 47
	public struct Message
	{
		// Token: 0x0600027F RID: 639 RVA: 0x0000ABC4 File Offset: 0x00008DC4
		internal void __MarshalFrom(ref Message.__Native @ref)
		{
			this.Category = @ref.Category;
			this.Severity = @ref.Severity;
			this.Id = @ref.Id;
			this.Description = ((@ref.PDescription == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(@ref.PDescription, @ref.DescriptionByteLength));
			this.DescriptionByteLength = @ref.DescriptionByteLength;
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000AC34 File Offset: 0x00008E34
		public override string ToString()
		{
			return string.Format("[{0}] [{1}] [{2}] : {3}", new object[]
			{
				this.Id,
				this.Severity,
				this.Category,
				this.Description
			});
		}

		// Token: 0x040000A7 RID: 167
		public MessageCategory Category;

		// Token: 0x040000A8 RID: 168
		public MessageSeverity Severity;

		// Token: 0x040000A9 RID: 169
		public MessageId Id;

		// Token: 0x040000AA RID: 170
		public string Description;

		// Token: 0x040000AB RID: 171
		internal PointerSize DescriptionByteLength;

		// Token: 0x02000030 RID: 48
		internal struct __Native
		{
			// Token: 0x040000AC RID: 172
			public MessageCategory Category;

			// Token: 0x040000AD RID: 173
			public MessageSeverity Severity;

			// Token: 0x040000AE RID: 174
			public MessageId Id;

			// Token: 0x040000AF RID: 175
			public IntPtr PDescription;

			// Token: 0x040000B0 RID: 176
			public PointerSize DescriptionByteLength;
		}
	}
}
