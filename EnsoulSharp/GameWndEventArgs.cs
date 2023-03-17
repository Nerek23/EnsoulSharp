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
		// Token: 0x06000507 RID: 1287 RVA: 0x0000C7EC File Offset: 0x0000BBEC
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
		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x0000C824 File Offset: 0x0000BC24
		// (set) Token: 0x06000509 RID: 1289 RVA: 0x0000C838 File Offset: 0x0000BC38
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
		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600050A RID: 1290 RVA: 0x0000C84C File Offset: 0x0000BC4C
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
		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x0000C864 File Offset: 0x0000BC64
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
		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x0000C878 File Offset: 0x0000BC78
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
		// Token: 0x1700012A RID: 298
		// (get) Token: 0x0600050D RID: 1293 RVA: 0x0000C88C File Offset: 0x0000BC8C
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
