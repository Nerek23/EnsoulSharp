using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000204 RID: 516
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("LeeSin", SpellSlot.Q, 0)]
	public class DamageLeeSinQ : DamageSpell
	{
		// Token: 0x06000C27 RID: 3111 RVA: 0x0003DA84 File Offset: 0x0003BC84
		public DamageLeeSinQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x0003DA9A File Offset: 0x0003BC9A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLeeSinQ.damages[level] + 1.1 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000708 RID: 1800
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
