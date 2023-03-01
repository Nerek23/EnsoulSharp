using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200023B RID: 571
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Morgana", SpellSlot.W, 0)]
	public class DamageMorganaW : DamageSpell
	{
		// Token: 0x06000CCB RID: 3275 RVA: 0x0003EB8E File Offset: 0x0003CD8E
		public DamageMorganaW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x0003EBA4 File Offset: 0x0003CDA4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMorganaW.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000740 RID: 1856
		private static readonly double[] damages = new double[]
		{
			60.0,
			110.0,
			170.0,
			230.0,
			290.0
		};
	}
}
