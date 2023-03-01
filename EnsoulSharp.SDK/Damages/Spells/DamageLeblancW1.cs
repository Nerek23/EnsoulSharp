using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000200 RID: 512
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Leblanc", SpellSlot.W, 1)]
	public class DamageLeblancW1 : DamageSpell
	{
		// Token: 0x06000C1B RID: 3099 RVA: 0x0003D932 File Offset: 0x0003BB32
		public DamageLeblancW1()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x0003D94F File Offset: 0x0003BB4F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLeblancW1.damages[source.Spellbook.GetSpell(SpellSlot.R).Level - 1] + 0.75 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000704 RID: 1796
		private static readonly double[] damages = new double[]
		{
			150.0,
			300.0,
			450.0
		};
	}
}
