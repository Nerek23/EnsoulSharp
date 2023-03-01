using System;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000085 RID: 133
	public class EllipsisTrimming : InlineObjectNative
	{
		// Token: 0x06000289 RID: 649 RVA: 0x0000A2F0 File Offset: 0x000084F0
		protected EllipsisTrimming(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000A2F9 File Offset: 0x000084F9
		public EllipsisTrimming(Factory factory, TextFormat textFormat) : this(IntPtr.Zero)
		{
			factory.CreateEllipsisTrimmingSign(textFormat, this);
		}
	}
}
