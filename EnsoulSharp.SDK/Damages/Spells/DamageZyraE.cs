using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200034B RID: 843
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zyra", SpellSlot.E, 0)]
	public class DamageZyraE : DamageSpell
	{
		// Token: 0x06000FF9 RID: 4089 RVA: 0x00044573 File Offset: 0x00042773
		public DamageZyraE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FFA RID: 4090 RVA: 0x00044589 File Offset: 0x00042789
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZyraE.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400086F RID: 2159
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
