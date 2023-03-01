using System;
using System.Runtime.InteropServices;
using EnsoulSharp.Native;
using EnsoulSharp.Native.Enums;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to navigation mesh.
	/// </summary>
	// Token: 0x02000157 RID: 343
	public class NavMesh
	{
		/// <summary>
		/// 	Gets the navigation mesh cell.
		/// </summary>
		/// <param name="position">The grid position.</param>
		/// <returns>An instance of the <see cref="T:EnsoulSharp.NavMeshCell" />.</returns>
		// Token: 0x06000672 RID: 1650 RVA: 0x0000D4AC File Offset: 0x0000C8AC
		public static NavMeshCell GetCell(Vector2 position)
		{
			return NavMesh.GetCell((int)((double)position.X), (int)((double)position.Y));
		}

		/// <summary>
		/// 	Gets the navigation mesh cell.
		/// </summary>
		/// <param name="x">The grid x.</param>
		/// <param name="y">The grid y.</param>
		/// <returns>An instance of the <see cref="T:EnsoulSharp.NavMeshCell" />.</returns>
		// Token: 0x06000673 RID: 1651 RVA: 0x0000D498 File Offset: 0x0000C898
		public static NavMeshCell GetCell(int x, int y)
		{
			return new NavMeshCell(x, y);
		}

		/// <summary>
		/// 	Gets the collision flags of the specfied world position.
		/// </summary>
		/// <param name="position">The world position.</param>
		/// <returns>The <see cref="T:EnsoulSharp.CollisionFlags" /> of the specfied world position.</returns>
		// Token: 0x06000674 RID: 1652 RVA: 0x0000D4E4 File Offset: 0x0000C8E4
		public static CollisionFlags GetCollisionFlags(Vector3 position)
		{
			return NavMesh.GetCollisionFlags(position.X, position.Y);
		}

		/// <summary>
		/// 	Gets the collision flags of the specified world position.
		/// </summary>
		/// <param name="x">The world x.</param>
		/// <param name="y">The world y.</param>
		/// <returns>The <see cref="T:EnsoulSharp.CollisionFlags" /> of the specified world position.</returns>
		// Token: 0x06000675 RID: 1653 RVA: 0x0000D4D0 File Offset: 0x0000C8D0
		public static CollisionFlags GetCollisionFlags(float x, float y)
		{
			return (CollisionFlags)<Module>.EnsoulSharp.Native.NavMesh.GetCollisionFlags(x, y);
		}

		/// <summary>
		/// 	Sets the collision flags of the specified world position.
		/// </summary>
		/// <param name="flags">The collision flags specified to set.</param>
		/// <param name="position">The world position.</param>
		// Token: 0x06000676 RID: 1654 RVA: 0x0000D51C File Offset: 0x0000C91C
		public static void SetCollisionFlags(CollisionFlags flags, Vector3 position)
		{
			NavMesh.SetCollisionFlags(flags, position.X, position.Y);
		}

		/// <summary>
		/// 	Sets the collision flags of the specified world position.
		/// </summary>
		/// <param name="flags">The collision flags specified to set.</param>
		/// <param name="x">The world x.</param>
		/// <param name="y">The world y.</param>
		// Token: 0x06000677 RID: 1655 RVA: 0x0000D504 File Offset: 0x0000C904
		public static void SetCollisionFlags(CollisionFlags flags, float x, float y)
		{
			<Module>.EnsoulSharp.Native.NavMesh.SetCollisionFlags(x, y, (CollisionFlags)flags);
		}

		/// <summary>
		/// 	Checks if there if a wall of type at the given position.
		/// </summary>
		/// <param name="position">The world position.</param>
		/// <param name="flags">The collision flags specified to check.</param>
		/// <param name="radius">The check radius.</param>
		/// <returns>A value indicating whether there is a wall of type at the given position.</returns>
		// Token: 0x06000678 RID: 1656 RVA: 0x0000D564 File Offset: 0x0000C964
		[return: MarshalAs(UnmanagedType.U1)]
		public static bool IsWallOfType(Vector3 position, CollisionFlags flags, float radius)
		{
			return NavMesh.IsWallOfType(position.X, position.Y, flags, radius);
		}

		/// <summary>
		/// 	Checks if there is a wall of type at the given position.
		/// </summary>
		/// <param name="x">The world x.</param>
		/// <param name="y">The world y.</param>
		/// <param name="flags">The collision flags specified to check.</param>
		/// <param name="radius">The check radius.</param>
		/// <returns>A value indicating whether there is a wall of type at the given position.</returns>
		// Token: 0x06000679 RID: 1657 RVA: 0x0000D540 File Offset: 0x0000C940
		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe static bool IsWallOfType(float x, float y, CollisionFlags flags, float radius)
		{
			NavGrid* ptr = <Module>.EnsoulSharp.Native.NavGrid.GetInstance();
			return ptr != null && <Module>.EnsoulSharp.Native.NavGrid.IsWallOfType(ptr, x, y, (CollisionFlags)flags, radius) != null;
		}

		/// <summary>
		/// 	Checks if there is water at the given position.
		/// </summary>
		/// <param name="position">The world position.</param>
		/// <returns>A value indicating whether there is water at the given position.</returns>
		// Token: 0x0600067A RID: 1658 RVA: 0x0000D6B4 File Offset: 0x0000CAB4
		[return: MarshalAs(UnmanagedType.U1)]
		public static bool IsWater(Vector3 position)
		{
			return NavMesh.IsWater(position.X, position.Y);
		}

		/// <summary>
		/// 	Checks if there is water at the given position.
		/// </summary>
		/// <param name="x">The world x.</param>
		/// <param name="y">The world y.</param>
		/// <returns>A value indicating whether there is water at the given position.</returns>
		// Token: 0x0600067B RID: 1659 RVA: 0x0000D694 File Offset: 0x0000CA94
		[return: MarshalAs(UnmanagedType.U1)]
		public static bool IsWater(float x, float y)
		{
			return NavMesh.GetCell(NavMesh.WorldToGrid(x, y)).IsWater;
		}

		/// <summary>
		/// 	Converts the given grid coordinates into 3D world coordinates.
		/// </summary>
		/// <param name="position">The grid position.</param>
		/// <returns>The 3D world coordinates result.</returns>
		// Token: 0x0600067C RID: 1660 RVA: 0x0000D5CC File Offset: 0x0000C9CC
		public static Vector3 GridToWorld(Vector2 position)
		{
			return NavMesh.GridToWorld((int)((double)position.X), (int)((double)position.Y));
		}

		/// <summary>
		/// 	Converts the given grid coordinates into 3D world coordinates.
		/// </summary>
		/// <param name="x">The grid x.</param>
		/// <param name="y">The grid y.</param>
		/// <returns>The 3D world coordinates result.</returns>
		// Token: 0x0600067D RID: 1661 RVA: 0x0000D588 File Offset: 0x0000C988
		public unsafe static Vector3 GridToWorld(int x, int y)
		{
			NavGrid* ptr = <Module>.EnsoulSharp.Native.NavGrid.GetInstance();
			if (ptr != null)
			{
				Vector3f vector3f;
				<Module>.EnsoulSharp.Native.NavGrid.CellToWorld(ptr, &vector3f, x, y);
				Vector3 result = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ref vector3f), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ref vector3f), <Module>.EnsoulSharp.Native.Vector3f.GetY(ref vector3f));
				return result;
			}
			return Vector3.Zero;
		}

		/// <summary>
		/// 	Converts the given 3D world coordinates into grid coordinates.
		/// </summary>
		/// <param name="position">The world position.</param>
		/// <returns>The grid coordinates result.</returns>
		// Token: 0x0600067E RID: 1662 RVA: 0x0000D630 File Offset: 0x0000CA30
		public static Vector2 WorldToGrid(Vector3 position)
		{
			return NavMesh.WorldToGrid(position.X, position.Y);
		}

		/// <summary>
		/// 	Converts the given 3D world coordinates into grid coordinates.
		/// </summary>
		/// <param name="x">The world x.</param>
		/// <param name="y">The world y.</param>
		/// <returns>The grid coordinates result.</returns>
		// Token: 0x0600067F RID: 1663 RVA: 0x0000D5F0 File Offset: 0x0000C9F0
		public unsafe static Vector2 WorldToGrid(float x, float y)
		{
			NavGrid* ptr = <Module>.EnsoulSharp.Native.NavGrid.GetInstance();
			if (ptr != null)
			{
				Vector2f vector2f;
				<Module>.EnsoulSharp.Native.NavGrid.WorldToCell(ptr, &vector2f, x, y);
				Vector2 result = new Vector2(<Module>.EnsoulSharp.Native.Vector2f.GetX(ref vector2f), <Module>.EnsoulSharp.Native.Vector2f.GetY(ref vector2f));
				return result;
			}
			return Vector2.Zero;
		}

		/// <summary>
		/// 	Gets the height of the given 3D world coordinates.
		/// </summary>
		/// <param name="position">The world position.</param>
		/// <returns>The height of the given 3D world coordinates.</returns>
		// Token: 0x06000680 RID: 1664 RVA: 0x0000D674 File Offset: 0x0000CA74
		public static float GetHeightForPosition(Vector3 position)
		{
			return NavMesh.GetHeightForPosition(position.X, position.Y);
		}

		/// <summary>
		/// 	Gets the height of the given 3D world coordinates.
		/// </summary>
		/// <param name="x">The world x.</param>
		/// <param name="y">The world y.</param>
		/// <returns>The height of the given 3D world coordinates.</returns>
		// Token: 0x06000681 RID: 1665 RVA: 0x0000D650 File Offset: 0x0000CA50
		public unsafe static float GetHeightForPosition(float x, float y)
		{
			NavGrid* ptr = <Module>.EnsoulSharp.Native.NavGrid.GetInstance();
			if (ptr != null)
			{
				return <Module>.EnsoulSharp.Native.NavGrid.GetHeightForValidPosition(ptr, x, y);
			}
			return 0f;
		}
	}
}
