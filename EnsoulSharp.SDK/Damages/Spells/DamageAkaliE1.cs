using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000117 RID: 279
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Akali", SpellSlot.E, 1)]
	public class DamageAkaliE1 : DamageSpell
	{
		// Token: 0x06000954 RID: 2388 RVA: 0x00038B2D File Offset: 0x00036D2D
		public DamageAkaliE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x00038B4A File Offset: 0x00036D4A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAkaliE1.damages[level] + (double)(0.595f * source.TotalAttackDamage) + (double)(0.84f * source.TotalMagicalDamage);
		}

		// Token: 0x040005FE RID: 1534
		private static readonly double[] damages = new double[]
		{
			70.0,
			131.25,
			192.25,
			253.75,
			315.0
		};
	}
}
