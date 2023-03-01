using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200026D RID: 621
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Pyke", SpellSlot.E, 0)]
	public class DamagePykeE : DamageSpell
	{
		// Token: 0x06000D61 RID: 3425 RVA: 0x0003FB59 File Offset: 0x0003DD59
		public DamagePykeE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D62 RID: 3426 RVA: 0x0003FB6F File Offset: 0x0003DD6F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamagePykeE.damages[level] + (double)(1f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x04000775 RID: 1909
		private static readonly double[] damages = new double[]
		{
			105.0,
			135.0,
			165.0,
			195.0,
			225.0
		};
	}
}
