using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.AttackableUnit" /> teleport event.
	/// </summary>
	// Token: 0x02000048 RID: 72
	public class AttackableUnitTeleportEventArgs : EventArgs
	{
		// Token: 0x060002E4 RID: 740 RVA: 0x000064D0 File Offset: 0x000058D0
		internal AttackableUnitTeleportEventArgs(string recallType, string recallName)
		{
			this.m_recallType = recallType;
			this.m_recallName = recallName;
		}

		/// <summary>
		/// 	Gets the recall type.
		/// </summary>
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x000064F4 File Offset: 0x000058F4
		public string RecallType
		{
			get
			{
				return this.m_recallType;
			}
		}

		/// <summary>
		/// 	Gets the recall name.
		/// </summary>
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060002E6 RID: 742 RVA: 0x00006508 File Offset: 0x00005908
		public string RecallName
		{
			get
			{
				return this.m_recallName;
			}
		}

		// Token: 0x0400035C RID: 860
		private string m_recallType;

		// Token: 0x0400035D RID: 861
		private string m_recallName;
	}
}
