using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002C4 RID: 708
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Taliyah", SpellSlot.E, 0)]
	public class DamageTaliyahE : DamageSpell
	{
		// Token: 0x06000E65 RID: 3685 RVA: 0x0004192B File Offset: 0x0003FB2B
		public DamageTaliyahE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E66 RID: 3686 RVA: 0x00041941 File Offset: 0x0003FB41
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTaliyahE.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007DB RID: 2011
		private static readonly double[] damages = new double[]
		{
			60.0,
			105.0,
			150.0,
			195.0,
			240.0
		};
	}
}
