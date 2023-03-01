using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002CF RID: 719
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Swain", SpellSlot.W, 0)]
	public class DamageSwainW : DamageSpell
	{
		// Token: 0x06000E86 RID: 3718 RVA: 0x00041C5F File Offset: 0x0003FE5F
		public DamageSwainW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E87 RID: 3719 RVA: 0x00041C75 File Offset: 0x0003FE75
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSwainW.damages[level] + 0.55 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007E6 RID: 2022
		private static readonly double[] damages = new double[]
		{
			80.0,
			115.0,
			150.0,
			185.0,
			220.0
		};
	}
}
