using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000107 RID: 263
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rell", SpellSlot.R, 1)]
	public class DamageRellR1 : DamageSpell
	{
		// Token: 0x06000924 RID: 2340 RVA: 0x000385CF File Offset: 0x000367CF
		public DamageRellR1()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x000385EC File Offset: 0x000367EC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRellR1.damages[level] + 0.0875 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005EB RID: 1515
		private static readonly double[] damages = new double[]
		{
			15.0,
			25.0,
			35.0
		};
	}
}
