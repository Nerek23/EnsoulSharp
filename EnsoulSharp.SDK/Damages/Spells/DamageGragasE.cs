using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000198 RID: 408
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gragas", SpellSlot.E, 0)]
	public class DamageGragasE : DamageSpell
	{
		// Token: 0x06000AE0 RID: 2784 RVA: 0x0003B704 File Offset: 0x00039904
		public DamageGragasE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x0003B71A File Offset: 0x0003991A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGragasE.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000697 RID: 1687
		private static readonly double[] damages = new double[]
		{
			80.0,
			125.0,
			170.0,
			215.0,
			260.0
		};
	}
}
