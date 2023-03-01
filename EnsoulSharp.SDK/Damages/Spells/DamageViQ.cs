using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000318 RID: 792
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vi", SpellSlot.Q, 0)]
	public class DamageViQ : DamageSpell
	{
		// Token: 0x06000F61 RID: 3937 RVA: 0x00043555 File Offset: 0x00041755
		public DamageViQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F62 RID: 3938 RVA: 0x0004356B File Offset: 0x0004176B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageViQ.damages[level] + 0.7 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000838 RID: 2104
		private static readonly double[] damages = new double[]
		{
			55.0,
			80.0,
			105.0,
			130.0,
			155.0
		};
	}
}
