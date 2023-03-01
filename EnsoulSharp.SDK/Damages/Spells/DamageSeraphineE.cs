using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002DE RID: 734
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Seraphine", SpellSlot.E, 0)]
	public class DamageSeraphineE : DamageSpell
	{
		// Token: 0x06000EB3 RID: 3763 RVA: 0x000420D9 File Offset: 0x000402D9
		public DamageSeraphineE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x000420EF File Offset: 0x000402EF
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSeraphineE.damages[level] + 0.35 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007F5 RID: 2037
		private static readonly double[] damages = new double[]
		{
			60.0,
			80.0,
			100.0,
			120.0,
			140.0
		};
	}
}
