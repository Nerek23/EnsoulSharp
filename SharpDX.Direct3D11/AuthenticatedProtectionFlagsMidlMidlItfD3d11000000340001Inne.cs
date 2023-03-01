using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000DF RID: 223
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct AuthenticatedProtectionFlagsMidlMidlItfD3d11000000340001Inner
	{
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x00010B7C File Offset: 0x0000ED7C
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x00010B89 File Offset: 0x0000ED89
		public bool ProtectionEnabled
		{
			get
			{
				return (this._ProtectionEnabled & 1) != 0;
			}
			set
			{
				this._ProtectionEnabled = ((this._ProtectionEnabled & -2) | ((value ? 1 : 0) & 1));
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x00010BA4 File Offset: 0x0000EDA4
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x00010BB3 File Offset: 0x0000EDB3
		public bool OverlayOrFullscreenRequired
		{
			get
			{
				return (this._OverlayOrFullscreenRequired >> 1 & 1) != 0;
			}
			set
			{
				this._OverlayOrFullscreenRequired = ((this._OverlayOrFullscreenRequired & -3) | ((value ? 1 : 0) & 1) << 1);
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x00010BD0 File Offset: 0x0000EDD0
		// (set) Token: 0x06000450 RID: 1104 RVA: 0x00010BE0 File Offset: 0x0000EDE0
		public int Reserved
		{
			get
			{
				return this._Reserved >> 2 & 1073741823;
			}
			set
			{
				this._Reserved = ((this._Reserved & 3) | (value & 1073741823) << 2);
			}
		}

		// Token: 0x040008E4 RID: 2276
		[FieldOffset(0)]
		internal int _ProtectionEnabled;

		// Token: 0x040008E5 RID: 2277
		[FieldOffset(0)]
		internal int _OverlayOrFullscreenRequired;

		// Token: 0x040008E6 RID: 2278
		[FieldOffset(0)]
		internal int _Reserved;
	}
}
