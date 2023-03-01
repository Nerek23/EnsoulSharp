using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200029F RID: 671
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ryze", SpellSlot.E, 0)]
	public class DamageRyzeE : DamageSpell
	{
		// Token: 0x06000DF6 RID: 3574 RVA: 0x00040BCE File Offset: 0x0003EDCE
		public DamageRyzeE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000DF7 RID: 3575 RVA: 0x00040BE4 File Offset: 0x0003EDE4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRyzeE.damages[level] + 0.3 * (double)source.TotalMagicalDamage + 0.02 * (double)source.BonusMana;
		}

		// Token: 0x040007AE RID: 1966
		private static readonly double[] damages = new double[]
		{
			60.0,
			80.0,
			100.0,
			120.0,
			140.0
		};
	}
}
