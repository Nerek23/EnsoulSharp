using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000173 RID: 371
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Evelynn", SpellSlot.W, 0)]
	public class DamageEvelynnW : DamageSpell
	{
		// Token: 0x06000A70 RID: 2672 RVA: 0x0003AAD8 File Offset: 0x00038CD8
		public DamageEvelynnW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x0003AAEE File Offset: 0x00038CEE
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageEvelynnW.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400066A RID: 1642
		private static readonly double[] damages = new double[]
		{
			250.0,
			300.0,
			350.0,
			400.0,
			450.0
		};
	}
}
