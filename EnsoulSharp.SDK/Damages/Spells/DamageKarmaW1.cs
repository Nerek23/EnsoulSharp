using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001D2 RID: 466
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Karma", SpellSlot.W, 1)]
	public class DamageKarmaW1 : DamageSpell
	{
		// Token: 0x06000B93 RID: 2963 RVA: 0x0003C9C9 File Offset: 0x0003ABC9
		public DamageKarmaW1()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x0003C9E6 File Offset: 0x0003ABE6
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKarmaW1.damages[level] + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006D5 RID: 1749
		private static readonly double[] damages = new double[]
		{
			80.0,
			130.0,
			180.0,
			230.0,
			280.0
		};
	}
}
