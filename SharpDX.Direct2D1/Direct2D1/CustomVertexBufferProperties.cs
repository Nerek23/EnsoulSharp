using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001C2 RID: 450
	public class CustomVertexBufferProperties
	{
		// Token: 0x060008A5 RID: 2213 RVA: 0x000067AA File Offset: 0x000049AA
		public CustomVertexBufferProperties()
		{
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x00018C14 File Offset: 0x00016E14
		public CustomVertexBufferProperties(byte[] inputSignature, InputElement[] inputElements, int stride)
		{
			this.InputSignature = inputSignature;
			this.InputElements = inputElements;
			this.Stride = stride;
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060008A7 RID: 2215 RVA: 0x00018C31 File Offset: 0x00016E31
		// (set) Token: 0x060008A8 RID: 2216 RVA: 0x00018C39 File Offset: 0x00016E39
		public byte[] InputSignature { get; set; }

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060008A9 RID: 2217 RVA: 0x00018C42 File Offset: 0x00016E42
		// (set) Token: 0x060008AA RID: 2218 RVA: 0x00018C4A File Offset: 0x00016E4A
		public InputElement[] InputElements { get; set; }

		// Token: 0x060008AB RID: 2219 RVA: 0x00009E0F File Offset: 0x0000800F
		internal void __MarshalFree(ref CustomVertexBufferProperties.__Native @ref)
		{
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x00018C53 File Offset: 0x00016E53
		internal void __MarshalFrom(ref CustomVertexBufferProperties.__Native @ref)
		{
			this.ShaderBufferWithInputSignature = @ref.ShaderBufferWithInputSignature;
			this.ShaderBufferSize = @ref.ShaderBufferSize;
			this.InputElementsPointer = @ref.InputElementsPointer;
			this.ElementCount = @ref.ElementCount;
			this.Stride = @ref.Stride;
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x00018C91 File Offset: 0x00016E91
		internal void __MarshalTo(ref CustomVertexBufferProperties.__Native @ref)
		{
			@ref.ShaderBufferWithInputSignature = this.ShaderBufferWithInputSignature;
			@ref.ShaderBufferSize = this.ShaderBufferSize;
			@ref.InputElementsPointer = this.InputElementsPointer;
			@ref.ElementCount = this.ElementCount;
			@ref.Stride = this.Stride;
		}

		// Token: 0x04000614 RID: 1556
		internal IntPtr ShaderBufferWithInputSignature;

		// Token: 0x04000615 RID: 1557
		internal int ShaderBufferSize;

		// Token: 0x04000616 RID: 1558
		internal IntPtr InputElementsPointer;

		// Token: 0x04000617 RID: 1559
		internal int ElementCount;

		// Token: 0x04000618 RID: 1560
		public int Stride;

		// Token: 0x020001C3 RID: 451
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000619 RID: 1561
			public IntPtr ShaderBufferWithInputSignature;

			// Token: 0x0400061A RID: 1562
			public int ShaderBufferSize;

			// Token: 0x0400061B RID: 1563
			public IntPtr InputElementsPointer;

			// Token: 0x0400061C RID: 1564
			public int ElementCount;

			// Token: 0x0400061D RID: 1565
			public int Stride;
		}
	}
}
