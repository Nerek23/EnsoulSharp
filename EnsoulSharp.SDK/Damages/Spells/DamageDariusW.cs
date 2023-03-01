using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000160 RID: 352
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Darius", SpellSlot.W, 0)]
	public class DamageDariusW : DamageSpell
	{
		// Token: 0x06000A38 RID: 2616 RVA: 0x0003A425 File Offset: 0x00038625
		public DamageDariusW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x0003A43B File Offset: 0x0003863B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageDariusW.damages[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000654 RID: 1620
		private static readonly double[] damages = new double[]
		{
			1.4,
			1.45,
			1.5,
			1.55,
			1.6
		};
	}
}
