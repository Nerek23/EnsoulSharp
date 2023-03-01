using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000189 RID: 393
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Galio", SpellSlot.W, 0)]
	public class DamageGalioW : DamageSpell
	{
		// Token: 0x06000AB3 RID: 2739 RVA: 0x0003B1EF File Offset: 0x000393EF
		public DamageGalioW()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x0003B205 File Offset: 0x00039405
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGalioW.damages[level] + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000684 RID: 1668
		private static readonly double[] damages = new double[]
		{
			20.0,
			35.0,
			50.0,
			65.0,
			80.0
		};
	}
}
