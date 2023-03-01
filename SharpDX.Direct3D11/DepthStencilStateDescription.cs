using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000011 RID: 17
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DepthStencilStateDescription
	{
		// Token: 0x06000052 RID: 82 RVA: 0x00002E60 File Offset: 0x00001060
		public static DepthStencilStateDescription Default()
		{
			DepthStencilStateDescription result = default(DepthStencilStateDescription);
			result.IsDepthEnabled = true;
			result.DepthWriteMask = DepthWriteMask.All;
			result.DepthComparison = Comparison.Less;
			result.IsStencilEnabled = false;
			result.StencilReadMask = byte.MaxValue;
			result.StencilWriteMask = byte.MaxValue;
			result.FrontFace.Comparison = Comparison.Always;
			result.FrontFace.DepthFailOperation = StencilOperation.Keep;
			result.FrontFace.FailOperation = StencilOperation.Keep;
			result.FrontFace.PassOperation = StencilOperation.Keep;
			result.BackFace.Comparison = Comparison.Always;
			result.BackFace.DepthFailOperation = StencilOperation.Keep;
			result.BackFace.FailOperation = StencilOperation.Keep;
			result.BackFace.PassOperation = StencilOperation.Keep;
			return result;
		}

		// Token: 0x04000026 RID: 38
		public RawBool IsDepthEnabled;

		// Token: 0x04000027 RID: 39
		public DepthWriteMask DepthWriteMask;

		// Token: 0x04000028 RID: 40
		public Comparison DepthComparison;

		// Token: 0x04000029 RID: 41
		public RawBool IsStencilEnabled;

		// Token: 0x0400002A RID: 42
		public byte StencilReadMask;

		// Token: 0x0400002B RID: 43
		public byte StencilWriteMask;

		// Token: 0x0400002C RID: 44
		public DepthStencilOperationDescription FrontFace;

		// Token: 0x0400002D RID: 45
		public DepthStencilOperationDescription BackFace;
	}
}
