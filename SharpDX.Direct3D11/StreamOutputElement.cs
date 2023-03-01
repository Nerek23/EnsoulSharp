using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000047 RID: 71
	public struct StreamOutputElement
	{
		// Token: 0x060002DC RID: 732 RVA: 0x0000B759 File Offset: 0x00009959
		public StreamOutputElement(int streamIndex, string semanticName, int semanticIndex, byte startComponent, byte componentCount, byte outputSlot)
		{
			this.Stream = streamIndex;
			this.SemanticName = semanticName;
			this.SemanticIndex = semanticIndex;
			this.StartComponent = startComponent;
			this.ComponentCount = componentCount;
			this.OutputSlot = outputSlot;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000B788 File Offset: 0x00009988
		internal void __MarshalFree(ref StreamOutputElement.__Native @ref)
		{
			Marshal.FreeHGlobal(@ref.SemanticName);
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000B798 File Offset: 0x00009998
		internal void __MarshalFrom(ref StreamOutputElement.__Native @ref)
		{
			this.Stream = @ref.Stream;
			this.SemanticName = Marshal.PtrToStringAnsi(@ref.SemanticName);
			this.SemanticIndex = @ref.SemanticIndex;
			this.StartComponent = @ref.StartComponent;
			this.ComponentCount = @ref.ComponentCount;
			this.OutputSlot = @ref.OutputSlot;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000B7F4 File Offset: 0x000099F4
		internal void __MarshalTo(ref StreamOutputElement.__Native @ref)
		{
			@ref.Stream = this.Stream;
			@ref.SemanticName = Marshal.StringToHGlobalAnsi(this.SemanticName);
			@ref.SemanticIndex = this.SemanticIndex;
			@ref.StartComponent = this.StartComponent;
			@ref.ComponentCount = this.ComponentCount;
			@ref.OutputSlot = this.OutputSlot;
		}

		// Token: 0x040000E8 RID: 232
		public int Stream;

		// Token: 0x040000E9 RID: 233
		public string SemanticName;

		// Token: 0x040000EA RID: 234
		public int SemanticIndex;

		// Token: 0x040000EB RID: 235
		public byte StartComponent;

		// Token: 0x040000EC RID: 236
		public byte ComponentCount;

		// Token: 0x040000ED RID: 237
		public byte OutputSlot;

		// Token: 0x02000048 RID: 72
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040000EE RID: 238
			public int Stream;

			// Token: 0x040000EF RID: 239
			public IntPtr SemanticName;

			// Token: 0x040000F0 RID: 240
			public int SemanticIndex;

			// Token: 0x040000F1 RID: 241
			public byte StartComponent;

			// Token: 0x040000F2 RID: 242
			public byte ComponentCount;

			// Token: 0x040000F3 RID: 243
			public byte OutputSlot;
		}
	}
}
