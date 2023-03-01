using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200013D RID: 317
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Blitzcrank", SpellSlot.R, 0)]
	public class DamageBlitzcrankR : DamageSpell
	{
		// Token: 0x060009C5 RID: 2501 RVA: 0x0003986F File Offset: 0x00037A6F
		public DamageBlitzcrankR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x00039885 File Offset: 0x00037A85
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageBlitzcrankR.damages[level] + 1.25 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000629 RID: 1577
		private static readonly double[] damages = new double[]
		{
			275.0,
			400.0,
			525.0
		};
	}
}
