using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200025D RID: 605
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ornn", SpellSlot.W, 0)]
	public class DamageOrnnW : DamageSpell
	{
		// Token: 0x06000D31 RID: 3377 RVA: 0x0003F679 File Offset: 0x0003D879
		public DamageOrnnW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x0003F68F File Offset: 0x0003D88F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageOrnnW.damages[level];
		}

		// Token: 0x04000764 RID: 1892
		private static readonly double[] damages = new double[]
		{
			80.0,
			130.0,
			180.0,
			230.0,
			280.0
		};
	}
}
