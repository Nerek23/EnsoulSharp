using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200023E RID: 574
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nami", SpellSlot.R, 0)]
	public class DamageNamiR : DamageSpell
	{
		// Token: 0x06000CD4 RID: 3284 RVA: 0x0003EC69 File Offset: 0x0003CE69
		public DamageNamiR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x0003EC7F File Offset: 0x0003CE7F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNamiR.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000743 RID: 1859
		private static readonly double[] damages = new double[]
		{
			150.0,
			250.0,
			350.0
		};
	}
}
