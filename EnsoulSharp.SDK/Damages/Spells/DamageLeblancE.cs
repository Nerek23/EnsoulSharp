using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001FD RID: 509
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Leblanc", SpellSlot.E, 0)]
	public class DamageLeblancE : DamageSpell
	{
		// Token: 0x06000C12 RID: 3090 RVA: 0x0003D83E File Offset: 0x0003BA3E
		public DamageLeblancE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x0003D854 File Offset: 0x0003BA54
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLeblancE.damages[level] + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000701 RID: 1793
		private static readonly double[] damages = new double[]
		{
			50.0,
			70.0,
			90.0,
			110.0,
			130.0
		};
	}
}
