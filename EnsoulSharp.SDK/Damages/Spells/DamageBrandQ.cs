using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200013F RID: 319
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Brand", SpellSlot.Q, 0)]
	public class DamageBrandQ : DamageSpell
	{
		// Token: 0x060009CB RID: 2507 RVA: 0x00039901 File Offset: 0x00037B01
		public DamageBrandQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x00039917 File Offset: 0x00037B17
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageBrandQ.damages[level] + 0.55 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400062B RID: 1579
		private static readonly double[] damages = new double[]
		{
			80.0,
			110.0,
			140.0,
			170.0,
			200.0
		};
	}
}
