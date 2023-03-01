using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000293 RID: 659
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Senna", SpellSlot.Q, 0)]
	public class DamageSennaQ : DamageSpell
	{
		// Token: 0x06000DD2 RID: 3538 RVA: 0x000407BD File Offset: 0x0003E9BD
		public DamageSennaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000DD3 RID: 3539 RVA: 0x000407D3 File Offset: 0x0003E9D3
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSennaQ.damages[level] + 0.5 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040007A0 RID: 1952
		private static readonly double[] damages = new double[]
		{
			30.0,
			65.0,
			100.0,
			135.0,
			170.0
		};
	}
}
