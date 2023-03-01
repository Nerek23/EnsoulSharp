using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200000A RID: 10
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct BufferDescription
	{
		// Token: 0x06000028 RID: 40 RVA: 0x00002953 File Offset: 0x00000B53
		public BufferDescription(int sizeInBytes, ResourceUsage usage, BindFlags bindFlags, CpuAccessFlags cpuAccessFlags, ResourceOptionFlags optionFlags, int structureByteStride)
		{
			this.SizeInBytes = sizeInBytes;
			this.Usage = usage;
			this.BindFlags = bindFlags;
			this.CpuAccessFlags = cpuAccessFlags;
			this.OptionFlags = optionFlags;
			this.StructureByteStride = structureByteStride;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002982 File Offset: 0x00000B82
		public BufferDescription(int sizeInBytes, BindFlags bindFlags, ResourceUsage usage)
		{
			this = default(BufferDescription);
			this.SizeInBytes = sizeInBytes;
			this.BindFlags = bindFlags;
			this.Usage = usage;
		}

		// Token: 0x0400001B RID: 27
		public int SizeInBytes;

		// Token: 0x0400001C RID: 28
		public ResourceUsage Usage;

		// Token: 0x0400001D RID: 29
		public BindFlags BindFlags;

		// Token: 0x0400001E RID: 30
		public CpuAccessFlags CpuAccessFlags;

		// Token: 0x0400001F RID: 31
		public ResourceOptionFlags OptionFlags;

		// Token: 0x04000020 RID: 32
		public int StructureByteStride;
	}
}
