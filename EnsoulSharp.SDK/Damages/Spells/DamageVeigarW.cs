using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200030D RID: 781
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Veigar", SpellSlot.W, 0)]
	public class DamageVeigarW : DamageSpell
	{
		// Token: 0x06000F40 RID: 3904 RVA: 0x000431BE File Offset: 0x000413BE
		public DamageVeigarW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F41 RID: 3905 RVA: 0x000431D4 File Offset: 0x000413D4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVeigarW.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x0400082C RID: 2092
		private static readonly double[] damages = new double[]
		{
			100.0,
			150.0,
			200.0,
			250.0,
			300.0
		};
	}
}
