using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000168 RID: 360
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct ScriptProperties
	{
		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000675 RID: 1653 RVA: 0x00014C54 File Offset: 0x00012E54
		// (set) Token: 0x06000676 RID: 1654 RVA: 0x00014C61 File Offset: 0x00012E61
		public bool RestrictCaretToClusters
		{
			get
			{
				return (this._RestrictCaretToClusters & 1) != 0;
			}
			set
			{
				this._RestrictCaretToClusters = ((this._RestrictCaretToClusters & -2) | ((value ? 1 : 0) & 1));
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000677 RID: 1655 RVA: 0x00014C7C File Offset: 0x00012E7C
		// (set) Token: 0x06000678 RID: 1656 RVA: 0x00014C8B File Offset: 0x00012E8B
		public bool UsesWordDividers
		{
			get
			{
				return (this._UsesWordDividers >> 1 & 1) != 0;
			}
			set
			{
				this._UsesWordDividers = ((this._UsesWordDividers & -3) | ((value ? 1 : 0) & 1) << 1);
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x00014CA8 File Offset: 0x00012EA8
		// (set) Token: 0x0600067A RID: 1658 RVA: 0x00014CB7 File Offset: 0x00012EB7
		public bool IsDiscreteWriting
		{
			get
			{
				return (this._IsDiscreteWriting >> 2 & 1) != 0;
			}
			set
			{
				this._IsDiscreteWriting = ((this._IsDiscreteWriting & -5) | ((value ? 1 : 0) & 1) << 2);
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x0600067B RID: 1659 RVA: 0x00014CD4 File Offset: 0x00012ED4
		// (set) Token: 0x0600067C RID: 1660 RVA: 0x00014CE3 File Offset: 0x00012EE3
		public bool IsBlockWriting
		{
			get
			{
				return (this._IsBlockWriting >> 3 & 1) != 0;
			}
			set
			{
				this._IsBlockWriting = ((this._IsBlockWriting & -9) | ((value ? 1 : 0) & 1) << 3);
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600067D RID: 1661 RVA: 0x00014D00 File Offset: 0x00012F00
		// (set) Token: 0x0600067E RID: 1662 RVA: 0x00014D0F File Offset: 0x00012F0F
		public bool IsDistributedWithinCluster
		{
			get
			{
				return (this._IsDistributedWithinCluster >> 4 & 1) != 0;
			}
			set
			{
				this._IsDistributedWithinCluster = ((this._IsDistributedWithinCluster & -17) | ((value ? 1 : 0) & 1) << 4);
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600067F RID: 1663 RVA: 0x00014D2C File Offset: 0x00012F2C
		// (set) Token: 0x06000680 RID: 1664 RVA: 0x00014D3B File Offset: 0x00012F3B
		public bool IsConnectedWriting
		{
			get
			{
				return (this._IsConnectedWriting >> 5 & 1) != 0;
			}
			set
			{
				this._IsConnectedWriting = ((this._IsConnectedWriting & -33) | ((value ? 1 : 0) & 1) << 5);
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x00014D58 File Offset: 0x00012F58
		// (set) Token: 0x06000682 RID: 1666 RVA: 0x00014D67 File Offset: 0x00012F67
		public bool IsCursiveWriting
		{
			get
			{
				return (this._IsCursiveWriting >> 6 & 1) != 0;
			}
			set
			{
				this._IsCursiveWriting = ((this._IsCursiveWriting & -65) | ((value ? 1 : 0) & 1) << 6);
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000683 RID: 1667 RVA: 0x00014D84 File Offset: 0x00012F84
		// (set) Token: 0x06000684 RID: 1668 RVA: 0x00014D94 File Offset: 0x00012F94
		public int Reserved
		{
			get
			{
				return this._Reserved >> 7 & 33554431;
			}
			set
			{
				this._Reserved = ((this._Reserved & 127) | (value & 33554431) << 7);
			}
		}

		// Token: 0x040005A5 RID: 1445
		[FieldOffset(0)]
		public int IsoScriptCode;

		// Token: 0x040005A6 RID: 1446
		[FieldOffset(4)]
		public int IsoScriptNumber;

		// Token: 0x040005A7 RID: 1447
		[FieldOffset(8)]
		public int ClusterLookahead;

		// Token: 0x040005A8 RID: 1448
		[FieldOffset(12)]
		public int JustificationCharacter;

		// Token: 0x040005A9 RID: 1449
		[FieldOffset(16)]
		internal int _RestrictCaretToClusters;

		// Token: 0x040005AA RID: 1450
		[FieldOffset(16)]
		internal int _UsesWordDividers;

		// Token: 0x040005AB RID: 1451
		[FieldOffset(16)]
		internal int _IsDiscreteWriting;

		// Token: 0x040005AC RID: 1452
		[FieldOffset(16)]
		internal int _IsBlockWriting;

		// Token: 0x040005AD RID: 1453
		[FieldOffset(16)]
		internal int _IsDistributedWithinCluster;

		// Token: 0x040005AE RID: 1454
		[FieldOffset(16)]
		internal int _IsConnectedWriting;

		// Token: 0x040005AF RID: 1455
		[FieldOffset(16)]
		internal int _IsCursiveWriting;

		// Token: 0x040005B0 RID: 1456
		[FieldOffset(16)]
		internal int _Reserved;
	}
}
