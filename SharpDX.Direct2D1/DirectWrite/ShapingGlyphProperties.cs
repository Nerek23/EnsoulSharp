using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000C1 RID: 193
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct ShapingGlyphProperties
	{
		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x0000D6E9 File Offset: 0x0000B8E9
		// (set) Token: 0x060003D8 RID: 984 RVA: 0x0000D6F1 File Offset: 0x0000B8F1
		public ScriptJustify Justification
		{
			get
			{
				return (ScriptJustify)this.Justification_;
			}
			set
			{
				this.Justification_ = (short)value;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x0000D6FB File Offset: 0x0000B8FB
		// (set) Token: 0x060003DA RID: 986 RVA: 0x0000D707 File Offset: 0x0000B907
		internal short Justification_
		{
			get
			{
				return this._Justification_ & 15;
			}
			set
			{
				this._Justification_ = ((this._Justification_ & -16) | (value & 15));
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060003DB RID: 987 RVA: 0x0000D71E File Offset: 0x0000B91E
		// (set) Token: 0x060003DC RID: 988 RVA: 0x0000D72D File Offset: 0x0000B92D
		public bool IsClusterStart
		{
			get
			{
				return (this._IsClusterStart >> 4 & 1) != 0;
			}
			set
			{
				this._IsClusterStart = (short)((int)(this._IsClusterStart & -17) | ((value ? 1 : 0) & 1) << 4);
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060003DD RID: 989 RVA: 0x0000D74B File Offset: 0x0000B94B
		// (set) Token: 0x060003DE RID: 990 RVA: 0x0000D75A File Offset: 0x0000B95A
		public bool IsDiacritic
		{
			get
			{
				return (this._IsDiacritic >> 5 & 1) != 0;
			}
			set
			{
				this._IsDiacritic = (short)((int)(this._IsDiacritic & -33) | ((value ? 1 : 0) & 1) << 5);
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060003DF RID: 991 RVA: 0x0000D778 File Offset: 0x0000B978
		// (set) Token: 0x060003E0 RID: 992 RVA: 0x0000D787 File Offset: 0x0000B987
		public bool IsZeroWidthSpace
		{
			get
			{
				return (this._IsZeroWidthSpace >> 6 & 1) != 0;
			}
			set
			{
				this._IsZeroWidthSpace = (short)((int)(this._IsZeroWidthSpace & -65) | ((value ? 1 : 0) & 1) << 6);
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060003E1 RID: 993 RVA: 0x0000D7A5 File Offset: 0x0000B9A5
		// (set) Token: 0x060003E2 RID: 994 RVA: 0x0000D7B6 File Offset: 0x0000B9B6
		internal short Reserved
		{
			get
			{
				return (short)(this._Reserved >> 7 & 511);
			}
			set
			{
				this._Reserved = (short)(((int)this._Reserved & -65409) | (int)(value & 511) << 7);
			}
		}

		// Token: 0x04000260 RID: 608
		[FieldOffset(0)]
		internal short _Justification_;

		// Token: 0x04000261 RID: 609
		[FieldOffset(0)]
		internal short _IsClusterStart;

		// Token: 0x04000262 RID: 610
		[FieldOffset(0)]
		internal short _IsDiacritic;

		// Token: 0x04000263 RID: 611
		[FieldOffset(0)]
		internal short _IsZeroWidthSpace;

		// Token: 0x04000264 RID: 612
		[FieldOffset(0)]
		internal short _Reserved;
	}
}
