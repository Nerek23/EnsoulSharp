using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002B2 RID: 690
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Shyvana", SpellSlot.W, 0)]
	public class DamageShyvanaW : DamageSpell
	{
		// Token: 0x06000E2F RID: 3631 RVA: 0x000412EC File Offset: 0x0003F4EC
		public DamageShyvanaW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x00041302 File Offset: 0x0003F502
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageShyvanaW.damages[level] + 0.15 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040007C4 RID: 1988
		private static readonly double[] damages = new double[]
		{
			10.0,
			16.25,
			22.5,
			28.75,
			35.0
		};
	}
}
