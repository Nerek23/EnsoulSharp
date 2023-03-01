using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200030C RID: 780
	[Guid("65019f75-8da2-497c-b32c-dfa34e48ede6")]
	public class Image : Resource
	{
		// Token: 0x06000DB3 RID: 3507 RVA: 0x00016258 File Offset: 0x00014458
		public Image(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000DB4 RID: 3508 RVA: 0x00025F07 File Offset: 0x00024107
		public new static explicit operator Image(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Image(nativePtr);
			}
			return null;
		}
	}
}
