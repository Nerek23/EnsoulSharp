using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200008F RID: 143
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FontFeature
	{
		// Token: 0x060002EF RID: 751 RVA: 0x0000BAC0 File Offset: 0x00009CC0
		public FontFeature(FontFeatureTag nameTag, int parameter)
		{
			this.NameTag = nameTag;
			this.Parameter = parameter;
		}

		// Token: 0x04000211 RID: 529
		public FontFeatureTag NameTag;

		// Token: 0x04000212 RID: 530
		public int Parameter;
	}
}
