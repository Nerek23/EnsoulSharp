using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200023C RID: 572
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nami", SpellSlot.E, 0)]
	public class DamageNamiE : DamageSpell
	{
		// Token: 0x06000CCE RID: 3278 RVA: 0x0003EBD7 File Offset: 0x0003CDD7
		public DamageNamiE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x0003EBED File Offset: 0x0003CDED
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNamiE.damages[level] + 0.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000741 RID: 1857
		private static readonly double[] damages = new double[]
		{
			25.0,
			40.0,
			55.0,
			70.0,
			85.0
		};
	}
}
