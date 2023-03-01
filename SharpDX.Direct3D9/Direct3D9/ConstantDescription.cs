using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000DA RID: 218
	public struct ConstantDescription
	{
		// Token: 0x06000717 RID: 1815 RVA: 0x0001950C File Offset: 0x0001770C
		internal void __MarshalFree(ref ConstantDescription.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x00019514 File Offset: 0x00017714
		internal void __MarshalFrom(ref ConstantDescription.__Native @ref)
		{
			this.Name = ((@ref.Name == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(@ref.Name));
			this.RegisterSet = @ref.RegisterSet;
			this.RegisterIndex = @ref.RegisterIndex;
			this.RegisterCount = @ref.RegisterCount;
			this.Class = @ref.Class;
			this.Type = @ref.Type;
			this.Rows = @ref.Rows;
			this.Columns = @ref.Columns;
			this.Elements = @ref.Elements;
			this.StructMembers = @ref.StructMembers;
			this.Bytes = @ref.Bytes;
			this.DefaultValue = @ref.DefaultValue;
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x000195CC File Offset: 0x000177CC
		internal void __MarshalTo(ref ConstantDescription.__Native @ref)
		{
			@ref.Name = ((this.Name == null) ? IntPtr.Zero : Utilities.StringToHGlobalAnsi(this.Name));
			@ref.RegisterSet = this.RegisterSet;
			@ref.RegisterIndex = this.RegisterIndex;
			@ref.RegisterCount = this.RegisterCount;
			@ref.Class = this.Class;
			@ref.Type = this.Type;
			@ref.Rows = this.Rows;
			@ref.Columns = this.Columns;
			@ref.Elements = this.Elements;
			@ref.StructMembers = this.StructMembers;
			@ref.Bytes = this.Bytes;
			@ref.DefaultValue = this.DefaultValue;
		}

		// Token: 0x04000A06 RID: 2566
		public string Name;

		// Token: 0x04000A07 RID: 2567
		public RegisterSet RegisterSet;

		// Token: 0x04000A08 RID: 2568
		public int RegisterIndex;

		// Token: 0x04000A09 RID: 2569
		public int RegisterCount;

		// Token: 0x04000A0A RID: 2570
		public ParameterClass Class;

		// Token: 0x04000A0B RID: 2571
		public ParameterType Type;

		// Token: 0x04000A0C RID: 2572
		public int Rows;

		// Token: 0x04000A0D RID: 2573
		public int Columns;

		// Token: 0x04000A0E RID: 2574
		public int Elements;

		// Token: 0x04000A0F RID: 2575
		public int StructMembers;

		// Token: 0x04000A10 RID: 2576
		public int Bytes;

		// Token: 0x04000A11 RID: 2577
		public IntPtr DefaultValue;

		// Token: 0x020000DB RID: 219
		internal struct __Native
		{
			// Token: 0x0600071A RID: 1818 RVA: 0x0001967D File Offset: 0x0001787D
			internal void __MarshalFree()
			{
				if (this.Name != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.Name);
				}
			}

			// Token: 0x04000A12 RID: 2578
			public IntPtr Name;

			// Token: 0x04000A13 RID: 2579
			public RegisterSet RegisterSet;

			// Token: 0x04000A14 RID: 2580
			public int RegisterIndex;

			// Token: 0x04000A15 RID: 2581
			public int RegisterCount;

			// Token: 0x04000A16 RID: 2582
			public ParameterClass Class;

			// Token: 0x04000A17 RID: 2583
			public ParameterType Type;

			// Token: 0x04000A18 RID: 2584
			public int Rows;

			// Token: 0x04000A19 RID: 2585
			public int Columns;

			// Token: 0x04000A1A RID: 2586
			public int Elements;

			// Token: 0x04000A1B RID: 2587
			public int StructMembers;

			// Token: 0x04000A1C RID: 2588
			public int Bytes;

			// Token: 0x04000A1D RID: 2589
			public IntPtr DefaultValue;
		}
	}
}
