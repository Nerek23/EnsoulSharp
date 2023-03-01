using System;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.MissileClient" /> commit movement event.
	/// </summary>
	// Token: 0x0200014F RID: 335
	public class MissileClientCommitMovementEventArgs : EventArgs
	{
		// Token: 0x06000652 RID: 1618 RVA: 0x0000D43C File Offset: 0x0000C83C
		internal MissileClientCommitMovementEventArgs(Vector2 position)
		{
			this.m_position = position;
		}

		/// <summary>
		/// 	Gets or sets the screen position of mouse.
		/// </summary>
		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x0000D458 File Offset: 0x0000C858
		// (set) Token: 0x06000654 RID: 1620 RVA: 0x0000D470 File Offset: 0x0000C870
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
