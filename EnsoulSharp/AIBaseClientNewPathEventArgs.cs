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
		// Token: 0x06000320 RID: 800 RVA: 0x00005448 File Offset: 0x00004848
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
		// (get) Token: 0x06000321 RID: 801 RVA: 0x00005470 File Offset: 0x00004870
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
		// (get) Token: 0x06000322 RID: 802 RVA: 0x00005484 File Offset: 0x00004884
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
		// (get) Token: 0x06000323 RID: 803 RVA: 0x00005498 File Offset: 0x00004898
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
