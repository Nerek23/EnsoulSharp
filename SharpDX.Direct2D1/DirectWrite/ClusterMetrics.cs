using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200014D RID: 333
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct ClusterMetrics
	{
		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600064D RID: 1613 RVA: 0x00014691 File Offset: 0x00012891
		// (set) Token: 0x0600064E RID: 1614 RVA: 0x0001469E File Offset: 0x0001289E
		public bool CanWrapLineAfter
		{
			get
			{
				return (this._CanWrapLineAfter & 1) != 0;
			}
			set
			{
				this._CanWrapLineAfter = ((this._CanWrapLineAfter & -2) | ((value ? 1 : 0) & 1));
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600064F RID: 1615 RVA: 0x000146BA File Offset: 0x000128BA
		// (set) Token: 0x06000650 RID: 1616 RVA: 0x000146C9 File Offset: 0x000128C9
		public bool IsWhitespace
		{
			get
			{
				return (this._IsWhitespace >> 1 & 1) != 0;
			}
			set
			{
				this._IsWhitespace = (short)((int)(this._IsWhitespace & -3) | ((value ? 1 : 0) & 1) << 1);
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000651 RID: 1617 RVA: 0x000146E7 File Offset: 0x000128E7
		// (set) Token: 0x06000652 RID: 1618 RVA: 0x000146F6 File Offset: 0x000128F6
		public bool IsNewline
		{
			get
			{
				return (this._IsNewline >> 2 & 1) != 0;
			}
			set
			{
				this._IsNewline = (short)((int)(this._IsNewline & -5) | ((value ? 1 : 0) & 1) << 2);
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x00014714 File Offset: 0x00012914
		// (set) Token: 0x06000654 RID: 1620 RVA: 0x00014723 File Offset: 0x00012923
		public bool IsSoftHyphen
		{
			get
			{
				return (this._IsSoftHyphen >> 3 & 1) != 0;
			}
			set
			{
				this._IsSoftHyphen = (short)((int)(this._IsSoftHyphen & -9) | ((value ? 1 : 0) & 1) << 3);
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000655 RID: 1621 RVA: 0x00014741 File Offset: 0x00012941
		// (set) Token: 0x06000656 RID: 1622 RVA: 0x00014750 File Offset: 0x00012950
		public bool IsRightToLeft
		{
			get
			{
				return (this._IsRightToLeft >> 4 & 1) != 0;
			}
			set
			{
				this._IsRightToLeft = (short)((int)(this._IsRightToLeft & -17) | ((value ? 1 : 0) & 1) << 4);
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000657 RID: 1623 RVA: 0x0001476E File Offset: 0x0001296E
		// (set) Token: 0x06000658 RID: 1624 RVA: 0x0001477F File Offset: 0x0001297F
		internal short Padding
		{
			get
			{
				return (short)(this._Padding >> 5 & 2047);
			}
			set
			{
				this._Padding = (short)(((int)this._Padding & -65505) | (int)(value & 2047) << 5);
			}
		}

		// Token: 0x040004D9 RID: 1241
		[FieldOffset(0)]
		public float Width;

		// Token: 0x040004DA RID: 1242
		[FieldOffset(4)]
		public short Length;

		// Token: 0x040004DB RID: 1243
		[FieldOffset(6)]
		internal short _CanWrapLineAfter;

		// Token: 0x040004DC RID: 1244
		[FieldOffset(6)]
		internal short _IsWhitespace;

		// Token: 0x040004DD RID: 1245
		[FieldOffset(6)]
		internal short _IsNewline;

		// Token: 0x040004DE RID: 1246
		[FieldOffset(6)]
		internal short _IsSoftHyphen;

		// Token: 0x040004DF RID: 1247
		[FieldOffset(6)]
		internal short _IsRightToLeft;

		// Token: 0x040004E0 RID: 1248
		[FieldOffset(6)]
		internal short _Padding;
	}
}
