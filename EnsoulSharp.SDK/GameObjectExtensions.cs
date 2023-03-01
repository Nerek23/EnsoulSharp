using System;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000033 RID: 51
	public static class GameObjectExtensions
	{
		// Token: 0x06000272 RID: 626 RVA: 0x00010330 File Offset: 0x0000E530
		public static bool Compare(this GameObject source, GameObject target)
		{
			if (source == null || !source.IsValid)
			{
				return false;
			}
			if (target == null || !target.IsValid)
			{
				return false;
			}
			if (source.Type == GameObjectType.EffectEmitter && target.Type == GameObjectType.EffectEmitter && source.NetworkId == 0 && target.NetworkId == 0)
			{
				return source.Index == target.Index;
			}
			return source.NetworkId == target.NetworkId;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x000103A4 File Offset: 0x0000E5A4
		public static int CountAllyHeroesInRange(this GameObject source, float range, AIBaseClient originalUnit = null)
		{
			if (source != null && source.IsValid && source.Position.IsValid())
			{
				return source.Position.CountAllyHeroesInRange(range, originalUnit);
			}
			return 0;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x000103D3 File Offset: 0x0000E5D3
		public static int CountEnemyHeroesInRange(this GameObject source, float range, AIBaseClient originalUnit = null)
		{
			if (source != null && source.IsValid && source.Position.IsValid())
			{
				return source.Position.CountEnemyHeroesInRange(range, originalUnit);
			}
			return 0;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00010402 File Offset: 0x0000E602
		public static float Distance(this GameObject source, Vector2 vector2)
		{
			return source.Position.Distance(vector2);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00010410 File Offset: 0x0000E610
		public static float Distance(this GameObject source, Vector3 vector3)
		{
			return source.Position.Distance(vector3);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0001041E File Offset: 0x0000E61E
		public static float Distance(this GameObject source, GameObject target)
		{
			return source.Position.Distance(target.Position);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00010431 File Offset: 0x0000E631
		public static float DistanceSquared(this GameObject source, GameObject target)
		{
			return source.DistanceSquared(target.Position);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0001043F File Offset: 0x0000E63F
		public static float DistanceSquared(this GameObject source, Vector2 position)
		{
			return source.Position.DistanceSquared(position);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0001044D File Offset: 0x0000E64D
		public static float DistanceSquared(this GameObject source, Vector3 position)
		{
			return source.DistanceSquared(position.ToVector2());
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0001045B File Offset: 0x0000E65B
		public static float DistanceToPlayer(this GameObject source)
		{
			return GameObjects.Player.Distance(source);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00010468 File Offset: 0x0000E668
		public static float DistanceToCursor(this GameObject source)
		{
			return source.Position.Distance(Game.CursorPos);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0001047C File Offset: 0x0000E67C
		public static bool InRange<T, T1>(this T unit, T1 target, float range, bool squared = false) where T : GameObject where T1 : GameObject
		{
			if (squared)
			{
				return (double)unit.DistanceSquared(target) <= Math.Pow((double)range, 2.0);
			}
			return unit.Distance(target) <= range;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x000104CB File Offset: 0x0000E6CB
		public static bool InRange(this GameObject target, float range, bool squared = false)
		{
			return GameObjects.Player.InRange(target, range, squared);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x000104DA File Offset: 0x0000E6DA
		public static bool InRange<T>(this T from, Vector2 to, float range, bool squared = false) where T : GameObject
		{
			return to.InRange(from.Position.ToVector2(), range, squared);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x000104F4 File Offset: 0x0000E6F4
		public static bool InRange<T>(this T from, Vector3 to, float range, bool squared = false) where T : GameObject
		{
			return to.InRange(from.Position.ToVector2(), range, squared);
		}
	}
}
