using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.AttackableUnit" /> teleport event.
	/// </summary>
	// Token: 0x02000048 RID: 72
	public class AttackableUnitTeleportEventArgs : EventArgs
	{
		// Token: 0x060002DD RID: 733 RVA: 0x00006438 File Offset: 0x00005838
		internal AttackableUnitTeleportEventArgs(string recallType, string recallName)
		{
			this.m_recallType = recallType;
			this.m_recallName = recallName;
		}

		/// <summary>
		/// 	Gets the recall type.
		/// </summary>
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060002DE RID: 734 RVA: 0x0000645C File Offset: 0x0000585C
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
		// (get) Token: 0x060002DF RID: 735 RVA: 0x00006470 File Offset: 0x00005870
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
