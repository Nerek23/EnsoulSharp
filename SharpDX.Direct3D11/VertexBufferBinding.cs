using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000050 RID: 80
	public struct VertexBufferBinding
	{
		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000313 RID: 787 RVA: 0x0000BF53 File Offset: 0x0000A153
		// (set) Token: 0x06000314 RID: 788 RVA: 0x0000BF5B File Offset: 0x0000A15B
		public Buffer Buffer
		{
			get
			{
				return this.m_Buffer;
			}
			set
			{
				this.m_Buffer = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000315 RID: 789 RVA: 0x0000BF64 File Offset: 0x0000A164
		// (set) Token: 0x06000316 RID: 790 RVA: 0x0000BF6C File Offset: 0x0000A16C
		public int Stride
		{
			get
			{
				return this.m_Stride;
			}
			set
			{
				this.m_Stride = value;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000317 RID: 791 RVA: 0x0000BF75 File Offset: 0x0000A175
		// (set) Token: 0x06000318 RID: 792 RVA: 0x0000BF7D File Offset: 0x0000A17D
		public int Offset
		{
			get
			{
				return this.m_Offset;
			}
			set
			{
				this.m_Offset = value;
			}
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0000BF86 File Offset: 0x0000A186
		public VertexBufferBinding(Buffer buffer, int stride, int offset)
		{
			this.m_Buffer = buffer;
			this.m_Stride = stride;
			this.m_Offset = offset;
		}

		// Token: 0x040000F4 RID: 244
		private Buffer m_Buffer;

		// Token: 0x040000F5 RID: 245
		private int m_Stride;

		// Token: 0x040000F6 RID: 246
		private int m_Offset;
	}
}
