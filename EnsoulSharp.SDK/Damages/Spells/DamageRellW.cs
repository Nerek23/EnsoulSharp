using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200010D RID: 269
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rell", SpellSlot.W, 0)]
	public class DamageRellW : DamageSpell
	{
		// Token: 0x06000936 RID: 2358 RVA: 0x0003879A File Offset: 0x0003699A
		public DamageRellW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x000387B0 File Offset: 0x000369B0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRellW.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005F1 RID: 1521
		private static readonly double[] damages = new double[]
		{
			70.0,
			105.0,
			140.0,
			175.0,
			210.0
		};
	}
}
