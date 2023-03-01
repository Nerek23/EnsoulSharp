using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002AD RID: 685
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Shen", SpellSlot.Q, 1)]
	public class DamageShenQ1 : DamageSpell
	{
		// Token: 0x06000E20 RID: 3616 RVA: 0x00041099 File Offset: 0x0003F299
		public DamageShenQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000E21 RID: 3617 RVA: 0x000410B8 File Offset: 0x0003F2B8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageShenQ1.damages[Math.Min(17, source.Level - 1)] + (DamageShenQ1.damagePercents[level] + 0.02 * (double)source.TotalMagicalDamage / 100.0) * (double)target.MaxHealth;
		}

		// Token: 0x040007BD RID: 1981
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

		// Token: 0x040007BE RID: 1982
		private static readonly double[] damagePercents = new double[]
		{
			0.05,
			0.055,
			0.06,
			0.065,
			0.07
		};
	}
}
