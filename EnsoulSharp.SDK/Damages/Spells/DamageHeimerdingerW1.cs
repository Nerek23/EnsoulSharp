using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001A7 RID: 423
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Heimerdinger", SpellSlot.W, 1)]
	public class DamageHeimerdingerW1 : DamageSpell
	{
		// Token: 0x06000B0D RID: 2829 RVA: 0x0003BBCF File Offset: 0x00039DCF
		public DamageHeimerdingerW1()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x0003BBEC File Offset: 0x00039DEC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageHeimerdingerW1.damages[source.Spellbook.GetSpell(SpellSlot.R).Level - 1] + 1.83 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006A7 RID: 1703
		private static readonly double[] damages = new double[]
		{
			503.0,
			697.5,
			892.0
		};
	}
}
