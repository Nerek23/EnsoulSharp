using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200028A RID: 650
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rengar", SpellSlot.W, 0)]
	public class DamageRengarW : DamageSpell
	{
		// Token: 0x06000DB7 RID: 3511 RVA: 0x000404CA File Offset: 0x0003E6CA
		public DamageRengarW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000DB8 RID: 3512 RVA: 0x000404E0 File Offset: 0x0003E6E0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRengarW.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000794 RID: 1940
		private static readonly double[] damages = new double[]
		{
			50.0,
			80.0,
			110.0,
			140.0,
			170.0
		};
	}
}
