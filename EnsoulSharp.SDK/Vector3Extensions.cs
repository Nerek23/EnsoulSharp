using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000059 RID: 89
	public static class Vector3Extensions
	{
		// Token: 0x0600036C RID: 876 RVA: 0x000198F8 File Offset: 0x00017AF8
		public static float AngleBetween(this Vector3 vector3, Vector3 toVector3)
		{
			return vector3.ToVector2().AngleBetween(toVector3);
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00019906 File Offset: 0x00017B06
		public static float AngleBetween(this Vector3 vector3, Vector2 toVector2)
		{
			return vector3.ToVector2().AngleBetween(toVector2);
		}

		// Token: 0x0600036E RID: 878 RVA: 0x00019914 File Offset: 0x00017B14
		public static Vector2 Closest(this Vector3 vector3, IEnumerable<Vector2> array)
		{
			return vector3.ToVector2().Closest(array);
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00019922 File Offset: 0x00017B22
		public static Vector3 Closest(this Vector3 vector3, IEnumerable<Vector3> array)
		{
			return vector3.ToVector2().Closest(array);
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00019930 File Offset: 0x00017B30
		public static int CountAllyHeroesInRange(this Vector3 vector3, float range, AIBaseClient originalUnit = null)
		{
			return (from h in GameObjects.AllyHeroes
			where h.IsValidTarget(range, false, vector3) && !h.Compare(originalUnit) && h.Distance(vector3) <= range
			select h).ToList<AIHeroClient>().Count;
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00019978 File Offset: 0x00017B78
		public static int CountEnemyHeroesInRange(this Vector3 vector3, float range, AIBaseClient originalUnit = null)
		{
			return (from h in GameObjects.EnemyHeroes
			where h.IsValidTarget(range, true, vector3) && !h.Compare(originalUnit) && h.Distance(vector3) <= range
			select h).ToList<AIHeroClient>().Count;
		}

		// Token: 0x06000372 RID: 882 RVA: 0x000199C0 File Offset: 0x00017BC0
		public static float Distance(this Vector3 vector3, GameObject obj)
		{
			return vector3.ToVector2().Distance(obj.Position.ToVector2());
		}

		// Token: 0x06000373 RID: 883 RVA: 0x000199D8 File Offset: 0x00017BD8
		public static float Distance(this Vector3 vector3, Vector3 toVector3)
		{
			return vector3.ToVector2().Distance(toVector3);
		}

		// Token: 0x06000374 RID: 884 RVA: 0x000199E6 File Offset: 0x00017BE6
		public static float Distance(this Vector3 vector3, Vector2 toVector2)
		{
			return vector3.ToVector2().Distance(toVector2);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x000199F4 File Offset: 0x00017BF4
		public static float DistanceSquared(this Vector3 vector3, GameObject obj)
		{
			return vector3.ToVector2().DistanceSquared(obj.Position.ToVector2());
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00019A0C File Offset: 0x00017C0C
		public static float DistanceSquared(this Vector3 vector3, Vector2 toVector2)
		{
			return vector3.ToVector2().DistanceSquared(toVector2);
		}

		// Token: 0x06000377 RID: 887 RVA: 0x00019A1A File Offset: 0x00017C1A
		public static float DistanceSquared(this Vector3 vector3, Vector3 toVector3)
		{
			return vector3.ToVector2().DistanceSquared(toVector3);
		}

		// Token: 0x06000378 RID: 888 RVA: 0x00019A28 File Offset: 0x00017C28
		public static float DistanceToCursor(this Vector3 vector3)
		{
			return Game.CursorPos.Distance(vector3);
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00019A35 File Offset: 0x00017C35
		public static float DistanceToPlayer(this Vector3 vector3)
		{
			return GameObjects.Player.Position.Distance(vector3);
		}

		// Token: 0x0600037A RID: 890 RVA: 0x00019A48 File Offset: 0x00017C48
		public static Vector3 Extend(this Vector3 vector3, Vector2 toVector2, float distance)
		{
			Vector3 right = distance * (toVector2.ToVector3(0f).SetZ(new float?(vector3.Z)) - vector3).Normalized();
			return vector3 + right;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00019A8C File Offset: 0x00017C8C
		public static Vector3 Extend(this Vector3 vector3, Vector3 toVector3, float distance)
		{
			Vector3 right = distance * (toVector3 - vector3).Normalized();
			return vector3 + right;
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00019AB3 File Offset: 0x00017CB3
		public static bool InRange(this Vector3 from, Vector2 checkPosition, float range, bool squared = false)
		{
			if (squared)
			{
				return (double)from.DistanceSquared(checkPosition) <= Math.Pow((double)range, 2.0);
			}
			return from.Distance(checkPosition) <= range;
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00019AE3 File Offset: 0x00017CE3
		public static bool InRange(this Vector3 from, Vector3 checkPosition, float range, bool squared = false)
		{
			if (squared)
			{
				return (double)from.DistanceSquared(checkPosition) <= Math.Pow((double)range, 2.0);
			}
			return from.Distance(checkPosition) <= range;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00019B13 File Offset: 0x00017D13
		public static bool InRange<T>(this Vector3 from, T target, float range, bool squared = false) where T : GameObject
		{
			return from.InRange(target.Position.ToVector2(), range, squared);
		}

		// Token: 0x0600037F RID: 895 RVA: 0x00019B30 File Offset: 0x00017D30
		public static float GetPathLength(this List<Vector3> path)
		{
			float num = 0f;
			for (int i = 0; i < path.Count - 1; i++)
			{
				num += path[i].Distance(path[i + 1]);
			}
			return num;
		}

		// Token: 0x06000380 RID: 896 RVA: 0x00019B6F File Offset: 0x00017D6F
		public static bool IsBuilding(this Vector3 vector3)
		{
			return NavMesh.GetCollisionFlags(vector3).HasFlag(CollisionFlags.Building);
		}

		// Token: 0x06000381 RID: 897 RVA: 0x00019B88 File Offset: 0x00017D88
		public static bool IsOnMiniMap(this Vector3 vector3, float radius = 0f)
		{
			Vector2 vector4;
			return Drawing.WorldToMinimap(vector3, out vector4) && vector4.X + radius > Library.GameCache.WindowsValue.MiniMapWidth && vector4.Y + radius > Library.GameCache.WindowsValue.MiniMapHeight;
		}

		// Token: 0x06000382 RID: 898 RVA: 0x00019BD8 File Offset: 0x00017DD8
		public static bool IsOnScreen(this Vector3 vector3, float radius = 0f)
		{
			Vector2 vector4;
			return Drawing.WorldToScreen(vector3, out vector4) && (vector4.X + radius >= 0f && vector4.X - radius <= (float)Library.GameCache.WindowsValue.WindowsWidth && vector4.Y + radius >= 0f) && vector4.Y - radius <= (float)Library.GameCache.WindowsValue.WindowsHeight;
		}

		// Token: 0x06000383 RID: 899 RVA: 0x00019C48 File Offset: 0x00017E48
		public static bool IsOrthogonal(this Vector3 vector3, Vector2 toVector2)
		{
			return vector3.ToVector2().IsOrthogonal(toVector2);
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00019C56 File Offset: 0x00017E56
		public static bool IsOrthogonal(this Vector3 vector3, Vector3 toVector3)
		{
			return vector3.ToVector2().IsOrthogonal(toVector3);
		}

		// Token: 0x06000385 RID: 901 RVA: 0x00019C64 File Offset: 0x00017E64
		public static bool IsUnderAllyTurret(this Vector3 position, float extraRange = 0f)
		{
			return GameObjects.AllyTurrets.Any((AITurretClient turret) => turret != null && turret.IsValid && !turret.IsDead && turret.Health > 1f && turret.Position.Distance(position) < 950f + extraRange);
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00019C9C File Offset: 0x00017E9C
		public static bool IsUnderEnemyTurret(this Vector3 position, float extraRange = 0f)
		{
			return GameObjects.EnemyTurrets.Any((AITurretClient turret) => turret != null && turret.IsValid && !turret.IsDead && turret.Health > 1f && turret.Position.Distance(position) < 950f + extraRange);
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00019CD3 File Offset: 0x00017ED3
		public static bool IsValid(this Vector3 vector3)
		{
			return vector3 != Vector3.Zero;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00019CE0 File Offset: 0x00017EE0
		public static bool IsWall(this Vector3 vector3)
		{
			return NavMesh.GetCollisionFlags(vector3).HasFlag(CollisionFlags.Wall);
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00019CF8 File Offset: 0x00017EF8
		public static float Magnitude(this Vector3 vector3)
		{
			return (float)Math.Sqrt(Math.Pow((double)vector3.X, 2.0) + Math.Pow((double)vector3.Y, 2.0) + Math.Pow((double)vector3.Z, 2.0));
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00019D4C File Offset: 0x00017F4C
		public static Vector3 Normalized(this Vector3 vector3)
		{
			vector3.Normalize();
			return vector3;
		}

		// Token: 0x0600038B RID: 907 RVA: 0x00019D58 File Offset: 0x00017F58
		public static float PathLength(this List<Vector3> path)
		{
			float num = 0f;
			for (int i = 0; i < path.Count - 1; i++)
			{
				num += path[i].Distance(path[i + 1]);
			}
			return num;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00019D98 File Offset: 0x00017F98
		public static float PathLength(this Vector3[] path)
		{
			float num = 0f;
			for (int i = 0; i < path.Length - 1; i++)
			{
				num += path[i].Distance(path[i + 1]);
			}
			return num;
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00019DD4 File Offset: 0x00017FD4
		public static Vector3 Perpendicular(this Vector3 vector3, int offset = 0)
		{
			if (offset != 0)
			{
				return new Vector3(vector3.Y, -vector3.X, vector3.Z);
			}
			return new Vector3(-vector3.Y, vector3.X, vector3.Z);
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00019E0A File Offset: 0x0001800A
		public static float Polar(this Vector3 vector3)
		{
			return vector3.ToVector2().Polar();
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00019E17 File Offset: 0x00018017
		public static ProjectionInfo ProjectOn(this Vector3 point, Vector3 segmentStart, Vector3 segmentEnd)
		{
			return point.ToVector2().ProjectOn(segmentStart.ToVector2(), segmentEnd.ToVector2());
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00019E30 File Offset: 0x00018030
		public static Vector3 Rotated(this Vector3 vector3, float angle)
		{
			double num = Math.Cos((double)angle);
			double num2 = Math.Sin((double)angle);
			return new Vector3((float)((double)vector3.X * num - (double)vector3.Y * num2), (float)((double)vector3.Y * num + (double)vector3.X * num2), vector3.Z);
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00019E80 File Offset: 0x00018080
		public static Vector3 SetZ(this Vector3 v, float? value = null)
		{
			if (value == null)
			{
				v.Z = Game.CursorPos.Z;
			}
			else
			{
				v.Z = value.Value;
			}
			return v;
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00019EAE File Offset: 0x000180AE
		public static Vector2 ToVector2(this Vector3 vector3)
		{
			return new Vector2(vector3.X, vector3.Y);
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00019EC1 File Offset: 0x000180C1
		public static List<Vector2> ToVector2(this List<Vector3> path)
		{
			return (from point in path
			select point.ToVector2()).ToList<Vector2>();
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00019EED File Offset: 0x000180ED
		public static Vector3 ToVector3World(this Vector2 vector2)
		{
			return new Vector3(vector2.X, vector2.Y, NavMesh.GetHeightForPosition(vector2.X, vector2.Y));
		}
	}
}
