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
	// Token: 0x02000159 RID: 345
	public class NavMesh
	{
		/// <summary>
		/// 	Gets the navigation mesh cell.
		/// </summary>
		/// <param name="position">The grid position.</param>
		/// <returns>An instance of the <see cref="T:EnsoulSharp.NavMeshCell" />.</returns>
		// Token: 0x0600067F RID: 1663 RVA: 0x0000D59C File Offset: 0x0000C99C
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
		// Token: 0x06000680 RID: 1664 RVA: 0x0000D588 File Offset: 0x0000C988
		public static NavMeshCell GetCell(int x, int y)
		{
			return new NavMeshCell(x, y);
		}

		/// <summary>
		/// 	Gets the collision flags of the specfied world position.
		/// </summary>
		/// <param name="position">The world position.</param>
		/// <returns>The <see cref="T:EnsoulSharp.CollisionFlags" /> of the specfied world position.</returns>
		// Token: 0x06000681 RID: 1665 RVA: 0x0000D5D4 File Offset: 0x0000C9D4
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
		// Token: 0x06000682 RID: 1666 RVA: 0x0000D5C0 File Offset: 0x0000C9C0
		public static CollisionFlags GetCollisionFlags(float x, float y)
		{
			return (CollisionFlags)<Module>.EnsoulSharp.Native.NavMesh.GetCollisionFlags(x, y);
		}

		/// <summary>
		/// 	Sets the collision flags of the specified world position.
		/// </summary>
		/// <param name="flags">The collision flags specified to set.</param>
		/// <param name="position">The world position.</param>
		// Token: 0x06000683 RID: 1667 RVA: 0x0000D60C File Offset: 0x0000CA0C
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
		// Token: 0x06000684 RID: 1668 RVA: 0x0000D5F4 File Offset: 0x0000C9F4
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
		// Token: 0x06000685 RID: 1669 RVA: 0x0000D654 File Offset: 0x0000CA54
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
		// Token: 0x06000686 RID: 1670 RVA: 0x0000D630 File Offset: 0x0000CA30
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
		// Token: 0x06000687 RID: 1671 RVA: 0x0000D7A4 File Offset: 0x0000CBA4
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
		// Token: 0x06000688 RID: 1672 RVA: 0x0000D784 File Offset: 0x0000CB84
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
		// Token: 0x06000689 RID: 1673 RVA: 0x0000D6BC File Offset: 0x0000CABC
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
		// Token: 0x0600068A RID: 1674 RVA: 0x0000D678 File Offset: 0x0000CA78
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
		// Token: 0x0600068B RID: 1675 RVA: 0x0000D720 File Offset: 0x0000CB20
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
		// Token: 0x0600068C RID: 1676 RVA: 0x0000D6E0 File Offset: 0x0000CAE0
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
		// Token: 0x0600068D RID: 1677 RVA: 0x0000D764 File Offset: 0x0000CB64
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
		// Token: 0x0600068E RID: 1678 RVA: 0x0000D740 File Offset: 0x0000CB40
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
