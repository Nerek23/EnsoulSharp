using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001E2 RID: 482
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kled", SpellSlot.Q, 0)]
	public class DamageKledQ : DamageSpell
	{
		// Token: 0x06000BC2 RID: 3010 RVA: 0x0003CFA3 File Offset: 0x0003B1A3
		public DamageKledQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000BC3 RID: 3011 RVA: 0x0003CFB9 File Offset: 0x0003B1B9
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKledQ.damages[level] + 0.65 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040006E5 RID: 1765
		private static readonly double[] damages = new double[]
		{
			30.0,
			55.0,
			80.0,
			105.0,
			130.0
		};
	}
}
