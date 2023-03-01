using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000109 RID: 265
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rell", SpellSlot.E, 0)]
	public class DamageRellE : DamageSpell
	{
		// Token: 0x0600092A RID: 2346 RVA: 0x00038668 File Offset: 0x00036868
		public DamageRellE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x0003867E File Offset: 0x0003687E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRellE.damages[level] + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005ED RID: 1517
		private static readonly double[] damages = new double[]
		{
			80.0,
			120.0,
			160.0,
			200.0,
			240.0
		};
	}
}
