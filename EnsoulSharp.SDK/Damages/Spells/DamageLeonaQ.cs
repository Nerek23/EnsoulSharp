using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000214 RID: 532
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Leona", SpellSlot.Q, 0)]
	public class DamageLeonaQ : DamageSpell
	{
		// Token: 0x06000C57 RID: 3159 RVA: 0x0003DFAA File Offset: 0x0003C1AA
		public DamageLeonaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x0003DFC0 File Offset: 0x0003C1C0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLeonaQ.damages[level] + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000718 RID: 1816
		private static readonly double[] damages = new double[]
		{
			10.0,
			35.0,
			60.0,
			85.0,
			110.0
		};
	}
}
