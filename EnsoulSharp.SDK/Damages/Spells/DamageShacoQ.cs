using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002A8 RID: 680
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Shaco", SpellSlot.Q, 0)]
	public class DamageShacoQ : DamageSpell
	{
		// Token: 0x06000E11 RID: 3601 RVA: 0x00040ECE File Offset: 0x0003F0CE
		public DamageShacoQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000E12 RID: 3602 RVA: 0x00040EE4 File Offset: 0x0003F0E4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageShacoQ.damages[level] + 0.5 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040007B7 RID: 1975
		private static readonly double[] damages = new double[]
		{
			25.0,
			35.0,
			45.0,
			55.0,
			65.0
		};
	}
}
