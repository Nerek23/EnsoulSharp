using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001B0 RID: 432
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Irelia", SpellSlot.W, 0)]
	public class DamageIreliaW : DamageSpell
	{
		// Token: 0x06000B2E RID: 2862 RVA: 0x0003BE0B File Offset: 0x0003A00B
		public DamageIreliaW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x0003BE21 File Offset: 0x0003A021
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageIreliaW.damages[level] + 1.2 * (double)source.TotalAttackDamage + 1.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006AD RID: 1709
		private static readonly double[] damages = new double[]
		{
			30.0,
			75.0,
			120.0,
			165.0,
			210.0
		};
	}
}
