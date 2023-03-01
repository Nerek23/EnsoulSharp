using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.AIBaseClient" /> buff add event.
	/// </summary>
	// Token: 0x0200004D RID: 77
	public class AIBaseClientBuffAddEventArgs : EventArgs
	{
		// Token: 0x0600030D RID: 781 RVA: 0x00005298 File Offset: 0x00004698
		internal AIBaseClientBuffAddEventArgs(BuffInstance buff)
		{
			this.m_buff = buff;
		}

		/// <summary>
		/// 	Gets the buff.
		/// </summary>
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600030E RID: 782 RVA: 0x000052B4 File Offset: 0x000046B4
		public BuffInstance Buff
		{
			get
			{
				return this.m_buff;
			}
		}

		// Token: 0x04000362 RID: 866
		private BuffInstance m_buff;
	}
}
