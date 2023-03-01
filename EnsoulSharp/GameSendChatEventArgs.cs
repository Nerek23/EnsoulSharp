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
		// Token: 0x060004F7 RID: 1271 RVA: 0x0000C684 File Offset: 0x0000BA84
		internal GameSendChatEventArgs([MarshalAs(UnmanagedType.U1)] bool process, string msg, [MarshalAs(UnmanagedType.U1)] bool sendToAll)
		{
			this.m_process = process;
			this.m_msg = msg;
			this.m_sendToAll = sendToAll;
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether the event should process.
		/// </summary>
		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060004F8 RID: 1272 RVA: 0x0000C6AC File Offset: 0x0000BAAC
		// (set) Token: 0x060004F9 RID: 1273 RVA: 0x0000C6C0 File Offset: 0x0000BAC0
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
		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060004FA RID: 1274 RVA: 0x0000C6D4 File Offset: 0x0000BAD4
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
		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060004FB RID: 1275 RVA: 0x0000C6E8 File Offset: 0x0000BAE8
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
