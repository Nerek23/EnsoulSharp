using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000174 RID: 372
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Evelynn", SpellSlot.Q, 0)]
	public class DamageEvelynnQ : DamageSpell
	{
		// Token: 0x06000A73 RID: 2675 RVA: 0x0003AB21 File Offset: 0x00038D21
		public DamageEvelynnQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x0003AB37 File Offset: 0x00038D37
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageEvelynnQ.damages[level] + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400066B RID: 1643
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
