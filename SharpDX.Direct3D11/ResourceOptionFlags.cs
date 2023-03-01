using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000083 RID: 131
	[Flags]
	public enum ResourceOptionFlags
	{
		// Token: 0x0400078E RID: 1934
		GenerateMipMaps = 1,
		// Token: 0x0400078F RID: 1935
		Shared = 2,
		// Token: 0x04000790 RID: 1936
		TextureCube = 4,
		// Token: 0x04000791 RID: 1937
		DrawIndirectArguments = 16,
		// Token: 0x04000792 RID: 1938
		BufferAllowRawViews = 32,
		// Token: 0x04000793 RID: 1939
		BufferStructured = 64,
		// Token: 0x04000794 RID: 1940
		ResourceClamp = 128,
		// Token: 0x04000795 RID: 1941
		SharedKeyedmutex = 256,
		// Token: 0x04000796 RID: 1942
		GdiCompatible = 512,
		// Token: 0x04000797 RID: 1943
		SharedNthandle = 2048,
		// Token: 0x04000798 RID: 1944
		RestrictedContent = 4096,
		// Token: 0x04000799 RID: 1945
		RestrictSharedResource = 8192,
		// Token: 0x0400079A RID: 1946
		RestrictSharedResourceDriver = 16384,
		// Token: 0x0400079B RID: 1947
		Guarded = 32768,
		// Token: 0x0400079C RID: 1948
		TilePool = 131072,
		// Token: 0x0400079D RID: 1949
		Tiled = 262144,
		// Token: 0x0400079E RID: 1950
		HwProtected = 524288,
		// Token: 0x0400079F RID: 1951
		None = 0
	}
}
