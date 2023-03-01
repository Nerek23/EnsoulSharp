using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000129 RID: 297
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Annie", SpellSlot.Q, 0)]
	public class DamageAnnieQ : DamageSpell
	{
		// Token: 0x0600098A RID: 2442 RVA: 0x00039124 File Offset: 0x00037324
		public DamageAnnieQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x0003913A File Offset: 0x0003733A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAnnieQ.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000611 RID: 1553
		private static readonly double[] damages = new double[]
		{
			80.0,
			115.0,
			150.0,
			185.0,
			220.0
		};
	}
}
