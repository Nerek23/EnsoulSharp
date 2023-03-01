using System;
using System.Runtime.InteropServices;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.Game" /> window event.
	/// </summary>
	// Token: 0x020000DB RID: 219
	public class GameWndEventArgs : EventArgs
	{
		// Token: 0x060004FC RID: 1276 RVA: 0x0000C6FC File Offset: 0x0000BAFC
		internal GameWndEventArgs([MarshalAs(UnmanagedType.U1)] bool process, IntPtr hWnd, uint uMsg, uint wParam, int lParam)
		{
			this.m_process = process;
			this.m_hWnd = hWnd;
			this.m_uMsg = uMsg;
			this.m_wParam = wParam;
			this.m_lParam = lParam;
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether the event should process.
		/// </summary>
		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x0000C734 File Offset: 0x0000BB34
		// (set) Token: 0x060004FE RID: 1278 RVA: 0x0000C748 File Offset: 0x0000BB48
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
		/// 	Gets the window handle.
		/// </summary>
		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060004FF RID: 1279 RVA: 0x0000C75C File Offset: 0x0000BB5C
		public IntPtr HWnd
		{
			get
			{
				return this.m_hWnd;
			}
		}

		/// <summary>
		/// 	Gets the message.
		/// </summary>
		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x0000C774 File Offset: 0x0000BB74
		public uint Msg
		{
			get
			{
				return this.m_uMsg;
			}
		}

		/// <summary>
		/// 	Gets the wparam.
		/// </summary>
		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000501 RID: 1281 RVA: 0x0000C788 File Offset: 0x0000BB88
		public uint WParam
		{
			get
			{
				return this.m_wParam;
			}
		}

		/// <summary>
		/// 	Gets the lparam.
		/// </summary>
		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x0000C79C File Offset: 0x0000BB9C
		public int LParam
		{
			get
			{
				return this.m_lParam;
			}
		}

		// Token: 0x040003CA RID: 970
		private bool m_process;

		// Token: 0x040003CB RID: 971
		private IntPtr m_hWnd;

		// Token: 0x040003CC RID: 972
		private uint m_uMsg;

		// Token: 0x040003CD RID: 973
		private uint m_wParam;

		// Token: 0x040003CE RID: 974
		private int m_lParam;
	}
}
