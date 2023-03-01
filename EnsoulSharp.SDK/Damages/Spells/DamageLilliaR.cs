using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200020C RID: 524
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lillia", SpellSlot.R, 0)]
	public class DamageLilliaR : DamageSpell
	{
		// Token: 0x06000C3F RID: 3135 RVA: 0x0003DD36 File Offset: 0x0003BF36
		public DamageLilliaR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x0003DD4C File Offset: 0x0003BF4C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLilliaR.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000710 RID: 1808
		private static readonly double[] damages = new double[]
		{
			100.0,
			150.0,
			200.0
		};
	}
}
