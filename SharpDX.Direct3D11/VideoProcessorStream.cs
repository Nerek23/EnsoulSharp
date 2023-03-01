using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200017E RID: 382
	public struct VideoProcessorStream
	{
		// Token: 0x060004A0 RID: 1184 RVA: 0x000022D3 File Offset: 0x000004D3
		internal void __MarshalFree(ref VideoProcessorStream.__Native @ref)
		{
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x000117DC File Offset: 0x0000F9DC
		internal void __MarshalFrom(ref VideoProcessorStream.__Native @ref)
		{
			this.Enable = @ref.Enable;
			this.OutputIndex = @ref.OutputIndex;
			this.InputFrameOrField = @ref.InputFrameOrField;
			this.PastFrames = @ref.PastFrames;
			this.FutureFrames = @ref.FutureFrames;
			if (@ref.PpPastSurfaces != IntPtr.Zero)
			{
				this.PpPastSurfaces = new VideoProcessorInputView(@ref.PpPastSurfaces);
			}
			else
			{
				this.PpPastSurfaces = null;
			}
			if (@ref.PInputSurface != IntPtr.Zero)
			{
				this.PInputSurface = new VideoProcessorInputView(@ref.PInputSurface);
			}
			else
			{
				this.PInputSurface = null;
			}
			if (@ref.PpFutureSurfaces != IntPtr.Zero)
			{
				this.PpFutureSurfaces = new VideoProcessorInputView(@ref.PpFutureSurfaces);
			}
			else
			{
				this.PpFutureSurfaces = null;
			}
			if (@ref.PpPastSurfacesRight != IntPtr.Zero)
			{
				this.PpPastSurfacesRight = new VideoProcessorInputView(@ref.PpPastSurfacesRight);
			}
			else
			{
				this.PpPastSurfacesRight = null;
			}
			if (@ref.PInputSurfaceRight != IntPtr.Zero)
			{
				this.PInputSurfaceRight = new VideoProcessorInputView(@ref.PInputSurfaceRight);
			}
			else
			{
				this.PInputSurfaceRight = null;
			}
			if (@ref.PpFutureSurfacesRight != IntPtr.Zero)
			{
				this.PpFutureSurfacesRight = new VideoProcessorInputView(@ref.PpFutureSurfacesRight);
				return;
			}
			this.PpFutureSurfacesRight = null;
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x0001192C File Offset: 0x0000FB2C
		internal void __MarshalTo(ref VideoProcessorStream.__Native @ref)
		{
			@ref.Enable = this.Enable;
			@ref.OutputIndex = this.OutputIndex;
			@ref.InputFrameOrField = this.InputFrameOrField;
			@ref.PastFrames = this.PastFrames;
			@ref.FutureFrames = this.FutureFrames;
			@ref.PpPastSurfaces = CppObject.ToCallbackPtr<VideoProcessorInputView>(this.PpPastSurfaces);
			@ref.PInputSurface = CppObject.ToCallbackPtr<VideoProcessorInputView>(this.PInputSurface);
			@ref.PpFutureSurfaces = CppObject.ToCallbackPtr<VideoProcessorInputView>(this.PpFutureSurfaces);
			@ref.PpPastSurfacesRight = CppObject.ToCallbackPtr<VideoProcessorInputView>(this.PpPastSurfacesRight);
			@ref.PInputSurfaceRight = CppObject.ToCallbackPtr<VideoProcessorInputView>(this.PInputSurfaceRight);
			@ref.PpFutureSurfacesRight = CppObject.ToCallbackPtr<VideoProcessorInputView>(this.PpFutureSurfacesRight);
		}

		// Token: 0x04000B6B RID: 2923
		public RawBool Enable;

		// Token: 0x04000B6C RID: 2924
		public int OutputIndex;

		// Token: 0x04000B6D RID: 2925
		public int InputFrameOrField;

		// Token: 0x04000B6E RID: 2926
		public int PastFrames;

		// Token: 0x04000B6F RID: 2927
		public int FutureFrames;

		// Token: 0x04000B70 RID: 2928
		public VideoProcessorInputView PpPastSurfaces;

		// Token: 0x04000B71 RID: 2929
		public VideoProcessorInputView PInputSurface;

		// Token: 0x04000B72 RID: 2930
		public VideoProcessorInputView PpFutureSurfaces;

		// Token: 0x04000B73 RID: 2931
		public VideoProcessorInputView PpPastSurfacesRight;

		// Token: 0x04000B74 RID: 2932
		public VideoProcessorInputView PInputSurfaceRight;

		// Token: 0x04000B75 RID: 2933
		public VideoProcessorInputView PpFutureSurfacesRight;

		// Token: 0x0200017F RID: 383
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000B76 RID: 2934
			public RawBool Enable;

			// Token: 0x04000B77 RID: 2935
			public int OutputIndex;

			// Token: 0x04000B78 RID: 2936
			public int InputFrameOrField;

			// Token: 0x04000B79 RID: 2937
			public int PastFrames;

			// Token: 0x04000B7A RID: 2938
			public int FutureFrames;

			// Token: 0x04000B7B RID: 2939
			public IntPtr PpPastSurfaces;

			// Token: 0x04000B7C RID: 2940
			public IntPtr PInputSurface;

			// Token: 0x04000B7D RID: 2941
			public IntPtr PpFutureSurfaces;

			// Token: 0x04000B7E RID: 2942
			public IntPtr PpPastSurfacesRight;

			// Token: 0x04000B7F RID: 2943
			public IntPtr PInputSurfaceRight;

			// Token: 0x04000B80 RID: 2944
			public IntPtr PpFutureSurfacesRight;
		}
	}
}
