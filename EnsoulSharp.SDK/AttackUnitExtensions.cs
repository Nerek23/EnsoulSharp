using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000010 RID: 16
	public static class AttackUnitExtensions
	{
		// Token: 0x06000083 RID: 131 RVA: 0x00005CD9 File Offset: 0x00003ED9
		public static float GetCurrentAutoAttackRange(this AttackableUnit target)
		{
			return GameObjects.Player.GetCurrentAutoAttackRange(target.Compare(GameObjects.Player) ? null : target);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00005CF6 File Offset: 0x00003EF6
		public static float GetRealAutoAttackRange(this AttackableUnit target)
		{
			return GameObjects.Player.GetRealAutoAttackRange(target.Compare(GameObjects.Player) ? null : target);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00005D14 File Offset: 0x00003F14
		public static bool InAutoAttackRange(this AttackableUnit target, float extraRange = 0f, bool checkTeam = true)
		{
			if (!target.IsValidTarget(3.4028235E+38f, checkTeam, default(Vector3)))
			{
				return false;
			}
			if (GameObjects.Player.CharacterName == "Azir" && (target.Type == GameObjectType.AIMinionClient || target.Type == GameObjectType.AIHeroClient))
			{
				IEnumerable<EffectEmitter> azirSoldiers = GameObjects.AzirSoldiers;
				if (azirSoldiers.Any<EffectEmitter>() && azirSoldiers.Any((EffectEmitter x) => x != null && !x.IsDead && (double)x.DistanceSquared(GameObjects.Player.ServerPosition) <= Math.Pow(770.0, 2.0) && (double)target.DistanceSquared(x) <= Math.Pow(350.0, 2.0)))
				{
					return true;
				}
			}
			float num = target.GetRealAutoAttackRange() + extraRange;
			AIBaseClient aibaseClient = target as AIBaseClient;
			return (double)Vector2.DistanceSquared((aibaseClient != null) ? aibaseClient.ServerPosition.ToVector2() : target.Position.ToVector2(), GameObjects.Player.ServerPosition.ToVector2()) <= Math.Pow((double)num, 2.0);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00005E08 File Offset: 0x00004008
		public static bool InCurrentAutoAttackRange(this AttackableUnit target, float extraRange = 0f, bool checkTeam = true)
		{
			if (!target.IsValidTarget(3.4028235E+38f, checkTeam, default(Vector3)))
			{
				return false;
			}
			if (GameObjects.Player.CharacterName == "Azir" && (target.Type == GameObjectType.AIMinionClient || target.Type == GameObjectType.AIHeroClient))
			{
				IEnumerable<EffectEmitter> azirSoldiers = GameObjects.AzirSoldiers;
				if (azirSoldiers.Any<EffectEmitter>() && azirSoldiers.Any((EffectEmitter x) => x != null && !x.IsDead && (double)x.DistanceSquared(GameObjects.Player.ServerPosition) <= Math.Pow(770.0, 2.0) && (double)target.DistanceSquared(x) <= Math.Pow(350.0, 2.0)))
				{
					return true;
				}
			}
			float num = target.GetCurrentAutoAttackRange() + extraRange;
			AIBaseClient aibaseClient = target as AIBaseClient;
			return (double)Vector2.DistanceSquared((aibaseClient != null) ? aibaseClient.ServerPosition.ToVector2() : target.Position.ToVector2(), GameObjects.Player.ServerPosition.ToVector2()) <= Math.Pow((double)num, 2.0);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00005EFC File Offset: 0x000040FC
		public static bool IsValidTarget(this AttackableUnit target, float range = 3.4028235E+38f, bool checkTeam = true, Vector3 rangeCheckFrom = default(Vector3))
		{
			if (target == null || !target.IsValid || target.IsDead || target.IsInvulnerable || !target.IsVisible || !target.IsTargetable)
			{
				return false;
			}
			if (checkTeam && target.Team == GameObjects.Player.Team)
			{
				return false;
			}
			if (!target.IsTargetableToTeam(checkTeam ? GameObjects.Player.Team : target.Team))
			{
				return false;
			}
			Vector3 toVector = (rangeCheckFrom != Vector3.Zero) ? rangeCheckFrom : GameObjects.Player.ServerPosition;
			AIBaseClient aibaseClient = target as AIBaseClient;
			if (aibaseClient != null)
			{
				return (!aibaseClient.ServerPosition.IsOnScreen(0f) || aibaseClient.IsHPBarRendered) && (double)aibaseClient.ServerPosition.DistanceSquared(toVector) < Math.Pow((double)range, 2.0);
			}
			return (double)target.Position.DistanceSquared(toVector) < Math.Pow((double)range, 2.0);
		}
	}
}
