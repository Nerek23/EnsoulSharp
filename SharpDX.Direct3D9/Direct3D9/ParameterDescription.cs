using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000F9 RID: 249
	public struct ParameterDescription
	{
		// Token: 0x0600074C RID: 1868 RVA: 0x0001A196 File Offset: 0x00018396
		internal void __MarshalFree(ref ParameterDescription.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x0001A1A0 File Offset: 0x000183A0
		internal void __MarshalFrom(ref ParameterDescription.__Native @ref)
		{
			this.Name = ((@ref.Name == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(@ref.Name));
			this.Semantic = ((@ref.Semantic == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(@ref.Semantic));
			this.Class = @ref.Class;
			this.Type = @ref.Type;
			this.Rows = @ref.Rows;
			this.Columns = @ref.Columns;
			this.Elements = @ref.Elements;
			this.Annotations = @ref.Annotations;
			this.StructMembers = @ref.StructMembers;
			this.Flags = @ref.Flags;
			this.Bytes = @ref.Bytes;
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x0001A268 File Offset: 0x00018468
		internal void __MarshalTo(ref ParameterDescription.__Native @ref)
		{
			@ref.Name = ((this.Name == null) ? IntPtr.Zero : Utilities.StringToHGlobalAnsi(this.Name));
			@ref.Semantic = ((this.Semantic == null) ? IntPtr.Zero : Utilities.StringToHGlobalAnsi(this.Semantic));
			@ref.Class = this.Class;
			@ref.Type = this.Type;
			@ref.Rows = this.Rows;
			@ref.Columns = this.Columns;
			@ref.Elements = this.Elements;
			@ref.Annotations = this.Annotations;
			@ref.StructMembers = this.StructMembers;
			@ref.Flags = this.Flags;
			@ref.Bytes = this.Bytes;
		}

		// Token: 0x04000DC4 RID: 3524
		public string Name;

		// Token: 0x04000DC5 RID: 3525
		public string Semantic;

		// Token: 0x04000DC6 RID: 3526
		public ParameterClass Class;

		// Token: 0x04000DC7 RID: 3527
		public ParameterType Type;

		// Token: 0x04000DC8 RID: 3528
		public int Rows;

		// Token: 0x04000DC9 RID: 3529
		public int Columns;

		// Token: 0x04000DCA RID: 3530
		public int Elements;

		// Token: 0x04000DCB RID: 3531
		public int Annotations;

		// Token: 0x04000DCC RID: 3532
		public int StructMembers;

		// Token: 0x04000DCD RID: 3533
		public int Flags;

		// Token: 0x04000DCE RID: 3534
		public int Bytes;

		// Token: 0x020000FA RID: 250
		internal struct __Native
		{
			// Token: 0x0600074F RID: 1871 RVA: 0x0001A321 File Offset: 0x00018521
			internal void __MarshalFree()
			{
				if (this.Name != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.Name);
				}
				if (this.Semantic != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.Semantic);
				}
			}

			// Token: 0x04000DCF RID: 3535
			public IntPtr Name;

			// Token: 0x04000DD0 RID: 3536
			public IntPtr Semantic;

			// Token: 0x04000DD1 RID: 3537
			public ParameterClass Class;

			// Token: 0x04000DD2 RID: 3538
			public ParameterType Type;

			// Token: 0x04000DD3 RID: 3539
			public int Rows;

			// Token: 0x04000DD4 RID: 3540
			public int Columns;

			// Token: 0x04000DD5 RID: 3541
			public int Elements;

			// Token: 0x04000DD6 RID: 3542
			public int Annotations;

			// Token: 0x04000DD7 RID: 3543
			public int StructMembers;

			// Token: 0x04000DD8 RID: 3544
			public int Flags;

			// Token: 0x04000DD9 RID: 3545
			public int Bytes;
		}
	}
}
