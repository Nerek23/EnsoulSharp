using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000161 RID: 353
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Diana", SpellSlot.Q, 0)]
	public class DamageDianaQ : DamageSpell
	{
		// Token: 0x06000A3B RID: 2619 RVA: 0x0003A464 File Offset: 0x00038664
		public DamageDianaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x0003A47A File Offset: 0x0003867A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageDianaQ.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000655 RID: 1621
		private static readonly double[] damages = new double[]
		{
			60.0,
			95.0,
			130.0,
			165.0,
			200.0
		};
	}
}
