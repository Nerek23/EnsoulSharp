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
		// Token: 0x0600044F RID: 1103 RVA: 0x0000F360 File Offset: 0x0000E760
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
		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000450 RID: 1104 RVA: 0x0000F390 File Offset: 0x0000E790
		// (set) Token: 0x06000451 RID: 1105 RVA: 0x0000F3A4 File Offset: 0x0000E7A4
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
		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000452 RID: 1106 RVA: 0x0000F3B8 File Offset: 0x0000E7B8
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
		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x0000F3CC File Offset: 0x0000E7CC
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
		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000454 RID: 1108 RVA: 0x0000F3E4 File Offset: 0x0000E7E4
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
