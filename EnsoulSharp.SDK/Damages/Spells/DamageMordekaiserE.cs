using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000237 RID: 567
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Mordekaiser", SpellSlot.E, 0)]
	public class DamageMordekaiserE : DamageSpell
	{
		// Token: 0x06000CBF RID: 3263 RVA: 0x0003EA6A File Offset: 0x0003CC6A
		public DamageMordekaiserE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x0003EA80 File Offset: 0x0003CC80
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMordekaiserE.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400073C RID: 1852
		private static readonly double[] damages = new double[]
		{
			80.0,
			95.0,
			110.0,
			125.0,
			140.0
		};
	}
}
