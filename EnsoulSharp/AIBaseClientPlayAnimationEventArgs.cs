using System;
using System.Runtime.InteropServices;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.AIBaseClient" /> play animation event.
	/// </summary>
	// Token: 0x02000051 RID: 81
	public class AIBaseClientPlayAnimationEventArgs : EventArgs
	{
		// Token: 0x0600031D RID: 797 RVA: 0x0000542C File Offset: 0x0000482C
		internal AIBaseClientPlayAnimationEventArgs([MarshalAs(UnmanagedType.U1)] bool process, string animation)
		{
			this.m_process = process;
			this.m_animation = animation;
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether the event should process.
		/// </summary>
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600031E RID: 798 RVA: 0x00005450 File Offset: 0x00004850
		// (set) Token: 0x0600031F RID: 799 RVA: 0x00005464 File Offset: 0x00004864
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
		/// 	Gets the animation name.
		/// </summary>
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000320 RID: 800 RVA: 0x00005478 File Offset: 0x00004878
		public string Animation
		{
			get
			{
				return this.m_animation;
			}
		}

		// Token: 0x0400036D RID: 877
		private bool m_process;

		// Token: 0x0400036E RID: 878
		private string m_animation;
	}
}
