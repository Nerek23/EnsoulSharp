using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.AIBaseClient" /> aggro event.
	/// </summary>
	// Token: 0x0200004C RID: 76
	public class AIBaseClientAggroEventArgs : EventArgs
	{
		// Token: 0x06000312 RID: 786 RVA: 0x000052E8 File Offset: 0x000046E8
		internal AIBaseClientAggroEventArgs(int networkId)
		{
			this.m_networkId = networkId;
		}

		/// <summary>
		/// 	Gets the target network id.
		/// </summary>
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000313 RID: 787 RVA: 0x00005304 File Offset: 0x00004704
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
