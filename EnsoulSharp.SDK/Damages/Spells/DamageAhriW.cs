using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000116 RID: 278
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ahri", SpellSlot.W, 0)]
	public class DamageAhriW : DamageSpell
	{
		// Token: 0x06000951 RID: 2385 RVA: 0x00038AE4 File Offset: 0x00036CE4
		public DamageAhriW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x00038AFA File Offset: 0x00036CFA
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAhriW.damages[level] + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005FD RID: 1533
		private static readonly double[] damages = new double[]
		{
			50.0,
			75.0,
			100.0,
			125.0,
			150.0
		};
	}
}
