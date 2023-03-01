using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001A9 RID: 425
	[Guid("0d85573c-01e3-4f7d-bfd9-0d60608bf3c3")]
	[Shadow(typeof(ComputeTransformShadow))]
	public interface ComputeTransform : Transform, TransformNode, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000832 RID: 2098
		void SetComputeInformation(ComputeInformation computeInfo);

		// Token: 0x06000833 RID: 2099
		RawInt3 CalculateThreadgroups(RawRectangle outputRect);
	}
}
