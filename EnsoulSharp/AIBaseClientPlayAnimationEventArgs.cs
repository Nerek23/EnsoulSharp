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
		// Token: 0x06000324 RID: 804 RVA: 0x000054AC File Offset: 0x000048AC
		internal AIBaseClientPlayAnimationEventArgs([MarshalAs(UnmanagedType.U1)] bool process, string animation)
		{
			this.m_process = process;
			this.m_animation = animation;
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether the event should process.
		/// </summary>
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000325 RID: 805 RVA: 0x000054D0 File Offset: 0x000048D0
		// (set) Token: 0x06000326 RID: 806 RVA: 0x000054E4 File Offset: 0x000048E4
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
		// (get) Token: 0x06000327 RID: 807 RVA: 0x000054F8 File Offset: 0x000048F8
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
