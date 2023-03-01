using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200013E RID: 318
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Brand", SpellSlot.E, 0)]
	public class DamageBrandE : DamageSpell
	{
		// Token: 0x060009C8 RID: 2504 RVA: 0x000398B8 File Offset: 0x00037AB8
		public DamageBrandE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x000398CE File Offset: 0x00037ACE
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageBrandE.damages[level] + 0.45 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400062A RID: 1578
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
