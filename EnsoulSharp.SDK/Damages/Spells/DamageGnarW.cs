using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000196 RID: 406
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gnar", SpellSlot.W, 0)]
	public class DamageGnarW : DamageSpell
	{
		// Token: 0x06000ADA RID: 2778 RVA: 0x0003B626 File Offset: 0x00039826
		public DamageGnarW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x0003B63C File Offset: 0x0003983C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageGnarW.damages[level] + DamageGnarW.damagePercents[level] * (double)target.MaxHealth + (double)source.TotalAttackDamage;
			if (!target.IsJungle())
			{
				return num;
			}
			return Math.Min((double)(300f + source.TotalAttackDamage), num);
		}

		// Token: 0x04000694 RID: 1684
		private static readonly double[] damages = new double[]
		{
			0.0,
			10.0,
			20.0,
			30.0,
			40.0
		};

		// Token: 0x04000695 RID: 1685
		private static readonly double[] damagePercents = new double[]
		{
			0.06,
			0.08,
			0.1,
			0.12,
			0.14
		};
	}
}
