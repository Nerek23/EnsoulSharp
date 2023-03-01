using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000331 RID: 817
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("XinZhao", SpellSlot.W, 0)]
	public class DamageXinZhaoW : DamageSpell
	{
		// Token: 0x06000FAC RID: 4012 RVA: 0x00043D1A File Offset: 0x00041F1A
		public DamageXinZhaoW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000FAD RID: 4013 RVA: 0x00043D30 File Offset: 0x00041F30
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageXinZhaoW.damages[level] + 0.9 * (double)source.TotalAttackDamage + 0.65 * (double)source.TotalMagicalDamage;
			if (target.Type != GameObjectType.AIMinionClient)
			{
				return num;
			}
			return 0.5 * num;
		}

		// Token: 0x04000853 RID: 2131
		private static readonly double[] damages = new double[]
		{
			50.0,
			85.0,
			120.0,
			155.0,
			190.0
		};
	}
}
