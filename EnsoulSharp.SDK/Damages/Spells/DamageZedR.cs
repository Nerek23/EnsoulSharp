using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000345 RID: 837
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zed", SpellSlot.R, 0)]
	public class DamageZedR : DamageSpell
	{
		// Token: 0x06000FE8 RID: 4072 RVA: 0x000443E1 File Offset: 0x000425E1
		public DamageZedR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000FE9 RID: 4073 RVA: 0x000443F7 File Offset: 0x000425F7
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (double)(0.65f * source.GetTotalAaDamage());
		}
	}
}
