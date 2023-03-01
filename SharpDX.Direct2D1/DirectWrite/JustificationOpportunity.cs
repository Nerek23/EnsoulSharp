using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200015C RID: 348
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct JustificationOpportunity
	{
		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x000149DE File Offset: 0x00012BDE
		// (set) Token: 0x06000663 RID: 1635 RVA: 0x000149EC File Offset: 0x00012BEC
		public int ExpansionPriority
		{
			get
			{
				return this._ExpansionPriority & 255;
			}
			set
			{
				this._ExpansionPriority = ((this._ExpansionPriority & -256) | (value & 255));
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x00014A08 File Offset: 0x00012C08
		// (set) Token: 0x06000665 RID: 1637 RVA: 0x00014A18 File Offset: 0x00012C18
		public int CompressionPriority
		{
			get
			{
				return this._CompressionPriority >> 8 & 255;
			}
			set
			{
				this._CompressionPriority = ((this._CompressionPriority & -65281) | (value & 255) << 8);
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000666 RID: 1638 RVA: 0x00014A36 File Offset: 0x00012C36
		// (set) Token: 0x06000667 RID: 1639 RVA: 0x00014A46 File Offset: 0x00012C46
		public bool AllowResidualExpansion
		{
			get
			{
				return (this._AllowResidualExpansion >> 16 & 1) != 0;
			}
			set
			{
				this._AllowResidualExpansion = ((this._AllowResidualExpansion & -65537) | ((value ? 1 : 0) & 1) << 16);
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000668 RID: 1640 RVA: 0x00014A67 File Offset: 0x00012C67
		// (set) Token: 0x06000669 RID: 1641 RVA: 0x00014A77 File Offset: 0x00012C77
		public bool AllowResidualCompression
		{
			get
			{
				return (this._AllowResidualCompression >> 17 & 1) != 0;
			}
			set
			{
				this._AllowResidualCompression = ((this._AllowResidualCompression & -131073) | ((value ? 1 : 0) & 1) << 17);
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600066A RID: 1642 RVA: 0x00014A98 File Offset: 0x00012C98
		// (set) Token: 0x0600066B RID: 1643 RVA: 0x00014AA8 File Offset: 0x00012CA8
		public bool ApplyToLeadingEdge
		{
			get
			{
				return (this._ApplyToLeadingEdge >> 18 & 1) != 0;
			}
			set
			{
				this._ApplyToLeadingEdge = ((this._ApplyToLeadingEdge & -262145) | ((value ? 1 : 0) & 1) << 18);
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600066C RID: 1644 RVA: 0x00014AC9 File Offset: 0x00012CC9
		// (set) Token: 0x0600066D RID: 1645 RVA: 0x00014AD9 File Offset: 0x00012CD9
		public bool ApplyToTrailingEdge
		{
			get
			{
				return (this._ApplyToTrailingEdge >> 19 & 1) != 0;
			}
			set
			{
				this._ApplyToTrailingEdge = ((this._ApplyToTrailingEdge & -524289) | ((value ? 1 : 0) & 1) << 19);
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600066E RID: 1646 RVA: 0x00014AFA File Offset: 0x00012CFA
		// (set) Token: 0x0600066F RID: 1647 RVA: 0x00014B0B File Offset: 0x00012D0B
		public int Reserved
		{
			get
			{
				return this._Reserved >> 20 & 4095;
			}
			set
			{
				this._Reserved = ((this._Reserved & 1048575) | (value & 4095) << 20);
			}
		}

		// Token: 0x04000545 RID: 1349
		[FieldOffset(0)]
		public float ExpansionMinimum;

		// Token: 0x04000546 RID: 1350
		[FieldOffset(4)]
		public float ExpansionMaximum;

		// Token: 0x04000547 RID: 1351
		[FieldOffset(8)]
		public float CompressionMaximum;

		// Token: 0x04000548 RID: 1352
		[FieldOffset(12)]
		internal int _ExpansionPriority;

		// Token: 0x04000549 RID: 1353
		[FieldOffset(12)]
		internal int _CompressionPriority;

		// Token: 0x0400054A RID: 1354
		[FieldOffset(12)]
		internal int _AllowResidualExpansion;

		// Token: 0x0400054B RID: 1355
		[FieldOffset(12)]
		internal int _AllowResidualCompression;

		// Token: 0x0400054C RID: 1356
		[FieldOffset(12)]
		internal int _ApplyToLeadingEdge;

		// Token: 0x0400054D RID: 1357
		[FieldOffset(12)]
		internal int _ApplyToTrailingEdge;

		// Token: 0x0400054E RID: 1358
		[FieldOffset(12)]
		internal int _Reserved;
	}
}
