using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001E1 RID: 481
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kled", SpellSlot.E, 0)]
	public class DamageKledE : DamageSpell
	{
		// Token: 0x06000BBF RID: 3007 RVA: 0x0003CF5A File Offset: 0x0003B15A
		public DamageKledE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000BC0 RID: 3008 RVA: 0x0003CF70 File Offset: 0x0003B170
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKledE.damages[level] + 0.65 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040006E4 RID: 1764
		private static readonly double[] damages = new double[]
		{
			35.0,
			60.0,
			85.0,
			110.0,
			135.0
		};
	}
}
