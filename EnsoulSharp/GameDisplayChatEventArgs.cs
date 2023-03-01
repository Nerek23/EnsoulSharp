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
		// Token: 0x060004F2 RID: 1266 RVA: 0x0000B210 File Offset: 0x0000A610
		internal GameDisplayChatEventArgs([MarshalAs(UnmanagedType.U1)] bool process, string msg, int flags)
		{
			this.m_process = process;
			this.m_msg = msg;
			this.m_flags = flags;
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether the event should process.
		/// </summary>
		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x0000B238 File Offset: 0x0000A638
		// (set) Token: 0x060004F4 RID: 1268 RVA: 0x0000B24C File Offset: 0x0000A64C
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
		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060004F5 RID: 1269 RVA: 0x0000B260 File Offset: 0x0000A660
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
		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060004F6 RID: 1270 RVA: 0x0000B274 File Offset: 0x0000A674
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
