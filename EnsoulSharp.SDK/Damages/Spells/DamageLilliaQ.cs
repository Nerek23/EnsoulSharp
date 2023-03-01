using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200020B RID: 523
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lillia", SpellSlot.Q, 0)]
	public class DamageLilliaQ : DamageSpell
	{
		// Token: 0x06000C3C RID: 3132 RVA: 0x0003DCED File Offset: 0x0003BEED
		public DamageLilliaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C3D RID: 3133 RVA: 0x0003DD03 File Offset: 0x0003BF03
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLilliaQ.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400070F RID: 1807
		private static readonly double[] damages = new double[]
		{
			40.0,
			50.0,
			60.0,
			70.0,
			80.0
		};
	}
}
