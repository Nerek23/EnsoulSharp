using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000108 RID: 264
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rell", SpellSlot.R, 0)]
	public class DamageRellR : DamageSpell
	{
		// Token: 0x06000927 RID: 2343 RVA: 0x0003861F File Offset: 0x0003681F
		public DamageRellR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x00038635 File Offset: 0x00036835
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRellR.damages[level] + 1.1 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005EC RID: 1516
		private static readonly double[] damages = new double[]
		{
			120.0,
			200.0,
			280.0
		};
	}
}
