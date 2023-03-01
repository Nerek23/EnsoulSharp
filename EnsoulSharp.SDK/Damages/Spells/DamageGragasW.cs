using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200019B RID: 411
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gragas", SpellSlot.W, 0)]
	public class DamageGragasW : DamageSpell
	{
		// Token: 0x06000AE9 RID: 2793 RVA: 0x0003B802 File Offset: 0x00039A02
		public DamageGragasW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x0003B818 File Offset: 0x00039A18
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGragasW.damages[level] + 0.7 * (double)source.TotalMagicalDamage + 0.07 * (double)target.MaxHealth;
		}

		// Token: 0x0400069A RID: 1690
		private static readonly double[] damages = new double[]
		{
			20.0,
			50.0,
			80.0,
			110.0,
			140.0
		};
	}
}
