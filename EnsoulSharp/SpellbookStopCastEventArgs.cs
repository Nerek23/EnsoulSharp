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
		// Token: 0x0600043D RID: 1085 RVA: 0x0000F1B8 File Offset: 0x0000E5B8
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
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600043E RID: 1086 RVA: 0x0000F1F8 File Offset: 0x0000E5F8
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
		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x0000F20C File Offset: 0x0000E60C
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
		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x0000F220 File Offset: 0x0000E620
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
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x0000F234 File Offset: 0x0000E634
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
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x0000F248 File Offset: 0x0000E648
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
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x0000F25C File Offset: 0x0000E65C
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
