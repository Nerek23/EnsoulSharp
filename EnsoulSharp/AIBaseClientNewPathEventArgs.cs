using System;
using System.Runtime.InteropServices;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.AIBaseClient" /> new path event.
	/// </summary>
	// Token: 0x02000050 RID: 80
	public class AIBaseClientNewPathEventArgs : EventArgs
	{
		// Token: 0x06000319 RID: 793 RVA: 0x000053C8 File Offset: 0x000047C8
		internal AIBaseClientNewPathEventArgs(Vector3[] path, [MarshalAs(UnmanagedType.U1)] bool isDash, float speed)
		{
			this.m_path = path;
			this.m_isDash = isDash;
			this.m_speed = speed;
		}

		/// <summary>
		/// 	Gets the path.
		/// </summary>
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600031A RID: 794 RVA: 0x000053F0 File Offset: 0x000047F0
		public Vector3[] Path
		{
			get
			{
				return this.m_path;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the new path is dash.
		/// </summary>
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600031B RID: 795 RVA: 0x00005404 File Offset: 0x00004804
		public bool IsDash
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.m_isDash;
			}
		}

		/// <summary>
		/// 	Gets the speed.
		/// </summary>
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600031C RID: 796 RVA: 0x00005418 File Offset: 0x00004818
		public float Speed
		{
			get
			{
				return this.m_speed;
			}
		}

		// Token: 0x0400036A RID: 874
		internal Vector3[] m_path;

		// Token: 0x0400036B RID: 875
		internal bool m_isDash;

		// Token: 0x0400036C RID: 876
		internal float m_speed;
	}
}
