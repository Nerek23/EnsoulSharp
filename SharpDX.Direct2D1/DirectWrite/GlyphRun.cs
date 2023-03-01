using System;
using System.Globalization;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000A6 RID: 166
	public class GlyphRun : IDisposable
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600034D RID: 845 RVA: 0x0000C45D File Offset: 0x0000A65D
		// (set) Token: 0x0600034E RID: 846 RVA: 0x0000C465 File Offset: 0x0000A665
		public FontFace FontFace { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600034F RID: 847 RVA: 0x0000C46E File Offset: 0x0000A66E
		// (set) Token: 0x06000350 RID: 848 RVA: 0x0000C476 File Offset: 0x0000A676
		public short[] Indices { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000351 RID: 849 RVA: 0x0000C47F File Offset: 0x0000A67F
		// (set) Token: 0x06000352 RID: 850 RVA: 0x0000C487 File Offset: 0x0000A687
		public float[] Advances { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000353 RID: 851 RVA: 0x0000C490 File Offset: 0x0000A690
		// (set) Token: 0x06000354 RID: 852 RVA: 0x0000C498 File Offset: 0x0000A698
		public GlyphOffset[] Offsets { get; set; }

		// Token: 0x06000355 RID: 853 RVA: 0x0000C4A1 File Offset: 0x0000A6A1
		internal void __MarshalFree(ref GlyphRun.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000C4AC File Offset: 0x0000A6AC
		internal void __MarshalFrom(ref GlyphRun.__Native @ref)
		{
			this.FontFace = ((@ref.FontFace == IntPtr.Zero) ? null : new FontFace(@ref.FontFace));
			if (this.FontFace != null)
			{
				((IUnknown)this.FontFace).AddReference();
			}
			this.FontSize = @ref.FontEmSize;
			this.GlyphCount = @ref.GlyphCount;
			if (@ref.GlyphIndices != IntPtr.Zero)
			{
				this.Indices = new short[this.GlyphCount];
				if (this.GlyphCount > 0)
				{
					Utilities.Read<short>(@ref.GlyphIndices, this.Indices, 0, this.GlyphCount);
				}
			}
			if (@ref.GlyphAdvances != IntPtr.Zero)
			{
				this.Advances = new float[this.GlyphCount];
				if (this.GlyphCount > 0)
				{
					Utilities.Read<float>(@ref.GlyphAdvances, this.Advances, 0, this.GlyphCount);
				}
			}
			if (@ref.GlyphOffsets != IntPtr.Zero)
			{
				this.Offsets = new GlyphOffset[this.GlyphCount];
				if (this.GlyphCount > 0)
				{
					Utilities.Read<GlyphOffset>(@ref.GlyphOffsets, this.Offsets, 0, this.GlyphCount);
				}
			}
			this.IsSideways = @ref.IsSideways;
			this.BidiLevel = @ref.BidiLevel;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0000C5F4 File Offset: 0x0000A7F4
		internal void __MarshalTo(ref GlyphRun.__Native @ref)
		{
			@ref.FontFace = ((this.FontFace == null) ? IntPtr.Zero : this.FontFace.NativePointer);
			@ref.FontEmSize = this.FontSize;
			@ref.GlyphCount = -1;
			@ref.GlyphIndices = IntPtr.Zero;
			@ref.GlyphAdvances = IntPtr.Zero;
			@ref.GlyphOffsets = IntPtr.Zero;
			if (this.Indices != null)
			{
				@ref.GlyphCount = this.Indices.Length;
				@ref.GlyphIndices = Marshal.AllocHGlobal(this.Indices.Length * 2);
				if (this.Indices.Length != 0)
				{
					Utilities.Write<short>(@ref.GlyphIndices, this.Indices, 0, this.Indices.Length);
				}
			}
			if (this.Advances != null)
			{
				if (@ref.GlyphCount >= 0 && @ref.GlyphCount != this.Advances.Length)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Invalid length for array Advances [{0}] and Indices [{1}]. Indices, Advances and Offsets array must have same size - or may be null", new object[]
					{
						this.Advances.Length,
						@ref.GlyphCount
					}));
				}
				@ref.GlyphCount = this.Advances.Length;
				@ref.GlyphAdvances = Marshal.AllocHGlobal(this.Advances.Length * 4);
				if (this.Advances.Length != 0)
				{
					Utilities.Write<float>(@ref.GlyphAdvances, this.Advances, 0, this.Advances.Length);
				}
			}
			if (this.Offsets != null)
			{
				if (@ref.GlyphCount >= 0 && @ref.GlyphCount != this.Offsets.Length)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Invalid length for array Offsets [{0}]. Indices, Advances and Offsets array must have same size (Current is [{1}]- or may be null", new object[]
					{
						this.Offsets.Length,
						@ref.GlyphCount
					}));
				}
				@ref.GlyphCount = this.Offsets.Length;
				@ref.GlyphOffsets = Marshal.AllocHGlobal(this.Offsets.Length * sizeof(GlyphOffset));
				if (this.Offsets.Length != 0)
				{
					Utilities.Write<GlyphOffset>(@ref.GlyphOffsets, this.Offsets, 0, this.Offsets.Length);
				}
			}
			if (@ref.GlyphCount < 0)
			{
				@ref.GlyphCount = 0;
			}
			this.GlyphCount = @ref.GlyphCount;
			@ref.IsSideways = this.IsSideways;
			@ref.BidiLevel = this.BidiLevel;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0000C825 File Offset: 0x0000AA25
		public void Dispose()
		{
			if (this.FontFace != null)
			{
				this.FontFace.Dispose();
				this.FontFace = null;
			}
		}

		// Token: 0x0400022F RID: 559
		internal FontFace FontFacePointer;

		// Token: 0x04000230 RID: 560
		public float FontSize;

		// Token: 0x04000231 RID: 561
		internal int GlyphCount;

		// Token: 0x04000232 RID: 562
		internal IntPtr GlyphIndicesPointer;

		// Token: 0x04000233 RID: 563
		internal IntPtr GlyphAdvancesPointer;

		// Token: 0x04000234 RID: 564
		internal IntPtr GlyphOffsetsPointer;

		// Token: 0x04000235 RID: 565
		public RawBool IsSideways;

		// Token: 0x04000236 RID: 566
		public int BidiLevel;

		// Token: 0x020000A7 RID: 167
		internal struct __Native
		{
			// Token: 0x0600035A RID: 858 RVA: 0x0000C844 File Offset: 0x0000AA44
			internal void __MarshalFree()
			{
				if (this.GlyphIndices != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.GlyphIndices);
				}
				if (this.GlyphAdvances != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.GlyphAdvances);
				}
				if (this.GlyphOffsets != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.GlyphOffsets);
				}
			}

			// Token: 0x04000237 RID: 567
			public IntPtr FontFace;

			// Token: 0x04000238 RID: 568
			public float FontEmSize;

			// Token: 0x04000239 RID: 569
			public int GlyphCount;

			// Token: 0x0400023A RID: 570
			public IntPtr GlyphIndices;

			// Token: 0x0400023B RID: 571
			public IntPtr GlyphAdvances;

			// Token: 0x0400023C RID: 572
			public IntPtr GlyphOffsets;

			// Token: 0x0400023D RID: 573
			public RawBool IsSideways;

			// Token: 0x0400023E RID: 574
			public int BidiLevel;
		}
	}
}
