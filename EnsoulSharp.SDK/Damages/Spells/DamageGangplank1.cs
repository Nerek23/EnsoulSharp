using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000F7 RID: 247
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gangplank", SpellSlot.R, 1)]
	public class DamageGangplank1 : DamageSpell
	{
		// Token: 0x060008F4 RID: 2292 RVA: 0x00037FB9 File Offset: 0x000361B9
		public DamageGangplank1()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x00037FD6 File Offset: 0x000361D6
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGangplank1.damages[level] + 1.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005D8 RID: 1496
		private static readonly double[] damages = new double[]
		{
			480.0,
			840.0,
			1200.0
		};
	}
}
