using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002F9 RID: 761
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Varus", SpellSlot.E, 0)]
	public class DamageVarusE : DamageSpell
	{
		// Token: 0x06000F04 RID: 3844 RVA: 0x00042AEF File Offset: 0x00040CEF
		public DamageVarusE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F05 RID: 3845 RVA: 0x00042B05 File Offset: 0x00040D05
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVarusE.damages[level] + (double)(0.9f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x04000815 RID: 2069
		private static readonly double[] damages = new double[]
		{
			60.0,
			100.0,
			140.0,
			180.0,
			220.0
		};
	}
}
