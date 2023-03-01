using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200032D RID: 813
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Xerath", SpellSlot.Q, 0)]
	public class DamageXerathQ : DamageSpell
	{
		// Token: 0x06000FA0 RID: 4000 RVA: 0x00043BF6 File Offset: 0x00041DF6
		public DamageXerathQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FA1 RID: 4001 RVA: 0x00043C0C File Offset: 0x00041E0C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageXerathQ.damages[level] + 0.85 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400084F RID: 2127
		private static readonly double[] damages = new double[]
		{
			70.0,
			110.0,
			150.0,
			190.0,
			230.0
		};
	}
}
