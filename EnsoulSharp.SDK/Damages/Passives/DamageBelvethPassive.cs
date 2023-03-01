using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000358 RID: 856
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Belveth")]
	public class DamageBelvethPassive : IPassiveDamage
	{
		// Token: 0x06001037 RID: 4151 RVA: 0x00044A2C File Offset: 0x00042C2C
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			int buffCount = target.GetBuffCount("BelvethRPassive");
			if (buffCount <= 0)
			{
				return 0.0;
			}
			int num = source.Spellbook.GetSpell(SpellSlot.R).Level - 1;
			double num2 = DamageBelvethPassive.damages[num];
			if (target.Type == GameObjectType.AIMinionClient && target.IsJungle())
			{
				num2 *= (double)Math.Min(10, buffCount);
				return Math.Min(num2, DamageBelvethPassive.maxmobdamages[num]);
			}
			return num2 * (double)buffCount;
		}

		// Token: 0x06001038 RID: 4152 RVA: 0x00044A9E File Offset: 0x00042C9E
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HasBuff("BelvethRPassive");
		}

		// Token: 0x06001039 RID: 4153 RVA: 0x00044AAB File Offset: 0x00042CAB
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x00044AAE File Offset: 0x00042CAE
		public DamageType GetDamageType()
		{
			return DamageType.True;
		}

		// Token: 0x04000875 RID: 2165
		private static readonly double[] damages = new double[]
		{
			4.5,
			6.0,
			7.5
		};

		// Token: 0x04000876 RID: 2166
		private static readonly double[] maxmobdamages = new double[]
		{
			45.0,
			60.0,
			75.0
		};
	}
}
