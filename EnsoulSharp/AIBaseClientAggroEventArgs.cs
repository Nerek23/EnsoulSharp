using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.AIBaseClient" /> aggro event.
	/// </summary>
	// Token: 0x0200004C RID: 76
	public class AIBaseClientAggroEventArgs : EventArgs
	{
		// Token: 0x0600030B RID: 779 RVA: 0x00005268 File Offset: 0x00004668
		internal AIBaseClientAggroEventArgs(int networkId)
		{
			this.m_networkId = networkId;
		}

		/// <summary>
		/// 	Gets the target network id.
		/// </summary>
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600030C RID: 780 RVA: 0x00005284 File Offset: 0x00004684
		public int NetworkId
		{
			get
			{
				return this.m_networkId;
			}
		}

		// Token: 0x04000361 RID: 865
		private int m_networkId;
	}
}
