using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200027E RID: 638
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Renekton", SpellSlot.E, 1)]
	public class DamageRenektonE1 : DamageSpell
	{
		// Token: 0x06000D93 RID: 3475 RVA: 0x000400CF File Offset: 0x0003E2CF
		public DamageRenektonE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x000400EC File Offset: 0x0003E2EC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRenektonE1.damages[level] + 1.35 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000787 RID: 1927
		private static readonly double[] damages = new double[]
		{
			70.0,
			115.0,
			160.0,
			205.0,
			250.0
		};
	}
}
