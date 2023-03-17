using System;
using System.Runtime.InteropServices;
using EnsoulSharp.Native;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to navigation mesh cell.
	/// </summary>
	// Token: 0x0200015A RID: 346
	public class NavMeshCell
	{
		// Token: 0x06000690 RID: 1680 RVA: 0x0000D7C4 File Offset: 0x0000CBC4
		internal NavMeshCell(int x, int y)
		{
			this.m_x = x;
			this.m_y = y;
		}

		/// <summary>
		/// 	Gets the collision flags of the grid.
		/// </summary>
		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000691 RID: 1681 RVA: 0x0000D85C File Offset: 0x0000CC5C
		// (set) Token: 0x06000692 RID: 1682 RVA: 0x0000D874 File Offset: 0x0000CC74
		public CollisionFlags CollFlags
		{
			get
			{
				return NavMesh.GetCollisionFlags(this.WorldPosition);
			}
			set
			{
				Vector3 worldPosition = this.WorldPosition;
				NavMesh.SetCollisionFlags(value, worldPosition);
			}
		}

		/// <summary>
		/// 	Get the grid x.
		/// </summary>
		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000693 RID: 1683 RVA: 0x0000D7E8 File Offset: 0x0000CBE8
		public int GridX
		{
			get
			{
				return this.m_x;
			}
		}

		/// <summary>
		/// 	Gets the grid y.
		/// </summary>
		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000694 RID: 1684 RVA: 0x0000D7FC File Offset: 0x0000CBFC
		public int GridY
		{
			get
			{
				return this.m_y;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the grid is water.
		/// </summary>
		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000695 RID: 1685 RVA: 0x0000D810 File Offset: 0x0000CC10
		public unsafe bool IsWater
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				NavGrid* ptr = <Module>.EnsoulSharp.Native.NavGrid.GetInstance();
				return ptr != null && <Module>.EnsoulSharp.Native.NavGrid.IsWater(ptr, this.m_x, this.m_y) != null;
			}
		}

		/// <summary>
		/// 	Gets the world position of the grid.
		/// </summary>
		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000696 RID: 1686 RVA: 0x0000D83C File Offset: 0x0000CC3C
		public Vector3 WorldPosition
		{
			get
			{
				return NavMesh.GridToWorld(this.m_x, this.m_y);
			}
		}

		// Token: 0x0400040D RID: 1037
		private int m_x;

		// Token: 0x0400040E RID: 1038
		private int m_y;
	}
}
