using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002C1 RID: 705
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Soraka", SpellSlot.E, 0)]
	public class DamageSorakaE : DamageSpell
	{
		// Token: 0x06000E5C RID: 3676 RVA: 0x0004180F File Offset: 0x0003FA0F
		public DamageSorakaE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E5D RID: 3677 RVA: 0x00041825 File Offset: 0x0003FA25
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSorakaE.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007D8 RID: 2008
		private static readonly double[] damages = new double[]
		{
			70.0,
			95.0,
			120.0,
			145.0,
			170.0
		};
	}
}
