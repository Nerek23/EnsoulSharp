using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200013C RID: 316
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Blitzcrank", SpellSlot.Q, 0)]
	public class DamageBlitzcrankQ : DamageSpell
	{
		// Token: 0x060009C2 RID: 2498 RVA: 0x00039826 File Offset: 0x00037A26
		public DamageBlitzcrankQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x0003983C File Offset: 0x00037A3C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageBlitzcrankQ.damages[level] + 1.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000628 RID: 1576
		private static readonly double[] damages = new double[]
		{
			105.0,
			155.0,
			205.0,
			255.0,
			305.0
		};
	}
}
