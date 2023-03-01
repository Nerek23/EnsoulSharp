using System;
using System.Runtime.InteropServices;
using EnsoulSharp.Native;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to navigation mesh cell.
	/// </summary>
	// Token: 0x02000158 RID: 344
	public class NavMeshCell
	{
		// Token: 0x06000683 RID: 1667 RVA: 0x0000D6D4 File Offset: 0x0000CAD4
		internal NavMeshCell(int x, int y)
		{
			this.m_x = x;
			this.m_y = y;
		}

		/// <summary>
		/// 	Gets the collision flags of the grid.
		/// </summary>
		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x0000D76C File Offset: 0x0000CB6C
		// (set) Token: 0x06000685 RID: 1669 RVA: 0x0000D784 File Offset: 0x0000CB84
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
		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000686 RID: 1670 RVA: 0x0000D6F8 File Offset: 0x0000CAF8
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
		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000687 RID: 1671 RVA: 0x0000D70C File Offset: 0x0000CB0C
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
		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000688 RID: 1672 RVA: 0x0000D720 File Offset: 0x0000CB20
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
		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000689 RID: 1673 RVA: 0x0000D74C File Offset: 0x0000CB4C
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
