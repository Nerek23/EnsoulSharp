using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002C6 RID: 710
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Taliyah", SpellSlot.Q, 0)]
	public class DamageTaliyahQ : DamageSpell
	{
		// Token: 0x06000E6B RID: 3691 RVA: 0x000419C4 File Offset: 0x0003FBC4
		public DamageTaliyahQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E6C RID: 3692 RVA: 0x000419DA File Offset: 0x0003FBDA
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTaliyahQ.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007DD RID: 2013
		private static readonly double[] damages = new double[]
		{
			45.0,
			65.0,
			85.0,
			105.0,
			125.0
		};
	}
}
