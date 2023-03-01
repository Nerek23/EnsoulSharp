using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000184 RID: 388
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Fizz", SpellSlot.R, 2)]
	public class DamageFizzR2 : DamageSpell
	{
		// Token: 0x06000AA4 RID: 2724 RVA: 0x0003B078 File Offset: 0x00039278
		public DamageFizzR2()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
			base.Stage = 2;
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x0003B095 File Offset: 0x00039295
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageFizzR2.damages[level] + 1.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400067F RID: 1663
		private static readonly double[] damages = new double[]
		{
			300.0,
			400.0,
			500.0
		};
	}
}
