using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200021A RID: 538
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lissandra", SpellSlot.W, 0)]
	public class DamageLissandraW : DamageSpell
	{
		// Token: 0x06000C69 RID: 3177 RVA: 0x0003E160 File Offset: 0x0003C360
		public DamageLissandraW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C6A RID: 3178 RVA: 0x0003E176 File Offset: 0x0003C376
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLissandraW.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400071E RID: 1822
		private static readonly double[] damages = new double[]
		{
			70.0,
			105.0,
			140.0,
			175.0,
			210.0
		};
	}
}
