using System;

namespace SharpDX
{
	// Token: 0x02000015 RID: 21
	public struct DataRectangle
	{
		// Token: 0x06000092 RID: 146 RVA: 0x00003237 File Offset: 0x00001437
		public DataRectangle(IntPtr dataPointer, int pitch)
		{
			this.DataPointer = dataPointer;
			this.Pitch = pitch;
		}

		// Token: 0x0400001E RID: 30
		public IntPtr DataPointer;

		// Token: 0x0400001F RID: 31
		public int Pitch;
	}
}
