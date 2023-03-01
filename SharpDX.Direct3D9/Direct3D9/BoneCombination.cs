using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200000F RID: 15
	public class BoneCombination
	{
		// Token: 0x06000091 RID: 145 RVA: 0x00003D09 File Offset: 0x00001F09
		internal void __MarshalFree(ref BoneCombination.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003D14 File Offset: 0x00001F14
		internal void __MarshalFrom(ref BoneCombination.__Native @ref)
		{
			this.AttribId = @ref.AttribId;
			this.FaceStart = @ref.FaceStart;
			this.FaceCount = @ref.FaceCount;
			this.VertexStart = @ref.VertexStart;
			this.VertexCount = @ref.VertexCount;
			this.BonedIdsPointer = @ref.BonedIdsPointer;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003D6C File Offset: 0x00001F6C
		internal void __MarshalTo(ref BoneCombination.__Native @ref)
		{
			@ref.AttribId = this.AttribId;
			@ref.FaceStart = this.FaceStart;
			@ref.FaceCount = this.FaceCount;
			@ref.VertexStart = this.VertexStart;
			@ref.VertexCount = this.VertexCount;
			@ref.BonedIdsPointer = IntPtr.Zero;
			if (this.BoneIds != null)
			{
				@ref.BonedIdsPointer = Marshal.AllocHGlobal(this.BoneIds.Length * 4);
			}
		}

		// Token: 0x04000454 RID: 1108
		public int[] BoneIds;

		// Token: 0x04000455 RID: 1109
		public int AttribId;

		// Token: 0x04000456 RID: 1110
		public int FaceStart;

		// Token: 0x04000457 RID: 1111
		public int FaceCount;

		// Token: 0x04000458 RID: 1112
		public int VertexStart;

		// Token: 0x04000459 RID: 1113
		public int VertexCount;

		// Token: 0x0400045A RID: 1114
		internal IntPtr BonedIdsPointer;

		// Token: 0x02000010 RID: 16
		internal struct __Native
		{
			// Token: 0x06000095 RID: 149 RVA: 0x00003DDD File Offset: 0x00001FDD
			internal void __MarshalFree()
			{
				if (this.BonedIdsPointer != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.BonedIdsPointer);
				}
			}

			// Token: 0x0400045B RID: 1115
			public int AttribId;

			// Token: 0x0400045C RID: 1116
			public int FaceStart;

			// Token: 0x0400045D RID: 1117
			public int FaceCount;

			// Token: 0x0400045E RID: 1118
			public int VertexStart;

			// Token: 0x0400045F RID: 1119
			public int VertexCount;

			// Token: 0x04000460 RID: 1120
			public IntPtr BonedIdsPointer;
		}
	}
}
