using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000107 RID: 263
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DepthStencilOperationDescription
	{
		// Token: 0x0400095E RID: 2398
		public StencilOperation FailOperation;

		// Token: 0x0400095F RID: 2399
		public StencilOperation DepthFailOperation;

		// Token: 0x04000960 RID: 2400
		public StencilOperation PassOperation;

		// Token: 0x04000961 RID: 2401
		public Comparison Comparison;
	}
}
