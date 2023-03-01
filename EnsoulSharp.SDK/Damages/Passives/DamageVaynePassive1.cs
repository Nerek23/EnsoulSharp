using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003C8 RID: 968
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Vayne")]
	public class DamageVaynePassive1 : IPassiveDamage
	{
		// Token: 0x060012AB RID: 4779 RVA: 0x00048B30 File Offset: 0x00046D30
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				double val = DamageVaynePassive1.damages[Math.Min(spell.Level - 1, 4)];
				double num = Math.Max(DamageVaynePassive1.damagePercents[Math.Min(spell.Level - 1, 4)] * (double)target.MaxHealth, val);
				if (target.Type == GameObjectType.AIMinionClient && target.Team == GameObjectTeam.Neutral)
				{
					num = Math.Min(200.0, num);
				}
				return num;
			}
			return 0.0;
		}

		// Token: 0x060012AC RID: 4780 RVA: 0x00048BBF File Offset: 0x00046DBF
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.GetBuffCount("vaynesilvereddebuff") == 2;
		}

		// Token: 0x060012AD RID: 4781 RVA: 0x00048BCF File Offset: 0x00046DCF
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060012AE RID: 4782 RVA: 0x00048BD2 File Offset: 0x00046DD2
		public DamageType GetDamageType()
		{
			return DamageType.True;
		}

		// Token: 0x040008CD RID: 2253
		private static readonly double[] damages = new double[]
		{
			50.0,
			65.0,
			80.0,
			95.0,
			110.0
		};

		// Token: 0x040008CE RID: 2254
		private static readonly double[] damagePercents = new double[]
		{
			0.04,
			0.065,
			0.09,
			0.15,
			0.14
		};
	}
}
