using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000145 RID: 325
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Camille", SpellSlot.Q, 2)]
	public class DamageCamilleQ2 : DamageSpell
	{
		// Token: 0x060009DD RID: 2525 RVA: 0x00039AB7 File Offset: 0x00037CB7
		public DamageCamilleQ2()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.True;
			base.Stage = 2;
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x00039AD4 File Offset: 0x00037CD4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCamilleQ2.damages[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000631 RID: 1585
		private static readonly double[] damages = new double[]
		{
			0.4,
			0.5,
			0.6,
			0.7,
			0.8
		};
	}
}
