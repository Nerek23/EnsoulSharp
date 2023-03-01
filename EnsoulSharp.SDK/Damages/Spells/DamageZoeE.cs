using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200033C RID: 828
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zoe", SpellSlot.E, 0)]
	public class DamageZoeE : DamageSpell
	{
		// Token: 0x06000FCD RID: 4045 RVA: 0x000440E3 File Offset: 0x000422E3
		public DamageZoeE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FCE RID: 4046 RVA: 0x000440F9 File Offset: 0x000422F9
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZoeE.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400085F RID: 2143
		private static readonly double[] damages = new double[]
		{
			70.0,
			110.0,
			150.0,
			190.0,
			230.0
		};
	}
}
