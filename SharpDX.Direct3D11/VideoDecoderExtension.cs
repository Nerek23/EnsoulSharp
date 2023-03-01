using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000172 RID: 370
	public struct VideoDecoderExtension
	{
		// Token: 0x06000491 RID: 1169 RVA: 0x000022D3 File Offset: 0x000004D3
		internal void __MarshalFree(ref VideoDecoderExtension.__Native @ref)
		{
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x000115FC File Offset: 0x0000F7FC
		internal void __MarshalFrom(ref VideoDecoderExtension.__Native @ref)
		{
			this.Function = @ref.Function;
			this.PPrivateInputData = @ref.PPrivateInputData;
			this.PrivateInputDataSize = @ref.PrivateInputDataSize;
			this.PPrivateOutputData = @ref.PPrivateOutputData;
			this.PrivateOutputDataSize = @ref.PrivateOutputDataSize;
			this.ResourceCount = @ref.ResourceCount;
			if (@ref.PpResourceList != IntPtr.Zero)
			{
				this.PpResourceList = new Resource(@ref.PpResourceList);
				return;
			}
			this.PpResourceList = null;
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0001167C File Offset: 0x0000F87C
		internal void __MarshalTo(ref VideoDecoderExtension.__Native @ref)
		{
			@ref.Function = this.Function;
			@ref.PPrivateInputData = this.PPrivateInputData;
			@ref.PrivateInputDataSize = this.PrivateInputDataSize;
			@ref.PPrivateOutputData = this.PPrivateOutputData;
			@ref.PrivateOutputDataSize = this.PrivateOutputDataSize;
			@ref.ResourceCount = this.ResourceCount;
			@ref.PpResourceList = CppObject.ToCallbackPtr<Resource>(this.PpResourceList);
		}

		// Token: 0x04000B2E RID: 2862
		public int Function;

		// Token: 0x04000B2F RID: 2863
		public IntPtr PPrivateInputData;

		// Token: 0x04000B30 RID: 2864
		public int PrivateInputDataSize;

		// Token: 0x04000B31 RID: 2865
		public IntPtr PPrivateOutputData;

		// Token: 0x04000B32 RID: 2866
		public int PrivateOutputDataSize;

		// Token: 0x04000B33 RID: 2867
		public int ResourceCount;

		// Token: 0x04000B34 RID: 2868
		public Resource PpResourceList;

		// Token: 0x02000173 RID: 371
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000B35 RID: 2869
			public int Function;

			// Token: 0x04000B36 RID: 2870
			public IntPtr PPrivateInputData;

			// Token: 0x04000B37 RID: 2871
			public int PrivateInputDataSize;

			// Token: 0x04000B38 RID: 2872
			public IntPtr PPrivateOutputData;

			// Token: 0x04000B39 RID: 2873
			public int PrivateOutputDataSize;

			// Token: 0x04000B3A RID: 2874
			public int ResourceCount;

			// Token: 0x04000B3B RID: 2875
			public IntPtr PpResourceList;
		}
	}
}
