using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002E5 RID: 741
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Thresh", SpellSlot.Q, 0)]
	public class DamageThreshQ : DamageSpell
	{
		// Token: 0x06000EC8 RID: 3784 RVA: 0x0004241E File Offset: 0x0004061E
		public DamageThreshQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000EC9 RID: 3785 RVA: 0x00042434 File Offset: 0x00040634
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageThreshQ.damages[level] + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007FD RID: 2045
		private static readonly double[] damages = new double[]
		{
			100.0,
			150.0,
			200.0,
			250.0,
			300.0
		};
	}
}
