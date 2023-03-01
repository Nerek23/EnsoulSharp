using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000329 RID: 809
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Yuumi", SpellSlot.Q, 0)]
	public class DamageYuumiQ : DamageSpell
	{
		// Token: 0x06000F94 RID: 3988 RVA: 0x00043ACB File Offset: 0x00041CCB
		public DamageYuumiQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F95 RID: 3989 RVA: 0x00043AE1 File Offset: 0x00041CE1
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageYuumiQ.damages[level] + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400084B RID: 2123
		private static readonly double[] damages = new double[]
		{
			50.0,
			80.0,
			110.0,
			140.0,
			170.0,
			200.0
		};
	}
}
