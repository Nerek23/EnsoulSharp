using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000126 RID: 294
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Anivia", SpellSlot.Q, 0)]
	public class DamageAniviaQ : DamageSpell
	{
		// Token: 0x06000981 RID: 2433 RVA: 0x00039049 File Offset: 0x00037249
		public DamageAniviaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x0003905F File Offset: 0x0003725F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAniviaQ.damages[level] + 0.25 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400060E RID: 1550
		private static readonly double[] damages = new double[]
		{
			50.0,
			70.0,
			90.0,
			110.0,
			130.0
		};
	}
}
