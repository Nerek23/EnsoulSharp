using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000153 RID: 339
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Chogath", SpellSlot.Q, 0)]
	public class DamageChogathQ : DamageSpell
	{
		// Token: 0x06000A07 RID: 2567 RVA: 0x00039F4F File Offset: 0x0003814F
		public DamageChogathQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00039F65 File Offset: 0x00038165
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageChogathQ.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x04000641 RID: 1601
		private static readonly double[] damages = new double[]
		{
			80.0,
			140.0,
			200.0,
			260.0,
			320.0
		};
	}
}
