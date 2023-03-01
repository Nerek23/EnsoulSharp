using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200000E RID: 14
	public static class AIBaseClientExtensions
	{
		// Token: 0x06000066 RID: 102 RVA: 0x00004CA6 File Offset: 0x00002EA6
		public static float GetBonusPhysicalDamage(this AIBaseClient source)
		{
			if (source == null || !source.IsValid)
			{
				return 0f;
			}
			if (source.Type == GameObjectType.AIHeroClient)
			{
				return source.TotalAttackDamage - source.BaseAttackDamage;
			}
			return source.FlatPhysicalDamageMod;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00004CDC File Offset: 0x00002EDC
		public static float GetCurrentAutoAttackRange(this AIBaseClient sender, AttackableUnit target)
		{
			if (sender == null || !sender.IsValid)
			{
				return 0f;
			}
			if (sender.Type == GameObjectType.AITurretClient)
			{
				return 900f;
			}
			float num = sender.AttackRange + sender.BoundingRadius;
			AIHeroClient aiheroClient = sender as AIHeroClient;
			if (target != null && target.IsValid)
			{
				if (aiheroClient != null && aiheroClient.IsValidTarget(3.4028235E+38f, false, default(Vector3)))
				{
					if (aiheroClient.CharacterName == "Aphelios")
					{
						AIBaseClient aibaseClient = target as AIBaseClient;
						if (aibaseClient != null && aibaseClient.IsValid() && aibaseClient.HasBuff("aphelioscalibrumbonusrangedebuff") && aiheroClient.HasBuff("aphelioscalibrumbonusrangebuff"))
						{
							num = 1800f;
						}
					}
					if (aiheroClient.CharacterName == "Caitlyn")
					{
						AIBaseClient aibaseClient2 = target as AIBaseClient;
						HashSet<EffectEmitter> source;
						if (aibaseClient2 != null && aibaseClient2.IsValid() && GameObjects.CaitlynHeadshotBeams.TryGetValue(aibaseClient2.NetworkId, out source))
						{
							if (source.Any((EffectEmitter effectEmitter) => effectEmitter.IsValid && !effectEmitter.IsDead))
							{
								num = 1300f;
							}
						}
					}
				}
				num += target.BoundingRadius - Math.Min((float)Game.Ping / 4f, 10f) - 5f;
			}
			return num;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00004E42 File Offset: 0x00003042
		public static float AttackSpeed(this AIBaseClient source)
		{
			return 1f / source.AttackDelay;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00004E50 File Offset: 0x00003050
		public static float GetRealAutoAttackRange(this AIBaseClient sender, AttackableUnit target)
		{
			if (sender == null || !sender.IsValid)
			{
				return 0f;
			}
			if (sender.Type == GameObjectType.AITurretClient)
			{
				return 900f;
			}
			float num = sender.AttackRange + sender.BoundingRadius;
			if (target != null && target.IsValid && !target.IsDead)
			{
				AIHeroClient aiheroClient = sender as AIHeroClient;
				if (aiheroClient != null && aiheroClient.IsValidTarget(3.4028235E+38f, false, default(Vector3)))
				{
					if (aiheroClient.CharacterName == "Aphelios")
					{
						AIBaseClient aibaseClient = target as AIBaseClient;
						if (aibaseClient != null && aibaseClient.IsValid() && aibaseClient.HasBuff("aphelioscalibrumbonusrangedebuff") && aiheroClient.HasBuff("aphelioscalibrumbonusrangebuff"))
						{
							num = 1800f;
						}
					}
					if (aiheroClient.CharacterName == "Caitlyn")
					{
						AIBaseClient aibaseClient2 = target as AIBaseClient;
						if (aibaseClient2 != null && aibaseClient2.IsValid() && (aibaseClient2.HasBuff("CaitlynWSnare") || aibaseClient2.HasBuff("CaitlynEMissile")))
						{
							num = 1300f;
						}
					}
				}
				num += target.BoundingRadius;
			}
			return num;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00004F83 File Offset: 0x00003183
		public static SpellDataInst GetSpell(this AIBaseClient source, SpellSlot slot)
		{
			if (source == null || !source.IsValid)
			{
				return null;
			}
			return source.Spellbook.GetSpell(slot);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00004FA4 File Offset: 0x000031A4
		public static SpellSlot GetSpellSlot(this AIBaseClient source, string name)
		{
			IEnumerable<SpellDataInst> spells = source.Spellbook.Spells;
			Func<SpellDataInst, bool> <>9__0;
			Func<SpellDataInst, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				predicate = (<>9__0 = ((SpellDataInst s) => s.Name.ToLower() == name.ToLower()));
			}
			using (IEnumerator<SpellDataInst> enumerator = spells.Where(predicate).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					return enumerator.Current.Slot;
				}
			}
			return SpellSlot.Unknown;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000502C File Offset: 0x0000322C
		public static bool HaveImmovableBuff(this AIBaseClient source)
		{
			if (source == null || !source.IsValid)
			{
				return false;
			}
			BuffType[] array = new BuffType[11];
			RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.6F05B757E9B71E2E8129477CFF56BCBF83E75DDC).FieldHandle);
			BuffType[] array2 = array;
			string[] array3 = new string[]
			{
				"recall",
				"superrecall",
				"root"
			};
			foreach (BuffType type in array2)
			{
				if (source.HasBuffOfType(type))
				{
					return true;
				}
			}
			string[] array5 = array3;
			for (int i = 0; i < array5.Length; i++)
			{
				string name = array5[i];
				if (source.Buffs.Any((BuffInstance x) => x != null && x.IsValid && x.Name.ToLower() == name))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000050E0 File Offset: 0x000032E0
		public static bool HaveSpellShield(this AIBaseClient source)
		{
			if (source == null || !source.IsValid || source.IsDead || source.Health <= 0f || !source.IsValidTarget(3.4028235E+38f, false, default(Vector3)))
			{
				return false;
			}
			BuffType[] array = new BuffType[]
			{
				BuffType.SpellShield
			};
			string[] array2 = new string[]
			{
				"blackshield",
				"bansheesveil",
				"sivire",
				"nocturneshroudofdarkness",
				"itemmagekillerveil"
			};
			foreach (BuffType type in array)
			{
				if (source.HasBuffOfType(type))
				{
					return true;
				}
			}
			string[] array4 = array2;
			for (int i = 0; i < array4.Length; i++)
			{
				string name = array4[i];
				if (source.Buffs.Any((BuffInstance x) => x.Name.ToLower() == name))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000051D4 File Offset: 0x000033D4
		public static bool InAutoAttackRange(this AIBaseClient source, AttackableUnit target, float extraRange = 0f, bool checkTeam = true)
		{
			if (!target.IsValidTarget(3.4028235E+38f, checkTeam, default(Vector3)))
			{
				return false;
			}
			float num = target.GetRealAutoAttackRange() + extraRange;
			AIBaseClient aibaseClient = target as AIBaseClient;
			return (double)Vector2.DistanceSquared((aibaseClient != null) ? aibaseClient.ServerPosition.ToVector2() : target.Position.ToVector2(), source.ServerPosition.ToVector2()) <= Math.Pow((double)num, 2.0);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000524C File Offset: 0x0000344C
		public static bool InCurrentAutoAttackRange(this AIBaseClient source, AttackableUnit target, float extraRange = 0f, bool checkTeam = true)
		{
			if (!target.IsValidTarget(3.4028235E+38f, checkTeam, default(Vector3)))
			{
				return false;
			}
			float num = target.GetRealAutoAttackRange() + extraRange;
			AIBaseClient aibaseClient = target as AIBaseClient;
			return (double)Vector2.DistanceSquared((aibaseClient != null) ? aibaseClient.ServerPosition.ToVector2() : target.Position.ToVector2(), source.ServerPosition.ToVector2()) <= Math.Pow((double)num, 2.0);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000052C2 File Offset: 0x000034C2
		public static bool IsBothFacing(this AIBaseClient source, AIBaseClient target)
		{
			return source.IsValid() && target.IsValid() && source.IsFacing(target) && target.IsFacing(source);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000052E6 File Offset: 0x000034E6
		public static bool IsFacing(this AIBaseClient source, AIBaseClient target)
		{
			return source.IsValid() && target.IsValid() && source.Direction.AngleBetween(target.Position - source.Position) < 90f;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000531D File Offset: 0x0000351D
		public static bool IsMelee(this AIBaseClient unit)
		{
			return unit != null && unit.IsValid && unit.IsMelee;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00005338 File Offset: 0x00003538
		public static bool IsUnderAllyTurret(this AIBaseClient unit, float extraRange = 0f)
		{
			return unit != null && unit.IsValid && unit.ServerPosition.IsUnderAllyTurret(extraRange);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00005359 File Offset: 0x00003559
		public static bool IsUnderEnemyTurret(this AIBaseClient unit, float extraRange = 0f)
		{
			return unit != null && unit.IsValid && unit.ServerPosition.IsUnderEnemyTurret(extraRange);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000537A File Offset: 0x0000357A
		public static bool IsValid(this AIBaseClient unit)
		{
			return unit != null && unit.IsValid;
		}
	}
}
