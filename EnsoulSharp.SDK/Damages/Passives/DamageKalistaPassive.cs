using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200039E RID: 926
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Kalista")]
	public class DamageKalistaPassive : IPassiveDamage
	{
		// Token: 0x060011BE RID: 4542 RVA: 0x000471C8 File Offset: 0x000453C8
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (target.HasBuff("kalistacoopstrikemarkally"))
			{
				BuffInstance buff = target.GetBuff("kalistacoopstrikemarkally");
				if (buff.Caster != null && buff.Caster.Compare(source))
				{
					SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
					if (spell != null && spell.Level > 0)
					{
						if (target.Type == GameObjectType.AIMinionClient && target.Health < 125f)
						{
							return (double)target.Health;
						}
						return DamageKalistaPassive.damages[Math.Min(spell.Level - 1, 4)] * (double)target.MaxHealth;
					}
				}
			}
			return 0.0;
		}

		// Token: 0x060011BF RID: 4543 RVA: 0x00047267 File Offset: 0x00045467
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HasBuff("kalistacoopstrikemarkally");
		}

		// Token: 0x060011C0 RID: 4544 RVA: 0x00047274 File Offset: 0x00045474
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060011C1 RID: 4545 RVA: 0x00047277 File Offset: 0x00045477
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008A8 RID: 2216
		private static readonly double[] damages = new double[]
		{
			0.14,
			0.15,
			0.16,
			0.17,
			0.18
		};
	}
}
