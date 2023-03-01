using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200011C RID: 284
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Alistar", SpellSlot.E, 1)]
	public class DamageAlistarE1 : DamageSpell
	{
		// Token: 0x06000963 RID: 2403 RVA: 0x00038D22 File Offset: 0x00036F22
		public DamageAlistarE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x00038D3F File Offset: 0x00036F3F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAlistarE1.damages[level] + 0.04 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000603 RID: 1539
		private static readonly double[] damages = new double[]
		{
			8.0,
			11.0,
			14.0,
			17.0,
			20.0
		};
	}
}
