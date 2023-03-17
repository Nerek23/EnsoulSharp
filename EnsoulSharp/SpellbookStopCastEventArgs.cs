using System;
using System.Runtime.InteropServices;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.Spellbook" /> stop cast event.
	/// </summary>
	// Token: 0x0200006C RID: 108
	public class SpellbookStopCastEventArgs : EventArgs
	{
		// Token: 0x06000448 RID: 1096 RVA: 0x0000F2A8 File Offset: 0x0000E6A8
		internal SpellbookStopCastEventArgs([MarshalAs(UnmanagedType.U1)] bool keepAnimationPlaying, [MarshalAs(UnmanagedType.U1)] bool hasBeenCast, [MarshalAs(UnmanagedType.U1)] bool spellStopCancelled, [MarshalAs(UnmanagedType.U1)] bool destroyMissile, int missileNetworkId, int spellCastId)
		{
			this.m_keepAnimationPlaying = keepAnimationPlaying;
			this.m_hasBeenCast = hasBeenCast;
			this.m_spellStopCancelled = spellStopCancelled;
			this.m_destroyMissile = destroyMissile;
			this.m_missileNetworkId = missileNetworkId;
			this.m_spellCastId = spellCastId;
		}

		/// <summary>
		/// 	Gets a value indicating whether keep spell animation playing.
		/// </summary>
		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x0000F2E8 File Offset: 0x0000E6E8
		public bool KeepAnimationPlaying
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.m_keepAnimationPlaying;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the spell has been cast.
		/// </summary>
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600044A RID: 1098 RVA: 0x0000F2FC File Offset: 0x0000E6FC
		public bool HasBeenCast
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.m_hasBeenCast;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the spell stop cancelled.
		/// </summary>
		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x0000F310 File Offset: 0x0000E710
		public bool SpellStopCancelled
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.m_spellStopCancelled;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the spell destroy missile.
		/// </summary>
		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600044C RID: 1100 RVA: 0x0000F324 File Offset: 0x0000E724
		public bool DestroyMissile
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.m_destroyMissile;
			}
		}

		/// <summary>
		/// 	Gets the destroy missile network id.
		/// </summary>
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x0000F338 File Offset: 0x0000E738
		public int MissileNetworkId
		{
			get
			{
				return this.m_missileNetworkId;
			}
		}

		/// <summary>
		/// 	Gets the spell cast id.
		/// </summary>
		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600044E RID: 1102 RVA: 0x0000F34C File Offset: 0x0000E74C
		public int SpellCastId
		{
			get
			{
				return this.m_spellCastId;
			}
		}

		// Token: 0x040003A0 RID: 928
		private bool m_keepAnimationPlaying;

		// Token: 0x040003A1 RID: 929
		private bool m_hasBeenCast;

		// Token: 0x040003A2 RID: 930
		private bool m_spellStopCancelled;

		// Token: 0x040003A3 RID: 931
		private bool m_destroyMissile;

		// Token: 0x040003A4 RID: 932
		private int m_missileNetworkId;

		// Token: 0x040003A5 RID: 933
		private int m_spellCastId;
	}
}
