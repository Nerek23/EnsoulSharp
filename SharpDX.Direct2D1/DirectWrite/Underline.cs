using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000170 RID: 368
	public struct Underline
	{
		// Token: 0x0600068C RID: 1676 RVA: 0x00014EE6 File Offset: 0x000130E6
		internal void __MarshalFree(ref Underline.__Native @ref)
		{
			Marshal.FreeHGlobal(@ref.LocaleName);
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x00014EF4 File Offset: 0x000130F4
		internal void __MarshalFrom(ref Underline.__Native @ref)
		{
			this.Width = @ref.Width;
			this.Thickness = @ref.Thickness;
			this.Offset = @ref.Offset;
			this.RunHeight = @ref.RunHeight;
			this.ReadingDirection = @ref.ReadingDirection;
			this.FlowDirection = @ref.FlowDirection;
			this.LocaleName = Marshal.PtrToStringUni(@ref.LocaleName);
			this.MeasuringMode = @ref.MeasuringMode;
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x00014F68 File Offset: 0x00013168
		internal void __MarshalTo(ref Underline.__Native @ref)
		{
			@ref.Width = this.Width;
			@ref.Thickness = this.Thickness;
			@ref.Offset = this.Offset;
			@ref.RunHeight = this.RunHeight;
			@ref.ReadingDirection = this.ReadingDirection;
			@ref.FlowDirection = this.FlowDirection;
			@ref.LocaleName = Marshal.StringToHGlobalUni(this.LocaleName);
			@ref.MeasuringMode = this.MeasuringMode;
		}

		// Token: 0x040005D9 RID: 1497
		public float Width;

		// Token: 0x040005DA RID: 1498
		public float Thickness;

		// Token: 0x040005DB RID: 1499
		public float Offset;

		// Token: 0x040005DC RID: 1500
		public float RunHeight;

		// Token: 0x040005DD RID: 1501
		public ReadingDirection ReadingDirection;

		// Token: 0x040005DE RID: 1502
		public FlowDirection FlowDirection;

		// Token: 0x040005DF RID: 1503
		public string LocaleName;

		// Token: 0x040005E0 RID: 1504
		public MeasuringMode MeasuringMode;

		// Token: 0x02000171 RID: 369
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040005E1 RID: 1505
			public float Width;

			// Token: 0x040005E2 RID: 1506
			public float Thickness;

			// Token: 0x040005E3 RID: 1507
			public float Offset;

			// Token: 0x040005E4 RID: 1508
			public float RunHeight;

			// Token: 0x040005E5 RID: 1509
			public ReadingDirection ReadingDirection;

			// Token: 0x040005E6 RID: 1510
			public FlowDirection FlowDirection;

			// Token: 0x040005E7 RID: 1511
			public IntPtr LocaleName;

			// Token: 0x040005E8 RID: 1512
			public MeasuringMode MeasuringMode;
		}
	}
}
