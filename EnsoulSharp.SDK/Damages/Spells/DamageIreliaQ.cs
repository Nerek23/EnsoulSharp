using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001AE RID: 430
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Irelia", SpellSlot.Q, 0)]
	public class DamageIreliaQ : DamageSpell
	{
		// Token: 0x06000B28 RID: 2856 RVA: 0x0003BD52 File Offset: 0x00039F52
		public DamageIreliaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0003BD68 File Offset: 0x00039F68
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageIreliaQ.damages[level] + 0.6 * (double)source.TotalAttackDamage;
			int num2 = 43 + 12 * source.Level;
			if (!target.IsMinion())
			{
				return num;
			}
			return num + (double)num2;
		}

		// Token: 0x040006AB RID: 1707
		private static readonly double[] damages = new double[]
		{
			5.0,
			25.0,
			45.0,
			65.0,
			85.0
		};
	}
}
