using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000321 RID: 801
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Volibear", SpellSlot.Q, 0)]
	public class DamageVolibearQ : DamageSpell
	{
		// Token: 0x06000F7C RID: 3964 RVA: 0x00043845 File Offset: 0x00041A45
		public DamageVolibearQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F7D RID: 3965 RVA: 0x0004385B File Offset: 0x00041A5B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVolibearQ.damages[level] + (double)(1.2f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x04000842 RID: 2114
		private static readonly double[] damages = new double[]
		{
			10.0,
			30.0,
			50.0,
			70.0,
			90.0
		};
	}
}
