using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.AIHeroClient" /> level up event.
	/// </summary>
	// Token: 0x020000B6 RID: 182
	public class AIHeroClientLevelUpEventArgs : EventArgs
	{
		// Token: 0x060004C0 RID: 1216 RVA: 0x00005C6C File Offset: 0x0000506C
		internal AIHeroClientLevelUpEventArgs(int level)
		{
			this.m_level = level;
		}

		/// <summary>
		/// 	Gets the level up to.
		/// </summary>
		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x00005C88 File Offset: 0x00005088
		public int Level
		{
			get
			{
				return this.m_level;
			}
		}

		// Token: 0x040003B7 RID: 951
		private int m_level;
	}
}
