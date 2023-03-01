using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002C2 RID: 706
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Soraka", SpellSlot.Q, 0)]
	public class DamageSorakaQ : DamageSpell
	{
		// Token: 0x06000E5F RID: 3679 RVA: 0x00041858 File Offset: 0x0003FA58
		public DamageSorakaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E60 RID: 3680 RVA: 0x0004186E File Offset: 0x0003FA6E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSorakaQ.damages[level] + 0.35 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007D9 RID: 2009
		private static readonly double[] damages = new double[]
		{
			85.0,
			120.0,
			155.0,
			190.0,
			225.0
		};
	}
}
