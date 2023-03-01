using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000B0 RID: 176
	public static class ResultCode
	{
		// Token: 0x04000899 RID: 2201
		public static readonly ResultDescriptor TooManyUniqueStateObjects = new ResultDescriptor(-2005139455, "SharpDX.Direct3D11", "D3D11_ERROR_TOO_MANY_UNIQUE_STATE_OBJECTS", "TooManyUniqueStateObjects", null);

		// Token: 0x0400089A RID: 2202
		public static readonly ResultDescriptor FileNotFound = new ResultDescriptor(-2005139454, "SharpDX.Direct3D11", "D3D11_ERROR_FILE_NOT_FOUND", "FileNotFound", null);

		// Token: 0x0400089B RID: 2203
		public static readonly ResultDescriptor TooManyUniqueViewObjects = new ResultDescriptor(-2005139453, "SharpDX.Direct3D11", "D3D11_ERROR_TOO_MANY_UNIQUE_VIEW_OBJECTS", "TooManyUniqueViewObjects", null);

		// Token: 0x0400089C RID: 2204
		public static readonly ResultDescriptor DeferredContextMapWithoutInitialDiscard = new ResultDescriptor(-2005139452, "SharpDX.Direct3D11", "D3D11_ERROR_DEFERRED_CONTEXT_MAP_WITHOUT_INITIAL_DISCARD", "DeferredContextMapWithoutInitialDiscard", null);
	}
}
