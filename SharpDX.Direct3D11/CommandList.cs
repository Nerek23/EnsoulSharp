using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000B3 RID: 179
	[Guid("a24bc4d1-769e-43f7-8013-98ff566c18e2")]
	public class CommandList : DeviceChild
	{
		// Token: 0x0600036A RID: 874 RVA: 0x00002075 File Offset: 0x00000275
		public CommandList(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0000D8B4 File Offset: 0x0000BAB4
		public new static explicit operator CommandList(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new CommandList(nativePtr);
			}
			return null;
		}
	}
}
