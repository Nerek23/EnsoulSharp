using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200023D RID: 573
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nami", SpellSlot.Q, 0)]
	public class DamageNamiQ : DamageSpell
	{
		// Token: 0x06000CD1 RID: 3281 RVA: 0x0003EC20 File Offset: 0x0003CE20
		public DamageNamiQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x0003EC36 File Offset: 0x0003CE36
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNamiQ.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000742 RID: 1858
		private static readonly double[] damages = new double[]
		{
			75.0,
			130.0,
			185.0,
			240.0,
			295.0
		};
	}
}
