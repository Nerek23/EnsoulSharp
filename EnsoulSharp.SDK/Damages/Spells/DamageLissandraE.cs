using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000217 RID: 535
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lissandra", SpellSlot.E, 0)]
	public class DamageLissandraE : DamageSpell
	{
		// Token: 0x06000C60 RID: 3168 RVA: 0x0003E085 File Offset: 0x0003C285
		public DamageLissandraE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C61 RID: 3169 RVA: 0x0003E09B File Offset: 0x0003C29B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLissandraE.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400071B RID: 1819
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
