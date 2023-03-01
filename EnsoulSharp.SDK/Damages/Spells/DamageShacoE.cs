using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002A7 RID: 679
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Shaco", SpellSlot.E, 0)]
	public class DamageShacoE : DamageSpell
	{
		// Token: 0x06000E0E RID: 3598 RVA: 0x00040E73 File Offset: 0x0003F073
		public DamageShacoE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E0F RID: 3599 RVA: 0x00040E89 File Offset: 0x0003F089
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageShacoE.damages[level] + 0.75 * (double)source.GetBonusPhysicalDamage() + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007B6 RID: 1974
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
