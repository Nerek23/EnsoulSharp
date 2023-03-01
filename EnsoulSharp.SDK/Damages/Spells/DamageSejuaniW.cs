using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002A5 RID: 677
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sejuani", SpellSlot.W, 0)]
	public class DamageSejuaniW : DamageSpell
	{
		// Token: 0x06000E08 RID: 3592 RVA: 0x00040DB6 File Offset: 0x0003EFB6
		public DamageSejuaniW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x00040DCC File Offset: 0x0003EFCC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSejuaniW.damages[level] + 0.2 * (double)source.TotalMagicalDamage + 0.02 * (double)source.MaxHealth;
		}

		// Token: 0x040007B4 RID: 1972
		private static readonly double[] damages = new double[]
		{
			20.0,
			25.0,
			30.0,
			35.0,
			40.0
		};
	}
}
