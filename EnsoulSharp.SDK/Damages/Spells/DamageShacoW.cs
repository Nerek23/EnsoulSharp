using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002AA RID: 682
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Shaco", SpellSlot.W, 0)]
	public class DamageShacoW : DamageSpell
	{
		// Token: 0x06000E17 RID: 3607 RVA: 0x00040F60 File Offset: 0x0003F160
		public DamageShacoW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E18 RID: 3608 RVA: 0x00040F76 File Offset: 0x0003F176
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageShacoW.damages[level] + 0.8 * (double)source.GetBonusPhysicalDamage() + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007B9 RID: 1977
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
