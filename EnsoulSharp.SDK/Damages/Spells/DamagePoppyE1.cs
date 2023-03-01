using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000269 RID: 617
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Poppy", SpellSlot.E, 1)]
	public class DamagePoppyE1 : DamageSpell
	{
		// Token: 0x06000D55 RID: 3413 RVA: 0x0003FA20 File Offset: 0x0003DC20
		public DamagePoppyE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000D56 RID: 3414 RVA: 0x0003FA3D File Offset: 0x0003DC3D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamagePoppyE1.damages[level] + (double)(1f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x04000771 RID: 1905
		private static readonly double[] damages = new double[]
		{
			120.0,
			160.0,
			200.0,
			240.0,
			280.0
		};
	}
}
