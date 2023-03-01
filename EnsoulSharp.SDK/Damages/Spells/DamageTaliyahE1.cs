using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002C7 RID: 711
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Taliyah", SpellSlot.E, 1)]
	public class DamageTaliyahE1 : DamageSpell
	{
		// Token: 0x06000E6E RID: 3694 RVA: 0x00041A0D File Offset: 0x0003FC0D
		public DamageTaliyahE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000E6F RID: 3695 RVA: 0x00041A2A File Offset: 0x0003FC2A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTaliyahE1.damages[level] + 0.75 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007DE RID: 2014
		private static readonly double[] damages = new double[]
		{
			62.5,
			112.5,
			162.5,
			212.5,
			262.5
		};
	}
}
