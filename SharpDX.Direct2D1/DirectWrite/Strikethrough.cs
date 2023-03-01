using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200016A RID: 362
	public struct Strikethrough
	{
		// Token: 0x06000689 RID: 1673 RVA: 0x00014E08 File Offset: 0x00013008
		internal void __MarshalFree(ref Strikethrough.__Native @ref)
		{
			Marshal.FreeHGlobal(@ref.LocaleName);
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x00014E18 File Offset: 0x00013018
		internal void __MarshalFrom(ref Strikethrough.__Native @ref)
		{
			this.Width = @ref.Width;
			this.Thickness = @ref.Thickness;
			this.Offset = @ref.Offset;
			this.ReadingDirection = @ref.ReadingDirection;
			this.FlowDirection = @ref.FlowDirection;
			this.LocaleName = Marshal.PtrToStringUni(@ref.LocaleName);
			this.MeasuringMode = @ref.MeasuringMode;
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00014E80 File Offset: 0x00013080
		internal void __MarshalTo(ref Strikethrough.__Native @ref)
		{
			@ref.Width = this.Width;
			@ref.Thickness = this.Thickness;
			@ref.Offset = this.Offset;
			@ref.ReadingDirection = this.ReadingDirection;
			@ref.FlowDirection = this.FlowDirection;
			@ref.LocaleName = Marshal.StringToHGlobalUni(this.LocaleName);
			@ref.MeasuringMode = this.MeasuringMode;
		}

		// Token: 0x040005B3 RID: 1459
		public float Width;

		// Token: 0x040005B4 RID: 1460
		public float Thickness;

		// Token: 0x040005B5 RID: 1461
		public float Offset;

		// Token: 0x040005B6 RID: 1462
		public ReadingDirection ReadingDirection;

		// Token: 0x040005B7 RID: 1463
		public FlowDirection FlowDirection;

		// Token: 0x040005B8 RID: 1464
		public string LocaleName;

		// Token: 0x040005B9 RID: 1465
		public MeasuringMode MeasuringMode;

		// Token: 0x0200016B RID: 363
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040005BA RID: 1466
			public float Width;

			// Token: 0x040005BB RID: 1467
			public float Thickness;

			// Token: 0x040005BC RID: 1468
			public float Offset;

			// Token: 0x040005BD RID: 1469
			public ReadingDirection ReadingDirection;

			// Token: 0x040005BE RID: 1470
			public FlowDirection FlowDirection;

			// Token: 0x040005BF RID: 1471
			public IntPtr LocaleName;

			// Token: 0x040005C0 RID: 1472
			public MeasuringMode MeasuringMode;
		}
	}
}
