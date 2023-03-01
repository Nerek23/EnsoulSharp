using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000295 RID: 661
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Senna", SpellSlot.W, 0)]
	public class DamageSennaW : DamageSpell
	{
		// Token: 0x06000DD8 RID: 3544 RVA: 0x00040861 File Offset: 0x0003EA61
		public DamageSennaW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000DD9 RID: 3545 RVA: 0x00040877 File Offset: 0x0003EA77
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSennaW.damages[level] + 0.7 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040007A2 RID: 1954
		private static readonly double[] damages = new double[]
		{
			70.0,
			115.0,
			160.0,
			205.0,
			250.0
		};
	}
}
