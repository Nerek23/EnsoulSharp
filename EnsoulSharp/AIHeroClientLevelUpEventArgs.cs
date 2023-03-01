using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.AIHeroClient" /> level up event.
	/// </summary>
	// Token: 0x020000B6 RID: 182
	public class AIHeroClientLevelUpEventArgs : EventArgs
	{
		// Token: 0x060004B5 RID: 1205 RVA: 0x00005BEC File Offset: 0x00004FEC
		internal AIHeroClientLevelUpEventArgs(int level)
		{
			this.m_level = level;
		}

		/// <summary>
		/// 	Gets the level up to.
		/// </summary>
		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x00005C08 File Offset: 0x00005008
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
