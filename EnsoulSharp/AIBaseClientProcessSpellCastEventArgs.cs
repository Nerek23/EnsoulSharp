using System;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.AIBaseClient" /> do cast and process spell cast event.
	/// </summary>
	// Token: 0x02000052 RID: 82
	public class AIBaseClientProcessSpellCastEventArgs : EventArgs
	{
		// Token: 0x06000328 RID: 808 RVA: 0x0000550C File Offset: 0x0000490C
		internal AIBaseClientProcessSpellCastEventArgs(SpellData sdata, int level, Vector3 start, Vector3 to, Vector3 end, int targetLocalId, int missileNetworkId, float castTime, float totalTime, SpellSlot slot)
		{
			this.m_sdata = sdata;
			this.m_level = level;
			this.m_start = start;
			this.m_to = to;
			this.m_end = end;
			this.m_targetLocalId = targetLocalId;
			this.m_missileNetworkId = missileNetworkId;
			this.m_castTime = castTime;
			this.m_totalTime = totalTime;
			this.m_slot = slot;
		}

		/// <summary>
		/// 	Gets the spell data.
		/// </summary>
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000329 RID: 809 RVA: 0x0000556C File Offset: 0x0000496C
		public SpellData SData
		{
			get
			{
				return this.m_sdata;
			}
		}

		/// <summary>
		/// 	Gets the spell level.
		/// </summary>
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600032A RID: 810 RVA: 0x00005580 File Offset: 0x00004980
		public int Level
		{
			get
			{
				return this.m_level;
			}
		}

		/// <summary>
		/// 	Gets the spell start position.
		/// </summary>
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600032B RID: 811 RVA: 0x00005594 File Offset: 0x00004994
		public Vector3 Start
		{
			get
			{
				return this.m_start;
			}
		}

		/// <summary>
		/// 	Gets the spell target position.
		/// </summary>
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600032C RID: 812 RVA: 0x000055AC File Offset: 0x000049AC
		public Vector3 To
		{
			get
			{
				return this.m_to;
			}
		}

		/// <summary>
		/// 	Gets the spell target end position.
		/// </summary>
		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600032D RID: 813 RVA: 0x000055C4 File Offset: 0x000049C4
		public Vector3 End
		{
			get
			{
				return this.m_end;
			}
		}

		/// <summary>
		/// 	Gets the spell target.
		/// </summary>
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600032E RID: 814 RVA: 0x000055DC File Offset: 0x000049DC
		public GameObject Target
		{
			get
			{
				return ObjectManager.CreateObjectFromPointer(<Module>.EnsoulSharp.Native.ObjectManager.GetUnitByIndex((uint)this.m_targetLocalId));
			}
		}

		/// <summary>
		/// 	Gets the spell missile network id.
		/// </summary>
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600032F RID: 815 RVA: 0x000055FC File Offset: 0x000049FC
		public int MissileNetworkId
		{
			get
			{
				return this.m_missileNetworkId;
			}
		}

		/// <summary>
		/// 	Gets the cast spell time.
		/// </summary>
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000330 RID: 816 RVA: 0x00005610 File Offset: 0x00004A10
		public float CastTime
		{
			get
			{
				return this.m_castTime;
			}
		}

		/// <summary>
		/// 	Gets the total spell time.
		/// </summary>
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000331 RID: 817 RVA: 0x00005624 File Offset: 0x00004A24
		public float TotalTime
		{
			get
			{
				return this.m_totalTime;
			}
		}

		/// <summary>
		/// 	Gets the spell slot.
		/// </summary>
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000332 RID: 818 RVA: 0x00005638 File Offset: 0x00004A38
		public SpellSlot Slot
		{
			get
			{
				return this.m_slot;
			}
		}

		// Token: 0x0400036F RID: 879
		private SpellData m_sdata;

		// Token: 0x04000370 RID: 880
		private int m_level;

		// Token: 0x04000371 RID: 881
		private Vector3 m_start;

		// Token: 0x04000372 RID: 882
		private Vector3 m_to;

		// Token: 0x04000373 RID: 883
		private Vector3 m_end;

		// Token: 0x04000374 RID: 884
		private int m_targetLocalId;

		// Token: 0x04000375 RID: 885
		private int m_missileNetworkId;

		// Token: 0x04000376 RID: 886
		private float m_castTime;

		// Token: 0x04000377 RID: 887
		private float m_totalTime;

		// Token: 0x04000378 RID: 888
		private SpellSlot m_slot;
	}
}
