using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200003C RID: 60
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct RenderTargetBlendDescription
	{
		// Token: 0x060002A5 RID: 677 RVA: 0x0000B0E8 File Offset: 0x000092E8
		public RenderTargetBlendDescription(bool isBlendEnabled, BlendOption sourceBlend, BlendOption destinationBlend, BlendOperation blendOperation, BlendOption sourceAlphaBlend, BlendOption destinationAlphaBlend, BlendOperation alphaBlendOperation, ColorWriteMaskFlags renderTargetWriteMask)
		{
			this.IsBlendEnabled = isBlendEnabled;
			this.SourceBlend = sourceBlend;
			this.DestinationBlend = destinationBlend;
			this.BlendOperation = blendOperation;
			this.SourceAlphaBlend = sourceAlphaBlend;
			this.DestinationAlphaBlend = destinationAlphaBlend;
			this.AlphaBlendOperation = alphaBlendOperation;
			this.RenderTargetWriteMask = renderTargetWriteMask;
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000B138 File Offset: 0x00009338
		public override string ToString()
		{
			return string.Format("IsBlendEnabled: {0}, SourceBlend: {1}, DestinationBlend: {2}, BlendOperation: {3}, SourceAlphaBlend: {4}, DestinationAlphaBlend: {5}, AlphaBlendOperation: {6}, RenderTargetWriteMask: {7}", new object[]
			{
				this.IsBlendEnabled,
				this.SourceBlend,
				this.DestinationBlend,
				this.BlendOperation,
				this.SourceAlphaBlend,
				this.DestinationAlphaBlend,
				this.AlphaBlendOperation,
				this.RenderTargetWriteMask
			});
		}

		// Token: 0x040000C6 RID: 198
		public RawBool IsBlendEnabled;

		// Token: 0x040000C7 RID: 199
		public BlendOption SourceBlend;

		// Token: 0x040000C8 RID: 200
		public BlendOption DestinationBlend;

		// Token: 0x040000C9 RID: 201
		public BlendOperation BlendOperation;

		// Token: 0x040000CA RID: 202
		public BlendOption SourceAlphaBlend;

		// Token: 0x040000CB RID: 203
		public BlendOption DestinationAlphaBlend;

		// Token: 0x040000CC RID: 204
		public BlendOperation AlphaBlendOperation;

		// Token: 0x040000CD RID: 205
		public ColorWriteMaskFlags RenderTargetWriteMask;
	}
}
