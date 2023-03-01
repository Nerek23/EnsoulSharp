using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001D0 RID: 464
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Karma", SpellSlot.Q, 1)]
	public class DamageKarmaQ1 : DamageSpell
	{
		// Token: 0x06000B8D RID: 2957 RVA: 0x0003C900 File Offset: 0x0003AB00
		public DamageKarmaQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x0003C91D File Offset: 0x0003AB1D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKarmaQ1.baiscdamages[level] + DamageKarmaQ1.rdamages[source.Spellbook.GetSpell(SpellSlot.R).Level - 1] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006D2 RID: 1746
		private static readonly double[] baiscdamages = new double[]
		{
			70.0,
			120.0,
			170.0,
			220.0,
			270.0
		};

		// Token: 0x040006D3 RID: 1747
		private static readonly double[] rdamages = new double[]
		{
			40.0,
			100.0,
			160.0,
			220.0
		};
	}
}
