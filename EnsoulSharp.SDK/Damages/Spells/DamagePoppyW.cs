using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200026C RID: 620
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Poppy", SpellSlot.W, 0)]
	public class DamagePoppyW : DamageSpell
	{
		// Token: 0x06000D5E RID: 3422 RVA: 0x0003FB10 File Offset: 0x0003DD10
		public DamagePoppyW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x0003FB26 File Offset: 0x0003DD26
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamagePoppyW.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000774 RID: 1908
		private static readonly double[] damages = new double[]
		{
			70.0,
			110.0,
			150.0,
			190.0,
			230.0
		};
	}
}
