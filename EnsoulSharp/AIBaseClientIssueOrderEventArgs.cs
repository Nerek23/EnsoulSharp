using System;
using System.Runtime.InteropServices;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.AIBaseClient" /> issue order event.
	/// </summary>
	// Token: 0x0200004F RID: 79
	public class AIBaseClientIssueOrderEventArgs : EventArgs
	{
		// Token: 0x06000311 RID: 785 RVA: 0x000052F8 File Offset: 0x000046F8
		internal AIBaseClientIssueOrderEventArgs([MarshalAs(UnmanagedType.U1)] bool process, GameObjectOrder order, Vector3 targetPosition, AttackableUnit target, [MarshalAs(UnmanagedType.U1)] bool isAttackMove, [MarshalAs(UnmanagedType.U1)] bool isPetCommand)
		{
			this.m_process = process;
			this.m_order = order;
			this.m_targetPosition = targetPosition;
			this.m_target = target;
			this.m_isAttackMove = isAttackMove;
			this.m_isPetCommand = isPetCommand;
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether the event should process.
		/// </summary>
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000312 RID: 786 RVA: 0x00005338 File Offset: 0x00004738
		// (set) Token: 0x06000313 RID: 787 RVA: 0x0000534C File Offset: 0x0000474C
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
		/// 	Gets the order.
		/// </summary>
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000314 RID: 788 RVA: 0x00005360 File Offset: 0x00004760
		public GameObjectOrder Order
		{
			get
			{
				return this.m_order;
			}
		}

		/// <summary>
		/// 	Gets the target position.
		/// </summary>
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000315 RID: 789 RVA: 0x00005374 File Offset: 0x00004774
		public Vector3 TargetPosition
		{
			get
			{
				return this.m_targetPosition;
			}
		}

		/// <summary>
		/// 	Gets the target.
		/// </summary>
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000316 RID: 790 RVA: 0x0000538C File Offset: 0x0000478C
		public AttackableUnit Target
		{
			get
			{
				return this.m_target;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the order is attack move.
		/// </summary>
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000317 RID: 791 RVA: 0x000053A0 File Offset: 0x000047A0
		public bool IsAttackMove
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.m_isAttackMove;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the order is pet command.
		/// </summary>
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000318 RID: 792 RVA: 0x000053B4 File Offset: 0x000047B4
		public bool IsPetCommand
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.m_isPetCommand;
			}
		}

		// Token: 0x04000364 RID: 868
		private bool m_process;

		// Token: 0x04000365 RID: 869
		private GameObjectOrder m_order;

		// Token: 0x04000366 RID: 870
		private Vector3 m_targetPosition;

		// Token: 0x04000367 RID: 871
		private AttackableUnit m_target;

		// Token: 0x04000368 RID: 872
		private bool m_isAttackMove;

		// Token: 0x04000369 RID: 873
		private bool m_isPetCommand;
	}
}
