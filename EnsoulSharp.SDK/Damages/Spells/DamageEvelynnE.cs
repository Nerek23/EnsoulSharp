using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000172 RID: 370
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Evelynn", SpellSlot.E, 0)]
	public class DamageEvelynnE : DamageSpell
	{
		// Token: 0x06000A6D RID: 2669 RVA: 0x0003AA73 File Offset: 0x00038C73
		public DamageEvelynnE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x0003AA89 File Offset: 0x00038C89
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageEvelynnE.damages[level] + (0.03 + 0.015 * (double)source.TotalMagicalDamage / 100.0) * (double)target.MaxHealth;
		}

		// Token: 0x04000669 RID: 1641
		private static readonly double[] damages = new double[]
		{
			55.0,
			70.0,
			85.0,
			100.0,
			115.0
		};
	}
}
