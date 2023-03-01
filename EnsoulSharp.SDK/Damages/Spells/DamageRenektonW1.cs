using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000284 RID: 644
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Renekton", SpellSlot.W, 1)]
	public class DamageRenektonW1 : DamageSpell
	{
		// Token: 0x06000DA5 RID: 3493 RVA: 0x000402A9 File Offset: 0x0003E4A9
		public DamageRenektonW1()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x000402C6 File Offset: 0x0003E4C6
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRenektonW1.damages[level] + 0.75 * (double)source.TotalAttackDamage + (double)(3f * source.TotalAttackDamage);
		}

		// Token: 0x0400078D RID: 1933
		private static readonly double[] damages = new double[]
		{
			15.0,
			60.0,
			105.0,
			150.0,
			195.0
		};
	}
}
