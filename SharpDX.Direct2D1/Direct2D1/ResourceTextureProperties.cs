using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000219 RID: 537
	public class ResourceTextureProperties
	{
		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000C27 RID: 3111 RVA: 0x0002277A File Offset: 0x0002097A
		// (set) Token: 0x06000C28 RID: 3112 RVA: 0x00022782 File Offset: 0x00020982
		public int[] Extents { get; set; }

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000C29 RID: 3113 RVA: 0x0002278B File Offset: 0x0002098B
		// (set) Token: 0x06000C2A RID: 3114 RVA: 0x00022793 File Offset: 0x00020993
		public ExtendMode[] ExtendModes { get; set; }

		// Token: 0x06000C2B RID: 3115 RVA: 0x00009E0F File Offset: 0x0000800F
		internal void __MarshalFree(ref ResourceTextureProperties.__Native @ref)
		{
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x0002279C File Offset: 0x0002099C
		internal void __MarshalFrom(ref ResourceTextureProperties.__Native @ref)
		{
			this.ExtentsPointer = @ref.ExtentsPointer;
			this.Dimensions = @ref.Dimensions;
			this.BufferPrecision = @ref.BufferPrecision;
			this.ChannelDepth = @ref.ChannelDepth;
			this.Filter = @ref.Filter;
			this.ExtendModesPointer = @ref.ExtendModesPointer;
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x000227F4 File Offset: 0x000209F4
		internal void __MarshalTo(ref ResourceTextureProperties.__Native @ref)
		{
			@ref.ExtentsPointer = this.ExtentsPointer;
			@ref.Dimensions = this.Dimensions;
			@ref.BufferPrecision = this.BufferPrecision;
			@ref.ChannelDepth = this.ChannelDepth;
			@ref.Filter = this.Filter;
			@ref.ExtendModesPointer = this.ExtendModesPointer;
		}

		// Token: 0x040006B6 RID: 1718
		internal IntPtr ExtentsPointer;

		// Token: 0x040006B7 RID: 1719
		public int Dimensions;

		// Token: 0x040006B8 RID: 1720
		public BufferPrecision BufferPrecision;

		// Token: 0x040006B9 RID: 1721
		public ChannelDepth ChannelDepth;

		// Token: 0x040006BA RID: 1722
		public Filter Filter;

		// Token: 0x040006BB RID: 1723
		internal IntPtr ExtendModesPointer;

		// Token: 0x0200021A RID: 538
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040006BC RID: 1724
			public IntPtr ExtentsPointer;

			// Token: 0x040006BD RID: 1725
			public int Dimensions;

			// Token: 0x040006BE RID: 1726
			public BufferPrecision BufferPrecision;

			// Token: 0x040006BF RID: 1727
			public ChannelDepth ChannelDepth;

			// Token: 0x040006C0 RID: 1728
			public Filter Filter;

			// Token: 0x040006C1 RID: 1729
			public IntPtr ExtendModesPointer;
		}
	}
}
