using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000B4 RID: 180
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct LineBreakpoint
	{
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000390 RID: 912 RVA: 0x0000CF9C File Offset: 0x0000B19C
		// (set) Token: 0x06000391 RID: 913 RVA: 0x0000CFA4 File Offset: 0x0000B1A4
		public BreakCondition BreakConditionBefore
		{
			get
			{
				return (BreakCondition)this.BreakConditionBefore_;
			}
			set
			{
				this.BreakConditionBefore_ = (byte)value;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000392 RID: 914 RVA: 0x0000CFAE File Offset: 0x0000B1AE
		// (set) Token: 0x06000393 RID: 915 RVA: 0x0000CFB6 File Offset: 0x0000B1B6
		public BreakCondition BreakConditionAfter
		{
			get
			{
				return (BreakCondition)this.BreakConditionAfter_;
			}
			set
			{
				this.BreakConditionAfter_ = (byte)value;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000394 RID: 916 RVA: 0x0000CFC0 File Offset: 0x0000B1C0
		// (set) Token: 0x06000395 RID: 917 RVA: 0x0000CFCB File Offset: 0x0000B1CB
		internal byte BreakConditionBefore_
		{
			get
			{
				return this._BreakConditionBefore_ & 3;
			}
			set
			{
				this._BreakConditionBefore_ = (byte)(((int)this._BreakConditionBefore_ & -4) | (int)(value & 3));
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000396 RID: 918 RVA: 0x0000CFE1 File Offset: 0x0000B1E1
		// (set) Token: 0x06000397 RID: 919 RVA: 0x0000CFEE File Offset: 0x0000B1EE
		internal byte BreakConditionAfter_
		{
			get
			{
				return (byte)(this._BreakConditionAfter_ >> 2 & 3);
			}
			set
			{
				this._BreakConditionAfter_ = (byte)(((int)this._BreakConditionAfter_ & -13) | (int)(value & 3) << 2);
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000398 RID: 920 RVA: 0x0000D006 File Offset: 0x0000B206
		// (set) Token: 0x06000399 RID: 921 RVA: 0x0000D015 File Offset: 0x0000B215
		public bool IsWhitespace
		{
			get
			{
				return (this._IsWhitespace >> 4 & 1) != 0;
			}
			set
			{
				this._IsWhitespace = (byte)(((int)this._IsWhitespace & -17) | ((value ? 1 : 0) & 1) << 4);
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600039A RID: 922 RVA: 0x0000D033 File Offset: 0x0000B233
		// (set) Token: 0x0600039B RID: 923 RVA: 0x0000D042 File Offset: 0x0000B242
		public bool IsSoftHyphen
		{
			get
			{
				return (this._IsSoftHyphen >> 5 & 1) != 0;
			}
			set
			{
				this._IsSoftHyphen = (byte)(((int)this._IsSoftHyphen & -33) | ((value ? 1 : 0) & 1) << 5);
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600039C RID: 924 RVA: 0x0000D060 File Offset: 0x0000B260
		// (set) Token: 0x0600039D RID: 925 RVA: 0x0000D06D File Offset: 0x0000B26D
		internal byte Padding
		{
			get
			{
				return (byte)(this._Padding >> 6 & 3);
			}
			set
			{
				this._Padding = (byte)(((int)this._Padding & -193) | (int)(value & 3) << 6);
			}
		}

		// Token: 0x0400024D RID: 589
		[FieldOffset(0)]
		internal byte _BreakConditionBefore_;

		// Token: 0x0400024E RID: 590
		[FieldOffset(0)]
		internal byte _BreakConditionAfter_;

		// Token: 0x0400024F RID: 591
		[FieldOffset(0)]
		internal byte _IsWhitespace;

		// Token: 0x04000250 RID: 592
		[FieldOffset(0)]
		internal byte _IsSoftHyphen;

		// Token: 0x04000251 RID: 593
		[FieldOffset(0)]
		internal byte _Padding;
	}
}
