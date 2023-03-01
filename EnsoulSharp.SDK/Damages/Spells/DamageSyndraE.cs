using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002D0 RID: 720
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Syndra", SpellSlot.E, 0)]
	public class DamageSyndraE : DamageSpell
	{
		// Token: 0x06000E89 RID: 3721 RVA: 0x00041CA8 File Offset: 0x0003FEA8
		public DamageSyndraE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E8A RID: 3722 RVA: 0x00041CBE File Offset: 0x0003FEBE
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSyndraE.damages[level] + 0.45 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007E7 RID: 2023
		private static readonly double[] damages = new double[]
		{
			75.0,
			115.0,
			155.0,
			195.0,
			235.0
		};
	}
}
