using System;

namespace SharpDX
{
	// Token: 0x02000012 RID: 18
	public struct DataBox
	{
		// Token: 0x06000069 RID: 105 RVA: 0x00002BA5 File Offset: 0x00000DA5
		public DataBox(IntPtr datapointer, int rowPitch, int slicePitch)
		{
			this.DataPointer = datapointer;
			this.RowPitch = rowPitch;
			this.SlicePitch = slicePitch;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002BBC File Offset: 0x00000DBC
		public DataBox(IntPtr dataPointer)
		{
			this.DataPointer = dataPointer;
			this.RowPitch = 0;
			this.SlicePitch = 0;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00002BD3 File Offset: 0x00000DD3
		public bool IsEmpty
		{
			get
			{
				return this.DataPointer == IntPtr.Zero && this.RowPitch == 0 && this.SlicePitch == 0;
			}
		}

		// Token: 0x04000013 RID: 19
		public IntPtr DataPointer;

		// Token: 0x04000014 RID: 20
		public int RowPitch;

		// Token: 0x04000015 RID: 21
		public int SlicePitch;
	}
}
