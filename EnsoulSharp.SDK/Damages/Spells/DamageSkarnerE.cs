using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002BB RID: 699
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Skarner", SpellSlot.E, 0)]
	public class DamageSkarnerE : DamageSpell
	{
		// Token: 0x06000E4A RID: 3658 RVA: 0x0004161E File Offset: 0x0003F81E
		public DamageSkarnerE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E4B RID: 3659 RVA: 0x00041634 File Offset: 0x0003F834
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSkarnerE.damages[level] + 0.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007D2 RID: 2002
		private static readonly double[] damages = new double[]
		{
			40.0,
			65.0,
			90.0,
			115.0,
			140.0
		};
	}
}
