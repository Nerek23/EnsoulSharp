using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000118 RID: 280
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Akali", SpellSlot.E, 0)]
	public class DamageAkaliE : DamageSpell
	{
		// Token: 0x06000957 RID: 2391 RVA: 0x00038B87 File Offset: 0x00036D87
		public DamageAkaliE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x00038B9D File Offset: 0x00036D9D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAkaliE.damages[level] + (double)(0.225f * source.TotalAttackDamage) + (double)(0.4f * source.TotalMagicalDamage);
		}

		// Token: 0x040005FF RID: 1535
		private static readonly double[] damages = new double[]
		{
			30.0,
			56.25,
			82.5,
			108.75,
			135.0
		};
	}
}
