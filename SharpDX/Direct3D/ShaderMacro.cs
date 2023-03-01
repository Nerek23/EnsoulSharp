using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D
{
	// Token: 0x0200009F RID: 159
	public struct ShaderMacro : IEquatable<ShaderMacro>
	{
		// Token: 0x0600033D RID: 829 RVA: 0x0000972D File Offset: 0x0000792D
		public ShaderMacro(string name, object definition)
		{
			this.Name = name;
			this.Definition = ((definition == null) ? null : definition.ToString());
		}

		// Token: 0x0600033E RID: 830 RVA: 0x00009748 File Offset: 0x00007948
		public bool Equals(ShaderMacro other)
		{
			return string.Equals(this.Name, other.Name) && string.Equals(this.Definition, other.Definition);
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00009770 File Offset: 0x00007970
		public override bool Equals(object obj)
		{
			return obj != null && obj is ShaderMacro && this.Equals((ShaderMacro)obj);
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0000978D File Offset: 0x0000798D
		public override int GetHashCode()
		{
			return ((this.Name != null) ? this.Name.GetHashCode() : 0) * 397 ^ ((this.Definition != null) ? this.Definition.GetHashCode() : 0);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x000097C2 File Offset: 0x000079C2
		public static bool operator ==(ShaderMacro left, ShaderMacro right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000342 RID: 834 RVA: 0x000097CC File Offset: 0x000079CC
		public static bool operator !=(ShaderMacro left, ShaderMacro right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000343 RID: 835 RVA: 0x000097D9 File Offset: 0x000079D9
		internal void __MarshalFree(ref ShaderMacro.__Native @ref)
		{
			Marshal.FreeHGlobal(@ref.Name);
			Marshal.FreeHGlobal(@ref.Definition);
		}

		// Token: 0x06000344 RID: 836 RVA: 0x000097F1 File Offset: 0x000079F1
		internal void __MarshalFrom(ref ShaderMacro.__Native @ref)
		{
			this.Name = Marshal.PtrToStringAnsi(@ref.Name);
			this.Definition = Marshal.PtrToStringAnsi(@ref.Definition);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00009815 File Offset: 0x00007A15
		internal void __MarshalTo(ref ShaderMacro.__Native @ref)
		{
			@ref.Name = Marshal.StringToHGlobalAnsi(this.Name);
			@ref.Definition = Marshal.StringToHGlobalAnsi(this.Definition);
		}

		// Token: 0x040011D5 RID: 4565
		public string Name;

		// Token: 0x040011D6 RID: 4566
		public string Definition;

		// Token: 0x020000A0 RID: 160
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040011D7 RID: 4567
			public IntPtr Name;

			// Token: 0x040011D8 RID: 4568
			public IntPtr Definition;
		}
	}
}
