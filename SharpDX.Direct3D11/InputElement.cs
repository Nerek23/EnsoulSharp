using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200002C RID: 44
	public struct InputElement : IEquatable<InputElement>
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000270 RID: 624 RVA: 0x0000A878 File Offset: 0x00008A78
		public static int AppendAligned
		{
			get
			{
				return -1;
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000A87B File Offset: 0x00008A7B
		public InputElement(string name, int index, Format format, int offset, int slot, InputClassification slotClass, int stepRate)
		{
			this.SemanticName = name;
			this.SemanticIndex = index;
			this.Format = format;
			this.Slot = slot;
			this.AlignedByteOffset = offset;
			this.Classification = slotClass;
			this.InstanceDataStepRate = stepRate;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000A8B2 File Offset: 0x00008AB2
		public InputElement(string name, int index, Format format, int offset, int slot)
		{
			this.SemanticName = name;
			this.SemanticIndex = index;
			this.Format = format;
			this.Slot = slot;
			this.AlignedByteOffset = offset;
			this.Classification = InputClassification.PerVertexData;
			this.InstanceDataStepRate = 0;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000A8E7 File Offset: 0x00008AE7
		public InputElement(string name, int index, Format format, int slot)
		{
			this.SemanticName = name;
			this.SemanticIndex = index;
			this.Format = format;
			this.Slot = slot;
			this.AlignedByteOffset = -1;
			this.Classification = InputClassification.PerVertexData;
			this.InstanceDataStepRate = 0;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000A91C File Offset: 0x00008B1C
		public bool Equals(InputElement other)
		{
			return object.Equals(other.SemanticName, this.SemanticName) && other.SemanticIndex == this.SemanticIndex && object.Equals(other.Format, this.Format) && other.Slot == this.Slot && other.AlignedByteOffset == this.AlignedByteOffset && object.Equals(other.Classification, this.Classification) && other.InstanceDataStepRate == this.InstanceDataStepRate;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000A9B0 File Offset: 0x00008BB0
		public override bool Equals(object obj)
		{
			return obj != null && !(obj.GetType() != typeof(InputElement)) && this.Equals((InputElement)obj);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000A9DC File Offset: 0x00008BDC
		public override int GetHashCode()
		{
			return (((((this.SemanticName.GetHashCode() * 397 ^ this.SemanticIndex.GetHashCode()) * 397 ^ this.Format.GetHashCode()) * 397 ^ this.Slot.GetHashCode()) * 397 ^ this.AlignedByteOffset.GetHashCode()) * 397 ^ this.Classification.GetHashCode()) * 397 ^ this.InstanceDataStepRate.GetHashCode();
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000AA6C File Offset: 0x00008C6C
		public static bool operator ==(InputElement left, InputElement right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000AA76 File Offset: 0x00008C76
		public static bool operator !=(InputElement left, InputElement right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000AA83 File Offset: 0x00008C83
		internal void __MarshalFree(ref InputElement.__Native @ref)
		{
			Marshal.FreeHGlobal(@ref.SemanticName);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000AA90 File Offset: 0x00008C90
		internal void __MarshalFrom(ref InputElement.__Native @ref)
		{
			this.SemanticName = Marshal.PtrToStringAnsi(@ref.SemanticName);
			this.SemanticIndex = @ref.SemanticIndex;
			this.Format = @ref.Format;
			this.Slot = @ref.Slot;
			this.AlignedByteOffset = @ref.AlignedByteOffset;
			this.Classification = @ref.Classification;
			this.InstanceDataStepRate = @ref.InstanceDataStepRate;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000AAF8 File Offset: 0x00008CF8
		internal void __MarshalTo(ref InputElement.__Native @ref)
		{
			@ref.SemanticName = Marshal.StringToHGlobalAnsi(this.SemanticName);
			@ref.SemanticIndex = this.SemanticIndex;
			@ref.Format = this.Format;
			@ref.Slot = this.Slot;
			@ref.AlignedByteOffset = this.AlignedByteOffset;
			@ref.Classification = this.Classification;
			@ref.InstanceDataStepRate = this.InstanceDataStepRate;
		}

		// Token: 0x04000099 RID: 153
		public string SemanticName;

		// Token: 0x0400009A RID: 154
		public int SemanticIndex;

		// Token: 0x0400009B RID: 155
		public Format Format;

		// Token: 0x0400009C RID: 156
		public int Slot;

		// Token: 0x0400009D RID: 157
		public int AlignedByteOffset;

		// Token: 0x0400009E RID: 158
		public InputClassification Classification;

		// Token: 0x0400009F RID: 159
		public int InstanceDataStepRate;

		// Token: 0x0200002D RID: 45
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040000A0 RID: 160
			public IntPtr SemanticName;

			// Token: 0x040000A1 RID: 161
			public int SemanticIndex;

			// Token: 0x040000A2 RID: 162
			public Format Format;

			// Token: 0x040000A3 RID: 163
			public int Slot;

			// Token: 0x040000A4 RID: 164
			public int AlignedByteOffset;

			// Token: 0x040000A5 RID: 165
			public InputClassification Classification;

			// Token: 0x040000A6 RID: 166
			public int InstanceDataStepRate;
		}
	}
}
