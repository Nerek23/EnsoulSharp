using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000185 RID: 389
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Fizz", SpellSlot.R, 1)]
	public class DamageFizzR1 : DamageSpell
	{
		// Token: 0x06000AA7 RID: 2727 RVA: 0x0003B0C8 File Offset: 0x000392C8
		public DamageFizzR1()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x0003B0E5 File Offset: 0x000392E5
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageFizzR1.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x04000680 RID: 1664
		private static readonly double[] damages = new double[]
		{
			225.0,
			325.0,
			425.0
		};
	}
}
