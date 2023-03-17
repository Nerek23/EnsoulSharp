using System;
using System.Runtime.InteropServices;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.Game" /> display chat event.
	/// </summary>
	// Token: 0x020000D9 RID: 217
	public class GameDisplayChatEventArgs : EventArgs
	{
		// Token: 0x060004FD RID: 1277 RVA: 0x0000B300 File Offset: 0x0000A700
		internal GameDisplayChatEventArgs([MarshalAs(UnmanagedType.U1)] bool process, string msg, int flags)
		{
			this.m_process = process;
			this.m_msg = msg;
			this.m_flags = flags;
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether the event should process.
		/// </summary>
		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060004FE RID: 1278 RVA: 0x0000B328 File Offset: 0x0000A728
		// (set) Token: 0x060004FF RID: 1279 RVA: 0x0000B33C File Offset: 0x0000A73C
		public bool Process
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.m_process;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				this.m_process = value;
			}
		}

		/// <summary>
		/// 	Gets the message.
		/// </summary>
		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x0000B350 File Offset: 0x0000A750
		public string Msg
		{
			get
			{
				return this.m_msg;
			}
		}

		/// <summary>
		/// 	Gets the flags.
		/// </summary>
		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000501 RID: 1281 RVA: 0x0000B364 File Offset: 0x0000A764
		public int Flags
		{
			get
			{
				return this.m_flags;
			}
		}

		// Token: 0x040003C4 RID: 964
		private bool m_process;

		// Token: 0x040003C5 RID: 965
		private string m_msg;

		// Token: 0x040003C6 RID: 966
		private int m_flags;
	}
}
