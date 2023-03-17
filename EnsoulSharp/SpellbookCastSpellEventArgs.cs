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
		// Token: 0x06000441 RID: 1089 RVA: 0x0000F1F0 File Offset: 0x0000E5F0
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
		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x0000F228 File Offset: 0x0000E628
		// (set) Token: 0x06000443 RID: 1091 RVA: 0x0000F23C File Offset: 0x0000E63C
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
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000444 RID: 1092 RVA: 0x0000F250 File Offset: 0x0000E650
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
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x0000F268 File Offset: 0x0000E668
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
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000446 RID: 1094 RVA: 0x0000F280 File Offset: 0x0000E680
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
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x0000F294 File Offset: 0x0000E694
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
