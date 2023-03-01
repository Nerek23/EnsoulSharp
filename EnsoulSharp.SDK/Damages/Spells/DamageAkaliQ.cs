using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000119 RID: 281
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Akali", SpellSlot.Q, 0)]
	public class DamageAkaliQ : DamageSpell
	{
		// Token: 0x0600095A RID: 2394 RVA: 0x00038BDA File Offset: 0x00036DDA
		public DamageAkaliQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x00038BF0 File Offset: 0x00036DF0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAkaliQ.damages[level] + (double)(0.65f * source.TotalAttackDamage) + (double)(0.6f * source.TotalMagicalDamage);
		}

		// Token: 0x04000600 RID: 1536
		private static readonly double[] damages = new double[]
		{
			30.0,
			55.0,
			80.0,
			105.0,
			130.0
		};
	}
}
