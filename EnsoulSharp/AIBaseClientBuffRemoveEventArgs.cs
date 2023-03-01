using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.AIBaseClient" /> buff remove event.
	/// </summary>
	// Token: 0x0200004E RID: 78
	public class AIBaseClientBuffRemoveEventArgs : EventArgs
	{
		// Token: 0x0600030F RID: 783 RVA: 0x000052C8 File Offset: 0x000046C8
		internal AIBaseClientBuffRemoveEventArgs(BuffInstance buff)
		{
			this.m_buff = buff;
		}

		/// <summary>
		/// 	Gets the buff.
		/// </summary>
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000310 RID: 784 RVA: 0x000052E4 File Offset: 0x000046E4
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
