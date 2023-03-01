using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003C9 RID: 969
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Viktor")]
	public class DamageViktorPassive : IPassiveDamage
	{
		// Token: 0x060012B1 RID: 4785 RVA: 0x00048C0C File Offset: 0x00046E0C
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return DamageViktorPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.55 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x060012B2 RID: 4786 RVA: 0x00048C62 File Offset: 0x00046E62
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("ViktorPowerTransferReturn");
		}

		// Token: 0x060012B3 RID: 4787 RVA: 0x00048C6F File Offset: 0x00046E6F
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060012B4 RID: 4788 RVA: 0x00048C72 File Offset: 0x00046E72
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008CF RID: 2255
		private static readonly double[] damages = new double[]
		{
			20.0,
			45.0,
			70.0,
			95.0,
			120.0
		};
	}
}
