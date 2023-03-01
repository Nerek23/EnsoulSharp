using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002E0 RID: 736
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Seraphine", SpellSlot.R, 0)]
	public class DamageSeraphineR : DamageSpell
	{
		// Token: 0x06000EB9 RID: 3769 RVA: 0x000422B1 File Offset: 0x000404B1
		public DamageSeraphineR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000EBA RID: 3770 RVA: 0x000422C7 File Offset: 0x000404C7
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSeraphineR.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007F8 RID: 2040
		private static readonly double[] damages = new double[]
		{
			150.0,
			200.0,
			250.0
		};
	}
}
