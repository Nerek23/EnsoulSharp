using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200032E RID: 814
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Xerath", SpellSlot.R, 0)]
	public class DamageXerathR : DamageSpell
	{
		// Token: 0x06000FA3 RID: 4003 RVA: 0x00043C3F File Offset: 0x00041E3F
		public DamageXerathR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FA4 RID: 4004 RVA: 0x00043C55 File Offset: 0x00041E55
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageXerathR.damages[level] + 0.45 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000850 RID: 2128
		private static readonly double[] damages = new double[]
		{
			200.0,
			250.0,
			300.0
		};
	}
}
