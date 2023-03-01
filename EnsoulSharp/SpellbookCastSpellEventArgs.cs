using System;
using System.Runtime.InteropServices;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.Spellbook" /> cast spell event.
	/// </summary>
	// Token: 0x0200006B RID: 107
	public class SpellbookCastSpellEventArgs : EventArgs
	{
		// Token: 0x06000436 RID: 1078 RVA: 0x0000F100 File Offset: 0x0000E500
		internal SpellbookCastSpellEventArgs([MarshalAs(UnmanagedType.U1)] bool process, Vector3 startPosition, Vector3 endPosition, GameObject target, SpellSlot slot)
		{
			this.m_process = process;
			this.m_startPosition = startPosition;
			this.m_endPosition = endPosition;
			this.m_target = target;
			this.m_slot = slot;
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether the event should process.
		/// </summary>
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x0000F138 File Offset: 0x0000E538
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x0000F14C File Offset: 0x0000E54C
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
		/// 	Gets the spell start position.
		/// </summary>
		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x0000F160 File Offset: 0x0000E560
		public Vector3 StartPosition
		{
			get
			{
				return this.m_startPosition;
			}
		}

		/// <summary>
		/// 	Gets the spell target position.
		/// </summary>
		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x0000F178 File Offset: 0x0000E578
		public Vector3 EndPosition
		{
			get
			{
				return this.m_endPosition;
			}
		}

		/// <summary>
		/// 	Gets the spell target.
		/// </summary>
		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x0000F190 File Offset: 0x0000E590
		public GameObject Target
		{
			get
			{
				return this.m_target;
			}
		}

		/// <summary>
		/// 	Gets the spell slot.
		/// </summary>
		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x0000F1A4 File Offset: 0x0000E5A4
		public SpellSlot Slot
		{
			get
			{
				return this.m_slot;
			}
		}

		// Token: 0x0400039B RID: 923
		private bool m_process;

		// Token: 0x0400039C RID: 924
		private Vector3 m_startPosition;

		// Token: 0x0400039D RID: 925
		private Vector3 m_endPosition;

		// Token: 0x0400039E RID: 926
		private GameObject m_target;

		// Token: 0x0400039F RID: 927
		private SpellSlot m_slot;
	}
}
