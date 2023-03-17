using System;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.MissileClient" /> commit movement event.
	/// </summary>
	// Token: 0x02000151 RID: 337
	public class MissileClientCommitMovementEventArgs : EventArgs
	{
		// Token: 0x0600065F RID: 1631 RVA: 0x0000D52C File Offset: 0x0000C92C
		internal MissileClientCommitMovementEventArgs(Vector2 position)
		{
			this.m_position = position;
		}

		/// <summary>
		/// 	Gets or sets the screen position of mouse.
		/// </summary>
		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000660 RID: 1632 RVA: 0x0000D548 File Offset: 0x0000C948
		// (set) Token: 0x06000661 RID: 1633 RVA: 0x0000D560 File Offset: 0x0000C960
		public Vector2 Position
		{
			get
			{
				return this.m_position;
			}
			set
			{
				this.m_position = value;
			}
		}

		// Token: 0x04000409 RID: 1033
		private Vector2 m_position;
	}
}
