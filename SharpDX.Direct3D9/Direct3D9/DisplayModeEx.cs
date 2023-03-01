using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200001E RID: 30
	public class DisplayModeEx
	{
		// Token: 0x0600023B RID: 571 RVA: 0x00009489 File Offset: 0x00007689
		public DisplayModeEx()
		{
			this.Size = Utilities.SizeOf<DisplayModeEx.__Native>();
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600023C RID: 572 RVA: 0x0000949C File Offset: 0x0000769C
		public float AspectRatio
		{
			get
			{
				return (float)this.Width / (float)this.Height;
			}
		}

		// Token: 0x0600023D RID: 573 RVA: 0x000094B0 File Offset: 0x000076B0
		public override string ToString()
		{
			return string.Format("Width: {0}, Height: {1}, RefreshRate: {2}, Format: {3}", new object[]
			{
				this.Width,
				this.Height,
				this.RefreshRate,
				this.Format
			});
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00009508 File Offset: 0x00007708
		internal static DisplayModeEx.__Native __NewNative()
		{
			return new DisplayModeEx.__Native
			{
				Size = Utilities.SizeOf<DisplayModeEx.__Native>()
			};
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0000952A File Offset: 0x0000772A
		internal void __MarshalFree(ref DisplayModeEx.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00009534 File Offset: 0x00007734
		internal void __MarshalFrom(ref DisplayModeEx.__Native @ref)
		{
			this.Size = @ref.Size;
			this.Width = @ref.Width;
			this.Height = @ref.Height;
			this.RefreshRate = @ref.RefreshRate;
			this.Format = @ref.Format;
			this.ScanLineOrdering = @ref.ScanLineOrdering;
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000958C File Offset: 0x0000778C
		internal void __MarshalTo(ref DisplayModeEx.__Native @ref)
		{
			@ref.Size = this.Size;
			@ref.Width = this.Width;
			@ref.Height = this.Height;
			@ref.RefreshRate = this.RefreshRate;
			@ref.Format = this.Format;
			@ref.ScanLineOrdering = this.ScanLineOrdering;
		}

		// Token: 0x040004BB RID: 1211
		internal int Size;

		// Token: 0x040004BC RID: 1212
		public int Width;

		// Token: 0x040004BD RID: 1213
		public int Height;

		// Token: 0x040004BE RID: 1214
		public int RefreshRate;

		// Token: 0x040004BF RID: 1215
		public Format Format;

		// Token: 0x040004C0 RID: 1216
		public ScanlineOrdering ScanLineOrdering;

		// Token: 0x0200001F RID: 31
		internal struct __Native
		{
			// Token: 0x06000242 RID: 578 RVA: 0x00002374 File Offset: 0x00000574
			internal void __MarshalFree()
			{
			}

			// Token: 0x040004C1 RID: 1217
			public int Size;

			// Token: 0x040004C2 RID: 1218
			public int Width;

			// Token: 0x040004C3 RID: 1219
			public int Height;

			// Token: 0x040004C4 RID: 1220
			public int RefreshRate;

			// Token: 0x040004C5 RID: 1221
			public Format Format;

			// Token: 0x040004C6 RID: 1222
			public ScanlineOrdering ScanLineOrdering;
		}
	}
}
