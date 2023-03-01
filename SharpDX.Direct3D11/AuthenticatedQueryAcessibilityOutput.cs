using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000E5 RID: 229
	public struct AuthenticatedQueryAcessibilityOutput
	{
		// Token: 0x06000457 RID: 1111 RVA: 0x00010CB4 File Offset: 0x0000EEB4
		internal void __MarshalFree(ref AuthenticatedQueryAcessibilityOutput.__Native @ref)
		{
			this.Output.__MarshalFree(ref @ref.Output);
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00010CC7 File Offset: 0x0000EEC7
		internal void __MarshalFrom(ref AuthenticatedQueryAcessibilityOutput.__Native @ref)
		{
			this.Output.__MarshalFrom(ref @ref.Output);
			this.BusType = @ref.BusType;
			this.AccessibleInContiguousBlocks = @ref.AccessibleInContiguousBlocks;
			this.AccessibleInNonContiguousBlocks = @ref.AccessibleInNonContiguousBlocks;
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00010CFE File Offset: 0x0000EEFE
		internal void __MarshalTo(ref AuthenticatedQueryAcessibilityOutput.__Native @ref)
		{
			this.Output.__MarshalTo(ref @ref.Output);
			@ref.BusType = this.BusType;
			@ref.AccessibleInContiguousBlocks = this.AccessibleInContiguousBlocks;
			@ref.AccessibleInNonContiguousBlocks = this.AccessibleInNonContiguousBlocks;
		}

		// Token: 0x040008F3 RID: 2291
		public AuthenticatedQueryOutput Output;

		// Token: 0x040008F4 RID: 2292
		public BusType BusType;

		// Token: 0x040008F5 RID: 2293
		public RawBool AccessibleInContiguousBlocks;

		// Token: 0x040008F6 RID: 2294
		public RawBool AccessibleInNonContiguousBlocks;

		// Token: 0x020000E6 RID: 230
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040008F7 RID: 2295
			public AuthenticatedQueryOutput.__Native Output;

			// Token: 0x040008F8 RID: 2296
			public BusType BusType;

			// Token: 0x040008F9 RID: 2297
			public RawBool AccessibleInContiguousBlocks;

			// Token: 0x040008FA RID: 2298
			public RawBool AccessibleInNonContiguousBlocks;
		}
	}
}
