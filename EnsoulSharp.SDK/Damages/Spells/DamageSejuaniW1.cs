using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002A6 RID: 678
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sejuani", SpellSlot.W, 1)]
	public class DamageSejuaniW1 : DamageSpell
	{
		// Token: 0x06000E0B RID: 3595 RVA: 0x00040E11 File Offset: 0x0003F011
		public DamageSejuaniW1()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000E0C RID: 3596 RVA: 0x00040E2E File Offset: 0x0003F02E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSejuaniW1.damages[level] + 0.6 * (double)source.TotalMagicalDamage + 0.0525 * (double)source.MaxHealth;
		}

		// Token: 0x040007B5 RID: 1973
		private static readonly double[] damages = new double[]
		{
			30.0,
			70.0,
			110.0,
			150.0,
			190.0
		};
	}
}
