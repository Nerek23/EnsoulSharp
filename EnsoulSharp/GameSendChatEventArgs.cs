using System;
using System.Runtime.InteropServices;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.Game" /> send chat event.
	/// </summary>
	// Token: 0x020000DA RID: 218
	public class GameSendChatEventArgs : EventArgs
	{
		// Token: 0x06000502 RID: 1282 RVA: 0x0000C774 File Offset: 0x0000BB74
		internal GameSendChatEventArgs([MarshalAs(UnmanagedType.U1)] bool process, string msg, [MarshalAs(UnmanagedType.U1)] bool sendToAll)
		{
			this.m_process = process;
			this.m_msg = msg;
			this.m_sendToAll = sendToAll;
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether the event should process.
		/// </summary>
		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000503 RID: 1283 RVA: 0x0000C79C File Offset: 0x0000BB9C
		// (set) Token: 0x06000504 RID: 1284 RVA: 0x0000C7B0 File Offset: 0x0000BBB0
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
		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000505 RID: 1285 RVA: 0x0000C7C4 File Offset: 0x0000BBC4
		public string Msg
		{
			get
			{
				return this.m_msg;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether send message to all channel.
		/// </summary>
		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000506 RID: 1286 RVA: 0x0000C7D8 File Offset: 0x0000BBD8
		public bool SendToAll
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.m_sendToAll;
			}
		}

		// Token: 0x040003C7 RID: 967
		private bool m_process;

		// Token: 0x040003C8 RID: 968
		private string m_msg;

		// Token: 0x040003C9 RID: 969
		private bool m_sendToAll;
	}
}
