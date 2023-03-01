using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000046 RID: 70
	public struct StreamOutputBufferBinding
	{
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060002D7 RID: 727 RVA: 0x0000B727 File Offset: 0x00009927
		// (set) Token: 0x060002D8 RID: 728 RVA: 0x0000B72F File Offset: 0x0000992F
		public Buffer Buffer
		{
			get
			{
				return this._buffer;
			}
			set
			{
				this._buffer = value;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060002D9 RID: 729 RVA: 0x0000B738 File Offset: 0x00009938
		// (set) Token: 0x060002DA RID: 730 RVA: 0x0000B740 File Offset: 0x00009940
		public int Offset
		{
			get
			{
				return this._offset;
			}
			set
			{
				this._offset = value;
			}
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000B749 File Offset: 0x00009949
		public StreamOutputBufferBinding(Buffer buffer, int offset)
		{
			this._buffer = buffer;
			this._offset = offset;
		}

		// Token: 0x040000E6 RID: 230
		private Buffer _buffer;

		// Token: 0x040000E7 RID: 231
		private int _offset;
	}
}
