using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002AC RID: 684
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Shen", SpellSlot.Q, 0)]
	public class DamageShenQ : DamageSpell
	{
		// Token: 0x06000E1D RID: 3613 RVA: 0x00041004 File Offset: 0x0003F204
		public DamageShenQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x0004101C File Offset: 0x0003F21C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageShenQ.damages[Math.Min(17, source.Level - 1)] + (DamageShenQ.damagePercents[level] + 0.015 * (double)source.TotalMagicalDamage / 100.0) * (double)target.MaxHealth;
		}

		// Token: 0x040007BB RID: 1979
		private static readonly double[] damages = new double[]
		{
			10.0,
			10.0,
			10.0,
			16.0,
			16.0,
			16.0,
			22.0,
			22.0,
			22.0,
			28.0,
			28.0,
			28.0,
			34.0,
			34.0,
			34.0,
			40.0,
			40.0,
			40.0
		};

		// Token: 0x040007BC RID: 1980
		private static readonly double[] damagePercents = new double[]
		{
			0.02,
			0.025,
			0.03,
			0.035,
			0.04
		};
	}
}
