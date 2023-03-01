using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200024B RID: 587
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nidalee", SpellSlot.W, 0)]
	public class DamageNidaleeW : DamageSpell
	{
		// Token: 0x06000CFB RID: 3323 RVA: 0x0003F0DD File Offset: 0x0003D2DD
		public DamageNidaleeW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CFC RID: 3324 RVA: 0x0003F0F3 File Offset: 0x0003D2F3
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNidaleeW.damages[level] + 0.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000751 RID: 1873
		private static readonly double[] damages = new double[]
		{
			40.0,
			80.0,
			120.0,
			160.0,
			200.0
		};
	}
}
