using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000171 RID: 369
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Evelynn", SpellSlot.E, 1)]
	public class DamageEvelynnE1 : DamageSpell
	{
		// Token: 0x06000A6A RID: 2666 RVA: 0x0003AA07 File Offset: 0x00038C07
		public DamageEvelynnE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x0003AA24 File Offset: 0x00038C24
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageEvelynnE1.damages[level] + (0.04 + 0.025 * (double)source.TotalMagicalDamage / 100.0) * (double)target.MaxHealth;
		}

		// Token: 0x04000668 RID: 1640
		private static readonly double[] damages = new double[]
		{
			75.0,
			100.0,
			125.0,
			150.0,
			175.0
		};
	}
}
