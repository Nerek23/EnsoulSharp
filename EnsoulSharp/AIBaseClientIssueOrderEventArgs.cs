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
		// Token: 0x06000318 RID: 792 RVA: 0x00005378 File Offset: 0x00004778
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
		// (get) Token: 0x06000319 RID: 793 RVA: 0x000053B8 File Offset: 0x000047B8
		// (set) Token: 0x0600031A RID: 794 RVA: 0x000053CC File Offset: 0x000047CC
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
		// (get) Token: 0x0600031B RID: 795 RVA: 0x000053E0 File Offset: 0x000047E0
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
		// (get) Token: 0x0600031C RID: 796 RVA: 0x000053F4 File Offset: 0x000047F4
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
		// (get) Token: 0x0600031D RID: 797 RVA: 0x0000540C File Offset: 0x0000480C
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
		// (get) Token: 0x0600031E RID: 798 RVA: 0x00005420 File Offset: 0x00004820
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
		// (get) Token: 0x0600031F RID: 799 RVA: 0x00005434 File Offset: 0x00004834
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
