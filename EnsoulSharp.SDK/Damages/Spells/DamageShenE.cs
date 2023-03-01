using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002AB RID: 683
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Shen", SpellSlot.E, 0)]
	public class DamageShenE : DamageSpell
	{
		// Token: 0x06000E1A RID: 3610 RVA: 0x00040FBB File Offset: 0x0003F1BB
		public DamageShenE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x00040FD1 File Offset: 0x0003F1D1
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageShenE.damages[level] + 0.15 * (double)source.BonusHealth;
		}

		// Token: 0x040007BA RID: 1978
		private static readonly double[] damages = new double[]
		{
			60.0,
			85.0,
			110.0,
			135.0,
			160.0
		};
	}
}
