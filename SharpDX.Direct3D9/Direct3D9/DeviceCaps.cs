using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000054 RID: 84
	[Flags]
	public enum DeviceCaps
	{
		// Token: 0x04000617 RID: 1559
		ExecuteSystemMemory = 16,
		// Token: 0x04000618 RID: 1560
		ExecuteVideoMemory = 32,
		// Token: 0x04000619 RID: 1561
		TLVertexSystemMemory = 64,
		// Token: 0x0400061A RID: 1562
		TLVertexVideoMemory = 128,
		// Token: 0x0400061B RID: 1563
		TextureSystemMemory = 256,
		// Token: 0x0400061C RID: 1564
		TextureVideoMemory = 512,
		// Token: 0x0400061D RID: 1565
		DrawPrimTLVertex = 1024,
		// Token: 0x0400061E RID: 1566
		CanRenderAfterFlip = 2048,
		// Token: 0x0400061F RID: 1567
		TextureNonLocalVideoMemory = 4096,
		// Token: 0x04000620 RID: 1568
		DrawPrimitives2 = 8192,
		// Token: 0x04000621 RID: 1569
		SeparateTextureMemory = 16384,
		// Token: 0x04000622 RID: 1570
		DrawPrimitives2Extended = 32768,
		// Token: 0x04000623 RID: 1571
		HWTransformAndLight = 65536,
		// Token: 0x04000624 RID: 1572
		CanBlitSysToNonLocal = 131072,
		// Token: 0x04000625 RID: 1573
		HWRasterization = 524288,
		// Token: 0x04000626 RID: 1574
		PureDevice = 1048576,
		// Token: 0x04000627 RID: 1575
		QuinticRTPatches = 2097152,
		// Token: 0x04000628 RID: 1576
		RTPatches = 4194304,
		// Token: 0x04000629 RID: 1577
		RTPatchHandleZero = 8388608,
		// Token: 0x0400062A RID: 1578
		NPatches = 16777216
	}
}
