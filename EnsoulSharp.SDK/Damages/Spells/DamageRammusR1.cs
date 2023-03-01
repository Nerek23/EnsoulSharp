using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000104 RID: 260
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rammus", SpellSlot.R, 1)]
	public class DamageRammusR1 : DamageSpell
	{
		// Token: 0x0600091B RID: 2331 RVA: 0x000384BD File Offset: 0x000366BD
		public DamageRammusR1()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x000384DA File Offset: 0x000366DA
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRammusR1.damages[level] + 0.6 * (double)source.TotalMagicalDamage + DamageRammusR1.qdamages[source.Spellbook.GetSpell(SpellSlot.Q).Level - 1];
		}

		// Token: 0x040005E7 RID: 1511
		private static readonly double[] damages = new double[]
		{
			100.0,
			175.0,
			250.0
		};

		// Token: 0x040005E8 RID: 1512
		private static readonly double[] qdamages = new double[]
		{
			100.0,
			130.0,
			160.0,
			190.0,
			220.0
		};
	}
}
