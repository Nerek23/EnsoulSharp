using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000249 RID: 585
	public class VertexBufferProperties
	{
		// Token: 0x06000D6F RID: 3439 RVA: 0x000067AA File Offset: 0x000049AA
		public VertexBufferProperties()
		{
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x00024F37 File Offset: 0x00023137
		public VertexBufferProperties(int inputCount, VertexUsage usage, DataStream data)
		{
			this.InputCount = inputCount;
			this.Usage = usage;
			this.Data = data;
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000D71 RID: 3441 RVA: 0x00024F54 File Offset: 0x00023154
		// (set) Token: 0x06000D72 RID: 3442 RVA: 0x00024F5C File Offset: 0x0002315C
		public DataStream Data
		{
			get
			{
				return this.data;
			}
			set
			{
				this.data = value;
				if (this.data != null)
				{
					this.DataPointer = this.data.DataPointer;
					this.SizeInBytes = (int)this.data.Length;
				}
			}
		}

		// Token: 0x06000D73 RID: 3443 RVA: 0x00009E0F File Offset: 0x0000800F
		internal void __MarshalFree(ref VertexBufferProperties.__Native @ref)
		{
		}

		// Token: 0x06000D74 RID: 3444 RVA: 0x00024F90 File Offset: 0x00023190
		internal void __MarshalFrom(ref VertexBufferProperties.__Native @ref)
		{
			this.InputCount = @ref.InputCount;
			this.Usage = @ref.Usage;
			this.DataPointer = @ref.DataPointer;
			this.SizeInBytes = @ref.SizeInBytes;
		}

		// Token: 0x06000D75 RID: 3445 RVA: 0x00024FC2 File Offset: 0x000231C2
		internal void __MarshalTo(ref VertexBufferProperties.__Native @ref)
		{
			@ref.InputCount = this.InputCount;
			@ref.Usage = this.Usage;
			@ref.DataPointer = this.DataPointer;
			@ref.SizeInBytes = this.SizeInBytes;
		}

		// Token: 0x040006C7 RID: 1735
		private DataStream data;

		// Token: 0x040006C8 RID: 1736
		public int InputCount;

		// Token: 0x040006C9 RID: 1737
		public VertexUsage Usage;

		// Token: 0x040006CA RID: 1738
		internal IntPtr DataPointer;

		// Token: 0x040006CB RID: 1739
		internal int SizeInBytes;

		// Token: 0x0200024A RID: 586
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040006CC RID: 1740
			public int InputCount;

			// Token: 0x040006CD RID: 1741
			public VertexUsage Usage;

			// Token: 0x040006CE RID: 1742
			public IntPtr DataPointer;

			// Token: 0x040006CF RID: 1743
			public int SizeInBytes;
		}
	}
}
