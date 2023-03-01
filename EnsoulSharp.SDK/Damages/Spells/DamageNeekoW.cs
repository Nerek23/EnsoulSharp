using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000212 RID: 530
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Neeko", SpellSlot.W, 0)]
	public class DamageNeekoW : DamageSpell
	{
		// Token: 0x06000C51 RID: 3153 RVA: 0x0003DF18 File Offset: 0x0003C118
		public DamageNeekoW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x0003DF2E File Offset: 0x0003C12E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNeekoW.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000716 RID: 1814
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
