using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000332 RID: 818
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("XinZhao", SpellSlot.Q, 0)]
	public class DamageXinZhaoQ : DamageSpell
	{
		// Token: 0x06000FAF RID: 4015 RVA: 0x00043D97 File Offset: 0x00041F97
		public DamageXinZhaoQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000FB0 RID: 4016 RVA: 0x00043DAD File Offset: 0x00041FAD
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageXinZhaoQ.damages[level] + 0.4 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000854 RID: 2132
		private static readonly double[] damages = new double[]
		{
			16.0,
			25.0,
			34.0,
			43.0,
			52.0
		};
	}
}
