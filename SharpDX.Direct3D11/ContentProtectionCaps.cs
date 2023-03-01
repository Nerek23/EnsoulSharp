using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000060 RID: 96
	public enum ContentProtectionCaps
	{
		// Token: 0x0400015B RID: 347
		Software = 1,
		// Token: 0x0400015C RID: 348
		Hardware,
		// Token: 0x0400015D RID: 349
		ProtectionAlwaysOn = 4,
		// Token: 0x0400015E RID: 350
		PartialDecryption = 8,
		// Token: 0x0400015F RID: 351
		ContentKey = 16,
		// Token: 0x04000160 RID: 352
		FreshenSessionKey = 32,
		// Token: 0x04000161 RID: 353
		EncryptedReadBack = 64,
		// Token: 0x04000162 RID: 354
		EncryptedReadBackKey = 128,
		// Token: 0x04000163 RID: 355
		SequentialCtrIv = 256,
		// Token: 0x04000164 RID: 356
		EncryptSlicedataOnly = 512,
		// Token: 0x04000165 RID: 357
		DecryptionBlit = 1024,
		// Token: 0x04000166 RID: 358
		HardwareProtectUncompressed = 2048,
		// Token: 0x04000167 RID: 359
		HardwareProtectedMemoryPageable = 4096,
		// Token: 0x04000168 RID: 360
		HardwareTeardown = 8192,
		// Token: 0x04000169 RID: 361
		HardwareDrmCommunication = 16384
	}
}
