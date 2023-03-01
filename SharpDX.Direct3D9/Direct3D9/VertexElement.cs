using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000116 RID: 278
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	public struct VertexElement
	{
		// Token: 0x06000760 RID: 1888 RVA: 0x0001A68E File Offset: 0x0001888E
		public VertexElement(short stream, short offset, DeclarationType type, DeclarationMethod method, DeclarationUsage usage, byte usageIndex)
		{
			this.Stream = stream;
			this.Offset = offset;
			this.Type = type;
			this.Method = method;
			this.Usage = usage;
			this.UsageIndex = usageIndex;
		}

		// Token: 0x04000E5F RID: 3679
		public short Stream;

		// Token: 0x04000E60 RID: 3680
		public short Offset;

		// Token: 0x04000E61 RID: 3681
		public DeclarationType Type;

		// Token: 0x04000E62 RID: 3682
		public DeclarationMethod Method;

		// Token: 0x04000E63 RID: 3683
		public DeclarationUsage Usage;

		// Token: 0x04000E64 RID: 3684
		public byte UsageIndex;

		// Token: 0x04000E65 RID: 3685
		public static readonly VertexElement VertexDeclarationEnd = new VertexElement(255, 0, DeclarationType.Unused, DeclarationMethod.Default, DeclarationUsage.Position, 0);
	}
}
