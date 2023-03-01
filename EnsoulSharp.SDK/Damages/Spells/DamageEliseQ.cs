using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200016E RID: 366
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Elise", SpellSlot.Q, 0)]
	public class DamageEliseQ : DamageSpell
	{
		// Token: 0x06000A61 RID: 2657 RVA: 0x0003A8FA File Offset: 0x00038AFA
		public DamageEliseQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x0003A910 File Offset: 0x00038B10
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageEliseQ.damages[level] + (0.04 + 0.0003 * (double)source.TotalMagicalDamage) * (double)target.Health;
		}

		// Token: 0x04000665 RID: 1637
		private static readonly double[] damages = new double[]
		{
			40.0,
			75.0,
			110.0,
			145.0,
			180.0
		};
	}
}
