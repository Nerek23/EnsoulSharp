using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.AIBaseClient" /> buff remove event.
	/// </summary>
	// Token: 0x0200004E RID: 78
	public class AIBaseClientBuffRemoveEventArgs : EventArgs
	{
		// Token: 0x06000316 RID: 790 RVA: 0x00005348 File Offset: 0x00004748
		internal AIBaseClientBuffRemoveEventArgs(BuffInstance buff)
		{
			this.m_buff = buff;
		}

		/// <summary>
		/// 	Gets the buff.
		/// </summary>
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000317 RID: 791 RVA: 0x00005364 File Offset: 0x00004764
		public BuffInstance Buff
		{
			get
			{
				return this.m_buff;
			}
		}

		// Token: 0x04000363 RID: 867
		private BuffInstance m_buff;
	}
}
