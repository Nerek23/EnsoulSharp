using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200022B RID: 555
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Maokai", SpellSlot.Q, 0)]
	public class DamageMaokaiQ : DamageSpell
	{
		// Token: 0x06000C9C RID: 3228 RVA: 0x0003E6C5 File Offset: 0x0003C8C5
		public DamageMaokaiQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C9D RID: 3229 RVA: 0x0003E6DB File Offset: 0x0003C8DB
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMaokaiQ.damages[level] + 0.4 * (double)source.TotalMagicalDamage + DamageMaokaiQ.damagePercents[level] * (double)source.MaxHealth;
		}

		// Token: 0x04000730 RID: 1840
		private static readonly double[] damages = new double[]
		{
			70.0,
			120.0,
			170.0,
			220.0,
			270.0
		};

		// Token: 0x04000731 RID: 1841
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
