using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000191 RID: 401
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gnar", SpellSlot.E, 0)]
	public class DamageGnarE : DamageSpell
	{
		// Token: 0x06000ACB RID: 2763 RVA: 0x0003B49D File Offset: 0x0003969D
		public DamageGnarE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x0003B4B3 File Offset: 0x000396B3
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGnarE.damages[level] + (double)source.MaxHealth * 0.06;
		}

		// Token: 0x0400068F RID: 1679
		private static readonly double[] damages = new double[]
		{
			50.0,
			85.0,
			120.0,
			155.0,
			190.0
		};
	}
}
