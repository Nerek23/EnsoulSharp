using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002B4 RID: 692
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Singed", SpellSlot.Q, 0)]
	public class DamageSingedQ : DamageSpell
	{
		// Token: 0x06000E35 RID: 3637 RVA: 0x000413A4 File Offset: 0x0003F5A4
		public DamageSingedQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E36 RID: 3638 RVA: 0x000413BA File Offset: 0x0003F5BA
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSingedQ.damages[level] + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007C7 RID: 1991
		private static readonly double[] damages = new double[]
		{
			40.0,
			60.0,
			80.0,
			100.0,
			120.0
		};
	}
}
