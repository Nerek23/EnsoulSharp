using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000241 RID: 577
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nasus", SpellSlot.E, 1)]
	public class DamageNasusE1 : DamageSpell
	{
		// Token: 0x06000CDD RID: 3293 RVA: 0x0003ED44 File Offset: 0x0003CF44
		public DamageNasusE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x0003ED61 File Offset: 0x0003CF61
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNasusE1.damages[level] + 0.12 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000746 RID: 1862
		private static readonly double[] damages = new double[]
		{
			11.0,
			19.0,
			27.0,
			35.0,
			43.0
		};
	}
}
