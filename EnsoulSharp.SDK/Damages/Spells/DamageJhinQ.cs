using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001C2 RID: 450
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jhin", SpellSlot.Q, 0)]
	public class DamageJhinQ : DamageSpell
	{
		// Token: 0x06000B64 RID: 2916 RVA: 0x0003C3C5 File Offset: 0x0003A5C5
		public DamageJhinQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x0003C3DB File Offset: 0x0003A5DB
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJhinQ.damages[level] + DamageJhinQ.damagePercents[level] * (double)source.GetBonusPhysicalDamage() + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006C0 RID: 1728
		private static readonly double[] damages = new double[]
		{
			45.0,
			70.0,
			95.0,
			120.0,
			145.0
		};

		// Token: 0x040006C1 RID: 1729
		private static readonly double[] damagePercents = new double[]
		{
			0.35,
			0.425,
			0.5,
			0.575,
			0.65
		};
	}
}
