using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000246 RID: 582
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nautilus", SpellSlot.R, 0)]
	public class DamageNautilusR : DamageSpell
	{
		// Token: 0x06000CEC RID: 3308 RVA: 0x0003EEC9 File Offset: 0x0003D0C9
		public DamageNautilusR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x0003EEDF File Offset: 0x0003D0DF
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNautilusR.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400074B RID: 1867
		private static readonly double[] damages = new double[]
		{
			150.0,
			275.0,
			400.0
		};
	}
}
