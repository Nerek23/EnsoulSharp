using System;

namespace SharpDX.IO
{
	// Token: 0x0200009A RID: 154
	[Flags]
	public enum NativeFileOptions : uint
	{
		// Token: 0x040011B0 RID: 4528
		None = 0U,
		// Token: 0x040011B1 RID: 4529
		Readonly = 1U,
		// Token: 0x040011B2 RID: 4530
		Hidden = 2U,
		// Token: 0x040011B3 RID: 4531
		System = 4U,
		// Token: 0x040011B4 RID: 4532
		Directory = 16U,
		// Token: 0x040011B5 RID: 4533
		Archive = 32U,
		// Token: 0x040011B6 RID: 4534
		Device = 64U,
		// Token: 0x040011B7 RID: 4535
		Normal = 128U,
		// Token: 0x040011B8 RID: 4536
		Temporary = 256U,
		// Token: 0x040011B9 RID: 4537
		SparseFile = 512U,
		// Token: 0x040011BA RID: 4538
		ReparsePoint = 1024U,
		// Token: 0x040011BB RID: 4539
		Compressed = 2048U,
		// Token: 0x040011BC RID: 4540
		Offline = 4096U,
		// Token: 0x040011BD RID: 4541
		NotContentIndexed = 8192U,
		// Token: 0x040011BE RID: 4542
		Encrypted = 16384U,
		// Token: 0x040011BF RID: 4543
		Write_Through = 2147483648U,
		// Token: 0x040011C0 RID: 4544
		Overlapped = 1073741824U,
		// Token: 0x040011C1 RID: 4545
		NoBuffering = 536870912U,
		// Token: 0x040011C2 RID: 4546
		RandomAccess = 268435456U,
		// Token: 0x040011C3 RID: 4547
		SequentialScan = 134217728U,
		// Token: 0x040011C4 RID: 4548
		DeleteOnClose = 67108864U,
		// Token: 0x040011C5 RID: 4549
		BackupSemantics = 33554432U,
		// Token: 0x040011C6 RID: 4550
		PosixSemantics = 16777216U,
		// Token: 0x040011C7 RID: 4551
		OpenReparsePoint = 2097152U,
		// Token: 0x040011C8 RID: 4552
		OpenNoRecall = 1048576U,
		// Token: 0x040011C9 RID: 4553
		FirstPipeInstance = 524288U
	}
}
