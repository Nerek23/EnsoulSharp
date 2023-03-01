using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002D5 RID: 725
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("TahmKench", SpellSlot.Q, 0)]
	public class DamageTahmKenchQ : DamageSpell
	{
		// Token: 0x06000E98 RID: 3736 RVA: 0x00041E2F File Offset: 0x0004002F
		public DamageTahmKenchQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E99 RID: 3737 RVA: 0x00041E45 File Offset: 0x00040045
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTahmKenchQ.damages[level] + (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007EC RID: 2028
		private static readonly double[] damages = new double[]
		{
			80.0,
			130.0,
			180.0,
			230.0,
			280.0
		};
	}
}
