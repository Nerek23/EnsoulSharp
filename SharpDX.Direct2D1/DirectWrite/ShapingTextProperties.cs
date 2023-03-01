using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000169 RID: 361
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct ShapingTextProperties
	{
		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000685 RID: 1669 RVA: 0x00014DAF File Offset: 0x00012FAF
		// (set) Token: 0x06000686 RID: 1670 RVA: 0x00014DBC File Offset: 0x00012FBC
		public bool IsShapedAlone
		{
			get
			{
				return (this._IsShapedAlone & 1) != 0;
			}
			set
			{
				this._IsShapedAlone = ((this._IsShapedAlone & -2) | ((value ? 1 : 0) & 1));
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000687 RID: 1671 RVA: 0x00014DD8 File Offset: 0x00012FD8
		// (set) Token: 0x06000688 RID: 1672 RVA: 0x00014DE9 File Offset: 0x00012FE9
		internal short Reserved
		{
			get
			{
				return (short)(this._Reserved >> 1 & 32767);
			}
			set
			{
				this._Reserved = (short)(((int)this._Reserved & -65535) | (int)(value & short.MaxValue) << 1);
			}
		}

		// Token: 0x040005B1 RID: 1457
		[FieldOffset(0)]
		internal short _IsShapedAlone;

		// Token: 0x040005B2 RID: 1458
		[FieldOffset(0)]
		internal short _Reserved;
	}
}
