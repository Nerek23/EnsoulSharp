using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200011D RID: 285
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Alistar", SpellSlot.Q, 0)]
	public class DamageAlistarQ : DamageSpell
	{
		// Token: 0x06000966 RID: 2406 RVA: 0x00038D72 File Offset: 0x00036F72
		public DamageAlistarQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x00038D88 File Offset: 0x00036F88
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAlistarQ.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000604 RID: 1540
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
