using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000152 RID: 338
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Chogath", SpellSlot.E, 0)]
	public class DamageChogathE : DamageSpell
	{
		// Token: 0x06000A04 RID: 2564 RVA: 0x00039ED2 File Offset: 0x000380D2
		public DamageChogathE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x00039EE8 File Offset: 0x000380E8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageChogathE.damages[level] + 0.3 * (double)source.TotalMagicalDamage + ((double)source.GetBuffCount("Feast") * 0.005 + 0.03) * (double)target.MaxHealth;
		}

		// Token: 0x04000640 RID: 1600
		private static readonly double[] damages = new double[]
		{
			22.0,
			34.0,
			46.0,
			58.0,
			70.0
		};
	}
}
