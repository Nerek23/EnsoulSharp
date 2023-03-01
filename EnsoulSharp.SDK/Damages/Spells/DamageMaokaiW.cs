using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200022D RID: 557
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Maokai", SpellSlot.W, 0)]
	public class DamageMaokaiW : DamageSpell
	{
		// Token: 0x06000CA2 RID: 3234 RVA: 0x0003E77D File Offset: 0x0003C97D
		public DamageMaokaiW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CA3 RID: 3235 RVA: 0x0003E793 File Offset: 0x0003C993
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMaokaiW.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000733 RID: 1843
		private static readonly double[] damages = new double[]
		{
			60.0,
			85.0,
			110.0,
			135.0,
			160.0
		};
	}
}
