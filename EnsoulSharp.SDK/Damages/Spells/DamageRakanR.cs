using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000275 RID: 629
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rakan", SpellSlot.R, 0)]
	public class DamageRakanR : DamageSpell
	{
		// Token: 0x06000D78 RID: 3448 RVA: 0x0003FDF5 File Offset: 0x0003DFF5
		public DamageRakanR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x0003FE0B File Offset: 0x0003E00B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRakanR.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400077D RID: 1917
		private static readonly double[] damages = new double[]
		{
			100.0,
			200.0,
			300.0
		};
	}
}
