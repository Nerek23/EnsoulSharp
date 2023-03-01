using System;
using System.Runtime.InteropServices;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.Spellbook" /> update charged spell event.
	/// </summary>
	// Token: 0x0200006D RID: 109
	public class SpellbookUpdateChargedSpellEventArgs : EventArgs
	{
		// Token: 0x06000444 RID: 1092 RVA: 0x0000F270 File Offset: 0x0000E670
		internal SpellbookUpdateChargedSpellEventArgs([MarshalAs(UnmanagedType.U1)] bool process, SpellSlot slot, Vector3 position, [MarshalAs(UnmanagedType.U1)] bool releaseCast)
		{
			this.m_process = process;
			this.m_slot = slot;
			this.m_position = position;
			this.m_releaseCast = releaseCast;
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether the event should process.
		/// </summary>
		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x0000F2A0 File Offset: 0x0000E6A0
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x0000F2B4 File Offset: 0x0000E6B4
		public bool Process
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.m_process;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				this.m_process = value;
			}
		}

		/// <summary>
		/// 	Gets the spell slot.
		/// </summary>
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x0000F2C8 File Offset: 0x0000E6C8
		public SpellSlot Slot
		{
			get
			{
				return this.m_slot;
			}
		}

		/// <summary>
		/// 	Gets the spell target position.
		/// </summary>
		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000448 RID: 1096 RVA: 0x0000F2DC File Offset: 0x0000E6DC
		public Vector3 Position
		{
			get
			{
				return this.m_position;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the spell is release cast.
		/// </summary>
		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x0000F2F4 File Offset: 0x0000E6F4
		public bool ReleaseCast
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.m_releaseCast;
			}
		}

		// Token: 0x040003A6 RID: 934
		private bool m_process;

		// Token: 0x040003A7 RID: 935
		private SpellSlot m_slot;

		// Token: 0x040003A8 RID: 936
		private Vector3 m_position;

		// Token: 0x040003A9 RID: 937
		private bool m_releaseCast;
	}
}
