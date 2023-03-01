using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001FA RID: 506
	public struct InputElement
	{
		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000AD8 RID: 2776 RVA: 0x0001F13D File Offset: 0x0001D33D
		public static int AppendAligned
		{
			get
			{
				return -1;
			}
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x0001F140 File Offset: 0x0001D340
		public InputElement(string name, int index, Format format, int slot)
		{
			this.SemanticName = name;
			this.SemanticIndex = index;
			this.Format = format;
			this.Slot = slot;
			this.AlignedByteOffset = InputElement.AppendAligned;
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x0001F16A File Offset: 0x0001D36A
		public InputElement(string name, int index, Format format, int offset, int slot)
		{
			this.SemanticName = name;
			this.SemanticIndex = index;
			this.Format = format;
			this.Slot = slot;
			this.AlignedByteOffset = offset;
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x0001F194 File Offset: 0x0001D394
		public bool Equals(InputElement other)
		{
			return object.Equals(other.SemanticName, this.SemanticName) && other.SemanticIndex == this.SemanticIndex && object.Equals(other.Format, this.Format) && other.Slot == this.Slot && other.AlignedByteOffset == this.AlignedByteOffset;
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x0001F1FD File Offset: 0x0001D3FD
		public override bool Equals(object obj)
		{
			return obj != null && !(obj.GetType() != typeof(InputElement)) && this.Equals((InputElement)obj);
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x0001F22C File Offset: 0x0001D42C
		public override int GetHashCode()
		{
			return (((this.SemanticName.GetHashCode() * 397 ^ this.SemanticIndex.GetHashCode()) * 397 ^ this.Format.GetHashCode()) * 397 ^ this.Slot.GetHashCode()) * 397 ^ this.AlignedByteOffset.GetHashCode();
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x0001F292 File Offset: 0x0001D492
		public static bool operator ==(InputElement left, InputElement right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x0001F29C File Offset: 0x0001D49C
		public static bool operator !=(InputElement left, InputElement right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x0001F2A9 File Offset: 0x0001D4A9
		internal void __MarshalFree(ref InputElement.__Native @ref)
		{
			Marshal.FreeHGlobal(@ref.SemanticName);
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x0001F2B8 File Offset: 0x0001D4B8
		internal void __MarshalFrom(ref InputElement.__Native @ref)
		{
			this.SemanticName = Marshal.PtrToStringAnsi(@ref.SemanticName);
			this.SemanticIndex = @ref.SemanticIndex;
			this.Format = @ref.Format;
			this.Slot = @ref.Slot;
			this.AlignedByteOffset = @ref.AlignedByteOffset;
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x0001F308 File Offset: 0x0001D508
		internal void __MarshalTo(ref InputElement.__Native @ref)
		{
			@ref.SemanticName = Marshal.StringToHGlobalAnsi(this.SemanticName);
			@ref.SemanticIndex = this.SemanticIndex;
			@ref.Format = this.Format;
			@ref.Slot = this.Slot;
			@ref.AlignedByteOffset = this.AlignedByteOffset;
		}

		// Token: 0x0400066C RID: 1644
		public string SemanticName;

		// Token: 0x0400066D RID: 1645
		public int SemanticIndex;

		// Token: 0x0400066E RID: 1646
		public Format Format;

		// Token: 0x0400066F RID: 1647
		public int Slot;

		// Token: 0x04000670 RID: 1648
		public int AlignedByteOffset;

		// Token: 0x020001FB RID: 507
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000671 RID: 1649
			public IntPtr SemanticName;

			// Token: 0x04000672 RID: 1650
			public int SemanticIndex;

			// Token: 0x04000673 RID: 1651
			public Format Format;

			// Token: 0x04000674 RID: 1652
			public int Slot;

			// Token: 0x04000675 RID: 1653
			public int AlignedByteOffset;
		}
	}
}
