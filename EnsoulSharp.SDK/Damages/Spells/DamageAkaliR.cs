using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200011B RID: 283
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Akali", SpellSlot.R, 0)]
	public class DamageAkaliR : DamageSpell
	{
		// Token: 0x06000960 RID: 2400 RVA: 0x00038CC7 File Offset: 0x00036EC7
		public DamageAkaliR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x00038CDD File Offset: 0x00036EDD
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAkaliR.damages[level] + 0.5 * (double)source.GetBonusAaDamage() + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000602 RID: 1538
		private static readonly double[] damages = new double[]
		{
			80.0,
			220.0,
			360.0
		};
	}
}
