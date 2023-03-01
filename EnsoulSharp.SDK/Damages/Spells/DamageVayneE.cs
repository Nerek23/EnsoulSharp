using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000308 RID: 776
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vayne", SpellSlot.E, 0)]
	public class DamageVayneE : DamageSpell
	{
		// Token: 0x06000F31 RID: 3889 RVA: 0x00042FF2 File Offset: 0x000411F2
		public DamageVayneE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F32 RID: 3890 RVA: 0x00043008 File Offset: 0x00041208
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVayneE.damages[level] + 0.5 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000826 RID: 2086
		private static readonly double[] damages = new double[]
		{
			50.0,
			85.0,
			120.0,
			155.0,
			190.0
		};
	}
}
