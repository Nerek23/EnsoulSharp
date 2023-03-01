using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200033F RID: 831
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zac", SpellSlot.E, 0)]
	public class DamageZacE : DamageSpell
	{
		// Token: 0x06000FD6 RID: 4054 RVA: 0x000441EB File Offset: 0x000423EB
		public DamageZacE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FD7 RID: 4055 RVA: 0x00044201 File Offset: 0x00042401
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZacE.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000863 RID: 2147
		private static readonly double[] damages = new double[]
		{
			60.0,
			105.0,
			150.0,
			195.0,
			240.0
		};
	}
}
